using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;

namespace Komunikator
{
    public partial class Form1 : Form
    {
        Thread connection_check = null;
        string buddy_nick = String.Empty;
        string buddy_ip = String.Empty;
        string nickname = "Sharek";
        List<string> nicknames = new List<string>();
        Socket socket, socket_listener;
        EndPoint endpoint_local, endpoint_remote, endpoint_listener;
        List<string> local_ips = new List<string>();
        string local_ip = "192.168.1.1";

        UdpClient udp = new UdpClient();

        string connection_status = "Nie połączono";
        Color connection_status_color = Color.Red;

        bool connected = false;
        bool disconnected = false;
        bool confirmed = false;

        bool polacz_tool_strip = true;
        bool rozlacz_tool_strip = false;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            User_StripStatusLabel1.Text = String.Format("{0} jako ({1})", Environment.UserName, nickname);
            Space_toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleRight;
            Space_toolStripStatusLabel1.Text = "Nie połączono";
            Connection_StripStatusLabel1.BackColor = Color.Red;
            Chat_listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            Chat_listBox1.MeasureItem += lst_MeasureItem;
            Chat_listBox1.DrawItem += lst_DrawItem;
            nicknames.Add(nickname);
            nicknames.Add("Sharek1");
            nicknames.Add("Sharek2");
            rozlanczToolStripMenuItem.Enabled = false;
            schematyKolorówToolStripMenuItem.Enabled = false;
            foreach (var nick in nicknames)
            {
                wybierzToolStripMenuItem.DropDownItems.Add(nick);
                usunToolStripMenuItem.DropDownItems.Add(nick);
            }
            this.usunToolStripMenuItem.DropDownItemClicked += usunMenuStrip_ItemClicked;
            this.wybierzToolStripMenuItem.DropDownItemClicked += wybierzMenuStrip_ItemClicked;

            GetLocal_Ip();

            if (local_ips.Count == 1)
            {
                local_ip = local_ips[0];
            }
            else
            {
                local_ip = local_ips[0];
                MessageBox.Show("Wykryto więcej niż jedną sieć do której podłączony jest komputer. Domyślnie komikator będzie się łączył w sieci " + local_ip + ". Możesz to zmienić w ustawiniach sieci.", "Dostępne sieci", MessageBoxButtons.OK);
            }
            socket_listener = null;
            socket_listener = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket_listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            socket_listener.ExclusiveAddressUse = false;

            IPEndPoint udp_ip = new IPEndPoint(IPAddress.Any, 80);
            udp.Client.Bind(udp_ip);

            StartListening();
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

