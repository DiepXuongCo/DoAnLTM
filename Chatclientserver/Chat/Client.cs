using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public partial class frmClient : Form
    {
        string clientName = "";

        public frmClient()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            panel1.Visible = false;
        }

        IPEndPoint ipe;
        TcpClient client;

        void Connect()
        {
            ipe = new IPEndPoint(IPAddress.Parse(textBox_Connect.Text), 1234);
            client = new TcpClient();
            try
            {
                client.Connect(ipe);
                NetworkStream ns = client.GetStream();
                StreamWriter sw = new StreamWriter(ns);
                sw.WriteLine("connect|" + clientName.ToUpper() + "| đã kết nối");
                sw.Flush();
                //string connect = "connect|" + clientName.ToUpper() + "| đã kết nối";          
                //client.Send(Serialize(connect));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //MessageBox.Show("Không thể kết nối tới server !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.SetApartmentState(ApartmentState.STA);
            listen.Start();
        }

        void Send()
        {
            NetworkStream ns = client.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            if (txtText.Text != string.Empty)
            {
                string chat = "chat|" + clientName.ToUpper() + ": " + txtText.Text;
                sw.WriteLine(chat);
                sw.Flush();
            }

        }

        void Receive()
        {

            try
            {
                NetworkStream ns = client.GetStream();
                StreamReader sr = new StreamReader(ns);
                while (true)
                {
                    byte[] data = new byte[1024 * 5000 * 20];
                    //client.Receive(data);

                    string message = sr.ReadLine();
                    string[] a = message.Split('|');
                    if (a[0] == "chat")
                    {
                        AddMessage(a[1]);
                    }
                    if(a[0] == "file")
                    {
                        string path = "E:\\đồ Án LTM\\Chatclientserver\\Chat\\";
                        string filename = a[2];
                        Thread.Sleep(10000);
                        
                        ReceiveFile(sr, path + filename);
                        //AddMessage("Received !");
                        string fileTail = GetFileTail(filename);
                        if (fileTail == "png" || fileTail == "jpg")
                        {
                            AddMessage(a[1] + ": đã gửi một ảnh ");
                            ShowImage(path + filename);
                        }
                        else
                        {
                            AddMessage(a[1] + ": đã gửi tệp " + filename);
                            AddMessage("tệp " + filename + " được lưu ở " + path);
                        }
                    }
                }
            }
            catch
            {
                Close();
            }
        }

        void AddMessage(string s)
        {

            richTextBox_chat.AppendText(s + Environment.NewLine);
            txtText.Clear();
        }

        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            stream.Position = 0;
            return formatter.Deserialize(stream);
        }

        Image sizeImage(int newWidth, int newHeight, string stPhotoPath)
        {
            Image imgPhoto = Image.FromFile(stPhotoPath);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            //Consider vertical pics
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;

                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((newWidth -
                          (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight -
                          (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);


            Bitmap bmPhoto = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto, new Rectangle(destX, destY, destWidth, destHeight), new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);

            grPhoto.Dispose();
            imgPhoto.Dispose();
            return bmPhoto;
        }

        string GetFileTail(string fileName)
        {
            string s = fileName.Substring(fileName.LastIndexOf('.') + 1);
            return s;
        }

        void ShowImage(string path)
        {
            try
            {
                Image img = Image.FromFile(path);
                img = sizeImage(180, 150, path);
                Clipboard.SetImage(img);
                richTextBox_chat.Paste();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("không gửi hình ảnh được", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
            }
            richTextBox_chat.AppendText(Environment.NewLine);
        }

        string fileto64, filename;
        void ConvertFileToBase64String(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            fileto64 = Convert.ToBase64String(bytes, Base64FormattingOptions.InsertLineBreaks);

            string filePathReplace = path;
            filePathReplace = filePathReplace.Replace("\\", "/");
            filename = filePathReplace.Substring(filePathReplace.LastIndexOf('/') + 1);
        }

        const int sizebuffer = 1024*5000;
        byte[] buffer;
        void SendFile(StreamWriter sw, string path)
        {
            panel1.Visible = true;
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            int numPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(file.Length) / Convert.ToDouble(sizebuffer)));
            progress_loadfile.Maximum = numPackets;
            progress_loadfile.Value = 0;

            sw.WriteLine(numPackets);
            sw.Flush();
            long TotalLength = file.Length;
            int CurrentPacketLength;
            for (int i = 0; i < numPackets; i++)
            {
                if (TotalLength > sizebuffer)
                {
                    CurrentPacketLength = sizebuffer;
                    TotalLength = TotalLength - CurrentPacketLength;
                }
                else
                    CurrentPacketLength = (int)TotalLength;
                buffer = new byte[CurrentPacketLength];
                // Đọc từ file
                file.Read(buffer, 0, CurrentPacketLength);
                sw.WriteLine(System.Convert.ToBase64String(buffer));
                sw.Flush();

                if (progress_loadfile.Value >= progress_loadfile.Maximum)
                    progress_loadfile.Value = progress_loadfile.Minimum;
                progress_loadfile.PerformStep();
                labelLoadFile.Text = "Đã gửi " + progress_loadfile.Value + "/" + progress_loadfile.Maximum;

            }
            file.Close();
            Cursor = Cursors.Default;
            panel1.Visible = false;
        }

        void ReceiveFile(StreamReader sr, string path)
        {

            int numPacket = Convert.ToInt32(sr.ReadLine());
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    panel1.Visible = true;
                    progress_loadfile.Maximum = numPacket;
                    progress_loadfile.Value = 0;
                    FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                    for (int i = 0; i < numPacket; i++)
                    {
                        string base64 = sr.ReadLine();      // Nội dung file
                        buffer = System.Convert.FromBase64String(base64);
                        file.Write(buffer, 0, buffer.Length);

                        if (progress_loadfile.Value >= progress_loadfile.Maximum)
                            progress_loadfile.Value = progress_loadfile.Minimum;
                        progress_loadfile.PerformStep();
                        labelLoadFile.Text = "Đã nhận " + progress_loadfile.Value + "/" + progress_loadfile.Maximum;
                    }
                    file.Close();
                    Cursor = Cursors.Default;
                    panel1.Visible = false;
                }));
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {
            txtText.Enabled = false;
            
            btnSend.Enabled = false;
            btnSendimage.Enabled = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();
            AddMessage(clientName.ToUpper() + ": " + txtText.Text);
        }

        private void frmClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            NetworkStream ns = client.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            string disconnect = "disconnect|" + clientName.ToUpper() + "| đã ngắt kết nối";
            sw.WriteLine(disconnect);
            sw.Flush();
            client.Close();
        }

        private void btnChoose_Click(object sender, EventArgs e) 
        {
            clientName = txtName.Text;

            if (txtName.Text == "")
                MessageBox.Show("bạn chưa đặt tên chat");
            else
            {
                Connect();
                clientName = txtName.Text;
                this.Text = txtName.Text.ToUpper() ;
                txtName.Enabled = false;
                txtText.Enabled = true;
                btnSend.Enabled = true;
                btnSendimage.Enabled = true;
                btnConnect.Enabled = false;
            }

        }

        private void btnSendimage_Click(object sender, EventArgs e)
        {
            NetworkStream ns = client.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            OpenFileDialog of = new OpenFileDialog();
            if(of.ShowDialog() == DialogResult.OK)
            {
                string path = of.FileName;
                ConvertFileToBase64String(path);
                
                string file = "file|"+clientName.ToUpper()+"|" + filename;
                sw.WriteLine(file);
                sw.Flush();

                Cursor.Current = Cursors.WaitCursor;
                SendFile(sw, path);
                Cursor.Current = Cursors.Arrow;
                //AddMessage(filename + " completed");
                Thread.Sleep(10000);
                string filetail = GetFileTail(filename);
                if(filetail == "bmp" || filetail == "png" || filetail == "jpg")
                {
                    AddMessage(clientName.ToUpper() + ": ");
                    ShowImage(path);
                }
                else
                {
                    AddMessage(clientName + ": đã gửi tệp " + filename);
                }
            }
            
        }

        //void uploadimage(string nameimg)
        //{
        //    Bitmap myBitmap = new Bitmap(nameimg);
        //    Clipboard.SetDataObject(myBitmap);
        //    DataFormats.Format myformat = DataFormats.GetFormat(DataFormats.Bitmap);
        //    if(richTextBox_chat.CanPaste(myformat))
        //    {
        //        richTextBox_chat.Paste(myformat);
        //    }
        //    else
        //    {
        //        MessageBox.Show("khong gui anh dc");
        //    }
        //}


        //Bitmap GetScreen()
        //{
        //    Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        //    Graphics g = Graphics.FromImage(bitmap);
        //    g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
        //    return bitmap;
        //}


    }
}
