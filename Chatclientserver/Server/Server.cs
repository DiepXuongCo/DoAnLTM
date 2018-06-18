using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class frmServer : Form
    {
        public frmServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        IPEndPoint ipe;
        TcpListener server;
        List<TcpClient> clientList;     
        void Connect()
        {
            clientList = new List<TcpClient>();
            ipe = new IPEndPoint(IPAddress.Any, 1234);
            server = new TcpListener(ipe);
            //server.Bind(ipe);
            server.Start();
            Thread listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        //server.Listen(10);
                        TcpClient client = server.AcceptTcpClient();
                        clientList.Add(client);

                        Thread rec = new Thread(Receive);
                        rec.IsBackground = true;
                        rec.SetApartmentState(ApartmentState.STA);
                        rec.Start(client);
                    }
                }
                catch
                {
                    ipe = new IPEndPoint(IPAddress.Any, 1234);
                    server = new TcpListener(ipe);
                }
            });
            listen.IsBackground = true;
            listen.SetApartmentState(ApartmentState.STA);
            listen.Start();
        }
        void Close()
        {
            server.Stop();
        }
        string time()
        {
            string t = DateTime.Now.ToString("dd/mm/yy | hh:mm:ss");
            return t;
        }


        void Receive(object obj)
        {
            TcpClient client = obj as TcpClient;
            try
            {              
                while (true)
                {
                    NetworkStream ns = client.GetStream();
                    StreamReader sr = new StreamReader(ns);

                    byte[] data = new byte[1024 * 24];
                    //client.Receive(data);

                    string message = sr.ReadLine();
                    
                    foreach (TcpClient item in clientList)
                    {
                        if (item != null && item != client)
                        {
                            NetworkStream nsitem = item.GetStream();
                            StreamWriter sw = new StreamWriter(nsitem);
                            sw.WriteLine(message);
                            sw.Flush();
                        }
                    }
                    string[] a = message.Split('|');
                    if (a[0] == "connect")
                    {
                        AddMessage(a[1]+a[2]);
                        list_client.Items.Add(a[1]);
                    }
                    else if (a[0] == "chat")
                    {
                        AddMessage(a[1]);
                    }
                    //else if (a[0] == "file")
                    //{
                    //    string file = a[1] + " đã gửi một tệp ";
                    //    AddMessage(file);
                    //}
                    else if (a[0] == "disconnect")
                    {
                        AddMessage(a[1]+a[2]);
                        list_client.Items.Remove(a[1]);
                    }
                    
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }
        }
        void AddMessage(string s)
        {
            //listBox_mess.Items.Add("[" + time() + "] " + s);
            richTextBox1.AppendText("[" + time() + "] " + s + Environment.NewLine);
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

        private void frmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
        string GetFileTail(string fileName)
        {
            string s = fileName.Substring(fileName.LastIndexOf('.') + 1);
            return s;
        }
    }
}
