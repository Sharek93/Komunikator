using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komunikator
{
    public partial class NetSet : Form
    {
        string selected_ip = String.Empty;
        List<string> Ip_list = new List<string>();

        public string Selected_ip
        {
            get
            {
                return selected_ip;
            }
        }

        public NetSet(List<string> Ip_list, string local_ip)
        {
            InitializeComponent();
            this.Ip_list = Ip_list;
            label2.Text = local_ip;
            selected_ip = local_ip;

            foreach (var ip in this.Ip_list)
            {
                listBox1.Items.Add(ip);
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                selected_ip = listBox1.SelectedItem.ToString();
                label2.Text = listBox1.SelectedItem.ToString();
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                selected_ip = listBox1.SelectedItem.ToString();
                label2.Text = listBox1.SelectedItem.ToString();
            }
        }
    }
}
