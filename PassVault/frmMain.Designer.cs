namespace PassVault
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lwMain = new ListView();
            btnAdd = new Button();
            btnRemove = new Button();
            btnEdit = new Button();
            txtLink = new TextBox();
            lblLink = new Label();
            txtPassword = new TextBox();
            lblPass = new Label();
            txtUname = new TextBox();
            lblUname = new Label();
            btnExit = new Button();
            btnLogout = new Button();
            label1 = new Label();
            txtAlias = new TextBox();
            btnSaveChanges = new Button();
            label2 = new Label();
            txtEmail = new TextBox();
            SuspendLayout();
            // 
            // lwMain
            // 
            lwMain.Location = new Point(12, 12);
            lwMain.Name = "lwMain";
            lwMain.Size = new Size(640, 426);
            lwMain.TabIndex = 10;
            lwMain.UseCompatibleStateImageBehavior = false;
            lwMain.View = View.List;
            lwMain.ItemActivate += lwMain_ItemActivate;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(658, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 177);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(658, 261);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(94, 171);
            btnRemove.TabIndex = 7;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(658, 189);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 66);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Update";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // txtLink
            // 
            txtLink.Location = new Point(758, 194);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(256, 27);
            txtLink.TabIndex = 3;
            txtLink.KeyDown += txtLink_KeyDown;
            // 
            // lblLink
            // 
            lblLink.AutoSize = true;
            lblLink.Location = new Point(758, 171);
            lblLink.Name = "lblLink";
            lblLink.Size = new Size(35, 20);
            lblLink.TabIndex = 5;
            lblLink.Text = "Link";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(758, 88);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(256, 27);
            txtPassword.TabIndex = 2;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Location = new Point(758, 65);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(70, 20);
            lblPass.TabIndex = 7;
            lblPass.Text = "Password";
            // 
            // txtUname
            // 
            txtUname.Location = new Point(758, 35);
            txtUname.Name = "txtUname";
            txtUname.Size = new Size(256, 27);
            txtUname.TabIndex = 1;
            txtUname.KeyDown += txtUname_KeyDown;
            // 
            // lblUname
            // 
            lblUname.AutoSize = true;
            lblUname.Location = new Point(758, 12);
            lblUname.Name = "lblUname";
            lblUname.Size = new Size(75, 20);
            lblUname.TabIndex = 9;
            lblUname.Text = "Username";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(758, 409);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(256, 29);
            btnExit.TabIndex = 9;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(758, 374);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(256, 29);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(758, 224);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 13;
            label1.Text = "Alias";
            // 
            // txtAlias
            // 
            txtAlias.Location = new Point(758, 247);
            txtAlias.Name = "txtAlias";
            txtAlias.Size = new Size(256, 27);
            txtAlias.TabIndex = 4;
            txtAlias.KeyDown += txtAlias_KeyDown;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(758, 325);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(256, 43);
            btnSaveChanges.TabIndex = 14;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(758, 118);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 16;
            label2.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(758, 141);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(256, 27);
            txtEmail.TabIndex = 15;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 450);
            Controls.Add(label2);
            Controls.Add(txtEmail);
            Controls.Add(btnSaveChanges);
            Controls.Add(label1);
            Controls.Add(txtAlias);
            Controls.Add(btnLogout);
            Controls.Add(btnExit);
            Controls.Add(lblUname);
            Controls.Add(txtUname);
            Controls.Add(lblPass);
            Controls.Add(txtPassword);
            Controls.Add(lblLink);
            Controls.Add(txtLink);
            Controls.Add(btnEdit);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(lwMain);
            Name = "frmMain";
            Text = "frmMain";
            Load += frmMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lwMain;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnEdit;
        private TextBox txtLink;
        private Label lblLink;
        private TextBox txtPassword;
        private Label lblPass;
        private TextBox txtUname;
        private Label lblUname;
        private Button btnExit;
        private Button btnLogout;
        private Label label1;
        private TextBox txtAlias;
        private Button btnSaveChanges;
        private Label label2;
        private TextBox txtEmail;
    }
}