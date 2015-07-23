using System;
using System.Drawing;
using System.Windows.Forms;

namespace LineGame
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            label1.MouseClick += new MouseEventHandler(Close);
            label1.MouseEnter += new EventHandler(Onfocus);
            label1.MouseLeave+=new EventHandler(Onleave);
            lgn.Click += new EventHandler(login);
        }

        void login(object sender, EventArgs e)
        {
            if (name.Text != String.Empty)
            {
                Player.Name = name.Text;
                LanLobby arena = new LanLobby();
                arena.Show();
                Hide();
            }
            else
            { MessageBox.Show("Please Enter Your Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Ignore;
            }
        }

        void Onfocus(object sender, EventArgs e)
        {
            label1.BackColor = label2.ForeColor;
            label1.ForeColor = Color.Black;
          
        }

        void Onleave(object sender, EventArgs e)
        {
            label1.BackColor = Color.Black;
            label1.ForeColor = Color.Chocolate;
        }

        void Close(object sender, MouseEventArgs e)
        {
                Close();    
        }

         protected override void OnLoad(EventArgs e)
        {
            AcceptButton = lgn;
        }

       
    }
}
