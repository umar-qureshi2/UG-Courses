using System;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Net.NetworkInformation;

namespace LineGame
{
    class Client : IDisposable
    {
        public static bool SearchComplete=false;
        /// <summary>
        /// Connects with the given ipaddress
        /// </summary>
        /// <param name="ip">IPaddress of the machine you want to connect</param>
        /// <returns>NetworkStream of the connected machine.</returns>
        public NetworkStream Connect(string ip)
        {
           try
           {
               TcpClient client = new TcpClient(ip, 9876);
               return client.GetStream();
           }
            catch(Exception ex)
           {
                MessageBox.Show("Player is Offline or Busy");
                return null;
           }
        }
        /// <summary>
        /// Is used Once Only to Retrieve list
        /// of available players.
        /// </summary>
        /// <param name="name">Name of the Player </param>
        /// <returns>List of names and ipadresses of available players </returns>
        public string Retrieve(string name)
        {
               
              try{
                  TcpClient client  = new TcpClient("192.168.1.1",13000);  
                       
          
                
                StreamWriter sw = new StreamWriter(client.GetStream());
                sw.AutoFlush = true;
                sw.Write(name);

                StreamReader sr = new StreamReader(client.GetStream());
                char[] data = new char[256];

                sr.Read(data, 0, data.Length);
                sw.Close();
                sr.Close();
                SearchComplete = true;
                return new string(data);
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return "*&";
            }
        }
        /// <summary>
        /// A general function use for reading data from the given stream.
        /// </summary>
        /// <param name="ns">Stream from which the data has to be read.</param>
        /// <returns>Data </returns>
        public string Read(NetworkStream ns)
        {
            try
            {
                StreamReader sr = new StreamReader(ns);
                char[] data = new char[256];
                sr.Read(data, 0, data.Length);
                return new string(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "\0";
            
            }
        }
        public string Read(NetworkStream ns,bool b)
        {
            try
            {
                StreamReader sr = new StreamReader(ns);
                char[] data = new char[256];
                sr.Read(data, 0, data.Length);
                return new string(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "\0";

            }
        }

    /// <summary>
    /// A general function use for writing data to the given stream.
    /// </summary>
    /// <param name="ns">Stream to which data has to be written</param>
    /// <param name="write">Data  </param>
        public void Write(NetworkStream ns,string write)
        {
            try
            {
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;
                sw.Write(write);
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private static IPAddress CalculateNetwork(UnicastIPAddressInformation addr)
        {
           
            if (addr.IPv4Mask == null)
                return null;

           Byte [] ip = addr.Address.GetAddressBytes();
            Byte[] mask = addr.IPv4Mask.GetAddressBytes();
            Byte[] result = new Byte[4];
            for (int i = 0; i < 4; ++i)
            {
                result[i] = (Byte)(ip[i] & mask[i]);
            }

            return new IPAddress(result);
        }


        #region IDisposable Members

        void IDisposable.Dispose()
        {
           //Dispose the null referenced object
            GC.Collect();
        }

        #endregion
    }
}
