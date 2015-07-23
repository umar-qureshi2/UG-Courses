using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;

namespace sc_lab_5
{
    public partial class Form1 : Form
    {
        string text = null;
        public Form1()
        {
            InitializeComponent();
        }

        
        /*private void button2_Click(object sender, EventArgs e)
        {
            text= System.IO.File.ReadAllText(@"C:\Users\Ivan\Documents\Visual Studio 2012\Projects\sc mini project\sc lab 5\ivan.txt");
            richTextBox1.Text = text;
            //string[] token = text.Split(' ');
            //richTextBox1.Text += token;
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form2 obj = new Form2(richTextBox1.Text);
            obj.Show();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            text = null;
            richTextBox1.Text = null;
            text = System.IO.File.ReadAllText(@"C:\Users\Ivan\Desktop\ivan.txt");
            richTextBox1.Text = text;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            text = null;
            richTextBox1.Text = null;
            text = System.IO.File.ReadAllText(@"C:\Users\Ivan\Desktop\code 1.txt");
            richTextBox1.Text = text;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            text = null;
            richTextBox1.Text = null;
            text = System.IO.File.ReadAllText(@"C:\Users\Ivan\Desktop\code 2.txt");
            richTextBox1.Text = text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
             Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            text = File.ReadAllText(openFileDialog1.FileName);
                            richTextBox1.Text = text;
                                                    
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        
        }



    }
}
