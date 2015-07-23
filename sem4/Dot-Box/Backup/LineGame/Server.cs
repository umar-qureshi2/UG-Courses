using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace LineGame
{
    public class Server
    {
        public static void Start()
        {
            try
            {
                
                IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress[] addr = ipEntry.AddressList;
                
                //addr[1] will contain IPAdress of local machine
                TcpListener Server = new TcpListener(IPAddress.Parse("127.0.0.9"), 9876);
                Server.Start();
                TcpClient client = Server.AcceptTcpClient();

                if (Player.State == PlayerState.Available)
                {
                    DialogResult dr = MessageBox.Show("A new challenger\nDo you want to play", "Game Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {

                        using (Client Client = new Client())
                        {
                            //Read Opponent Name from Client.
                            string opname = Client.Read(client.GetStream());
                            opname = opname.Substring(0, opname.IndexOf('\0'));
                            //Writing Yes to the client.
                            Client.Write(client.GetStream(), "yes");
                            Player.IsServer = true;
                            //Starting Game
                            Application.Run(new Game(client.GetStream(), opname));
                            

                        }
                    }
                    else
                    {
                        using (Client Client = new Client())
                        {
                            //If Player doesnot accept the request.
                            Client.Write(client.GetStream(), "&|&");

                        }
                    }
                }
                else
                {
                    using (Client Client = new Client())
                    {   
                        //If Player is not available.
                        Client.Write(client.GetStream(), "&|&");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }


    }
}