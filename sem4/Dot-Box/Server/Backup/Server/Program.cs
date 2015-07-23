using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Linq;

class Server
{
private static List<client> clients = new List<client>();
private struct client
{
    public string name, ip;
}
private static IPAddress CalculateNetwork(UnicastIPAddressInformation addr)
{
    // The mask will be null in some scenarios, like a dhcp address 169.254.x.x
    if (addr.IPv4Mask == null)
        return null;

    var ip = addr.Address.GetAddressBytes();
    var mask = addr.IPv4Mask.GetAddressBytes();
    var result = new Byte[4];
    for (int i = 0; i < 4; ++i)
    {
        result[i] = (Byte)(ip[i] & mask[i]);
    }

    return new IPAddress(result);
}
    
    public static void Main()
    {
        TcpListener server=null;
        try
        {
            IPHostEntry iph = Dns.GetHostEntry(Dns.GetHostName());
            server = new TcpListener(iph.AddressList[1], 13000);
            server.Start();
           
            Console.WriteLine("Server Started at {0}",iph.AddressList[1]);
           
                while (true)
                {
                    TcpClient Client = server.AcceptTcpClient();
                    client cl = new client();
                    IPEndPoint IPend = (IPEndPoint)Client.Client.RemoteEndPoint;
                    cl.ip = IPend.Address.ToString();
                   
                    StreamReader sr = new StreamReader(Client.GetStream());
                    char[] data = new char[20];
                    sr.Read(data, 0, data.Length);
                    cl.name = new string(data);
                    cl.name=cl.name.Substring(0,cl.name.IndexOf('\0'));
                  
                  Console.WriteLine(cl.name+" "+cl.ip);

                  
                      StreamWriter sw = new StreamWriter(Client.GetStream());
                      sw.AutoFlush = true;
                      StringBuilder names = new StringBuilder();
                      StringBuilder ips = new StringBuilder();
                      foreach (client c in clients)
                      {
                          names.Append(c.name + "*");
                          ips.Append(c.ip + "*");
                      }

                      string write = names + "&" + ips;
                      if (clients.Count == 0)
                          write = "No One Available*&";
                      sw.Write(write.ToCharArray());
                      clients.Add(cl);
           }
        }

        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
            Console.Read();
        }
        finally
        {
           server.Stop();
        }


    }
}