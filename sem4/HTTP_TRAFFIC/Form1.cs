using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Microsoft.Win32;
using MyLicense;
using IWshRuntimeLibrary;

namespace System_App
{
    public partial class Form1 : Form
    {
        bool isAlt = false;
        bool isCtrl = false;

        void ghk_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyCode.ToString());
            if (e.KeyCode == Keys.Menu || e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu)
            {
                isAlt = true;
                return;
            }
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
            {
                isCtrl = true;
                return;
            }
            if (kkk.Count > 1)
            {
                if (kkk[kkk.Count - 1] != e.KeyCode)
                    kkk.Add(e.KeyCode);
            }
            else
            {
                kkk.Add(e.KeyCode);
            }
            if (kkk.Count == Akey.Length)
            {
                for (int i = 0; i < Akey.Length; i++)
                    shortCut += kkk[i].ToString();
            }

            if (shortCut.Contains(Akey))// && isAlt && isCtrl)
            {
                this.Visible = !this.Visible;
                this.Opacity = 100;
            }
            //this.Text = shortCut;
        }

        void ghk_KeyUp(object sender, KeyEventArgs e)
        {
            shortCut = "";
            kkk.Clear();
            if (e.KeyCode == Keys.Menu || e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu)
            {
                isAlt = false;
                return;
            }
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
            {
                isCtrl = false;
                return;
            }
        }

        StreamWriter sw;
        GlobalKeyboardHook ghk;
        List<Keys> kkk = new List<Keys>();
        Random rrr = new Random();

        string swName = "ZZZ18SepURLCat";
        string shortCut = "";        
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
        string filename = "Log.txt";
        string Akey = "CPG";
        string ipAdd = "ALL";

        string exeURL = "";
        string exeUser = "";
        string exePro = "";

        string[] arrURL;
        string[] arrUser;
        string[] arrPro;

        bool isDV = false;
        bool isCap = false;

        int maxURL = 100;
        int rnd = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*try
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true);                
                if (reg != null)
                    reg.SetValue("EnableLUA", "0");
            }
            catch { }*/

            //runAtStart();maxURL
            
            this.Opacity = 70;
            ghk = new GlobalKeyboardHook();
            ghk.KeyUp += new KeyEventHandler(ghk_KeyUp);
            ghk.KeyDown += new KeyEventHandler(ghk_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                ghk.HookedKeys.Add(key);
            ghk.hook();
            
            label2.Text = path;
            textBox1.Text = filename;
            textBox2.Text = Akey;
            textBox3.Text = maxURL.ToString();
            comboBox1.SelectedIndex = -1;
            checkBox1.Checked = isDV;
            
            Load_Interfaces();
            
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.Items.Insert(0, "ALL");
                if (Load_Registry())
                {
                    if (isCap)
                        run_Threads();
                }
                else
                {
                    this.Opacity = 100;
                }
            }
            else
            {
                MessageBox.Show("No Interfacess Found");
                this.Opacity = 100;
            }
            WorkingLicense w = new WorkingLicense(swName + "Lic", 2012, 9, 23);
            //w.run();
        }

        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int ctr = rnd;

                BackgroundWorker bgw = (BackgroundWorker)sender;

                Socket mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);

                //Bind the socket to the selected IP address
                mainSocket.Bind(new IPEndPoint(IPAddress.Parse((string)e.Argument), 0));

                //Set the socket  options
                mainSocket.SetSocketOption(SocketOptionLevel.IP,            //Applies only to IP packets
                                           SocketOptionName.HeaderIncluded, //Set the include the header
                                           true);                           //option to true

                byte[] byTrue = new byte[4] { 1, 0, 0, 0 };
                byte[] byOut = new byte[4] { 1, 0, 0, 0 }; //Capture outgoing packets

                //Socket.IOControl is analogous to the WSAIoctl method of Winsock 2
                mainSocket.IOControl(IOControlCode.ReceiveAll,            //Equivalent to SIO_RCVALL constant
                    //of Winsock 2
                                     byTrue,
                                     byOut);
                
                string lastHost = "rndomxyzabc";

                while (true)
                {
                    try
                    {
                        byte[] byteData = new byte[8192];
                        //Start receiving the packets asynchronously
                        int nReceived = 0;
                        try
                        {
                            nReceived = mainSocket.Receive(byteData, 0, byteData.Length, SocketFlags.None);
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show("Recv Err \n" + ex.Message);
                        }
                        IPHeader ipHeader = new IPHeader(byteData, nReceived);

                        //Now according to the protocol being carried by the IP datagram we parse 
                        //the data field of the datagram
                        if (ipHeader.ProtocolType == Protocol.TCP)
                        {
                            TCPHeader tcpHeader = new TCPHeader(ipHeader.Data,              //IPHeader.Data stores the data being 
                                //carried by the IP datagram
                            ipHeader.MessageLength);//Length of the data field                    
                            string httpPack = Encoding.ASCII.GetString(tcpHeader.Data);
                            string msg = httpPack.ToLower();
                            string host = "";
                            string url = "";
                            string ua = "";                    

                            if (msg.StartsWith("get") && msg.ToLower().Contains("host:"))
                            {
                                string[] hs = httpPack.Split(Environment.NewLine.ToCharArray());
                                string[] ms = msg.Split(Environment.NewLine.ToCharArray());

                                for (int i = 0; i < ms.Length; i++)
                                {
                                    if (ms[i].StartsWith("host:"))
                                    {
                                        host = hs[i].Substring(5);
                                        break;
                                    }
                                }
                                for (int i = 0; i < ms.Length; i++)
                                {
                                    if (ms[i].StartsWith("user-agent:"))
                                    {
                                        ua = getPro(hs[i].ToLower());
                                        break;
                                    }
                                }
                                if (isDV)
                                {
                                    for (int i = 0; i < ms.Length; i++)
                                    {
                                        if (ms[i].StartsWith("get"))
                                        {
                                            //MessageBox.Show(hs[i]);
                                            url = hs[i].Substring(4);
                                            url = url.Remove(url.LastIndexOf(" "));
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (msg.StartsWith("post") && msg.ToLower().Contains("host:"))
                            {
                                string[] hs = httpPack.Split(Environment.NewLine.ToCharArray());
                                string[] ms = msg.Split(Environment.NewLine.ToCharArray());

                                for (int i = 0; i < ms.Length; i++)
                                {
                                    if (ms[i].StartsWith("host:"))
                                    {
                                        host = hs[i].Substring(5);
                                        break;
                                    }
                                }
                                for (int i = 0; i < ms.Length; i++)
                                {
                                    if (ms[i].StartsWith("user-agent:"))
                                    {
                                        ua = getPro(hs[i].ToLower());
                                        break;
                                    }
                                }
                                if (isDV)
                                {
                                    for (int i = 0; i < ms.Length; i++)
                                    {
                                        if (ms[i].StartsWith("get"))
                                        {
                                            //MessageBox.Show(hs[i]);
                                            url = hs[i].Substring(4);
                                            url = url.Remove(url.LastIndexOf(" "));
                                            break;
                                        }
                                    }
                                }
                            }
                            if (!isDV)
                            {
                                if (host.Contains(lastHost))
                                    host = "";
                                else if (match(host, lastHost) > 50)
                                {
                                    //MessageBox.Show(host + "\n\n" + lastHost + "\n\n" + match(host, lastHost).ToString());
                                    host = "";
                                }
                            }

                            if (host != "")
                            {
                                if (rnd != ctr)
                                    break;
                                lock (sw)
                                {
                                    bool isNote = true;
                                    foreach (string s in arrURL)
                                    {
                                        if (s != "")
                                        {
                                            if (host.ToLower().Contains(s.ToLower().Trim()))
                                            {
                                                isNote = false;
                                                break;
                                            }
                                        }
                                    }
                                    foreach (string s in arrPro)
                                    {
                                        if (s != "")
                                        {
                                            if (ua.ToLower().Contains(s.ToLower().Trim()))
                                            {
                                                isNote = false;
                                                break;
                                            }
                                        }
                                    }
                                    foreach (string s in arrUser)
                                    {
                                        if (s != "")
                                        {
                                            if (Environment.UserName.ToLower().Contains(s.ToLower().Trim()))
                                            {
                                                isNote = false;
                                                break;
                                            }
                                        }
                                    }
                                    if (isNote)
                                    {
                                        lastHost = host;
                                        if (isDV)
                                        {
                                            string s = DateTime.Now.ToShortDateString() + ", " + DateTime.Now.ToShortTimeString() + ", " +
                                                url + ", " + ua + ", " + Environment.UserName;
                                            sw.WriteLine(s);
                                            bgw.ReportProgress(0, s);
                                        }
                                        else
                                        {
                                            string s = DateTime.Now.ToShortDateString() + ", " + DateTime.Now.ToShortTimeString() + ", " +
                                                host + ", " + ua + ", " + Environment.UserName;
                                            sw.WriteLine(s);
                                            bgw.ReportProgress(0, s);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception exe)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Interfac Error" + ex.Message);
            }
        }

        void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            listBox1.Items.Add(e.UserState);
            if (listBox1.Items.Count > maxURL)
            {
                listBox1.Items.RemoveAt(0);
                //this.Text = listBox1.Items.Count.ToString();
            }
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.Text = "comp" + DateTime.Now.ToShortTimeString();
        }

        private float match(string host, string lastHost)
        {
            string[] dmns = lastHost.Split('.');
            float i = 0;
            foreach (string s in dmns)
            {
                if (host.Contains("." + s))
                    i++;
            }
            i = i / dmns.Length * 100;

            return i;
        }

        private string getPro(string s)
        {
            if (s.Contains("chrome/") || s.Contains("chrome "))
                return "Chrome";
            else if (s.Contains("cometbird/") || s.Contains("cometbird "))
                return "CometBird";
            else if (s.Contains("opera/") || s.Contains("opera "))
                return "Opera";
            else if (s.Contains("msie/") || s.Contains("msie "))
                return "IE";
            else if (s.Contains("netscape/") || s.Contains("netscape "))
                return "Netscape";
            else if (s.Contains("safari/") || s.Contains("safair "))
                return "Safari";
            else if (s.Contains("firefox/") || s.Contains("firefox "))
                return "Firefox";
            return "Unknown";
        }

        public void Load_Interfaces()
        {            
            IPHostEntry HosyEntry = Dns.GetHostEntry((Dns.GetHostName()));
            if (HosyEntry.AddressList.Length > 0)
            {
                foreach (IPAddress ip in HosyEntry.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                        comboBox1.Items.Add(ip.ToString());
                }

                
            }            
        }

        public bool Load_Registry()
        {
            try
            {
                if (comboBox1.Items.Count == 0)
                {
                    MessageBox.Show("No Interfaces Found");
                    return false;
                }

                RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\" + swName, true);
                if (rk == null || rk.GetValue("path") == null)
                {
                    //MessageBox.Show("First Time Run, Set Configurations");
                    return false;
                }

                label2.Text = rk.GetValue("path").ToString();
                textBox1.Text = rk.GetValue("filename").ToString();
                textBox2.Text = rk.GetValue("akey").ToString();
                textBox3.Text = rk.GetValue("maxurl").ToString();
                if (!comboBox1.Items.Contains(rk.GetValue("interface").ToString()))
                    comboBox1.Items.Add(rk.GetValue("interface").ToString());
                comboBox1.SelectedItem = rk.GetValue("interface").ToString();
                if (rk.GetValue("dv").ToString() == "T")
                    checkBox1.Checked = true;
                else
                    checkBox1.Checked = false;
                textBox5.Text = rk.GetValue("exeurl").ToString();
                textBox6.Text = rk.GetValue("exepro").ToString();
                textBox7.Text = rk.GetValue("exeuser").ToString();
                if (rk.GetValue("iscap").ToString() == "T")
                {
                    isCap = true;
                    button3.Enabled = false;
                    button4.Enabled = true;
                }
                else
                {
                    isCap = false;
                    button3.Enabled = true;
                    button4.Enabled = false;
                }

                path = label2.Text;
                filename = textBox1.Text;
                Akey = textBox2.Text;
                maxURL = int.Parse(textBox3.Text);
                ipAdd = comboBox1.SelectedItem.ToString();
                isDV = checkBox1.Checked;

                exeURL = textBox5.Text.Replace(" ", "");
                exePro = textBox6.Text.Replace(" ", "");
                exeUser = textBox7.Text.Replace(" ", "");

                arrURL = exeURL.Split(',');
                arrPro = exePro.Split(',');
                arrUser = exeUser.Split(',');
            }
            catch (Exception ex)
            {
                MessageBox.Show("1" + ex.Message + "\n\n" + "Try Running App as Administrator or Set the Configurations Again");
                try
                { Registry.LocalMachine.OpenSubKey("SOFTWARE\\" + swName); }
                catch { }
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.Text = folderBrowserDialog1.SelectedPath + "\\";
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Write Log File Name");
                return;
            }
            if (!textBox1.Text.ToLower().EndsWith(".txt"))
                textBox1.Text += ".txt";

            if (textBox2.Text == "")
            {
                MessageBox.Show("Write Active Key");
                return;
            }
            int i;
            if (!int.TryParse(textBox3.Text, out i))
            {
                MessageBox.Show("Write Correct Maximum URL\n\nExqample: 100");
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select Some Interface");
                return;
            }

            try
            {                
                RegistryKey rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\" + swName);
                rk.OpenSubKey("SOFTWARE\\" + swName);
                rk.SetValue("path", label2.Text);
                rk.SetValue("filename", textBox1.Text);
                rk.SetValue("akey", textBox2.Text);
                rk.SetValue("maxurl", textBox3.Text);
                rk.SetValue("interface", comboBox1.SelectedItem.ToString());
                if (checkBox1.Checked)
                    rk.SetValue("dv", "T");
                else
                    rk.SetValue("dv", "F");
                
                rk.SetValue("exeurl", textBox5.Text);
                rk.SetValue("exepro", textBox6.Text);
                rk.SetValue("exeuser", textBox7.Text);
                rk.SetValue("iscap", "F");
                rk.Flush();
                rk.Close();

                path = label2.Text;
                filename = textBox1.Text;
                Akey = textBox2.Text;
                maxURL = int.Parse(textBox3.Text);
                ipAdd = comboBox1.SelectedItem.ToString();
                isDV = checkBox1.Checked;

                exeURL = textBox5.Text.Replace(" ", "");
                exePro = textBox6.Text.Replace(" ", "");
                exeUser = textBox7.Text.Replace(" ", "");

                arrURL = exeURL.Split(',');
                arrPro = exePro.Split(',');
                arrUser = exeUser.Split(',');

                MessageBox.Show("Settings Successfully Saved / Applied.\n\n Press CTRL + ALT + " + Akey + " in the desktop to display the application");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nSettings Not Applied\n\n" + "Try Running App as Administrator");
                label2.Text = path;
                textBox1.Text = filename;
                textBox2.Text = Akey;
                textBox3.Text = maxURL.ToString();
                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedItem = isDV;
                checkBox1.Checked = isDV;
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\" + swName);                
                if (rk == null || rk.GetValue("path") == null)
                {
                    MessageBox.Show("First Set Configurations\n\nThen Press Start Button");
                    return;
                }
                rk.Close();

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                
                isCap = true;

                RegistryKey rkk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\" + swName);                
                rkk.OpenSubKey("SOFTWARE\\" + swName);
                rkk.SetValue("iscap", "T");
                rkk.Flush();rkk.Close();

                if (sw != null)
                    sw.Close();

                sw = new StreamWriter(path + filename, true);
                run_Threads();

                button3.Enabled = false;
                button4.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Start Err\n\n" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                rnd = rrr.Next(0, 9999);

                isCap = false;

                RegistryKey rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\" + swName);
                rk.OpenSubKey("SOFTWARE\\" + swName);
                rk.SetValue("iscap", "F");
                rk.Flush(); rk.Close();

                if (sw != null)
                    sw.Close();

                button3.Enabled = true;
                button4.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stop Err\n\n" + ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.ToUpper();
            textBox2.Select(textBox2.Text.Length, 0);
        }

        private void run_Threads()
        {
            rnd = rrr.Next(0, 9999);
            listBox1.Items.Clear();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (sw != null)
            {
                lock (sw)
                {
                    sw.Close();
                    sw.Dispose();
                }
            }
            sw = new StreamWriter(path + filename, true);
            sw.AutoFlush = true;

            if (comboBox1.SelectedItem.ToString().ToLower().Contains("all"))
            {
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (!comboBox1.Items[i].ToString().ToLower().Contains("all"))
                    {
                        BackgroundWorker bgw = new BackgroundWorker();
                        bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
                        bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
                        bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
                        bgw.WorkerReportsProgress = true;
                        bgw.WorkerSupportsCancellation = true;

                        bgw.RunWorkerAsync(comboBox1.Items[i].ToString());
                    }

                }
            }
            else
            {
                BackgroundWorker bgw = new BackgroundWorker();
                bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
                bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
                bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
                bgw.WorkerReportsProgress = true;
                bgw.WorkerSupportsCancellation = true;
                bgw.RunWorkerAsync(comboBox1.SelectedItem.ToString());
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = false;
        }
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 30)
            {
                textBox4.Text = textBox4.Text.Substring(0, 30);
                textBox4.Select(textBox4.Text.Length, 0);
            }
        }

        private void runAtStart()
        {
            try
            {
                string AllUsers_Startup = Environment.ExpandEnvironmentVariables("%AllUsersProfile%") + "\\Start Menu\\Programs\\Startup\\";

                WshShellClass shell = new WshShellClass();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(AllUsers_Startup + "Win App.lnk");
                FileInfo fi = new FileInfo(Application.ExecutablePath);
                shortcut.TargetPath = fi.DirectoryName + "\\" + "Win App.exe";
                shortcut.Description = "Test";
                shortcut.Save();
                //MessageBox.Show(fi.DirectoryName + "\\" + "Win App.exe");
                return;
                //MessageBox.Show(System_AllUsers);            
                string linkName = "MyUrl";

                using (StreamWriter writer = new StreamWriter(AllUsers_Startup + "\\" + linkName + ".url"))
                {
                    string app = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    writer.WriteLine("[InternetShortcut]");
                    writer.WriteLine("URL=file:///" + app);
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
           // MessageBox.Show("LEARN");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }        
    }
}
