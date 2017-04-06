namespace Komunikator
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.User_StripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Space_toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Connection_StripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Send_button1 = new System.Windows.Forms.Button();
            this.Text_textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polanczToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rozlanczToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pseudonimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.wybierzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaSieciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.schematyKolorówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ciemnyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgramieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Chat_listBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.User_StripStatusLabel1,
            this.Space_toolStripStatusLabel1,
            this.Connection_StripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(434, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // User_StripStatusLabel1
            // 
            this.User_StripStatusLabel1.Name = "User_StripStatusLabel1";
            this.User_StripStatusLabel1.Size = new System.Drawing.Size(30, 17);
            this.User_StripStatusLabel1.Text = "User";
            // 
            // Space_toolStripStatusLabel1
            // 
            this.Space_toolStripStatusLabel1.Name = "Space_toolStripStatusLabel1";
            this.Space_toolStripStatusLabel1.Size = new System.Drawing.Size(373, 17);
            this.Space_toolStripStatusLabel1.Spring = true;
            this.Space_toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Connection_StripStatusLabel1
            // 
            this.Connection_StripStatusLabel1.Name = "Connection_StripStatusLabel1";
            this.Connection_StripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            this.Connection_StripStatusLabel1.Text = "   ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Send_button1);
            this.panel1.Controls.Add(this.Text_textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 258);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(434, 81);
            this.panel1.TabIndex = 2;
            // 
            // Send_button1
            // 
            this.Send_button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.Send_button1.Location = new System.Drawing.Point(354, 10);
            this.Send_button1.Name = "Send_button1";
            this.Send_button1.Size = new System.Drawing.Size(70, 61);
            this.Send_button1.TabIndex = 1;
            this.Send_button1.Text = "Wyślij";
            this.Send_button1.UseVisualStyleBackColor = true;
            this.Send_button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Text_textBox1
            // 
            this.Text_textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Text_textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Text_textBox1.Location = new System.Drawing.Point(10, 10);
            this.Text_textBox1.Multiline = true;
            this.Text_textBox1.Name = "Text_textBox1";
            this.Text_textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Text_textBox1.Size = new System.Drawing.Size(330, 61);
            this.Text_textBox1.TabIndex = 0;
            this.Text_textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_textBox1_KeyPress);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.ustawieniaToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(434, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.polanczToolStripMenuItem,
            this.rozlanczToolStripMenuItem,
            this.toolStripSeparator1,
            this.zamknijToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // polanczToolStripMenuItem
            // 
            this.polanczToolStripMenuItem.Name = "polanczToolStripMenuItem";
            this.polanczToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.polanczToolStripMenuItem.Text = "Połącz";
            this.polanczToolStripMenuItem.Click += new System.EventHandler(this.polaczToolStripMenuItem_Click);
            // 
            // rozlanczToolStripMenuItem
            // 
            this.rozlanczToolStripMenuItem.Name = "rozlanczToolStripMenuItem";
            this.rozlanczToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.rozlanczToolStripMenuItem.Text = "Rozłącz";
            this.rozlanczToolStripMenuItem.Click += new System.EventHandler(this.rozlanczToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.zamknijToolStripMenuItem_Click);
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pseudonimToolStripMenuItem,
            this.ustawieniaSieciToolStripMenuItem,
            this.toolStripSeparator3,
            this.schematyKolorówToolStripMenuItem,
            this.standardowyToolStripMenuItem,
            this.ciemnyToolStripMenuItem});
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            this.ustawieniaToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.ustawieniaToolStripMenuItem.Text = "Ustawienia";
            // 
            // pseudonimToolStripMenuItem
            // 
            this.pseudonimToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nowyToolStripMenuItem,
            this.usunToolStripMenuItem,
            this.toolStripSeparator4,
            this.wybierzToolStripMenuItem});
            this.pseudonimToolStripMenuItem.Name = "pseudonimToolStripMenuItem";
            this.pseudonimToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.pseudonimToolStripMenuItem.Text = "Pseudonim";
            // 
            // nowyToolStripMenuItem
            // 
            this.nowyToolStripMenuItem.Name = "nowyToolStripMenuItem";
            this.nowyToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.nowyToolStripMenuItem.Text = "Dodaj";
            this.nowyToolStripMenuItem.Click += new System.EventHandler(this.nowyToolStripMenuItem_Click);
            // 
            // usunToolStripMenuItem
            // 
            this.usunToolStripMenuItem.Name = "usunToolStripMenuItem";
            this.usunToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.usunToolStripMenuItem.Text = "Usun";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(113, 6);
            // 
            // wybierzToolStripMenuItem
            // 
            this.wybierzToolStripMenuItem.Name = "wybierzToolStripMenuItem";
            this.wybierzToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.wybierzToolStripMenuItem.Text = "Wybierz";
            // 
            // ustawieniaSieciToolStripMenuItem
            // 
            this.ustawieniaSieciToolStripMenuItem.Name = "ustawieniaSieciToolStripMenuItem";
            this.ustawieniaSieciToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ustawieniaSieciToolStripMenuItem.Text = "Ustawienia Sieci";
            this.ustawieniaSieciToolStripMenuItem.Click += new System.EventHandler(this.ustawieniaSieciToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // schematyKolorówToolStripMenuItem
            // 
            this.schematyKolorówToolStripMenuItem.Name = "schematyKolorówToolStripMenuItem";
            this.schematyKolorówToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.schematyKolorówToolStripMenuItem.Text = "Schematy kolorów";
            // 
            // standardowyToolStripMenuItem
            // 
            this.standardowyToolStripMenuItem.Name = "standardowyToolStripMenuItem";
            this.standardowyToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.standardowyToolStripMenuItem.Text = "Standardowy";
            this.standardowyToolStripMenuItem.Click += new System.EventHandler(this.standardowyToolStripMenuItem_Click);
            // 
            // ciemnyToolStripMenuItem
            // 
            this.ciemnyToolStripMenuItem.Name = "ciemnyToolStripMenuItem";
            this.ciemnyToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ciemnyToolStripMenuItem.Text = "Ciemny";
            this.ciemnyToolStripMenuItem.Click += new System.EventHandler(this.ciemnyToolStripMenuItem_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oProgramieToolStripMenuItem});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // oProgramieToolStripMenuItem
            // 
            this.oProgramieToolStripMenuItem.Name = "oProgramieToolStripMenuItem";
            this.oProgramieToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.oProgramieToolStripMenuItem.Text = "O Programie";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Chat_listBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(434, 234);
            this.panel2.TabIndex = 4;
            // 
            // Chat_listBox1
            // 
            this.Chat_listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chat_listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Chat_listBox1.FormattingEnabled = true;
            this.Chat_listBox1.Location = new System.Drawing.Point(10, 10);
            this.Chat_listBox1.Name = "Chat_listBox1";
            this.Chat_listBox1.Size = new System.Drawing.Size(414, 214);
            this.Chat_listBox1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(434, 361);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(210, 250);
            this.Name = "Form1";
            this.Text = "Komunikator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ClientSizeChanged += new System.EventHandler(this.Form1_ClientSizeChanged);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Connection_StripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel User_StripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel Space_toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polanczToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rozlanczToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ciemnyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgramieToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Send_button1;
        private System.Windows.Forms.TextBox Text_textBox1;
        private System.Windows.Forms.ListBox Chat_listBox1;
        private System.Windows.Forms.ToolStripMenuItem pseudonimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem schematyKolorówToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wybierzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaSieciToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}

