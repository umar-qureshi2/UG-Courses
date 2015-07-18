using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cache_mapping_sim
{
    public partial class Form1 : Form
    {
        OpenFileDialog file;
        Label[] ramLabels = new Label[20];
        char[] codes;
        Label[] blockLabels = new Label[5];
        int code_i;
        int time;
        #region constructor
        public Form1()
        {
            InitializeComponent();
            file = new OpenFileDialog();
            toolStripButton2.Enabled = false;
            code_i = 0;
            time = 1;
            skipper.Enabled = false;
            next_step.Enabled = false;
            ramLabels[0] = ram0;
            ramLabels[1] = ram1;
            ramLabels[2] = ram2;
            ramLabels[3] = ram3;
            ramLabels[4] = ram4;
            ramLabels[5] = ram5;
            ramLabels[6] = ram6;
            ramLabels[7] = ram7;
            ramLabels[8] = ram8;
            ramLabels[9] = ram9;
            ramLabels[10] = ram10;
            ramLabels[11] = ram11;
            ramLabels[12] = ram12;
            ramLabels[13] = ram13;
            ramLabels[14] = ram14;
            ramLabels[15] = ram15;
            ramLabels[16] = ram16;
            ramLabels[17] = ram17;
            ramLabels[18] = ram18;
            ramLabels[19] = ram19;
            blockLabels[0] = block1;
            blockLabels[1] = block2;
            blockLabels[2] = block3;
            blockLabels[3] = block4;
            blockLabels[4] = block5;
        }
        #endregion

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void focus_label(Label sam)
        {
            sam.BackColor = Color.Red;
            if (sam.Font.Size < 13)
            {
                Font temp = new Font(sam.Font.FontFamily, sam.Font.Size + 8);
                sam.Font = temp;
            }
            //else
            //{
            //    sam.BackColor = this.BackColor;
            //    if (sam.Font.Size > 13)
            //    {
            //        Font temp = new Font(sam.Font.FontFamily, sam.Font.Size - 8);
            //        sam.Font = temp;
            //    }
            //}
            Update();
            System.Threading.Thread.SpinWait(10000000);
        }

        void restore_label(Label sam)
        {
            sam.BackColor = this.BackColor;
            if (sam.Font.Size > 13)
            {
                Font temp = new Font(sam.Font.FontFamily, sam.Font.Size - 8);
                sam.Font = temp;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (current_algo!="-")
            {
                MessageBox.Show("Please Complete the current Simulation to Select New file");
                return;
            }
            DialogResult dr = file.ShowDialog();
            file.Filter = "text Files|*.txt";
            try
            {
                System.IO.StreamReader objReader;
                if (dr.ToString() != "OK") { return; }
                else if (file.FileName == "" || !file.FileName.EndsWith("txt"))
                {
                    MessageBox.Show("Please select a valid file", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripButton1_Click(sender, e);
                    return;
                }
                objReader = new System.IO.StreamReader(file.FileName);
                code.Text = objReader.ReadToEnd();
                objReader.Close();
                //codes = new char[code.Text.Length];
                codes = code.Text.ToCharArray();
                toolStripButton2.Enabled = true;
                skipper.Enabled = true;
                next_step.Enabled = true;
                help.Text = "Code for File is shown in Left Box below";
                current_algo = "-";
                cache_line0.Text = cache_line1.Text = cache_line2.Text = ""; code_i = 0; time = 1;
                att_line0.Text = att_line1.Text = att_line2.Text = "";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
                throw;
            }

        }

        void recolor(Label ee)
        {
            if (ee.BackColor != Color.Black)
                ee.BackColor = Color.Black;
            else
                ee.BackColor = Color.Red;
            Update();
            System.Threading.Thread.SpinWait(10000000);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (label1.BackColor == this.BackColor)
                focus_label(label1);
            else restore_label(label1);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (label3.BackColor == this.BackColor)
                focus_label(label3);
            else restore_label(label3);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (label2.BackColor == this.BackColor)
                focus_label(label2);
            else restore_label(label2);
        }

        void fifo(int i)
        {
            System.Threading.Thread.CurrentThread.Interrupt();
            //check for hits
            label42.Text = "Time of Entry";
            help.Text = "code found in RAM";
            help.Text = "Searching for Block in Cache";
            string Block = "Block" + (Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble((i + 1) / 4.00)))).ToString();
            if (cache_line0.Text == Block || cache_line1.Text == Block || cache_line2.Text == Block)
            {
                help.Text = "Block Found in Cache :-)";
                Label_adder_click(fifo_hits);
                Label_adder_click(fifo_hits);
                help.Text = "fifo hits incremented";
                return;
            }
            else//misses
            {
                help.Text = "Block not found in cache :-(";
                Label_adder_click(fifo_misses);
                Label_adder_click(fifo_misses);
                help.Text = "fifo misses incremented";
                help.Text = "Updating Cache for Fifo";
                if (cache_line0.Text == "")
                {
                    UpdateMe(Block, cache_line0);
                    UpdateMe(time.ToString(), att_line0);
                    UpdateMe(Block, cache_line0);
                    UpdateMe(time.ToString(), att_line0);
                }
                else if (cache_line1.Text == "")
                {
                    UpdateMe(Block, cache_line1);
                    UpdateMe(time.ToString(), att_line1);
                    UpdateMe(Block, cache_line1);
                    UpdateMe(time.ToString(), att_line1);
                }
                else if (cache_line2.Text == "")
                {
                    UpdateMe(Block, cache_line2);
                    UpdateMe(time.ToString(), att_line2);
                    UpdateMe(Block, cache_line2);
                    UpdateMe(time.ToString(), att_line2);
                }
                else
                {
                    help.Text = "Replacing in cache using FIFO";
                    Label_adder_click(fifo_replace); Label_adder_click(fifo_replace);
                    bool flag1 = int.Parse(att_line0.Text) < (int.Parse(att_line1.Text));
                    bool flag2 = int.Parse(att_line1.Text) < (int.Parse(att_line2.Text));
                    if (flag1 && flag2)
                    {
                        help.Text = "Replaced Line 0";
                        help.Text = cache_line0.Text + " Replaced with " + Block;
                        UpdateMe(Block, cache_line0);
                        UpdateMe(time.ToString(), att_line0);
                        UpdateMe(Block, cache_line0);
                        UpdateMe(time.ToString(), att_line0);

                    }
                    else if (!flag1 && flag2)
                    {
                        help.Text = "Replaced Line 1";
                        help.Text = cache_line1.Text + " Replaced with " + Block;
                        UpdateMe(Block, cache_line1);
                        UpdateMe(time.ToString(), att_line1);
                        UpdateMe(Block, cache_line1);
                        UpdateMe(time.ToString(), att_line1);

                    }
                    else
                    {
                        help.Text = "Replaced Line 2";
                        help.Text = cache_line2.Text + " Replaced with " + Block;
                        UpdateMe(Block, cache_line2);
                        UpdateMe(time.ToString(), att_line2);
                        UpdateMe(Block, cache_line2);
                        UpdateMe(time.ToString(), att_line2);
                    }

                }//replacements ends
            }//misses scope ends
            System.Threading.Thread.CurrentThread.Interrupt();
        }//fifo ends

        void lru(int i)
        {
            System.Threading.Thread.CurrentThread.Interrupt();
            //check for hits
            label42.Text = "Time of Usage";
            help.Text = "code found in RAM";
            help.Text = "Searching for Block in Cache";
            string Block = "Block" + (Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble((i + 1) / 4.00)))).ToString();
            if (cache_line0.Text == Block)
            {
                help.Text = "Block Found in Cache :-)";
                Label_adder_click(lru_hits);
                Label_adder_click(lru_hits);
                UpdateMe(time.ToString(), att_line0);
                UpdateMe(time.ToString(), att_line0);
                help.Text = "lru hits incremented";
                return;
            }
            else if (cache_line1.Text == Block)
            {
                help.Text = "Block Found in Cache :-)";
                Label_adder_click(lru_hits);
                Label_adder_click(lru_hits);
                UpdateMe(time.ToString(), att_line1); UpdateMe(time.ToString(), att_line1);

                help.Text = "lru hits incremented";
                return;
            }
            else if (cache_line2.Text == Block)
            {
                help.Text = "Block Found in Cache :-)";
                Label_adder_click(lru_hits);
                Label_adder_click(lru_hits);
                UpdateMe(time.ToString(), att_line2); UpdateMe(time.ToString(), att_line2);
                help.Text = "lru hits incremented";
                return;
            }
            else//misses
            {
                help.Text = "Block not found in cache :-(";
                Label_adder_click(lru_misses);
                Label_adder_click(lru_misses);
                help.Text = "lru misses incremented";
                help.Text = "Updating Cache for lru";
                if (cache_line0.Text == "")
                {
                    UpdateMe(Block, cache_line0);
                    UpdateMe(time.ToString(), att_line0);
                    UpdateMe(Block, cache_line0);
                    UpdateMe(time.ToString(), att_line0);
                }
                else if (cache_line1.Text == "")
                {
                    UpdateMe(Block, cache_line1);
                    UpdateMe(time.ToString(), att_line1);
                    UpdateMe(Block, cache_line1);
                    UpdateMe(time.ToString(), att_line1);
                }
                else if (cache_line2.Text == "")
                {
                    UpdateMe(Block, cache_line2);
                    UpdateMe(time.ToString(), att_line2);
                    UpdateMe(Block, cache_line2);
                    UpdateMe(time.ToString(), att_line2);
                }
                else
                {
                    help.Text = "Replacing in cache using lru";
                    Label_adder_click(lru_replace); Label_adder_click(lru_replace);
                    bool flag1 = int.Parse(att_line0.Text) < (int.Parse(att_line1.Text));
                    bool flag2 = int.Parse(att_line1.Text) < (int.Parse(att_line2.Text));
                    if (flag1 && flag2)
                    {
                        help.Text = "Replaced Line 0";
                        help.Text = cache_line0.Text + " Replaced with " + Block;
                        UpdateMe(Block, cache_line0);
                        UpdateMe(time.ToString(), att_line0);
                        UpdateMe(Block, cache_line0);
                        UpdateMe(time.ToString(), att_line0);

                    }
                    else if (!flag1 && flag2)
                    {
                        help.Text = "Replaced Line 1";
                        help.Text = cache_line1.Text + " Replaced with " + Block;
                        UpdateMe(Block, cache_line1);
                        UpdateMe(time.ToString(), att_line1);
                        UpdateMe(Block, cache_line1);
                        UpdateMe(time.ToString(), att_line1);

                    }
                    else
                    {
                        help.Text = "Replaced Line 2";
                        help.Text = cache_line2.Text + " Replaced with " + Block;
                        UpdateMe(Block, cache_line2);
                        UpdateMe(time.ToString(), att_line2);
                        UpdateMe(Block, cache_line2);
                        UpdateMe(time.ToString(), att_line2);
                    }

                }//replacements ends
            }//misses scope ends
            System.Threading.Thread.CurrentThread.Interrupt();
        }//lru ends

        void lfu(int i)
        {
            System.Threading.Thread.CurrentThread.Interrupt();
            //check for hits
            label42.Text = "Usage Frequency";
            help.Text = "code found in RAM";
            help.Text = "Searching for Block in Cache";
            string Block = "Block" + (Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble((i + 1) / 4.00)))).ToString();
            if (cache_line0.Text == Block)
            {
                help.Text = "Block Found in Cache :-)";
                Label_adder_click(lfu_hits);
                Label_adder_click(lfu_hits);
                UpdateMe((1 + Convert.ToInt32(att_line0.Text)).ToString(), att_line0);
                UpdateMe((1+Convert.ToInt32(att_line0.Text)).ToString(), att_line0);
                help.Text = "lfu hits incremented";
                return;
            }
            else if (cache_line1.Text == Block)
            {
                help.Text = "Block Found in Cache :-)";
                Label_adder_click(lfu_hits);
                Label_adder_click(lfu_hits);
                UpdateMe((1 + Convert.ToInt32(att_line1.Text)).ToString(), att_line1); UpdateMe((1+Convert.ToInt32(att_line1.Text)).ToString(), att_line1);

                help.Text = "lfu hits incremented";
                return;
            }
            else if (cache_line2.Text == Block)
            {
                help.Text = "Block Found in Cache :-)";
                Label_adder_click(lfu_hits);
                Label_adder_click(lfu_hits);
                UpdateMe((1 + Convert.ToInt32(att_line2.Text)).ToString(), att_line2); UpdateMe((1+Convert.ToInt32(att_line2.Text)).ToString(), att_line2);
                help.Text = "lfu hits incremented";
                return;
            }
            else//misses
            {
                help.Text = "Block not found in cache :-(";
                Label_adder_click(lfu_misses);
                Label_adder_click(lfu_misses);
                help.Text = "lfu misses incremented";
                help.Text = "Updating Cache for lfu";
                if (cache_line0.Text == "")
                {
                    UpdateMe(Block, cache_line0);
                    UpdateMe("1", att_line0);
                    UpdateMe(Block, cache_line0);
                    UpdateMe("1", att_line0);
                }
                else if (cache_line1.Text == "")
                {
                    UpdateMe(Block, cache_line1);
                    UpdateMe("1", att_line1);
                    UpdateMe(Block, cache_line1);
                    UpdateMe("1", att_line1);
                }
                else if (cache_line2.Text == "")
                {
                    UpdateMe(Block, cache_line2);
                    UpdateMe("1", att_line2);
                    UpdateMe(Block, cache_line2);
                    UpdateMe("1", att_line2);
                }
                else
                {
                    help.Text = "Replacing in cache using lfu";
                    Label_adder_click(lfu_replace); Label_adder_click(lfu_replace);
                    bool flag1 = int.Parse(att_line0.Text) < (int.Parse(att_line1.Text));
                    bool flag2 = int.Parse(att_line1.Text) < (int.Parse(att_line2.Text));
                    if (flag1 && flag2)
                    {
                        help.Text = "Replaced Line 0";
                        help.Text = cache_line0.Text + " Replaced with " + Block;
                        UpdateMe(Block, cache_line0);
                        UpdateMe("1", att_line0);
                        UpdateMe(Block, cache_line0);
                        UpdateMe("1", att_line0);

                    }
                    else if (!flag1 && flag2)
                    {
                        help.Text = "Replaced Line 1";
                        help.Text = cache_line1.Text + " Replaced with " + Block;
                        UpdateMe(Block, cache_line1);
                        UpdateMe("1", att_line1);
                        UpdateMe(Block, cache_line1);
                        UpdateMe("1", att_line1);

                    }
                    else
                    {
                        help.Text = "Replaced Line 2";
                        help.Text = cache_line2.Text + " Replaced with " + Block;
                        UpdateMe(Block, cache_line2);
                        UpdateMe("1", att_line2);
                        UpdateMe(Block, cache_line2);
                        UpdateMe("1", att_line2);
                    }

                }//replacements ends
            }//misses scope ends
            System.Threading.Thread.CurrentThread.Interrupt();
        }//lfu ends

        private void allAtOnceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr= MessageBox.Show("This will run all steps of FIFO, LRU and LFU one by one\nyou will not have choice to stop while processing","Information",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (dr.ToString() != "OK") return;
            this.Update();
            System.Threading.Thread.BeginCriticalRegion();
            System.Threading.Thread.BeginThreadAffinity();
            System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
            next_step.Enabled = skipper.Enabled = false;
            #region All At Once
            cache_line0.Text = cache_line1.Text = cache_line2.Text = "";
            att_line0.Text = att_line1.Text = att_line2.Text = "";
            code_i = 0; time = 1;
            focus_label(label1);
            for (; code_i < code.Text.Length; code_i++)//fifo
            {
                if ((Convert.ToChar(codes[code_i])) < 'A' || (Convert.ToChar(codes[code_i])) > 'T')
                {

                }
                else
                {
                    current_time.Text = "Current Time : " + time.ToString();
                    current_code.Text = "Current Code Char : " + Convert.ToChar(codes[code_i]);
                    int i = getRamID(Convert.ToChar(codes[code_i]));
                    recolor(ramLabels[i]);
                    int j = (Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble((i + 1) / 4.00))));
                    recolor(blockLabels[j - 1]);
                    fifo(i);
                    recolor(blockLabels[j - 1]);
                    recolor(ramLabels[i]);
                    time++;
                }
                System.Threading.Thread.CurrentThread.Interrupt();
            }
            restore_label(label1);

            cache_line0.Text = cache_line1.Text = cache_line2.Text = "";
            att_line0.Text = att_line1.Text = att_line2.Text = "";
            code_i = 0; time = 1;
            focus_label(label2);
            for (; code_i < code.Text.Length; code_i++)//LRU
            {
                if ((Convert.ToChar(codes[code_i])) < 'A' || (Convert.ToChar(codes[code_i])) > 'T')
                {

                }
                else
                {
                    current_time.Text = "Current Time : " + time.ToString();
                    current_code.Text = "Current Code Char : " + Convert.ToChar(codes[code_i]);
                    int i = getRamID(Convert.ToChar(codes[code_i]));
                    recolor(ramLabels[i]);
                    int j = (Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble((i + 1) / 4.00))));
                    recolor(blockLabels[j - 1]);
                    lru(i);
                    recolor(blockLabels[j - 1]);
                    recolor(ramLabels[i]);
                    time++;
                }
                System.Threading.Thread.CurrentThread.Interrupt();
            }
            restore_label(label2);

            cache_line0.Text = cache_line1.Text = cache_line2.Text = "";
            att_line0.Text = att_line1.Text = att_line2.Text = "0";
            code_i = 0; time = 1;
            focus_label(label3);
            for (; code_i < code.Text.Length; code_i++)//LFU
            {
                if ((Convert.ToChar(codes[code_i])) < 'A' || (Convert.ToChar(codes[code_i])) > 'T')
                {

                }
                else
                {
                    current_time.Text = "Current Time : " + time.ToString();
                    current_code.Text = "Current Code Char : " + Convert.ToChar(codes[code_i]);
                    int i = getRamID(Convert.ToChar(codes[code_i]));
                    recolor(ramLabels[i]);
                    int j = (Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble((i + 1) / 4.00))));
                    recolor(blockLabels[j - 1]);
                    lfu(i);
                    recolor(blockLabels[j - 1]);
                    recolor(ramLabels[i]);
                    time++;
                }
                System.Threading.Thread.CurrentThread.Interrupt();
            }
            restore_label(label3);


            #endregion
            System.Threading.Thread.EndCriticalRegion();
            System.Threading.Thread.EndThreadAffinity();
            current_algo = "-";
            //this.Enabled = true;
          
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog d1 = new OpenFileDialog();
            d1.Filter = "text|*.txt";
            DialogResult r = d1.ShowDialog();
            try
            {
                if (d1.FileName != "" && r.ToString() == "OK")
                {
                    System.IO.Stream s1 = d1.OpenFile();
                    foreach (var item in ramLabels)
                    {
                        char b = Convert.ToChar(s1.ReadByte());
                        if (b >= 'A' && b <= 'T')
                        {
                            item.Text = b.ToString();
                        }
                    }
                }
            }
            catch (OverflowException ov)
            {
                MessageBox.Show(ov.Message, "Error in file opening", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                throw;
            }
        }

        private int getRamID(char test)
        {
            for (int i = 0; i < 20; i++)
            {
                if (ramLabels[i].Text == test.ToString())
                    return i;
            }
            return -1;
        }

        private void Label_adder_click(Label y)
        {
            if (y.BackColor == this.BackColor)
            { y.Text = (int.Parse(y.Text) + 1).ToString(); focus_label(y); }
            else restore_label(y);
        }

        private void UpdateMe(string text, Label y)
        {
            if (y.BackColor != Color.Black)
            {
                y.BackColor = Color.Black;
                y.Text = text;
            }
            else
                y.BackColor = Color.Red;
            Update();
            System.Threading.Thread.SpinWait(10000000);
        }
        #region delete_me

        private void fifo_hits_Click(object sender, EventArgs e)
        {
            if (fifo_hits.BackColor == this.BackColor)
            { fifo_hits.Text = (int.Parse(fifo_hits.Text) + 1).ToString(); focus_label(fifo_hits); }
            else restore_label(fifo_hits);

        }
        private void lru_hits_Click(object sender, EventArgs e)
        {
            if (lru_hits.BackColor == this.BackColor)
            { lru_hits.Text = (int.Parse(lru_hits.Text) + 1).ToString(); focus_label(lru_hits); }
            else restore_label(lru_hits);
        }
        private void lfu_hits_Click(object sender, EventArgs e)
        {
            if (lfu_hits.BackColor == this.BackColor)
            { lfu_hits.Text = (int.Parse(lfu_hits.Text) + 1).ToString(); focus_label(lfu_hits); }
            else restore_label(lfu_hits);
        }

        private void fifo_misses_Click(object sender, EventArgs e)
        {
            if (fifo_misses.BackColor == this.BackColor)
            { fifo_misses.Text = (int.Parse(fifo_misses.Text) + 1).ToString(); focus_label(fifo_misses); }
            else restore_label(fifo_misses);
        }
        private void lru_misses_Click(object sender, EventArgs e)
        {
            if (lru_misses.BackColor == this.BackColor)
            { lru_misses.Text = (int.Parse(lru_misses.Text) + 1).ToString(); focus_label(lru_misses); }
            else restore_label(lru_misses);
        }
        private void lfu_misses_Click(object sender, EventArgs e)
        {
            if (lfu_misses.BackColor == this.BackColor)
            { lfu_misses.Text = (int.Parse(lfu_misses.Text) + 1).ToString(); focus_label(lfu_misses); }
            else restore_label(lfu_misses);
        }

        private void fifo_replace_Click(object sender, EventArgs e)
        {
            if (fifo_replace.BackColor == this.BackColor)
            { fifo_replace.Text = (int.Parse(fifo_replace.Text) + 1).ToString(); focus_label(fifo_replace); }
            else restore_label(fifo_replace);
        }
        private void lru_replace_Click(object sender, EventArgs e)
        {
            if (lru_replace.BackColor == this.BackColor)
            { lru_replace.Text = (int.Parse(lru_replace.Text) + 1).ToString(); focus_label(lru_replace); }
            else restore_label(lru_replace);
        }
        private void lfu_replace_Click(object sender, EventArgs e)
        {
            if (lfu_replace.BackColor == this.BackColor)
            { lfu_replace.Text = (int.Parse(lfu_replace.Text) + 1).ToString(); focus_label(lfu_replace); }
            else restore_label(lfu_replace);
        }
        #endregion

        string current_algo = "-";

        private void next_step_Click(object sender, EventArgs e)
        {
            if (current_algo == "-")
            {
                toolStripButton1.Enabled = toolStripButton2.Enabled=toolStripButton3.Enabled=false;
                current_algo = "fifo";
            }
            if (code_i >= code.Text.Length)
            {
                cache_line0.Text = cache_line1.Text = cache_line2.Text = ""; code_i = 0; time = 1;
                att_line0.Text = att_line1.Text = att_line2.Text = "";
                if (current_algo == "fifo")
                {
                    restore_label(label1);
                    current_algo = "lru";
                }
                else if (current_algo == "lru")
                {
                    restore_label(label2);
                    current_algo = "lfu";
                    att_line0.Text = att_line1.Text = att_line2.Text = "0";
                }
                else if (current_algo == "lfu")
                {
                    restore_label(label3);
                    DialogResult dr= MessageBox.Show("All replacement algorithms and steps have been simulated\ndo you want to start over","Successful Simulation of Algorithms",MessageBoxButtons.YesNo,MessageBoxIcon.Question );
                    if (dr.ToString()=="OK")
                    {
                        current_algo = "fifo";
                    }
                    else
                    {
                        current_algo = "-";
                        toolStripButton1.Enabled = true;
                        next_step.Enabled = false;
                        skipper.Enabled = false;
                    }
                }
            }
            if ((Convert.ToChar(codes[code_i])) < 'A' || (Convert.ToChar(codes[code_i])) > 'T')
            {
            }
            else
            {
                current_time.Text = "Current Time : " + time.ToString();
                current_code.Text = "Current Code Char : " + Convert.ToChar(codes[code_i]);
                int i = getRamID(Convert.ToChar(codes[code_i]));
                recolor(ramLabels[i]);
                int j = (Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble((i + 1) / 4.00))));
                recolor(blockLabels[j - 1]);
                if (current_algo == "fifo")
                {
                    focus_label(label1);
                    fifo(i);
                }
                else if (current_algo == "lru")
                {
                    focus_label(label2);
                    lru(i);
                }
                else if (current_algo == "lfu")
                {
                    focus_label(label3);
                    lfu(i);
                }
                recolor(blockLabels[j - 1]);
                recolor(ramLabels[i]);
                time++;
            }
            code_i++;
        }

        //private void prev_step_Click(object sender, EventArgs e)
        //{
        //    stack.Pop();
        //    Form1 sample = stack.Pop();

        //    file = sample.file;
        //    ramLabels = sample.ramLabels;
        //    codes = sample.codes;
        //    blockLabels = sample.blockLabels;
        //    code_i = sample.code_i;
        //    time = sample.time;
        //    toolStrip1 = sample.toolStrip1;
        //    toolStripDropDownButton1 = sample.toolStripDropDownButton1;
        //    helpToolStripMenuItem = sample.helpToolStripMenuItem;
        //    toolStripMenuItem1 = sample.toolStripMenuItem1;
        //    help = sample.help;
        //    groupBox1 = sample.groupBox1;
        //    toolStripSeparator1 = sample.toolStripSeparator1;
        //    code = sample.code;
        //    groupBox2 = sample.groupBox2;
        //    contextMenuStrip1 = sample.contextMenuStrip1;
        //    lfu_replace = sample.lfu_replace;
        //    lru_replace = sample.lru_replace;
        //    fifo_replace = sample.fifo_replace;
        //    lfu_misses = sample.lfu_misses;
        //    lru_misses = sample.lru_misses;
        //    fifo_misses = sample.fifo_misses;
        //    lfu_hits = sample.lfu_hits;
        //    lru_hits = sample.lru_hits;
        //    fifo_hits = sample.fifo_hits;
        //    groupBox3 = sample.groupBox3;
        //    ram0 = sample.ram0;
        //    ram15 = sample.ram15;
        //    ram14 = sample.ram14;
        //    ram13 = sample.ram13;
        //    ram12 = sample.ram12;
        //    ram11 = sample.ram11;
        //    ram10 = sample.ram10;
        //    ram9 = sample.ram9;
        //    ram8 = sample.ram8;
        //    ram7 = sample.ram7;
        //    ram6 = sample.ram6;
        //    ram5 = sample.ram5;
        //    ram4 = sample.ram4;
        //    ram3 = sample.ram3;
        //    ram2 = sample.ram2;
        //    ram1 = sample.ram1;
        //    ram19 = sample.ram19;
        //    ram18 = sample.ram18;
        //    ram17 = sample.ram17;
        //    ram16 = sample.ram16 ;
        //    label36 = sample.label36;
        //    groupBox4 = sample.groupBox4;
        //    cache_line2 = sample.cache_line2;
        //    cache_line1 = sample.cache_line1;
        //    cache_line0 = sample.cache_line0;
        //    label38 = sample.label38;
        //    att_line2 = sample.att_line2;
        //    att_line1 = sample.att_line1;
        //    att_line0 = sample.att_line0;
        //    label42 = sample.label42;
        //    toolStripButton2 = sample.toolStripButton2;
        //    allAtOnceToolStripMenuItem = sample.allAtOnceToolStripMenuItem;
        //    stepByStepToolStripMenuItem = sample.stepByStepToolStripMenuItem;
        //    toolStripButton3 = sample.toolStripButton3;
        //    next_step = sample.next_step;
        //    prev_step = sample.prev_step;
        //    restartApplicationToolStripMenuItem = sample.restartApplicationToolStripMenuItem;
        //    this.Update();
        //}

        private void restartApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void help_TextChanged(object sender, EventArgs e)
        {
            Update();
            //System.Threading.Thread.SpinWait(Convert.ToInt32(3e7));
        }

        private void current_code_TextChanged(object sender, EventArgs e)
        {
            if (code_i<code.Text.Length-1)
            {
                next_char.Text = "Next Code Char : " + codes[code_i + 1];
            }
            else
            {
                next_char.Text = "Next Code Char : --";
            }
        }

        private void current_code_Click(object sender, EventArgs e)
        {

        }

    }

}
