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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checklistObject = new System.Windows.Forms.CheckedListBox();
            this.cbbGranteeSys = new System.Windows.Forms.ComboBox();
            this.cbbGranterSys = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbObjectObj = new System.Windows.Forms.ComboBox();
            this.cbbGranteeObj = new System.Windows.Forms.ComboBox();
            this.cbbGranterObj = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1001, 593);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.checklistObject);
            this.tabPage1.Controls.Add(this.cbbGranteeSys);
            this.tabPage1.Controls.Add(this.cbbGranterSys);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(993, 564);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "System Privileges";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(224, 395);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(854, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.clickBack);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Grantee";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Granter";
            // 
            // checklistObject
            // 
            this.checklistObject.FormattingEnabled = true;
            this.checklistObject.Items.AddRange(new object[] {
            "CREATE SESSION",
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
            this.checklistObject.Location = new System.Drawing.Point(533, 60);
            this.checklistObject.Name = "checklistObject";
            this.checklistObject.Size = new System.Drawing.Size(245, 327);
            this.checklistObject.TabIndex = 2;
            // 
            // cbbGranteeSys
            // 
            this.cbbGranteeSys.FormattingEnabled = true;
            this.cbbGranteeSys.Location = new System.Drawing.Point(275, 60);
            this.cbbGranteeSys.Name = "cbbGranteeSys";
            this.cbbGranteeSys.Size = new System.Drawing.Size(179, 24);
            this.cbbGranteeSys.TabIndex = 1;
            this.cbbGranteeSys.SelectedIndexChanged += new System.EventHandler(this.cbbGranteeSys_SelectedIndexChanged);
            // 
            // cbbGranterSys
            // 
            this.cbbGranterSys.FormattingEnabled = true;
            this.cbbGranterSys.Location = new System.Drawing.Point(33, 60);
            this.cbbGranterSys.Name = "cbbGranterSys";
            this.cbbGranterSys.Size = new System.Drawing.Size(159, 24);
            this.cbbGranterSys.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.checkedListBox2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cbbObjectObj);
            this.tabPage2.Controls.Add(this.cbbGranteeObj);
            this.tabPage2.Controls.Add(this.cbbGranterObj);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(993, 564);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Object Privileges";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(399, 366);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(874, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.clickBack);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "SELECT",
            "INSERT",
            "UPDATE",
            "DELETE"});
            this.checkedListBox2.Location = new System.Drawing.Point(32, 236);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkedListBox2.Size = new System.Drawing.Size(181, 106);
            this.checkedListBox2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(544, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Object";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Grantee";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Granter";
            // 
            // cbbObjectObj
            // 
            this.cbbObjectObj.FormattingEnabled = true;
            this.cbbObjectObj.Location = new System.Drawing.Point(547, 83);
            this.cbbObjectObj.Name = "cbbObjectObj";
            this.cbbObjectObj.Size = new System.Drawing.Size(201, 24);
            this.cbbObjectObj.TabIndex = 2;
            this.cbbObjectObj.Click += new System.EventHandler(this.cbbGranterSys_SelectedIndexChanged);
            // 
            // cbbGranteeObj
            // 
            this.cbbGranteeObj.FormattingEnabled = true;
            this.cbbGranteeObj.Location = new System.Drawing.Point(282, 83);
            this.cbbGranteeObj.Name = "cbbGranteeObj";
            this.cbbGranteeObj.Size = new System.Drawing.Size(201, 24);
            this.cbbGranteeObj.TabIndex = 1;
            // 
            // cbbGranterObj
            // 
            this.cbbGranterObj.FormattingEnabled = true;
            this.cbbGranterObj.Location = new System.Drawing.Point(32, 83);
            this.cbbGranterObj.Name = "cbbGranterObj";
            this.cbbGranterObj.Size = new System.Drawing.Size(200, 24);
            this.cbbGranterObj.TabIndex = 0;
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
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbbGranteeSys;
        private System.Windows.Forms.ComboBox cbbGranterSys;
        private System.Windows.Forms.CheckedListBox checklistObject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbObjectObj;
        private System.Windows.Forms.ComboBox cbbGranteeObj;
        private System.Windows.Forms.ComboBox cbbGranterObj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}