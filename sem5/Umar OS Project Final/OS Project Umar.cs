using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            goodToGo = false;
        }

        FileOpening fileOpen;
        MLFeedbackQueues multiq;
        bool goodToGo;

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result =  openFileDialog1.ShowDialog();
            if (result.ToString()=="OK")
            {
                fileOpen = new FileOpening(openFileDialog1.FileName);
                goodToGo = true;
                Process[] ListBox = fileOpen.getProcessList();
                multiq = new MLFeedbackQueues(ListBox);
                foreach (Process item in ListBox)
                {
                    if (item==null)
                    {
                        break;
                    }
                    listBox1.Items.Add(item.name);
                    listBox2.Items.Add(item.arrival_time);
                    listBox3.Items.Add(item.burst);
                }

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!goodToGo || !int.TryParse(toolStripTextBox1.Text, out multiq.SleepTime))
            {
                MessageBox.Show("An Error in file opening or Animation Delay value");
                return;
            }
            
            label12.Hide(); textBox5.Hide();
            toolStripLabel1.Visible = false;
            toolStripTextBox1.Visible = false;
            textBox5.Text = toolStripTextBox1.Text;
            while (multiq.Simulate(textBox1,textBox2,textBox3,textBox4,label1,label11))
            {   
                Thread.Sleep(10);
            }
            label13.Visible = true; label13.Text = "Average waiting time = " + Process.getAvgWaiting(fileOpen.getProcessList()) + " ms"; MessageBox.Show("Average waiting time = " + Process.getAvgWaiting(fileOpen.getProcessList()) + " ms");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!goodToGo || !int.TryParse(toolStripTextBox1.Text, out multiq.SleepTime))
            {
                MessageBox.Show("An Error in file opening or Animation Delay value");
                return;
            }

            label12.Hide(); textBox5.Hide();
            toolStripLabel1.Visible = false;
            toolStripTextBox1.Visible = false;
            textBox5.Text = toolStripTextBox1.Text;

            if (multiq.Simulate(textBox1, textBox2, textBox3, textBox4, label1, label11))
            {
                Thread.Sleep(10);
            }
            else { label13.Visible = true; label13.Text = "Average waiting time = " + Process.getAvgWaiting(fileOpen.getProcessList()) + " ms"; MessageBox.Show("Average waiting time = " + Process.getAvgWaiting(fileOpen.getProcessList()) + " ms"); }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OS LAB PROJECT\nMulti Level Feedback Queue Simulation\n\nMade by:\nCapt Naveed Sharif\nNC Hafiz Abdul Manan\nNC Muhammad Umar Farooq Qureshi\n\nClick browse file and then Simulate\n\nSee Sample.txt file for sample input\nIt will output average waiting time in end","About US",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

    }
}
