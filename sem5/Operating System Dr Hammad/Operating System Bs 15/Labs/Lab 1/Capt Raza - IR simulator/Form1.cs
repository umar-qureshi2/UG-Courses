using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Capt_Raza___IR_simulator
{
    public partial class Form1 : Form
    {
        int cycleCount;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cycleCount = 0;            
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            switch (cycleCount)
            {
                case 0: txtb_MAR.Text = txtb_PC.Text;
                    lbl_instr.Text = "Memory[MAR] -> MDR";
                    break;

                case 1: 
                    int Mem_loc = int.Parse(txtb_MAR.Text);                    
                    string Mem_contents = dataGridView1.Rows[Mem_loc].Cells[0].Value.ToString();
                    txtb_Add.Text = Mem_loc.ToString();
                    txtb_Contents.Text = Mem_contents;
                    txtb_MDR.Text = txtb_Contents.Text;
                    lbl_instr.Text = "PC++";
                    break;

                case 2:
                    int pc = int.Parse(txtb_PC.Text);
                    pc++;
                    txtb_PC.Text = pc.ToString();
                    lbl_instr.Text = "MDR -> IR";
                    break;

                case 3:
                    txtb_ICode.Text = txtb_MDR.Text[0].ToString() + txtb_MDR.Text[1].ToString();
                    txtb_IContent.Text = txtb_MDR.Text[2].ToString() + txtb_MDR.Text[3].ToString() + txtb_MDR.Text[4].ToString();
                    lbl_instr.Text = "Instruction Execution";
                    break;

                case 4:
                    lbl_instr.Text = "PC -> MAR";
                    switch (txtb_ICode.Text)
                    {
                        //Load from given address
                        case "00":
                            txtb_ACCUM.Text = txtb_IContent.Text;
                            break;

                        //Add 5
                        case "01":
                            txtb_ACCUM.Text = (int.Parse(txtb_ACCUM.Text) + 5).ToString();
                            break;

                        //Store to given address
                        case "10":
                            int loc = int.Parse(txtb_IContent.Text);
                            dataGridView1.Rows[loc].Cells[0].Value = txtb_ACCUM.Text;
                            break;

                        //set PC to 0
                        case "11":
                            txtb_PC.Text = "00";
                            break;                            
                    }
                    break;
            }
            cycleCount++;
            cycleCount = cycleCount % 5;
        }     
    }
}
