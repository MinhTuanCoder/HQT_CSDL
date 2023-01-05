namespace QuanLySieuThiDienMay
{
    partial class Login
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
            this.lb_userName = new System.Windows.Forms.Label();
            this.lb_passWord = new System.Windows.Forms.Label();
            this.tb_userName = new System.Windows.Forms.TextBox();
            this.tb_passWord = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_serverName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lb_userName
            // 
            this.lb_userName.AutoSize = true;
            this.lb_userName.Location = new System.Drawing.Point(58, 71);
            this.lb_userName.Name = "lb_userName";
            this.lb_userName.Size = new System.Drawing.Size(67, 16);
            this.lb_userName.TabIndex = 0;
            this.lb_userName.Text = "Tài khoản";
            // 
            // lb_passWord
            // 
            this.lb_passWord.AutoSize = true;
            this.lb_passWord.Location = new System.Drawing.Point(58, 139);
            this.lb_passWord.Name = "lb_passWord";
            this.lb_passWord.Size = new System.Drawing.Size(61, 16);
            this.lb_passWord.TabIndex = 1;
            this.lb_passWord.Text = "Mật khẩu";
            // 
            // tb_userName
            // 
            this.tb_userName.Location = new System.Drawing.Point(151, 71);
            this.tb_userName.Name = "tb_userName";
            this.tb_userName.Size = new System.Drawing.Size(182, 22);
            this.tb_userName.TabIndex = 2;
            // 
            // tb_passWord
            // 
            this.tb_passWord.Location = new System.Drawing.Point(151, 136);
            this.tb_passWord.Name = "tb_passWord";
            this.tb_passWord.Size = new System.Drawing.Size(182, 22);
            this.tb_passWord.TabIndex = 3;
            this.tb_passWord.UseSystemPasswordChar = true;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(61, 200);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(128, 33);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "Đăng nhập";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(206, 200);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(127, 33);
            this.btn_exit.TabIndex = 5;
            this.btn_exit.Text = "Thoát";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên máy chủ";
            // 
            // cbb_serverName
            // 
            this.cbb_serverName.FormattingEnabled = true;
            this.cbb_serverName.Location = new System.Drawing.Point(151, 16);
            this.cbb_serverName.Name = "cbb_serverName";
            this.cbb_serverName.Size = new System.Drawing.Size(182, 24);
            this.cbb_serverName.TabIndex = 7;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 286);
            this.Controls.Add(this.cbb_serverName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.tb_passWord);
            this.Controls.Add(this.tb_userName);
            this.Controls.Add(this.lb_passWord);
            this.Controls.Add(this.lb_userName);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập tài khoản";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_userName;
        private System.Windows.Forms.Label lb_passWord;
        private System.Windows.Forms.TextBox tb_userName;
        private System.Windows.Forms.TextBox tb_passWord;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb_serverName;
    }
}

