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
    public partial class AddNickname : Form
    {
        string nickname = String.Empty;

        public AddNickname()
        {
            InitializeComponent();
            textBox1.MaxLength = 10;
            this.ActiveControl = textBox1;
            textBox1.Focus();
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                nickname = textBox1.Text;
            }
            this.Close();            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textBox1.Text.Length > 0)
                {
                    nickname = textBox1.Text;
                    this.Close();
                }                
            }
        }
    }
}
