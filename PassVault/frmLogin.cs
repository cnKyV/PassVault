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
            var frm = new frmNew();
            this.Visible = false;
            frm.ShowDialog(this);
            this.Visible = true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}