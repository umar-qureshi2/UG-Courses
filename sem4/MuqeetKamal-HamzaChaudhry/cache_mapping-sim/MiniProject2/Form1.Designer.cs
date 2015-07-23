namespace MiniProject2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.help = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.code = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label113 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.lfu_replace = new System.Windows.Forms.Label();
            this.lru_replace = new System.Windows.Forms.Label();
            this.fifo_replace = new System.Windows.Forms.Label();
            this.lfu_misses = new System.Windows.Forms.Label();
            this.lru_misses = new System.Windows.Forms.Label();
            this.fifo_misses = new System.Windows.Forms.Label();
            this.lfu_hits = new System.Windows.Forms.Label();
            this.lru_hits = new System.Windows.Forms.Label();
            this.fifo_hits = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.block5 = new System.Windows.Forms.Label();
            this.block4 = new System.Windows.Forms.Label();
            this.block3 = new System.Windows.Forms.Label();
            this.block2 = new System.Windows.Forms.Label();
            this.block1 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.ram19 = new System.Windows.Forms.Label();
            this.ram18 = new System.Windows.Forms.Label();
            this.ram17 = new System.Windows.Forms.Label();
            this.ram16 = new System.Windows.Forms.Label();
            this.ram15 = new System.Windows.Forms.Label();
            this.ram14 = new System.Windows.Forms.Label();
            this.ram13 = new System.Windows.Forms.Label();
            this.ram12 = new System.Windows.Forms.Label();
            this.ram11 = new System.Windows.Forms.Label();
            this.ram10 = new System.Windows.Forms.Label();
            this.ram9 = new System.Windows.Forms.Label();
            this.ram8 = new System.Windows.Forms.Label();
            this.ram7 = new System.Windows.Forms.Label();
            this.ram6 = new System.Windows.Forms.Label();
            this.ram5 = new System.Windows.Forms.Label();
            this.ram4 = new System.Windows.Forms.Label();
            this.ram3 = new System.Windows.Forms.Label();
            this.ram2 = new System.Windows.Forms.Label();
            this.ram1 = new System.Windows.Forms.Label();
            this.ram0 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.att_line2 = new System.Windows.Forms.Label();
            this.att_line1 = new System.Windows.Forms.Label();
            this.att_line0 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.cache_line2 = new System.Windows.Forms.Label();
            this.cache_line1 = new System.Windows.Forms.Label();
            this.cache_line0 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.next_step = new System.Windows.Forms.Button();
            this.current_time = new System.Windows.Forms.Button();
            this.current_code = new System.Windows.Forms.Button();
            this.skipper = new System.Windows.Forms.Button();
            this.next_char = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // help
            // 
            this.help.AutoSize = true;
            this.help.Location = new System.Drawing.Point(75, 41);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(324, 21);
            this.help.TabIndex = 2;
            this.help.Text = "Please Click \"New code file\" to select code file";
            this.help.TextChanged += new System.EventHandler(this.help_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.code);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(25, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 210);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Code";
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(7, 29);
            this.code.Multiline = true;
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.code.Size = new System.Drawing.Size(94, 165);
            this.code.TabIndex = 0;
            this.code.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label113);
            this.groupBox2.Controls.Add(this.label114);
            this.groupBox2.Controls.Add(this.label115);
            this.groupBox2.Controls.Add(this.lfu_replace);
            this.groupBox2.Controls.Add(this.lru_replace);
            this.groupBox2.Controls.Add(this.fifo_replace);
            this.groupBox2.Controls.Add(this.lfu_misses);
            this.groupBox2.Controls.Add(this.lru_misses);
            this.groupBox2.Controls.Add(this.fifo_misses);
            this.groupBox2.Controls.Add(this.lfu_hits);
            this.groupBox2.Controls.Add(this.lru_hits);
            this.groupBox2.Controls.Add(this.fifo_hits);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(427, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 165);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(273, 16);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(82, 21);
            this.label113.TabIndex = 21;
            this.label113.Text = "REPLACES";
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(182, 16);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(63, 21);
            this.label114.TabIndex = 20;
            this.label114.Text = "MISSES";
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(94, 16);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(42, 21);
            this.label115.TabIndex = 19;
            this.label115.Text = "HITS";
            // 
            // lfu_replace
            // 
            this.lfu_replace.AutoSize = true;
            this.lfu_replace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lfu_replace.Location = new System.Drawing.Point(299, 121);
            this.lfu_replace.Name = "lfu_replace";
            this.lfu_replace.Size = new System.Drawing.Size(19, 21);
            this.lfu_replace.TabIndex = 18;
            this.lfu_replace.Text = "0";
            this.lfu_replace.Click += new System.EventHandler(this.lfu_replace_Click);
            // 
            // lru_replace
            // 
            this.lru_replace.AutoSize = true;
            this.lru_replace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lru_replace.Location = new System.Drawing.Point(299, 83);
            this.lru_replace.Name = "lru_replace";
            this.lru_replace.Size = new System.Drawing.Size(19, 21);
            this.lru_replace.TabIndex = 17;
            this.lru_replace.Text = "0";
            this.lru_replace.Click += new System.EventHandler(this.lru_replace_Click);
            // 
            // fifo_replace
            // 
            this.fifo_replace.AutoSize = true;
            this.fifo_replace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fifo_replace.Location = new System.Drawing.Point(299, 43);
            this.fifo_replace.Name = "fifo_replace";
            this.fifo_replace.Size = new System.Drawing.Size(19, 21);
            this.fifo_replace.TabIndex = 16;
            this.fifo_replace.Text = "0";
            this.fifo_replace.Click += new System.EventHandler(this.fifo_replace_Click);
            // 
            // lfu_misses
            // 
            this.lfu_misses.AutoSize = true;
            this.lfu_misses.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lfu_misses.Location = new System.Drawing.Point(194, 121);
            this.lfu_misses.Name = "lfu_misses";
            this.lfu_misses.Size = new System.Drawing.Size(19, 21);
            this.lfu_misses.TabIndex = 15;
            this.lfu_misses.Text = "0";
            this.lfu_misses.Click += new System.EventHandler(this.lfu_misses_Click);
            // 
            // lru_misses
            // 
            this.lru_misses.AutoSize = true;
            this.lru_misses.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lru_misses.Location = new System.Drawing.Point(194, 83);
            this.lru_misses.Name = "lru_misses";
            this.lru_misses.Size = new System.Drawing.Size(19, 21);
            this.lru_misses.TabIndex = 14;
            this.lru_misses.Text = "0";
            this.lru_misses.Click += new System.EventHandler(this.lru_misses_Click);
            // 
            // fifo_misses
            // 
            this.fifo_misses.AutoSize = true;
            this.fifo_misses.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fifo_misses.Location = new System.Drawing.Point(194, 43);
            this.fifo_misses.Name = "fifo_misses";
            this.fifo_misses.Size = new System.Drawing.Size(19, 21);
            this.fifo_misses.TabIndex = 13;
            this.fifo_misses.Text = "0";
            this.fifo_misses.Click += new System.EventHandler(this.fifo_misses_Click);
            // 
            // lfu_hits
            // 
            this.lfu_hits.AutoSize = true;
            this.lfu_hits.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lfu_hits.Location = new System.Drawing.Point(106, 121);
            this.lfu_hits.Name = "lfu_hits";
            this.lfu_hits.Size = new System.Drawing.Size(19, 21);
            this.lfu_hits.TabIndex = 12;
            this.lfu_hits.Text = "0";
            this.lfu_hits.Click += new System.EventHandler(this.lfu_hits_Click);
            // 
            // lru_hits
            // 
            this.lru_hits.AutoSize = true;
            this.lru_hits.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lru_hits.Location = new System.Drawing.Point(106, 83);
            this.lru_hits.Name = "lru_hits";
            this.lru_hits.Size = new System.Drawing.Size(19, 21);
            this.lru_hits.TabIndex = 11;
            this.lru_hits.Text = "0";
            this.lru_hits.Click += new System.EventHandler(this.lru_hits_Click);
            // 
            // fifo_hits
            // 
            this.fifo_hits.AutoSize = true;
            this.fifo_hits.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fifo_hits.Location = new System.Drawing.Point(106, 47);
            this.fifo_hits.Name = "fifo_hits";
            this.fifo_hits.Size = new System.Drawing.Size(19, 21);
            this.fifo_hits.TabIndex = 10;
            this.fifo_hits.Text = "0";
            this.fifo_hits.Click += new System.EventHandler(this.fifo_hits_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Location = new System.Drawing.Point(19, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "LFU";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Location = new System.Drawing.Point(19, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "LRU";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(19, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "FIFO";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.block5);
            this.groupBox3.Controls.Add(this.block4);
            this.groupBox3.Controls.Add(this.block3);
            this.groupBox3.Controls.Add(this.block2);
            this.groupBox3.Controls.Add(this.block1);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.ram19);
            this.groupBox3.Controls.Add(this.ram18);
            this.groupBox3.Controls.Add(this.ram17);
            this.groupBox3.Controls.Add(this.ram16);
            this.groupBox3.Controls.Add(this.ram15);
            this.groupBox3.Controls.Add(this.ram14);
            this.groupBox3.Controls.Add(this.ram13);
            this.groupBox3.Controls.Add(this.ram12);
            this.groupBox3.Controls.Add(this.ram11);
            this.groupBox3.Controls.Add(this.ram10);
            this.groupBox3.Controls.Add(this.ram9);
            this.groupBox3.Controls.Add(this.ram8);
            this.groupBox3.Controls.Add(this.ram7);
            this.groupBox3.Controls.Add(this.ram6);
            this.groupBox3.Controls.Add(this.ram5);
            this.groupBox3.Controls.Add(this.ram4);
            this.groupBox3.Controls.Add(this.ram3);
            this.groupBox3.Controls.Add(this.ram2);
            this.groupBox3.Controls.Add(this.ram1);
            this.groupBox3.Controls.Add(this.ram0);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 438);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(824, 137);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RAM";
            // 
            // block5
            // 
            this.block5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.block5.Location = new System.Drawing.Point(649, 25);
            this.block5.Name = "block5";
            this.block5.Size = new System.Drawing.Size(128, 19);
            this.block5.TabIndex = 25;
            this.block5.Text = "Block5";
            this.block5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // block4
            // 
            this.block4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.block4.Location = new System.Drawing.Point(487, 25);
            this.block4.Name = "block4";
            this.block4.Size = new System.Drawing.Size(128, 19);
            this.block4.TabIndex = 24;
            this.block4.Text = "Block4";
            this.block4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // block3
            // 
            this.block3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.block3.Location = new System.Drawing.Point(329, 25);
            this.block3.Name = "block3";
            this.block3.Size = new System.Drawing.Size(128, 19);
            this.block3.TabIndex = 23;
            this.block3.Text = "Block3";
            this.block3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // block2
            // 
            this.block2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.block2.Location = new System.Drawing.Point(174, 25);
            this.block2.Name = "block2";
            this.block2.Size = new System.Drawing.Size(128, 19);
            this.block2.TabIndex = 22;
            this.block2.Text = "Block2";
            this.block2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // block1
            // 
            this.block1.BackColor = System.Drawing.Color.Black;
            this.block1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.block1.Location = new System.Drawing.Point(20, 25);
            this.block1.Name = "block1";
            this.block1.Size = new System.Drawing.Size(128, 19);
            this.block1.TabIndex = 21;
            this.block1.Text = "Block1";
            this.block1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Red;
            this.label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label36.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(8, 112);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(789, 17);
            this.label36.TabIndex = 20;
            this.label36.Text = "|123  |  124  |  125  |  126    |    127  |  128  |  129  |  130    |    131  |  " +
    "132  |  133  |  134    |    135  |  136  |  137  |  138    |    139  |  140  |  " +
    "141  |  142|";
            // 
            // ram19
            // 
            this.ram19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram19.Location = new System.Drawing.Point(758, 54);
            this.ram19.Name = "ram19";
            this.ram19.Size = new System.Drawing.Size(19, 44);
            this.ram19.TabIndex = 19;
            this.ram19.Text = "T";
            this.ram19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram18
            // 
            this.ram18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram18.Location = new System.Drawing.Point(723, 54);
            this.ram18.Name = "ram18";
            this.ram18.Size = new System.Drawing.Size(19, 44);
            this.ram18.TabIndex = 18;
            this.ram18.Text = "S";
            this.ram18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram17
            // 
            this.ram17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram17.Location = new System.Drawing.Point(688, 54);
            this.ram17.Name = "ram17";
            this.ram17.Size = new System.Drawing.Size(19, 44);
            this.ram17.TabIndex = 17;
            this.ram17.Text = "R";
            this.ram17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram16
            // 
            this.ram16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram16.Location = new System.Drawing.Point(653, 54);
            this.ram16.Name = "ram16";
            this.ram16.Size = new System.Drawing.Size(19, 44);
            this.ram16.TabIndex = 16;
            this.ram16.Text = "Q";
            this.ram16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram15
            // 
            this.ram15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram15.Location = new System.Drawing.Point(596, 54);
            this.ram15.Name = "ram15";
            this.ram15.Size = new System.Drawing.Size(19, 44);
            this.ram15.TabIndex = 15;
            this.ram15.Text = "P";
            this.ram15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram14
            // 
            this.ram14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram14.Location = new System.Drawing.Point(561, 54);
            this.ram14.Name = "ram14";
            this.ram14.Size = new System.Drawing.Size(19, 44);
            this.ram14.TabIndex = 14;
            this.ram14.Text = "O";
            this.ram14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram13
            // 
            this.ram13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram13.Location = new System.Drawing.Point(526, 54);
            this.ram13.Name = "ram13";
            this.ram13.Size = new System.Drawing.Size(19, 44);
            this.ram13.TabIndex = 13;
            this.ram13.Text = "N";
            this.ram13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram12
            // 
            this.ram12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram12.Location = new System.Drawing.Point(491, 54);
            this.ram12.Name = "ram12";
            this.ram12.Size = new System.Drawing.Size(19, 44);
            this.ram12.TabIndex = 12;
            this.ram12.Text = "M";
            this.ram12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram11
            // 
            this.ram11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram11.Location = new System.Drawing.Point(438, 54);
            this.ram11.Name = "ram11";
            this.ram11.Size = new System.Drawing.Size(19, 44);
            this.ram11.TabIndex = 11;
            this.ram11.Text = "L";
            this.ram11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram10
            // 
            this.ram10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram10.Location = new System.Drawing.Point(403, 54);
            this.ram10.Name = "ram10";
            this.ram10.Size = new System.Drawing.Size(19, 44);
            this.ram10.TabIndex = 10;
            this.ram10.Text = "K";
            this.ram10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram9
            // 
            this.ram9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram9.Location = new System.Drawing.Point(368, 54);
            this.ram9.Name = "ram9";
            this.ram9.Size = new System.Drawing.Size(19, 44);
            this.ram9.TabIndex = 9;
            this.ram9.Text = "J";
            this.ram9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram8
            // 
            this.ram8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram8.Location = new System.Drawing.Point(333, 54);
            this.ram8.Name = "ram8";
            this.ram8.Size = new System.Drawing.Size(19, 44);
            this.ram8.TabIndex = 8;
            this.ram8.Text = "I";
            this.ram8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram7
            // 
            this.ram7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram7.Location = new System.Drawing.Point(283, 54);
            this.ram7.Name = "ram7";
            this.ram7.Size = new System.Drawing.Size(19, 44);
            this.ram7.TabIndex = 7;
            this.ram7.Text = "H";
            this.ram7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram6
            // 
            this.ram6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram6.Location = new System.Drawing.Point(248, 54);
            this.ram6.Name = "ram6";
            this.ram6.Size = new System.Drawing.Size(19, 44);
            this.ram6.TabIndex = 6;
            this.ram6.Text = "G";
            this.ram6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram5
            // 
            this.ram5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram5.Location = new System.Drawing.Point(213, 54);
            this.ram5.Name = "ram5";
            this.ram5.Size = new System.Drawing.Size(19, 44);
            this.ram5.TabIndex = 5;
            this.ram5.Text = "F";
            this.ram5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram4
            // 
            this.ram4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram4.Location = new System.Drawing.Point(178, 54);
            this.ram4.Name = "ram4";
            this.ram4.Size = new System.Drawing.Size(19, 44);
            this.ram4.TabIndex = 4;
            this.ram4.Text = "E";
            this.ram4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram3
            // 
            this.ram3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram3.Location = new System.Drawing.Point(129, 54);
            this.ram3.Name = "ram3";
            this.ram3.Size = new System.Drawing.Size(19, 44);
            this.ram3.TabIndex = 3;
            this.ram3.Text = "D";
            this.ram3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram2
            // 
            this.ram2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram2.Location = new System.Drawing.Point(94, 54);
            this.ram2.Name = "ram2";
            this.ram2.Size = new System.Drawing.Size(19, 44);
            this.ram2.TabIndex = 2;
            this.ram2.Text = "C";
            this.ram2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram1
            // 
            this.ram1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram1.Location = new System.Drawing.Point(59, 54);
            this.ram1.Name = "ram1";
            this.ram1.Size = new System.Drawing.Size(19, 44);
            this.ram1.TabIndex = 1;
            this.ram1.Text = "B";
            this.ram1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ram0
            // 
            this.ram0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ram0.Location = new System.Drawing.Point(24, 54);
            this.ram0.Name = "ram0";
            this.ram0.Size = new System.Drawing.Size(19, 44);
            this.ram0.TabIndex = 0;
            this.ram0.Text = "A";
            this.ram0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.att_line2);
            this.groupBox4.Controls.Add(this.att_line1);
            this.groupBox4.Controls.Add(this.att_line0);
            this.groupBox4.Controls.Add(this.label42);
            this.groupBox4.Controls.Add(this.cache_line2);
            this.groupBox4.Controls.Add(this.cache_line1);
            this.groupBox4.Controls.Add(this.cache_line0);
            this.groupBox4.Controls.Add(this.label38);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(260, 230);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(477, 158);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cache";
            // 
            // att_line2
            // 
            this.att_line2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.att_line2.Location = new System.Drawing.Point(305, 105);
            this.att_line2.Name = "att_line2";
            this.att_line2.Size = new System.Drawing.Size(134, 23);
            this.att_line2.TabIndex = 11;
            this.att_line2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // att_line1
            // 
            this.att_line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.att_line1.Location = new System.Drawing.Point(305, 82);
            this.att_line1.Name = "att_line1";
            this.att_line1.Size = new System.Drawing.Size(134, 23);
            this.att_line1.TabIndex = 10;
            this.att_line1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // att_line0
            // 
            this.att_line0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.att_line0.Location = new System.Drawing.Point(305, 59);
            this.att_line0.Name = "att_line0";
            this.att_line0.Size = new System.Drawing.Size(134, 23);
            this.att_line0.TabIndex = 9;
            this.att_line0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label42
            // 
            this.label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label42.Location = new System.Drawing.Point(305, 36);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(134, 23);
            this.label42.TabIndex = 8;
            this.label42.Text = "Time of Entry";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cache_line2
            // 
            this.cache_line2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cache_line2.Location = new System.Drawing.Point(93, 105);
            this.cache_line2.Name = "cache_line2";
            this.cache_line2.Size = new System.Drawing.Size(212, 23);
            this.cache_line2.TabIndex = 7;
            this.cache_line2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cache_line1
            // 
            this.cache_line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cache_line1.Location = new System.Drawing.Point(93, 82);
            this.cache_line1.Name = "cache_line1";
            this.cache_line1.Size = new System.Drawing.Size(212, 23);
            this.cache_line1.TabIndex = 6;
            this.cache_line1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cache_line0
            // 
            this.cache_line0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cache_line0.Location = new System.Drawing.Point(93, 59);
            this.cache_line0.Name = "cache_line0";
            this.cache_line0.Size = new System.Drawing.Size(212, 23);
            this.cache_line0.TabIndex = 5;
            this.cache_line0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label38
            // 
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label38.Location = new System.Drawing.Point(93, 36);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(212, 23);
            this.label38.TabIndex = 4;
            this.label38.Text = "Block Currently Present";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Location = new System.Drawing.Point(24, 105);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(69, 23);
            this.label24.TabIndex = 3;
            this.label24.Text = "2";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label23.Location = new System.Drawing.Point(24, 82);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(69, 23);
            this.label23.TabIndex = 2;
            this.label23.Text = "1";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Location = new System.Drawing.Point(24, 59);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 23);
            this.label22.TabIndex = 1;
            this.label22.Text = "0";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Location = new System.Drawing.Point(24, 36);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 23);
            this.label21.TabIndex = 0;
            this.label21.Text = "Line No.";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::MiniProject2.Properties.Resources.tumblr_lhv505PtkC1qgh8qto1_400;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(20, 88);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 118);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox1.Image = global::MiniProject2.Properties.Resources.callout;
            this.pictureBox1.Location = new System.Drawing.Point(68, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(339, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImage = global::MiniProject2.Properties.Resources.toolstrip;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(848, 31);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.Black;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 28);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem,
            this.restartApplicationToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuItem1.Text = "How to Use";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // restartApplicationToolStripMenuItem
            // 
            this.restartApplicationToolStripMenuItem.Name = "restartApplicationToolStripMenuItem";
            this.restartApplicationToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.restartApplicationToolStripMenuItem.Text = "Restart Application";
            this.restartApplicationToolStripMenuItem.Click += new System.EventHandler(this.restartApplicationToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ForeColor = System.Drawing.Color.Black;
            this.toolStripButton1.Image = global::MiniProject2.Properties.Resources.open;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(113, 28);
            this.toolStripButton1.Text = "New code File";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.ForeColor = System.Drawing.Color.Black;
            this.toolStripButton2.Image = global::MiniProject2.Properties.Resources.start;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(122, 28);
            this.toolStripButton2.Text = "Start Simulation";
            this.toolStripButton2.Click += new System.EventHandler(this.allAtOnceToolStripMenuItem_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.ForeColor = System.Drawing.Color.Black;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(146, 28);
            this.toolStripButton3.Text = "New Content For RAM";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // next_step
            // 
            this.next_step.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(230)))), ((int)(((byte)(23)))));
            this.next_step.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next_step.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(225)))), ((int)(((byte)(15)))));
            this.next_step.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.next_step.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next_step.ForeColor = System.Drawing.Color.Black;
            this.next_step.Location = new System.Drawing.Point(353, 401);
            this.next_step.Name = "next_step";
            this.next_step.Size = new System.Drawing.Size(116, 31);
            this.next_step.TabIndex = 9;
            this.next_step.Text = "Next Step";
            this.next_step.UseVisualStyleBackColor = true;
            this.next_step.Click += new System.EventHandler(this.next_step_Click);
            // 
            // current_time
            // 
            this.current_time.BackColor = System.Drawing.Color.Red;
            this.current_time.Cursor = System.Windows.Forms.Cursors.Hand;
            this.current_time.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.current_time.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.current_time.ForeColor = System.Drawing.Color.White;
            this.current_time.Location = new System.Drawing.Point(151, 155);
            this.current_time.Name = "current_time";
            this.current_time.Size = new System.Drawing.Size(208, 31);
            this.current_time.TabIndex = 10;
            this.current_time.Text = "Current Time : ";
            this.current_time.UseVisualStyleBackColor = false;
            // 
            // current_code
            // 
            this.current_code.BackColor = System.Drawing.Color.Red;
            this.current_code.Cursor = System.Windows.Forms.Cursors.Hand;
            this.current_code.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.current_code.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.current_code.ForeColor = System.Drawing.Color.White;
            this.current_code.Location = new System.Drawing.Point(151, 124);
            this.current_code.Name = "current_code";
            this.current_code.Size = new System.Drawing.Size(208, 31);
            this.current_code.TabIndex = 11;
            this.current_code.Text = "Current Code Char : ";
            this.current_code.UseVisualStyleBackColor = false;
            this.current_code.TextChanged += new System.EventHandler(this.current_code_TextChanged);
            // 
            // skipper
            // 
            this.skipper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(230)))), ((int)(((byte)(23)))));
            this.skipper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.skipper.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.skipper.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(225)))), ((int)(((byte)(15)))));
            this.skipper.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.skipper.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skipper.ForeColor = System.Drawing.Color.Black;
            this.skipper.Location = new System.Drawing.Point(475, 401);
            this.skipper.Name = "skipper";
            this.skipper.Size = new System.Drawing.Size(216, 31);
            this.skipper.TabIndex = 12;
            this.skipper.Text = "Skip Current Algorithm";
            this.skipper.UseVisualStyleBackColor = true;
            this.skipper.Click += new System.EventHandler(this.skipper_Click);
            // 
            // next_char
            // 
            this.next_char.BackColor = System.Drawing.Color.Red;
            this.next_char.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next_char.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.next_char.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next_char.ForeColor = System.Drawing.Color.White;
            this.next_char.Location = new System.Drawing.Point(151, 186);
            this.next_char.Name = "next_char";
            this.next_char.Size = new System.Drawing.Size(208, 31);
            this.next_char.TabIndex = 13;
            this.next_char.Text = "Next Code Char : ";
            this.next_char.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(848, 587);
            this.Controls.Add(this.next_char);
            this.Controls.Add(this.skipper);
            this.Controls.Add(this.current_code);
            this.Controls.Add(this.current_time);
            this.Controls.Add(this.next_step);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.help);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Associative Mapping Simulator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label help;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.Label lfu_replace;
        private System.Windows.Forms.Label lru_replace;
        private System.Windows.Forms.Label fifo_replace;
        private System.Windows.Forms.Label lfu_misses;
        private System.Windows.Forms.Label lru_misses;
        private System.Windows.Forms.Label fifo_misses;
        private System.Windows.Forms.Label lfu_hits;
        private System.Windows.Forms.Label lru_hits;
        private System.Windows.Forms.Label fifo_hits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label ram0;
        private System.Windows.Forms.Label ram15;
        private System.Windows.Forms.Label ram14;
        private System.Windows.Forms.Label ram13;
        private System.Windows.Forms.Label ram12;
        private System.Windows.Forms.Label ram11;
        private System.Windows.Forms.Label ram10;
        private System.Windows.Forms.Label ram9;
        private System.Windows.Forms.Label ram8;
        private System.Windows.Forms.Label ram7;
        private System.Windows.Forms.Label ram6;
        private System.Windows.Forms.Label ram5;
        private System.Windows.Forms.Label ram4;
        private System.Windows.Forms.Label ram3;
        private System.Windows.Forms.Label ram2;
        private System.Windows.Forms.Label ram1;
        private System.Windows.Forms.Label ram19;
        private System.Windows.Forms.Label ram18;
        private System.Windows.Forms.Label ram17;
        private System.Windows.Forms.Label ram16;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label block1;
        private System.Windows.Forms.Label block5;
        private System.Windows.Forms.Label block4;
        private System.Windows.Forms.Label block3;
        private System.Windows.Forms.Label block2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label cache_line2;
        private System.Windows.Forms.Label cache_line1;
        private System.Windows.Forms.Label cache_line0;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label att_line2;
        private System.Windows.Forms.Label att_line1;
        private System.Windows.Forms.Label att_line0;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Button next_step;
        private System.Windows.Forms.ToolStripMenuItem restartApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Button current_time;
        private System.Windows.Forms.Button current_code;
        private System.Windows.Forms.Button skipper;
        private System.Windows.Forms.Button next_char;
    }
}

