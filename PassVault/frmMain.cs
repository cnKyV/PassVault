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
            if (!validateInput())
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

            var row = new[] { txtAlias.Text, txtUname.Text, txtPassword.Text, txtLink.Text };
            var lwItem = new ListViewItem(row);

            lwMain.Items.Add(lwItem);

        }

        private bool validateInput()
        {
            if (string.IsNullOrEmpty(txtLink.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtUname.Text))
                return false;

            return true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtUname;

            lwMain.Columns.Add("Alias", lwMain.Width / 4);
            lwMain.Columns.Add("Username", lwMain.Width / 4);
            lwMain.Columns.Add("Password", lwMain.Width / 4);
            lwMain.Columns.Add("Website", lwMain.Width / 4);

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
                txtLink.Text = lwMain.SelectedItems[0].SubItems[3].Text;
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
            lwMain.SelectedItems[0].SubItems[3].Text = txtLink.Text;

        }

        private void SaveChanges()
        {

        }
    }
}
