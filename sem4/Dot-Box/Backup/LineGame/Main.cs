using System;
using System.Drawing;
using System.Windows.Forms;

namespace LineGame
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            label3.MouseEnter += new EventHandler(Onfocus);
            label3.MouseLeave += new EventHandler(Onleave);
            label4.MouseClick += new MouseEventHandler(Exit);
            label2.MouseClick += new MouseEventHandler(Multiplayer);
            
        }

        void Multiplayer(object sender, MouseEventArgs e)
        {
            Login lgn = new Login();
            DialogResult dr= lgn.ShowDialog();
            if (dr == DialogResult.OK)
               Hide();
       
           
        }

        void Exit(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        protected override void OnLoad(EventArgs e)
        {
            label1.Location = new Point(Width / 2 - label1.Width / 2,100);
            label2.Location = new Point(Width / 2 - label2.Width / 2,470);
            label3.Location = new Point(Width / 2 - label3.Width / 2,400);
            label4.Location = new Point(Width / 2 - label4.Width / 2, 540);
            Player.State = PlayerState.Available;
           
            
           
        }
        void Onleave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.Transparent;
            label.ForeColor = label1.ForeColor;
        }

        void Onfocus(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = label.ForeColor;
            label.ForeColor = Color.Transparent; 
        }
      

 

      

      
    }
}
