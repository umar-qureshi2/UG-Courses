using System;
using System.Threading;
using System.Windows.Forms;

namespace LineGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            //Every Game will run its own server to listen for game request
            Thread server = new Thread(() => Server.Start());
            server.IsBackground = true;
            server.Start();
            server.IsBackground = true;
            Application.Run(new Main());
            
        }
    }
}
