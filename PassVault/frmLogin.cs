using PassVault.Services;

namespace PassVault
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnNewMaster_Click(object sender, EventArgs e)
        {
            this.OpenNewForm(Enums.FormType.CreateForm);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUser.Text is null || txtMaster.Text is null)
            {
                MessageBox.Show("Username or Password is empty");
                return;
            }

            var isLoginSuccesful = CredentialService.Login(txtUser.Text, txtMaster.Text);
           
            if (!isLoginSuccesful)
            {
                MessageBox.Show("Incorrect Credentials");
                CredentialService.Logoff();
                return;
            }

            this.OpenNewForm(Enums.FormType.MainForm);
        }
    }
}
