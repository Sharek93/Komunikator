using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komunikator
{
    
    public partial class Connect : Form
    {
        string buddy_ip = String.Empty;
        int port = 80;
        bool anuluj = false;
        string local_ip;
        string nickname;

        UdpClient udp = new UdpClient();

        Socket socket;
        EndPoint endpoint_receiver;

        public Connect(string ip, string nick)
        {
            InitializeComponent();
            textBox2.Enabled = false;
            this.local_ip = ip;
            this.nickname = nick;
           
            socket = null;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            socket.ExclusiveAddressUse = false;

            IPEndPoint udp_ip = new IPEndPoint(IPAddress.Any, 81);
            udp.Client.Bind(udp_ip);           
            StartListening();
        }

        public string Adres_ip
        {
            get
            {
                return buddy_ip;
            }
        }
        public int Port
        {
            get
            {
                return port;
            }
        }
        public bool Anuluj
        {
            get
            {
                return anuluj;
            }
        }
        public void ListboxInvoke(ListBox listbox, string value)
        {
            if (listbox.InvokeRequired)
            {
                listbox.Invoke((MethodInvoker)delegate ()
                {
                    ListboxInvoke(listbox, value);
                });
            }
            else
            {
                listbox.Items.Add(value);
            }
        }

        public void TextboxInvoke(TextBox textbox, string value)
        {
            if (textbox.InvokeRequired)
            {
                textbox.Invoke((MethodInvoker)delegate ()
                {
                    textbox.Text = value;
                });
            }
        }

        private void StartListening()
        {
            udp.BeginReceive(Receive, new object());
        }
        private void Receive(IAsyncResult ar)
        {
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Any, 81);
                byte[] bytes = udp.EndReceive(ar, ref ip);
                string recived_message = Encoding.Default.GetString(bytes);

                string[] temp = recived_message.Split('_');
                if (temp[0] == "#IsPresent")
                {
                    byte[] message = Encoding.Default.GetBytes("#Present_" + local_ip + "_" + nickname + "_");
                    endpoint_receiver = new IPEndPoint(IPAddress.Parse(temp[1]), 81);
                    socket.Connect(endpoint_receiver);
                    socket.Send(message);
                }
                if (temp[0] == "#Present")
                {
                    if (temp[1] != local_ip)
                    {
                        ListboxInvoke(listBox1, temp[2] + "_" + temp[1]);
                    }
                }
                if (temp[0] == "#Try")
                {
                    if (MessageBox.Show("Czatownik" + temp[2] + " (" + temp[1] + ") Próbuje nawiązać połączenie. Chcesz je przyjąć?", "Czat", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        TextboxInvoke(textBox1, temp[1]);
                        buddy_ip = temp[1];
                    }
                }
                StartListening();
            }
            catch (Exception){}
        }

        private void Connect_button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0 && textBox2.TextLength > 0)
            {
                if (listBox1.SelectedIndex != -1)
                {
                    string selected = listBox1.SelectedItem.ToString();
                    string[] temp = selected.Split('_');
                    buddy_ip = temp[1];
                }
                else
                {
                    buddy_ip = textBox1.Text;
                }
                anuluj = false;
                port = Convert.ToInt32(textBox2.Text);

                UdpClient client = new UdpClient();
                byte[] message = Encoding.Default.GetBytes("#Try_" + local_ip + "_" + nickname + "_");
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(buddy_ip), 81);
                client.Send(message, message.Length, ip);

                ip = new IPEndPoint(IPAddress.Parse(buddy_ip), 80);
                client.Send(message, message.Length, ip);
                client.Close();

                udp.Close();
                this.Close();
            }            
        }
        private void Cancel_button2_Click(object sender, EventArgs e)
        {
            anuluj = true;
            udp.Close();
            this.Close();
        }

        private void Search_button3_Click(object sender, EventArgs e)
        {
            try
            {
                UdpClient client = new UdpClient();
                IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, 81);
                byte[] message = Encoding.Default.GetBytes("#IsPresent_"+local_ip+"_");
                client.Send(message,message.Length,ip);

                ip = new IPEndPoint(IPAddress.Broadcast, 80);
                client.Send(message, message.Length, ip);
                client.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString());
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string selected = listBox1.SelectedItem.ToString();
            string[] temp = selected.Split('_');

            buddy_ip = temp[1];
            textBox1.Text = temp[1];
        }

        private void Connect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(buddy_ip == String.Empty)
            {
                anuluj = true;
            }
            udp.Close();
        }
    }
}
