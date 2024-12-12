namespace Connect_Oracle
{
    partial class DangNhap
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
            this.Host = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.Label();
            this.sid = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.Label();
            this.txt_host = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.txt_sid = new System.Windows.Forms.TextBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cb_pass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Host
            // 
            this.Host.AutoSize = true;
            this.Host.Location = new System.Drawing.Point(60, 133);
            this.Host.Name = "Host";
            this.Host.Size = new System.Drawing.Size(80, 29);
            this.Host.TabIndex = 2;
            this.Host.Text = "Host :";
            // 
            // port
            // 
            this.port.AutoSize = true;
            this.port.Location = new System.Drawing.Point(60, 205);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(75, 29);
            this.port.TabIndex = 3;
            this.port.Text = "Port :";
            // 
            // sid
            // 
            this.sid.AutoSize = true;
            this.sid.Location = new System.Drawing.Point(60, 280);
            this.sid.Name = "sid";
            this.sid.Size = new System.Drawing.Size(66, 29);
            this.sid.TabIndex = 4;
            this.sid.Text = "Sid :";
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Location = new System.Drawing.Point(60, 351);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(82, 29);
            this.user.TabIndex = 5;
            this.user.Text = "User :";
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.Location = new System.Drawing.Point(60, 430);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(142, 29);
            this.pass.TabIndex = 6;
            this.pass.Text = "Password :";
            // 
            // txt_host
            // 
            this.txt_host.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.txt_host.Location = new System.Drawing.Point(209, 133);
            this.txt_host.Name = "txt_host";
            this.txt_host.Size = new System.Drawing.Size(431, 34);
            this.txt_host.TabIndex = 7;
            this.txt_host.Text = "localhost";
            // 
            // txt_port
            // 
            this.txt_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.txt_port.Location = new System.Drawing.Point(209, 205);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(431, 34);
            this.txt_port.TabIndex = 8;
            this.txt_port.Text = "1521";
            // 
            // txt_sid
            // 
            this.txt_sid.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.txt_sid.Location = new System.Drawing.Point(209, 280);
            this.txt_sid.Name = "txt_sid";
            this.txt_sid.Size = new System.Drawing.Size(431, 34);
            this.txt_sid.TabIndex = 9;
            this.txt_sid.Text = "orcl";
            // 
            // txt_user
            // 
            this.txt_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.txt_user.Location = new System.Drawing.Point(209, 348);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(431, 34);
            this.txt_user.TabIndex = 1;
            // 
            // txt_pass
            // 
            this.txt_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.txt_pass.Location = new System.Drawing.Point(209, 430);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(431, 34);
            this.txt_pass.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(292, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(324, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 46);
            this.label1.TabIndex = 14;
            this.label1.Text = "Login";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(230, 573);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(315, 29);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Dont have an account yet?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.clickDHAC);
            // 
            // cb_pass
            // 
            this.cb_pass.AutoSize = true;
            this.cb_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_pass.Location = new System.Drawing.Point(209, 470);
            this.cb_pass.Name = "cb_pass";
            this.cb_pass.Size = new System.Drawing.Size(137, 22);
            this.cb_pass.TabIndex = 16;
            this.cb_pass.Text = "Show password";
            this.cb_pass.UseVisualStyleBackColor = true;
            this.cb_pass.CheckedChanged += new System.EventHandler(this.cb_pass_CheckedChanged);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 635);
            this.Controls.Add(this.cb_pass);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.txt_sid);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_host);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.user);
            this.Controls.Add(this.sid);
            this.Controls.Add(this.port);
            this.Controls.Add(this.Host);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DangNhap";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Host;
        private System.Windows.Forms.Label port;
        private System.Windows.Forms.Label sid;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Label pass;
        private System.Windows.Forms.TextBox txt_host;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.TextBox txt_sid;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox cb_pass;
    }
}

