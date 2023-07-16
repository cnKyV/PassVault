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
    public partial class frmNew : Form
    {
        public frmNew()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text is null || txtPassword.Text is null)
            {
                MessageBox.Show("Username or Password is null");
                return;
            }

            FileService.UpsertFile(txtUsername.Text, txtPassword.Text);
            this.OpenNewForm(Enums.FormType.LoginForm);
        }
    }
}
