namespace Connect_Oracle
{
    partial class Phanquyen
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbGranteeSys = new System.Windows.Forms.ComboBox();
            this.btnPrivilege = new System.Windows.Forms.Button();
            this.checklistObjectSys = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RevokeSystem = new System.Windows.Forms.Button();
            this.cbbUserRevokeSys = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.checklistObjectObj = new System.Windows.Forms.CheckedListBox();
            this.cbbGranterObj = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbGranteeObj = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbObjectObj = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.clbPriviRevokeSys = new System.Windows.Forms.CheckedListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1001, 593);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(993, 564);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "System Privileges";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage5);
            this.tabControl3.Controls.Add(this.tabPage6);
            this.tabControl3.Location = new System.Drawing.Point(6, 6);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(981, 530);
            this.tabControl3.TabIndex = 10;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button2);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.cbbGranteeSys);
            this.tabPage5.Controls.Add(this.btnPrivilege);
            this.tabPage5.Controls.Add(this.checklistObjectSys);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(973, 501);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Grant";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(868, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 35);
            this.button2.TabIndex = 13;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.clickBack);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(365, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(243, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "Grant System Privileges";
            // 
            // cbbGranteeSys
            // 
            this.cbbGranteeSys.FormattingEnabled = true;
            this.cbbGranteeSys.Location = new System.Drawing.Point(30, 55);
            this.cbbGranteeSys.Name = "cbbGranteeSys";
            this.cbbGranteeSys.Size = new System.Drawing.Size(179, 24);
            this.cbbGranteeSys.TabIndex = 1;
            // 
            // btnPrivilege
            // 
            this.btnPrivilege.Location = new System.Drawing.Point(277, 55);
            this.btnPrivilege.Name = "btnPrivilege";
            this.btnPrivilege.Size = new System.Drawing.Size(102, 24);
            this.btnPrivilege.TabIndex = 9;
            this.btnPrivilege.Text = "Privilege";
            this.btnPrivilege.UseVisualStyleBackColor = true;
            this.btnPrivilege.Click += new System.EventHandler(this.clickPrivilegeSys);
            // 
            // checklistObjectSys
            // 
            this.checklistObjectSys.FormattingEnabled = true;
            this.checklistObjectSys.Items.AddRange(new object[] {
            "CREATE TABLE",
            "CREATE USER",
            "ALTER USER",
            "DROP USER",
            "CREATE VIEW",
            "CREATE ANY TABLE",
            "ALTER ANY TABLE",
            "DROP ANY TABLE",
            "SELECT ANY TABLE",
            "INSERT ANY TABLE",
            "UPDATE ANY TABLE",
            "DELETE ANY TABLE",
            "EXECUTE ANY PROCEDURE"});
            this.checklistObjectSys.Location = new System.Drawing.Point(520, 55);
            this.checklistObjectSys.Name = "checklistObjectSys";
            this.checklistObjectSys.Size = new System.Drawing.Size(313, 276);
            this.checklistObjectSys.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Grantee";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.clbPriviRevokeSys);
            this.tabPage6.Controls.Add(this.label10);
            this.tabPage6.Controls.Add(this.label4);
            this.tabPage6.Controls.Add(this.RevokeSystem);
            this.tabPage6.Controls.Add(this.cbbUserRevokeSys);
            this.tabPage6.Controls.Add(this.button3);
            this.tabPage6.Controls.Add(this.label9);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(973, 501);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Revoke";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(244, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Privileges";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "User";
            // 
            // RevokeSystem
            // 
            this.RevokeSystem.Location = new System.Drawing.Point(561, 70);
            this.RevokeSystem.Name = "RevokeSystem";
            this.RevokeSystem.Size = new System.Drawing.Size(105, 24);
            this.RevokeSystem.TabIndex = 15;
            this.RevokeSystem.Text = "Revoke";
            this.RevokeSystem.UseVisualStyleBackColor = true;
            this.RevokeSystem.Click += new System.EventHandler(this.btnRevokeSys_Click);
            // 
            // cbbUserRevokeSys
            // 
            this.cbbUserRevokeSys.FormattingEnabled = true;
            this.cbbUserRevokeSys.Location = new System.Drawing.Point(37, 71);
            this.cbbUserRevokeSys.Name = "cbbUserRevokeSys";
            this.cbbUserRevokeSys.Size = new System.Drawing.Size(146, 24);
            this.cbbUserRevokeSys.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(868, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 35);
            this.button3.TabIndex = 12;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.clickBack);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(357, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(262, 25);
            this.label9.TabIndex = 11;
            this.label9.Text = "Revoke System Privileges";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(993, 564);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Object Privileges";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(-4, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(972, 537);
            this.tabControl2.TabIndex = 9;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.checklistObjectObj);
            this.tabPage3.Controls.Add(this.cbbGranterObj);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.cbbGranteeObj);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.cbbObjectObj);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(964, 508);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Grant";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(380, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Grant Object Privileges";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(859, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.clickBack);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(404, 190);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // checklistObjectObj
            // 
            this.checklistObjectObj.FormattingEnabled = true;
            this.checklistObjectObj.Items.AddRange(new object[] {
            "SELECT",
            "INSERT",
            "UPDATE",
            "DELETE"});
            this.checklistObjectObj.Location = new System.Drawing.Point(670, 126);
            this.checklistObjectObj.Name = "checklistObjectObj";
            this.checklistObjectObj.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checklistObjectObj.Size = new System.Drawing.Size(181, 106);
            this.checklistObjectObj.TabIndex = 6;
            // 
            // cbbGranterObj
            // 
            this.cbbGranterObj.FormattingEnabled = true;
            this.cbbGranterObj.Location = new System.Drawing.Point(55, 126);
            this.cbbGranterObj.Name = "cbbGranterObj";
            this.cbbGranterObj.Size = new System.Drawing.Size(181, 24);
            this.cbbGranterObj.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(464, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Object";
            // 
            // cbbGranteeObj
            // 
            this.cbbGranteeObj.FormattingEnabled = true;
            this.cbbGranteeObj.Location = new System.Drawing.Point(259, 126);
            this.cbbGranteeObj.Name = "cbbGranteeObj";
            this.cbbGranteeObj.Size = new System.Drawing.Size(181, 24);
            this.cbbGranteeObj.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Grantee";
            // 
            // cbbObjectObj
            // 
            this.cbbObjectObj.FormattingEnabled = true;
            this.cbbObjectObj.Location = new System.Drawing.Point(467, 126);
            this.cbbObjectObj.Name = "cbbObjectObj";
            this.cbbObjectObj.Size = new System.Drawing.Size(181, 24);
            this.cbbObjectObj.TabIndex = 2;
            this.cbbObjectObj.Click += new System.EventHandler(this.cbbGranterSys_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Granter";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(964, 508);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Revoke";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(859, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 35);
            this.button5.TabIndex = 11;
            this.button5.Text = "Back";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.clickBack);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(352, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(253, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "Revoke Object Privileges";
            // 
            // clbPriviRevokeSys
            // 
            this.clbPriviRevokeSys.CheckOnClick = true;
            this.clbPriviRevokeSys.FormattingEnabled = true;
            this.clbPriviRevokeSys.HorizontalScrollbar = true;
            this.clbPriviRevokeSys.Location = new System.Drawing.Point(247, 71);
            this.clbPriviRevokeSys.Name = "clbPriviRevokeSys";
            this.clbPriviRevokeSys.Size = new System.Drawing.Size(295, 293);
            this.clbPriviRevokeSys.TabIndex = 19;
            this.clbPriviRevokeSys.Click += new System.EventHandler(this.cbbPriviRevokeSys_Click);
            // 
            // Phanquyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 617);
            this.Controls.Add(this.tabControl1);
            this.Name = "Phanquyen";
            this.Text = "Phanquyen";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbbGranteeSys;
        private System.Windows.Forms.CheckedListBox checklistObjectSys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbObjectObj;
        private System.Windows.Forms.ComboBox cbbGranteeObj;
        private System.Windows.Forms.ComboBox cbbGranterObj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox checklistObjectObj;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPrivilege;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button RevokeSystem;
        private System.Windows.Forms.ComboBox cbbUserRevokeSys;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox clbPriviRevokeSys;
    }
}