        public void GetLocal_Ip()
        {
            string ip = String.Empty;

            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress item in host.AddressList)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    local_ips.Add(item.ToString());
                }
            }
        }

        private void StartListening()
        {
            udp.BeginReceive(Receive, new object());
        }
        private void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 80);
            byte[] bytes = udp.EndReceive(ar, ref ip);
            string recived_message = Encoding.Default.GetString(bytes);

            string[] temp = recived_message.Split('_');
            if (temp[0] == "#IsPresent")
            {
                endpoint_listener = new IPEndPoint(IPAddress.Parse(temp[1]), 81);
                socket_listener.Connect(endpoint_listener);
                byte[] message = Encoding.Default.GetBytes("#Present_" + local_ip + "_" + nickname + "_");
                socket_listener.Send(message);
            }
            if (temp[0] == "#Try")
            {
                if (MessageBox.Show("Czatownik" + temp[2] + " (" + temp[1] + ") Próbuje nawiązać połączenie. Chcesz je przyjąć?", "Czat", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Connect_to(temp[1], 80);
                }
            }

            StartListening();
        }

        private void MessageCallback(IAsyncResult aResult)
        {
            if (disconnected == false)
            {
                try
                {
                    int size = socket.EndReceiveFrom(aResult, ref endpoint_remote);
                    if (size > 0)
                    {
                        byte[] received_data = (byte[])aResult.AsyncState;
                        string received_message = Encoding.Default.GetString(received_data);

                        string[] temp = received_message.Split('_');

                        if (temp[0] == "#OK")
                        {
                            connection_check.Abort();
                            confirmed = true;
                        }
                        else if (temp[0] == "#Buddy")
                        {
                            byte[] message = Encoding.Default.GetBytes("#OK_");
                            socket.Send(message);
                            buddy_nick = temp[1];
                            connection_status = "Połączono z " + buddy_nick;
                            connection_status_color = Color.Green;
                            ListboxInvoke(Chat_listBox1, "Rozpoczynasz czat z " + buddy_nick);
                        }
                        else if (temp[0] == "#BuddyChange")
                        {
                            buddy_nick = temp[1];
                            connection_status = "Połączono z " + buddy_nick;
                            ListboxInvoke(Chat_listBox1, "Rozmówca zmienił pseudonim na " + buddy_nick);
                        }
                        else if (temp[0] == "#End")
                        {
                            disconnected = true;
                            ListboxInvoke(Chat_listBox1, "Rozłączono z rozmówcą");
                            Disconnect();
                            connection_check = new Thread(new ThreadStart(Confirm_connection));
                            connection_check.Start();
                        }
                        else
                        {
                            ListboxInvoke(Chat_listBox1, buddy_nick + ": " + received_message);
                        }
                    }

                    byte[] buffer = new byte[1500];
                    if (disconnected == false)
                    {
                        socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endpoint_remote, new AsyncCallback(MessageCallback), buffer);
                    }         
                }
                catch (Exception e)
                {
                    MessageBox.Show("Messagecallback: " + e.ToString());
                } 
            }
            disconnected = false;
        }

        private void Confirm_connection()
        {
            do
            {
                if (connected == true && confirmed == false)
                {
                    byte[] message = Encoding.Default.GetBytes("#Buddy_" + nickname + "_");
                    socket.Send(message);
                }
                Thread.Sleep(500);
            } while (true);
        }

        public void Connect_to(string ip, int port)
        {
            socket = null;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            socket.ExclusiveAddressUse = false;

            try
            {
                if (!socket.IsBound)
                {
                    endpoint_local = new IPEndPoint(IPAddress.Parse(local_ip), 80);
                    socket.Bind(endpoint_local);
                }

                endpoint_remote = new IPEndPoint(IPAddress.Parse(ip), port);
                socket.BeginConnect(endpoint_remote, new AsyncCallback(ConnectCallback), socket);

                byte[] buffer = new byte[1500];

                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endpoint_remote, new AsyncCallback(MessageCallback), buffer);

                connection_status = "Oczekiwanie...";
                connection_status_color = Color.Yellow;

                connection_check = new Thread(new ThreadStart(Confirm_connection));
                connection_check.Start();

                connected = true;

                polacz_tool_strip = false;
                rozlacz_tool_strip = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connect: " + ex.ToString());
            }
        }

        private void Disconnect()
        {
            if (socket.Connected == true)
            {
                disconnected = true;
                connected = false;
                byte[] message = Encoding.Default.GetBytes("#End_");
                socket.Send(message);
                connection_status = "Nie Połączono";
                connection_status_color = Color.Red;
                socket.Close();
                polacz_tool_strip = true;
                rozlacz_tool_strip = false;
                confirmed = false;
            }
        }

        private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(Chat_listBox1.Items[e.Index].ToString(), Chat_listBox1.Font, Chat_listBox1.Width).Height;
        }

        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(Chat_listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
            catch (Exception) { }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Text_textBox1.TextLength > 0)
            {
                if (connected == true)
                {
                    byte[] message = Encoding.Default.GetBytes(Text_textBox1.Text);
                    socket.Send(message);
                }
                else
                {
                    Chat_listBox1.Items.Add("Nie jesteś połączony, poniższa wiadomość nie została wysłana!");
                }

                Chat_listBox1.Items.Add(nickname + ": " + Text_textBox1.Text);
                Text_textBox1.Text = String.Empty;
            }
            Chat_listBox1.TopIndex = Chat_listBox1.Items.Count - 1;
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            Text_textBox1.Width = ClientRectangle.Width - 104;
            Text_textBox1.Refresh();
            Chat_listBox1.Refresh();
        }

        private void Text_textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                if (Text_textBox1.TextLength > 0)
                {
                    if (connected == true)
                    {
                        byte[] message = Encoding.Default.GetBytes(Text_textBox1.Text);
                        socket.Send(message);
                    }
                    else
                    {
                        Chat_listBox1.Items.Add("Nie jesteś połączony, poniższa wiadomość nie została wysłana!");
                    }

                    Chat_listBox1.Items.Add(nickname + ": " + Text_textBox1.Text);
                    Text_textBox1.Text = String.Empty;
                    Text_textBox1.Clear();
                }
                Chat_listBox1.TopIndex = Chat_listBox1.Items.Count - 1;
            }
        }
        
        private void polaczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connect cn = new Connect(local_ip,nickname);
            cn.ShowDialog();

            if (cn.Anuluj == false)
            {
                Connect_to(cn.Adres_ip, cn.Port);
            }            
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState; 
                client.EndConnect(ar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNickname ad = new AddNickname();
            ad.ShowDialog();
            if (ad.Nickname.Length > 0)
            {
                nicknames.Add(ad.Nickname);
                wybierzToolStripMenuItem.DropDownItems.Add(ad.Nickname);
                usunToolStripMenuItem.DropDownItems.Add(ad.Nickname);
                if (nicknames.Count == 1)
                {
                    nickname = nicknames[0];
                    User_StripStatusLabel1.Text = String.Format("{0} jako ({1})", Environment.UserName, nickname);
                }         
            }
            if (nicknames.Count > 0)
            {
                usunToolStripMenuItem.Enabled = true;
                wybierzToolStripMenuItem.Enabled = true;
            }
        }

        private void wybierzMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            nickname = item.Text;
            User_StripStatusLabel1.Text = String.Format("{0} jako ({1})", Environment.UserName, nickname);
            Chat_listBox1.Items.Add("Zmieniłeś pseudonim na " + nickname);


            if (connected == true)
            {
                byte[] message = Encoding.Default.GetBytes("#BuddyChange_" + nickname + "_");
                socket.Send(message);
            }
        }

        private void usunMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if (item.Text == nickname)
            {
                nicknames.Remove(item.Text);
                if (nicknames.Count == 0)
                {
                    nickname = "No name";
                }
                else
                {
                    nickname = nicknames[0];
                }               
            }         
            else
            {
                nicknames.Remove(item.Text);
            }            
            wybierzToolStripMenuItem.DropDownItems.Clear();
            foreach (var nick in nicknames)
            {
                wybierzToolStripMenuItem.DropDownItems.Add(nick);
            }

            usunToolStripMenuItem.DropDownItems.Remove(item);
            User_StripStatusLabel1.Text = String.Format("{0} jako ({1})", Environment.UserName, nickname);

            if (nicknames.Count == 0)
            {
                usunToolStripMenuItem.Enabled = false;
                wybierzToolStripMenuItem.Enabled = false;
            }
        }

        private void standardowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chat_listBox1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            Text_textBox1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            Send_button1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));

            User_StripStatusLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            Space_toolStripStatusLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));

            MainMenuStrip.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            ustawieniaToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            pomocToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
        }

        private void ciemnyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ustawieniaSieciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetSet ns = new NetSet(local_ips, local_ip);
            ns.ShowDialog();
            local_ip = ns.Selected_ip;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz wyjść?", "Zamykanie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (connected == true)
                {
                    byte[] message = Encoding.Default.GetBytes("#End_");
                    socket.Send(message);
                }               
                Application.ExitThread();
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            polanczToolStripMenuItem.Enabled = polacz_tool_strip;
            rozlanczToolStripMenuItem.Enabled = rozlacz_tool_strip;
            Space_toolStripStatusLabel1.Text = connection_status;
            Connection_StripStatusLabel1.BackColor = connection_status_color;
        }

        private void rozlanczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListboxInvoke(Chat_listBox1, "Zakończyłeś czat");
            Disconnect();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {                  
            if (MessageBox.Show("Czy na pewno chcesz wyjść?", "Zamykanie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (connected == true)
                {
                    byte[] message = Encoding.Default.GetBytes("#End_");
                    socket.Send(message);
                }
                Application.ExitThread();
                Environment.Exit(0);
                this.Close();
            }           
        }
    }
}
