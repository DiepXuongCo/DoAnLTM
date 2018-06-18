namespace Chat
{
    partial class frmClient
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.textBox_Connect = new System.Windows.Forms.TextBox();
            this.richTextBox_chat = new System.Windows.Forms.RichTextBox();
            this.btnSendimage = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progress_loadfile = new System.Windows.Forms.ProgressBar();
            this.labelLoadFile = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tin nhắn:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(48, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(234, 20);
            this.txtName.TabIndex = 3;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(12, 330);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(335, 23);
            this.txtText.TabIndex = 4;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(353, 295);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 58);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Gửi";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(353, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Kết nối";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // textBox_Connect
            // 
            this.textBox_Connect.Location = new System.Drawing.Point(288, 14);
            this.textBox_Connect.Name = "textBox_Connect";
            this.textBox_Connect.ReadOnly = true;
            this.textBox_Connect.Size = new System.Drawing.Size(59, 20);
            this.textBox_Connect.TabIndex = 8;
            this.textBox_Connect.Text = "127.0.0.1";
            // 
            // richTextBox_chat
            // 
            this.richTextBox_chat.Location = new System.Drawing.Point(12, 41);
            this.richTextBox_chat.Name = "richTextBox_chat";
            this.richTextBox_chat.Size = new System.Drawing.Size(416, 248);
            this.richTextBox_chat.TabIndex = 14;
            this.richTextBox_chat.Text = "";
            // 
            // btnSendimage
            // 
            this.btnSendimage.Location = new System.Drawing.Point(275, 295);
            this.btnSendimage.Name = "btnSendimage";
            this.btnSendimage.Size = new System.Drawing.Size(72, 27);
            this.btnSendimage.TabIndex = 15;
            this.btnSendimage.Text = "Tệp";
            this.btnSendimage.UseVisualStyleBackColor = true;
            this.btnSendimage.Click += new System.EventHandler(this.btnSendimage_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelLoadFile);
            this.panel1.Controls.Add(this.progress_loadfile);
            this.panel1.Location = new System.Drawing.Point(12, 256);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 33);
            this.panel1.TabIndex = 16;
            // 
            // progress_loadfile
            // 
            this.progress_loadfile.Location = new System.Drawing.Point(96, 5);
            this.progress_loadfile.Name = "progress_loadfile";
            this.progress_loadfile.Size = new System.Drawing.Size(314, 23);
            this.progress_loadfile.Step = 1;
            this.progress_loadfile.TabIndex = 0;
            // 
            // labelLoadFile
            // 
            this.labelLoadFile.AutoSize = true;
            this.labelLoadFile.Location = new System.Drawing.Point(25, 5);
            this.labelLoadFile.Name = "labelLoadFile";
            this.labelLoadFile.Size = new System.Drawing.Size(65, 13);
            this.labelLoadFile.TabIndex = 1;
            this.labelLoadFile.Text = "đang gửi file";
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 367);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSendimage);
            this.Controls.Add(this.richTextBox_chat);
            this.Controls.Add(this.textBox_Connect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmClient";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmClient_FormClosed);
            this.Load += new System.EventHandler(this.Client_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox textBox_Connect;
        private System.Windows.Forms.RichTextBox richTextBox_chat;
        private System.Windows.Forms.Button btnSendimage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelLoadFile;
        private System.Windows.Forms.ProgressBar progress_loadfile;
    }
}

