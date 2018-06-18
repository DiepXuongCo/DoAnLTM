using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;
using Limilabs.Mail;
using Limilabs.Client.POP3;
using System.Threading;

namespace SendReceiveMailClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            
        }
        struct DataParameter
        {
            public int process;
            public int delay;
        }
        DataParameter _inputparameter;
        MailMessage mes;
        Attachment atm = null;
        SmtpClient clientmail;
        Pop3 pop3;
        IMail imail;
        DataTable dtmail;
        string idmail = "0";
        Thread sendmail;

        void loginmail()
        {
            try
            {
                clientmail = new SmtpClient("smtp.gmail.com", 587);

                pop3 = new Pop3();
                pop3.ConnectSSL("pop.gmail.com", 995);

                clientmail.EnableSsl = true;
                clientmail.Credentials = new NetworkCredential(textBox_gmailSend.Text, textBox_password.Text);

                pop3.Login(textBox_gmailSend.Text, textBox_password.Text);

                MessageBox.Show(" Tài khoản đăng nhập thành công", "Đăng nhập hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đăng nhập thất bại", "Đăng nhập hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
            }
        }

        void ChooseFile()
        {
            OpenFileDialog opF = new OpenFileDialog();
            if (opF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_browser.Text = opF.FileName;
            }
        }

        void SendMail(string from_gmail, string to_gmail,string subject, string content,Attachment file = null)
        {
            mes = new MailMessage(from_gmail, to_gmail, subject, content);
            if (atm != null)
            {
                mes.Attachments.Add(atm);
            }
            clientmail.Send(mes);
            MessageBox.Show("Đã gửi mail thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void loadMail()
        {
            //lblLoadMail.Visible = true;
            //prgLoadMail.Visible = true;
            int numPacket = (pop3.GetAll()).Count;

            prgLoadMail.Maximum = numPacket;
            prgLoadMail.Value = 0;

            dtmail = new DataTable();
            dtmail.Columns.Add("id", typeof(string));
            dtmail.Columns.Add("người Gửi", typeof(string));
            dtmail.Columns.Add("chủ đề", typeof(string));
            dtmail.Columns.Add("thời gian", typeof(string));
            //int i = 1;
            foreach (string uid in pop3.GetAll())
            {
                imail = new MailBuilder().CreateFromEml(pop3.GetHeadersByUID(uid));
                DataRow row = dtmail.NewRow();
                row["id"] = uid;
                row["người Gửi"] = imail.From.ToString();
                row["chủ đề"] = imail.Subject;
                row["thời gian"] = imail.Date.ToString();

                if (prgLoadMail.Value >= prgLoadMail.Maximum)
                    prgLoadMail.Value = prgLoadMail.Minimum;
                prgLoadMail.PerformStep();
                this.Invoke((MethodInvoker)delegate () { lblLoadMail.Text = "Đã nhận " + prgLoadMail.Value + "/" + prgLoadMail.Maximum; });
                //lblLoadMail.Text = "Đã nhận " + prgLoadMail.Value + "/" + prgLoadMail.Maximum;

                dtmail.Rows.Add(row);
                dtmail.AcceptChanges();
                
            }
            
            dataGridView_Mail.DataSource = dtmail;
        }

        void DelMail()
        {
            if(idmail != "0")
            {
                pop3.DeleteMessageByUID(idmail);
                foreach(DataRow row in dtmail.Rows)
                {
                    if(idmail == row["id"].ToString())
                    {
                        dtmail.Rows.Remove(row);
                        dtmail.AcceptChanges();
                        break;
                    }
                }
                dataGridView_Mail.DataSource = dtmail;
            }
        }

        bool check = true;
        private void button_login_Click(object sender, EventArgs e)
        {
            if (check)
            {
                loginmail();
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                //textBox_gmailReceive.Enabled = true;
                //textBox_title.Enabled = true;
                //textBox_browser.Enabled = true;
                //textBox_content.Enabled = true;

                //radio_motmail.Enabled = true;
                radio_motmail.Checked = true;
                check = false;
                textBox_gmailSend.ReadOnly = true;
                textBox_password.ReadOnly = true;
                //radio_nhieumail.Enabled = true;
                button_login.Text = "Thoát";
                //button_Browser.Enabled = true;
                //button_SendMail.Enabled = true;
                //button_Update.Enabled = true;
                //button_ReceiveMail.Enabled = true;
                //button_delete.Enabled = true;
                //button_maillist.Enabled = true;

                //dataGridView_Mail.Enabled = true;

                //richTextBox_content.Enabled = true;
            }
            else
            {                
                textBox_gmailSend.Text = "";
                textBox_password.Text = "";
                textBox_gmailSend.ReadOnly = false;
                textBox_password.ReadOnly = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                check = true;
                button_login.Text = "Đăng nhập";
                textBox_gmailReceive.Text = "";
                textBox_title.Text = "";
                textBox_browser.Text = "";
                textBox_content.Text = "";

            }
        }

        private void button_SendMail_Click(object sender, EventArgs e)
        {
            sendmail = new Thread(() =>
            {
                atm = null;
                try
                {
                    FileInfo file = new FileInfo(textBox_browser.Text);
                    atm = new Attachment(textBox_browser.Text);
                }
                catch
                {

                }
                if (radio_motmail.Checked == true)
                {
                    SendMail(textBox_gmailSend.Text, textBox_gmailReceive.Text, textBox_title.Text, textBox_content.Text, atm);
                }
                if (radio_nhieumail.Checked == true)
                {
                    StreamReader sr = new StreamReader(textBox_gmailReceive.Text);
                    string email;
                    while ((email = sr.ReadLine()) != null)
                    {
                        SendMail(textBox_gmailSend.Text, email, textBox_title.Text, textBox_content.Text, atm);
                    }
                    sr.Close();
                }
            });
            sendmail.Start();
            
        }

        private void button_Browser_Click(object sender, EventArgs e)
        {
            ChooseFile();
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            textBox_gmailReceive.Text = "";
            textBox_title.Text = "";
            textBox_browser.Text = "";
            textBox_content.Text = "";
        }

        private void button_ReceiveMail_Click(object sender, EventArgs e)
        {           
            loadMail();
        }

        //lấy nội dung mail
        private void dataGridView_Mail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_Mail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (e.ColumnIndex == 0)
                {
                    string id = dataGridView_Mail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    imail = new MailBuilder().CreateFromEml(pop3.GetMessageByUID(id));
                    richTextBox_content.Text = imail.Text;

                    idmail = id;
                }
                else
                {
                    idmail = "0";
                }
            }
            else
            {
                idmail = "0";
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            DelMail();
        }

        private void radio_motmail_CheckedChanged(object sender, EventArgs e)
        {
            button_maillist.Enabled = false;
            textBox_gmailReceive.Text = "";
            textBox_gmailReceive.ReadOnly = false;
        }

        private void radio_nhieumail_CheckedChanged(object sender, EventArgs e)
        {
            button_maillist.Enabled = true;
            textBox_gmailReceive.Text = "";
            textBox_gmailReceive.ReadOnly = true;
        }

        private void button_maillist_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            if(of.ShowDialog() == DialogResult.OK)
            {
                textBox_gmailReceive.Text = of.FileName;
            }
        }
    }
}
