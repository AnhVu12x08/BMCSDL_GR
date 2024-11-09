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
            this.label1 = new System.Windows.Forms.Label();
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
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(389, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "LOGIN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Host
            // 
            this.Host.AutoSize = true;
            this.Host.Location = new System.Drawing.Point(90, 148);
            this.Host.Name = "Host";
            this.Host.Size = new System.Drawing.Size(64, 24);
            this.Host.TabIndex = 2;
            this.Host.Text = "Host :";
            this.Host.Click += new System.EventHandler(this.label2_Click);
            // 
            // port
            // 
            this.port.AutoSize = true;
            this.port.Location = new System.Drawing.Point(90, 212);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(59, 24);
            this.port.TabIndex = 3;
            this.port.Text = "Port :";
            // 
            // sid
            // 
            this.sid.AutoSize = true;
            this.sid.Location = new System.Drawing.Point(90, 287);
            this.sid.Name = "sid";
            this.sid.Size = new System.Drawing.Size(52, 24);
            this.sid.TabIndex = 4;
            this.sid.Text = "Sid :";
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Location = new System.Drawing.Point(90, 358);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(65, 24);
            this.user.TabIndex = 5;
            this.user.Text = "User :";
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.Location = new System.Drawing.Point(90, 442);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(112, 24);
            this.pass.TabIndex = 6;
            this.pass.Text = "Password :";
            // 
            // txt_host
            // 
            this.txt_host.Location = new System.Drawing.Point(239, 148);
            this.txt_host.Name = "txt_host";
            this.txt_host.Size = new System.Drawing.Size(431, 29);
            this.txt_host.TabIndex = 7;
            this.txt_host.Text = "localhost";
            this.txt_host.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(239, 212);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(431, 29);
            this.txt_port.TabIndex = 8;
            this.txt_port.Text = "1521";
            // 
            // txt_sid
            // 
            this.txt_sid.Location = new System.Drawing.Point(239, 287);
            this.txt_sid.Name = "txt_sid";
            this.txt_sid.Size = new System.Drawing.Size(431, 29);
            this.txt_sid.TabIndex = 9;
            this.txt_sid.Text = "orcl";
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(239, 355);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(431, 29);
            this.txt_user.TabIndex = 10;
            this.txt_user.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(239, 437);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(431, 29);
            this.txt_pass.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 517);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 40);
            this.button1.TabIndex = 12;
            this.button1.Text = "Dang nhap";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(515, 517);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 40);
            this.button2.TabIndex = 13;
            this.button2.Text = "Thoat";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 592);
            this.Controls.Add(this.button2);
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
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "DangNhap";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.DangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Button button2;
    }
}

