using System;
using System.Threading;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;


namespace LineGame
{
    public partial class Game : Form
    {
        #region Declarations
        private int[] GridX, GridY;
        private Player player1;
        char[,] arr;
        string turn, waiting;
        Client client;
        NetworkStream Network_Stream;
        int row = 19;
        int col = 29;
        int[] lines;
        int xindx, yindx;
        #endregion
        
	public Game(NetworkStream ns, string op_name)
        {
            InitializeComponent();
            GridX = new int[15];
            GridY = new int[10];
            Network_Stream = ns;
            arr = new char[19, 29];
            lines = new int[29];
           
            player1 = new Player();
            client = new Client();
            player1.OpponentName = op_name;
            if (Player.IsServer)
            {
                turn = Player.Name;
                waiting = player1.OpponentName;
            }
            else
            {
                turn = player1.OpponentName;
                waiting = Player.Name;
            }

            Thread read = new Thread(() => Read_Stream());
            read.IsBackground = true;
            read.Start();




        }
        /// <summary>
        /// Reading Indicies from Stream
        /// When Opponent Player is at turn.
        /// </summary>
        private void Read_Stream()
        {
            using (Client c = new Client())
            {
                try
                {
                    while (true)
                    {
                        string data = c.Read(Network_Stream);
                        //lock the shared variables.
                        lock (this)
                        {
                            xindx = Convert.ToInt16(data.Substring(0, data.IndexOf('&')));
                            yindx = Convert.ToInt16(data.Substring(data.IndexOf('&') + 1));
                            //Drawing line without giving point.
                            DrawLine(new Point(0, 0));
                        }


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }
        bool check(Char t)
        {
            int count = 0;
            int chk = 0;
            for (int i = 0; i < row - 1; i = i + 2)
            {

                for (int j = 0; j < col; j++)
                    if (arr[i, j] == '1')
                    {
                        if (arr[i + 1, j - 1] == '1' && arr[i + 1, j + 1] == '1' && arr[i + 2, j] == '1' && arr[i + 1, j] == ' ')
                        {

                            arr[i + 1, j] = t;
                            chk = 1;
                            Graphics gf = CreateGraphics();
                            gf.DrawString(t.ToString(), new Font("Times New Roman", 12), Brushes.Black, new PointF(j * 25 + 95, i * 25 + 115));

                            count++;


                        }
                    }
            }
            if (chk == 1)
                return true;
            else return false;
        }




       private bool result()
        {
        int    c = player1.Score + player1.OpponentScore;
            if (c == 126)
            {
                if (player1.Score> player1.OpponentScore)

                    MessageBox.Show("Player " + Player.Name + " wins with Score " + player1.Score + " / " + player1.OpponentScore);

                else if (player1.Score < player1.OpponentScore)
                    MessageBox.Show("Player " + player1.OpponentName + " wins with Score " + player1.OpponentScore + " / " +player1.Score);
                else
                    MessageBox.Show("Match Draw");
                return false;
            }
            else

                return true;
        }



       private bool input(int r, int c, char[,] arr)
        {

            if ((c % 2 == 0 && r % 2 == 0) || arr[r, c] == 'o' || arr[r, c] == '|' || arr[r, c] == '-')
            {
                MessageBox.Show("wrong selection\n");
                return false;
            }
            else if (r % 2 == 0)
            {
                arr[r, c] = '1';

            }
            else
            {
                arr[r, c] = '1';

            }
            return true;

        }



        private void DrawLine(Point point)
        {
            Graphics gfx = CreateGraphics();
           //If its player turn calculate Indicies.
            if (turn == Player.Name)
            {
                xindx = 0; yindx = 0;


                if (((point.X % 50 <= 5 || point.X % 50 > 45) || (point.Y % 50 <= 5 || point.Y % 50 > 45)) && result())
                {
                    while (point.X > lines[xindx])
                        xindx++;
                    while (point.Y > lines[yindx])
                        yindx++;

                    int temp = xindx;
                    xindx = yindx;
                    yindx = temp;

                  



                    if (input(xindx, yindx, arr))
                    {
                        if (!check(turn[0]))
                        {
                            string tt = turn;
                            turn = waiting;
                            waiting = tt;

                        }


                       
                        if (yindx % 2 == 0)
                        {
                            gfx.DrawLine(new Pen(Brushes.Red, 5), new Point(Convert.ToInt16(Math.Ceiling((double)yindx / 2) * 50 + 100), Convert.ToInt16(Math.Ceiling((double)xindx / 2) * 50 + 50)), new Point(Convert.ToInt16(Math.Ceiling((double)yindx / 2) * 50 + 100), Convert.ToInt16(Math.Ceiling((double)xindx / 2) * 50 + 100)));


                        }
                        else
                        {
                            gfx.DrawLine(new Pen(Brushes.Red, 5), new Point(Convert.ToInt16(Math.Ceiling((double)yindx / 2) * 50 + 51), Convert.ToInt16(Math.Ceiling((double)xindx / 2) * 50 + 100)), new Point(Convert.ToInt16(Math.Ceiling((double)yindx / 2) * 50 + 101), Convert.ToInt16(Math.Ceiling((double)xindx / 2) * 50 + 100)));


                        }
                        player1.Score++;
                    }
                }
                //Writing indicies to the opponent. 
                client.Write(Network_Stream, xindx + "&" + yindx);
            }
            else
            {

                if (input(xindx, yindx, arr))
                {
                    if (!check(turn[0]))
                    {
                        string tt = turn;
                        turn = waiting;
                        waiting = tt;

                    }


                
                    if (yindx % 2 == 0)
                    {
                        gfx.DrawLine(new Pen(Brushes.Red, 5), new Point(Convert.ToInt16(Math.Ceiling((double)yindx / 2) * 50 + 100), Convert.ToInt16(Math.Ceiling((double)xindx / 2) * 50 + 50)), new Point(Convert.ToInt16(Math.Ceiling((double)yindx / 2) * 50 + 100), Convert.ToInt16(Math.Ceiling((double)xindx / 2) * 50 + 100)));


                    }
                    else
                    {
                        gfx.DrawLine(new Pen(Brushes.Red, 5), new Point(Convert.ToInt16(Math.Ceiling((double)yindx / 2) * 50 + 51), Convert.ToInt16(Math.Ceiling((double)xindx / 2) * 50 + 100)), new Point(Convert.ToInt16(Math.Ceiling((double)yindx / 2) * 50 + 101), Convert.ToInt16(Math.Ceiling((double)xindx / 2) * 50 + 100)));


                    }
                    player1.OpponentScore++;
                   
                }


            }
            label11.Text = player1.Score.ToString();
            label13.Text = player1.OpponentScore.ToString();
            result();
            
        }


        protected override void OnLoad(EventArgs e)
        {
            label8.Text = Player.Name;
          
            player1.Score = player1.OpponentScore = 0;
            for (int i = 98, indx = 0; indx < 15; i += 50, indx++)
            { GridX[indx] = i; }
            for (int i = 98, indx = 0; indx < 10; i += 50, indx++)
            { GridY[indx] = i; }
            for (int i = 0; i < row; i++)
            {

                if (i % 2 == 0)
                {
                    for (int j = 0; j < col; j++)
                        if (j % 2 != 0 && i % 2 != 0)
                            arr[i, j] = ' ';
                        else if (j % 2 == 0)
                            arr[i, j] = '0';
                        else
                            arr[i, j] = '0';
                }
                else
                {
                    for (int j = 0; j < col; j++)
                        if (j % 2 != 0 && i % 2 != 0)
                            arr[i, j] = ' ';
                        else if (j % 2 == 0)
                            arr[i, j] = '0';
                        else
                            arr[i, j] = '0';
                }
            }


            for (int i = 0, val = 95; i < 29; i++)
            {

                if (i % 2 != 0)
                    val += 38;
                else
                    val += 12;
                lines[i] = val;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
                Graphics gfx = e.Graphics;
                int linex = 52, liney = 52;
                for (int i = 0; i < 10; i++)
                {
                    liney += 50;
                    gfx.DrawLine(new Pen(Brushes.Gray, 2), new Point(100, liney), new Point(800, liney));
                }
                for (int i = 0; i < 15; i++)
                {
                    linex += 50;
                    gfx.DrawLine(new Pen(Brushes.Gray, 2), new Point(linex, 100), new Point(linex, 550));
                }
                
            

            foreach (int k in GridX)
                foreach (int l in GridY)
                    e.Graphics.FillEllipse(Brushes.Blue, new Rectangle(k, l, 7, 7));
            

        }
       protected override void OnMouseClick(MouseEventArgs e)
        {
            if (turn == Player.Name)
                DrawLine(e.Location);
        }

       private void Game_Load(object sender, EventArgs e)
       {

       }

    }
}
