using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace wifi_lock_screen
{
    public partial class Lock : Form
    {
        long lock_time = 60;
        string unlock_mac = "90-67-1c-4c-55-42";
        string unlock_ip = "";

        [StructLayout(LayoutKind.Sequential)]
        public struct LASTINPUTINFO
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public uint dwTime;
        }
        [DllImport("user32.dll")]
        public static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        public Lock()
        {
            InitializeComponent();
        }

        public void GetUnlockMac()
        {
            StreamReader sr = new StreamReader("unlock_mac.txt", Encoding.Default);
            unlock_mac = sr.ReadLine();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            unlock_ip = GetMacIP(unlock_mac);
        }

        public long GetIdleTick()
        {
            LASTINPUTINFO vLastInputInfo = new LASTINPUTINFO();
            vLastInputInfo.cbSize = Marshal.SizeOf(vLastInputInfo);
            if (!GetLastInputInfo(ref vLastInputInfo)) return 0;
            return (Environment.TickCount - (long)vLastInputInfo.dwTime) / 1000;
        }

        public bool IPAvailable(string ip)
        {
            Ping ping = new Ping();
            try
            {
                PingReply pr = ping.Send(ip);
                if (pr == null)
                {
                    return false;
                }
                else return pr.Status == IPStatus.Success;
            }
            catch { return false; }

        }


        public string GetMacIP(string mac)
        {
            mac = mac.ToLower();
            string arp_list = CMD("arp -a");
            Match mc = Regex.Match(arp_list, @"\S*(?=\s*" + mac + ")");
            return mc.Value;
        }
        public string CMD(string str)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(str + "&exit");
            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
            return output;
        }


        private void idleCheck_Tick(object sender, EventArgs e)
        {

            if (GetIdleTick() >= lock_time)
            {
                if (IPAvailable(unlock_ip) == false)
                {
                    this.Show();
                }
            }
        }

        private void unlockCheck_Tick(object sender, EventArgs e)
        {
            if (this.Visible == false) return;
            unlock_ip = GetMacIP(unlock_mac);
            if (IPAvailable(unlock_ip))
            {
                this.Hide();
            }

        }

        private void keepTop_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //this.TopMost = true;
                this.Focus();
            }
        }

        private void btn_lock_MouseClick(object sender, MouseEventArgs e)
        {
            //Unlock Test
            if (e.Button == MouseButtons.Middle)
            {
                this.Hide();
            }
        }

        private void btn_lock_Click(object sender, EventArgs e)
        {

        }
    }
}
