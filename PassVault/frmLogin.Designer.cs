namespace PassVault
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMaster = new Label();
            txtMaster = new TextBox();
            btnLogin = new Button();
            btnNewMaster = new Button();
            label1 = new Label();
            txtUser = new TextBox();
            SuspendLayout();
            // 
            // lblMaster
            // 
            lblMaster.AutoSize = true;
            lblMaster.Location = new Point(12, 45);
            lblMaster.Name = "lblMaster";
            lblMaster.Size = new Size(85, 20);
            lblMaster.TabIndex = 0;
            lblMaster.Text = "Master Pass";
            // 
            // txtMaster
            // 
            txtMaster.Location = new Point(103, 45);
            txtMaster.Name = "txtMaster";
            txtMaster.Size = new Size(197, 27);
            txtMaster.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(103, 78);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(197, 29);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnNewMaster
            // 
            btnNewMaster.Location = new Point(3, 78);
            btnNewMaster.Name = "btnNewMaster";
            btnNewMaster.Size = new Size(94, 29);
            btnNewMaster.TabIndex = 3;
            btnNewMaster.Text = "Create New";
            btnNewMaster.UseVisualStyleBackColor = true;
            btnNewMaster.Click += btnNewMaster_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 4;
            label1.Text = "Username";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(103, 12);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(197, 27);
            txtUser.TabIndex = 5;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 119);
            Controls.Add(txtUser);
            Controls.Add(label1);
            Controls.Add(btnNewMaster);
            Controls.Add(btnLogin);
            Controls.Add(txtMaster);
            Controls.Add(lblMaster);
            Name = "frmLogin";
            Text = "Login";
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaster;
        private TextBox txtMaster;
        private Button btnLogin;
        private Button btnNewMaster;
        private Label label1;
        private TextBox txtUser;
    }
}