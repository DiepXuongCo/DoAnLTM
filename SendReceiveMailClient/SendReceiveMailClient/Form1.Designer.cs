namespace SendReceiveMailClient
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_login = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_gmailSend = new System.Windows.Forms.TextBox();
            this.button_Update = new System.Windows.Forms.Button();
            this.button_SendMail = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_maillist = new System.Windows.Forms.Button();
            this.radio_nhieumail = new System.Windows.Forms.RadioButton();
            this.radio_motmail = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Browser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_content = new System.Windows.Forms.TextBox();
            this.textBox_browser = new System.Windows.Forms.TextBox();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.textBox_gmailReceive = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.richTextBox_content = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView_Mail = new System.Windows.Forms.DataGridView();
            this.button_ReceiveMail = new System.Windows.Forms.Button();
            this.prgLoadMail = new System.Windows.Forms.ProgressBar();
            this.lblLoadMail = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Mail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_login);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_password);
            this.groupBox1.Controls.Add(this.textBox_gmailSend);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đăng nhập";
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(355, 19);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(69, 33);
            this.button_login.TabIndex = 7;
            this.button_login.Text = "Đăng nhập";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mật khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tài khoản:";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(75, 36);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(275, 20);
            this.textBox_password.TabIndex = 4;
            this.textBox_password.UseSystemPasswordChar = true;
            // 
            // textBox_gmailSend
            // 
            this.textBox_gmailSend.Location = new System.Drawing.Point(75, 14);
            this.textBox_gmailSend.Name = "textBox_gmailSend";
            this.textBox_gmailSend.Size = new System.Drawing.Size(275, 20);
            this.textBox_gmailSend.TabIndex = 3;
            // 
            // button_Update
            // 
            this.button_Update.Location = new System.Drawing.Point(147, 385);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(75, 23);
            this.button_Update.TabIndex = 6;
            this.button_Update.Text = "Cập nhật";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // button_SendMail
            // 
            this.button_SendMail.Location = new System.Drawing.Point(228, 385);
            this.button_SendMail.Name = "button_SendMail";
            this.button_SendMail.Size = new System.Drawing.Size(75, 23);
            this.button_SendMail.TabIndex = 5;
            this.button_SendMail.Text = "Gửi";
            this.button_SendMail.UseVisualStyleBackColor = true;
            this.button_SendMail.Click += new System.EventHandler(this.button_SendMail_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_maillist);
            this.groupBox2.Controls.Add(this.radio_nhieumail);
            this.groupBox2.Controls.Add(this.radio_motmail);
            this.groupBox2.Controls.Add(this.button_Update);
            this.groupBox2.Controls.Add(this.button_SendMail);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button_Browser);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_content);
            this.groupBox2.Controls.Add(this.textBox_browser);
            this.groupBox2.Controls.Add(this.textBox_title);
            this.groupBox2.Controls.Add(this.textBox_gmailReceive);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 414);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gửi Mail";
            // 
            // button_maillist
            // 
            this.button_maillist.Location = new System.Drawing.Point(355, 41);
            this.button_maillist.Name = "button_maillist";
            this.button_maillist.Size = new System.Drawing.Size(63, 23);
            this.button_maillist.TabIndex = 14;
            this.button_maillist.Text = "các mail";
            this.button_maillist.UseVisualStyleBackColor = true;
            this.button_maillist.Click += new System.EventHandler(this.button_maillist_Click);
            // 
            // radio_nhieumail
            // 
            this.radio_nhieumail.AutoSize = true;
            this.radio_nhieumail.Location = new System.Drawing.Point(181, 19);
            this.radio_nhieumail.Name = "radio_nhieumail";
            this.radio_nhieumail.Size = new System.Drawing.Size(120, 17);
            this.radio_nhieumail.TabIndex = 13;
            this.radio_nhieumail.TabStop = true;
            this.radio_nhieumail.Text = "Gửi mail nhiều người";
            this.radio_nhieumail.UseVisualStyleBackColor = true;
            this.radio_nhieumail.CheckedChanged += new System.EventHandler(this.radio_nhieumail_CheckedChanged);
            // 
            // radio_motmail
            // 
            this.radio_motmail.AutoSize = true;
            this.radio_motmail.Location = new System.Drawing.Point(75, 19);
            this.radio_motmail.Name = "radio_motmail";
            this.radio_motmail.Size = new System.Drawing.Size(100, 17);
            this.radio_motmail.TabIndex = 12;
            this.radio_motmail.TabStop = true;
            this.radio_motmail.Text = "Gửi mail 1 người";
            this.radio_motmail.UseVisualStyleBackColor = true;
            this.radio_motmail.CheckedChanged += new System.EventHandler(this.radio_motmail_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nội dung:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "File:";
            // 
            // button_Browser
            // 
            this.button_Browser.Location = new System.Drawing.Point(334, 95);
            this.button_Browser.Name = "button_Browser";
            this.button_Browser.Size = new System.Drawing.Size(85, 23);
            this.button_Browser.TabIndex = 9;
            this.button_Browser.Text = "đính kèm Tệp";
            this.button_Browser.UseVisualStyleBackColor = true;
            this.button_Browser.Click += new System.EventHandler(this.button_Browser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Chủ Đề:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gmail nhận:";
            // 
            // textBox_content
            // 
            this.textBox_content.Location = new System.Drawing.Point(75, 124);
            this.textBox_content.Multiline = true;
            this.textBox_content.Name = "textBox_content";
            this.textBox_content.Size = new System.Drawing.Size(344, 255);
            this.textBox_content.TabIndex = 7;
            // 
            // textBox_browser
            // 
            this.textBox_browser.Location = new System.Drawing.Point(75, 98);
            this.textBox_browser.Name = "textBox_browser";
            this.textBox_browser.ReadOnly = true;
            this.textBox_browser.Size = new System.Drawing.Size(253, 20);
            this.textBox_browser.TabIndex = 6;
            // 
            // textBox_title
            // 
            this.textBox_title.Location = new System.Drawing.Point(75, 69);
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.Size = new System.Drawing.Size(344, 20);
            this.textBox_title.TabIndex = 5;
            // 
            // textBox_gmailReceive
            // 
            this.textBox_gmailReceive.Location = new System.Drawing.Point(75, 43);
            this.textBox_gmailReceive.Name = "textBox_gmailReceive";
            this.textBox_gmailReceive.Size = new System.Drawing.Size(275, 20);
            this.textBox_gmailReceive.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblLoadMail);
            this.groupBox3.Controls.Add(this.prgLoadMail);
            this.groupBox3.Controls.Add(this.button_delete);
            this.groupBox3.Controls.Add(this.richTextBox_content);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.dataGridView_Mail);
            this.groupBox3.Controls.Add(this.button_ReceiveMail);
            this.groupBox3.Location = new System.Drawing.Point(448, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(492, 491);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nhận Mail";
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(411, 211);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 24);
            this.button_delete.TabIndex = 15;
            this.button_delete.Text = "Xóa Mail";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // richTextBox_content
            // 
            this.richTextBox_content.Location = new System.Drawing.Point(8, 238);
            this.richTextBox_content.Name = "richTextBox_content";
            this.richTextBox_content.Size = new System.Drawing.Size(478, 247);
            this.richTextBox_content.TabIndex = 14;
            this.richTextBox_content.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Nội dung mail";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(416, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Số lượng mail";
            // 
            // dataGridView_Mail
            // 
            this.dataGridView_Mail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Mail.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView_Mail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Mail.Location = new System.Drawing.Point(6, 50);
            this.dataGridView_Mail.Name = "dataGridView_Mail";
            this.dataGridView_Mail.Size = new System.Drawing.Size(480, 132);
            this.dataGridView_Mail.TabIndex = 6;
            this.dataGridView_Mail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Mail_CellClick);
            // 
            // button_ReceiveMail
            // 
            this.button_ReceiveMail.Location = new System.Drawing.Point(6, 17);
            this.button_ReceiveMail.Name = "button_ReceiveMail";
            this.button_ReceiveMail.Size = new System.Drawing.Size(75, 27);
            this.button_ReceiveMail.TabIndex = 5;
            this.button_ReceiveMail.Text = "Load mail";
            this.button_ReceiveMail.UseVisualStyleBackColor = true;
            this.button_ReceiveMail.Click += new System.EventHandler(this.button_ReceiveMail_Click);
            // 
            // prgLoadMail
            // 
            this.prgLoadMail.Location = new System.Drawing.Point(89, 188);
            this.prgLoadMail.Name = "prgLoadMail";
            this.prgLoadMail.Size = new System.Drawing.Size(397, 23);
            this.prgLoadMail.Step = 1;
            this.prgLoadMail.TabIndex = 16;
            // 
            // lblLoadMail
            // 
            this.lblLoadMail.AutoSize = true;
            this.lblLoadMail.Location = new System.Drawing.Point(6, 188);
            this.lblLoadMail.Name = "lblLoadMail";
            this.lblLoadMail.Size = new System.Drawing.Size(77, 13);
            this.lblLoadMail.TabIndex = 17;
            this.lblLoadMail.Text = "Đang load mail";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 506);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Mail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_gmailSend;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.Button button_SendMail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Browser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_content;
        private System.Windows.Forms.TextBox textBox_browser;
        private System.Windows.Forms.TextBox textBox_title;
        private System.Windows.Forms.TextBox textBox_gmailReceive;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.RichTextBox richTextBox_content;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView_Mail;
        private System.Windows.Forms.Button button_ReceiveMail;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.RadioButton radio_nhieumail;
        private System.Windows.Forms.RadioButton radio_motmail;
        private System.Windows.Forms.Button button_maillist;
        private System.Windows.Forms.Label lblLoadMail;
        private System.Windows.Forms.ProgressBar prgLoadMail;
    }
}

