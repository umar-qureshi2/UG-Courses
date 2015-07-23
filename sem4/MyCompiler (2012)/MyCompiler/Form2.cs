using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCompiler
{
    public partial class Form2 : Form
    {
        public Form2(string m)
        {
            InitializeComponent();
            string[] arr = m.Split(' ','\n','\t');
            
            //remove while space index to array.
            arr = arr.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            for (int i = 2; i < arr.Length; i++)
            {
                dataGridView1.Rows.Add(arr[i].Trim(), arr[++i].Trim());
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                dataGridView1.Font = fontDialog1.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                dataGridView1.ForeColor = colorDialog1.Color;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}