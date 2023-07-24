using PassVault.Models;
using PassVault.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassVault
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Empty field!");
                return;
            }

            if (string.IsNullOrEmpty(txtAlias.Text))
            {

                var txtLinkAsList = txtLink.Text.Split('.');
                Array.Resize(ref txtLinkAsList, 3);

                txtAlias.Text = txtLinkAsList.FirstOrDefault(x => x.Length > 3);
            }

            var row = new[] { txtAlias.Text, txtUname.Text, txtPassword.Text, txtEmail.Text, txtLink.Text };
            var lwItem = new ListViewItem(row);

            lwMain.Items.Add(lwItem);

        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtLink.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtUname.Text))
                return false;

            return true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtUname;

            lwMain.Columns.Add("Alias", lwMain.Width / 5);
            lwMain.Columns.Add("Username", lwMain.Width / 5);
            lwMain.Columns.Add("Password", lwMain.Width / 5);
            lwMain.Columns.Add("Email", lwMain.Width / 5);
            lwMain.Columns.Add("Website", lwMain.Width / 5);

            lwMain.View = View.Details;
            lwMain.FullRowSelect = true;
            lwMain.GridLines = true;
        }

        private void txtUname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                this.ActiveControl = txtPassword;

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                this.ActiveControl = txtLink;
        }

        private void txtLink_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                this.ActiveControl = txtAlias;

            if (e.KeyCode == Keys.Enter)
                btnAdd_Click(sender, e);
        }

        private void txtAlias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                this.ActiveControl = txtUname;

            if (e.KeyCode == Keys.Enter)
                btnAdd_Click(sender, e);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var isAnItemSelected = lwMain.SelectedItems.Count > 0 && lwMain.SelectedItems.Count < 2;

            if (!isAnItemSelected)
            {
                MessageBox.Show("Please select one record to update");
                return;
            }

            lwMain.Items.RemoveAt(lwMain.SelectedIndices[0]);


        }

        private void lwMain_ItemActivate(object sender, EventArgs e)
        {
            var isAnItemSelected = lwMain.SelectedItems.Count > 0 && lwMain.SelectedItems.Count < 2;

            if (isAnItemSelected)
            {
                txtAlias.Text = lwMain.SelectedItems[0].SubItems[0].Text;
                txtUname.Text = lwMain.SelectedItems[0].SubItems[1].Text;
                txtPassword.Text = lwMain.SelectedItems[0].SubItems[2].Text;
                txtEmail.Text = lwMain.SelectedItems[0].SubItems[3].Text;
                txtLink.Text = lwMain.SelectedItems[0].SubItems[4].Text;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var isAnItemSelected = lwMain.SelectedItems.Count > 0 && lwMain.SelectedItems.Count < 2;

            if (!isAnItemSelected)
            {
                MessageBox.Show("Please select one record to update");
                return;
            }

            lwMain.SelectedItems[0].SubItems[0].Text = txtAlias.Text;
            lwMain.SelectedItems[0].SubItems[1].Text = txtUname.Text;
            lwMain.SelectedItems[0].SubItems[2].Text = txtPassword.Text;
            lwMain.SelectedItems[0].SubItems[3].Text = txtEmail.Text;
            lwMain.SelectedItems[0].SubItems[4].Text = txtLink.Text;

        }

        private async Task SaveChanges()
        {
            if (string.IsNullOrEmpty(CredentialService.Username) || string.IsNullOrEmpty(CredentialService.Password) || !CredentialService.HasLoggedIn)
            {
                MessageBox.Show("User not found!");
                return;
            }

            var accounts = new List<Account>();

            foreach (ListViewItem lwAccount in lwMain.Items)
            {
                //var account = new Account(lwAccount.SubItems[1].Text, lwAccount.SubItems[2].Text, lwAccount.SubItems[3].Text, lwAccount.SubItems[4].Text, lwAccount.SubItems[0].Text);
                var account = new Account();

                account.Username = lwAccount.SubItems[1].Text;
                account.Password = lwAccount.SubItems[2].Text;
                account.Email = lwAccount.SubItems[3].Text;
                account.Link = lwAccount.SubItems[4].Text;
                account.Alias = lwAccount.SubItems[0].Text;

                accounts.Add(account);
            }

            if (CredentialService.UsernameHashed is not null && CredentialService.PasswordHashed is not null)
            {
                var credentials = new Credentials(CredentialService.UsernameHashed, CredentialService.PasswordHashed, accounts);

                await FileService.UpsertFile(CredentialService.Username, CredentialService.Password, credentials);
            }
            else
                MessageBox.Show("You are not logged-in or corrupt JSON file!");

        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            await SaveChanges();
        }
    }
}
