using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Threading;

namespace LineGame
{
    public partial class LanLobby : Form
    {
        List<string> ips;
        List<string> names;

        public LanLobby()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            label1.Location = new Point(Width / 2 - label1.Width / 2, 100);
            btn_list.Click += new EventHandler(btn_list_Click);
            names = new List<string>();
            ips = new List<string>();
            Player.State = PlayerState.Available;
       
        }

        void btn_list_Click(object sender, EventArgs e)
        {
            names.Clear();
            ips.Clear();
            using (Client client = new Client())
            {
                string RecievedData = client.Retrieve(Player.Name);
                string name = RecievedData.Substring(0, RecievedData.IndexOf('&'));
                string ip = RecievedData.Substring(RecievedData.IndexOf('&') + 1);
              

                for (int startindx = 0, length = name.IndexOf('*'), prv = length; startindx < name.Length; )
                {
                    names.Add(name.Substring(startindx, length));
                    startindx = prv + 1;
                    prv = name.IndexOf('*', startindx);
                    length = prv - startindx;

                }

                for (int startindx = 0, length = ip.IndexOf('*'), prv = length; prv != -1; )
                {
                    ips.Add(ip.Substring(startindx, length));
                    startindx = prv + 1;
                    prv = ip.IndexOf('*', startindx);
                    length = prv - startindx;

                }
                foreach (string s in names)
                    AvailablePlayers.Items.Add(s);
            }
          
            
        }


        private void back_Click(object sender, EventArgs e)
        {
            Main page = new Main();
            page.Show();
            Close();
        }

        private void strt_btn_Click(object sender, EventArgs e)
        {
            if (AvailablePlayers.SelectedIndex != -1)
            {
                using (Client client = new Client())
                {
                    NetworkStream ns = client.Connect(ips[AvailablePlayers.SelectedIndex]);
                    client.Write(ns, Player.Name);
                    string data = client.Read(ns);
                    data = data.Substring(0, data.IndexOf('\0'));
                    if (data == "&|&")
                    {
                        MessageBox.Show("Sorry this player is busy", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ns.Close();
                    }
                    else
                    {
                        Player.IsServer = false;
                        //Starting Game
                        Game game = new Game(ns, names[AvailablePlayers.SelectedIndex]);
                        game.Show();
                        Close();
                    }
                
                }
            
            
            }
            else
                MessageBox.Show("Please Select Any Player", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);    
            

        }
       
    }
}
