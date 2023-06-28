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
            listView1 = new ListView();
            btnAdd = new Button();
            btnRemove = new Button();
            btnEdit = new Button();
            txtLink = new TextBox();
            lblLink = new Label();
            txtPassword = new TextBox();
            lblPass = new Label();
            textBox1 = new TextBox();
            lblUname = new Label();
            btnExit = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(640, 426);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(658, 261);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 177);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(658, 12);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(94, 171);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(658, 189);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 66);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // txtLink
            // 
            txtLink.Location = new Point(758, 141);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(256, 27);
            txtLink.TabIndex = 4;
            // 
            // lblLink
            // 
            lblLink.AutoSize = true;
            lblLink.Location = new Point(758, 118);
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
            txtPassword.TabIndex = 6;
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
            // textBox1
            // 
            textBox1.Location = new Point(758, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(256, 27);
            textBox1.TabIndex = 8;
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
            btnExit.TabIndex = 10;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(758, 374);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(256, 29);
            btnLogout.TabIndex = 11;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 450);
            Controls.Add(btnLogout);
            Controls.Add(btnExit);
            Controls.Add(lblUname);
            Controls.Add(textBox1);
            Controls.Add(lblPass);
            Controls.Add(txtPassword);
            Controls.Add(lblLink);
            Controls.Add(txtLink);
            Controls.Add(btnEdit);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(listView1);
            Name = "frmMain";
            Text = "frmMain";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnEdit;
        private TextBox txtLink;
        private Label lblLink;
        private TextBox txtPassword;
        private Label lblPass;
        private TextBox textBox1;
        private Label lblUname;
        private Button btnExit;
        private Button btnLogout;
    }
}