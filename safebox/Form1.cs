using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace safebox
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public string Devcontest(string arg)
        {
            if (!IsRunAsAdministrator())
            {
                Process process = new Process();
                process.StartInfo.FileName = "devcon.exe";
                process.StartInfo.Arguments = arg;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.Verb = "runas";

                try
                {
                    process.Start();
                }
                catch (Exception)
                {
                    return "admin error";
                }

                // Synchronously the standard output of the spawned process. 
                StreamReader reader = process.StandardOutput;
                string output = reader.ReadToEnd();

                // Write the redirected output to this application's window.
                // Console.WriteLine(output);
                process.WaitForExit();
                process.Close();

                //Console.WriteLine("\n\nPress any key to exit.");
                //Console.ReadLine();
                return output;
            }
            else
            {
                Process process = new Process();
                process.StartInfo.FileName = "devcon.exe";
                process.StartInfo.Arguments = arg;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.Verb = "runas";

                process.Start();

                // Synchronously read the standard output of the spawned process. 
                StreamReader reader = process.StandardOutput;
                string output = reader.ReadToEnd();

                // Write the redirected output to this application's window.
                // Console.WriteLine(output);
                process.WaitForExit();
                process.Close();

                //Console.WriteLine("\n\nPress any key to exit.");
                //Console.ReadLine();
                return output;
            }
        }

        private bool IsRunAsAdministrator()
        {
            var wi = System.Security.Principal.WindowsIdentity.GetCurrent();
            var wp = new System.Security.Principal.WindowsPrincipal(wi);

            return wp.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.metroToggle1.Checked == true)
            {
                string return_s = Devcontest("enable =image");
                notifyIcon1.ShowBalloonTip(2000, "WARNING", "Webcam can be used", ToolTipIcon.Warning);
            }
            else
            {
                string return_s = Devcontest("disable =image");
            }
        }

        private void metroToggle2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.metroToggle2.Checked == true)
            {
                string return_s = Devcontest("enable =audio");
                notifyIcon1.ShowBalloonTip(2000, "WARNING", "Audio can be used", ToolTipIcon.Warning);
            }
            else
            {
                string return_s = Devcontest("disable =audio");
            }
        }

        private void metroToggle3_CheckedChanged(object sender, EventArgs e)
        {
            Calnet calnett = new Calnet();
            Thread t1 = new Thread(() => calnett.CalnetProc(metroTextBox2, metroToggle3, notifyIcon1));

            if (this.metroToggle3.Checked == true)
            {
                t1.Start();
            }
            else
            {

            }
        }

        private void metroToggle4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle4.Checked == true)
            {
                Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR", "Start", 3, Microsoft.Win32.RegistryValueKind.DWord);
                notifyIcon1.ShowBalloonTip(2000, "WARNING", "USB Storage can be used", ToolTipIcon.Warning);
            }
            else
            {
                Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR", "Start", 4, Microsoft.Win32.RegistryValueKind.DWord);
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }        

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroToggle3.Checked = false;
            Application.Exit();
        }
    }
    
    public class Calnet
    {
        public void CalnetProc(MetroFramework.Controls.MetroTextBox abc, MetroFramework.Controls.MetroToggle tg, NotifyIcon nf)
        {
            PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("Network Interface");
            string[] instances = performanceCounterCategory.GetInstanceNames();

            List<PerformanceCounter> pcarr1 = new List<PerformanceCounter>();
            List<PerformanceCounter> pcarr2 = new List<PerformanceCounter>();

            foreach (string name in instances)
            {
                PerformanceCounter performanceCounterSent = new PerformanceCounter("Network Interface", "Bytes Sent/sec", name);
                PerformanceCounter performanceCounterReceived = new PerformanceCounter("Network Interface", "Bytes Received/sec", name);
                pcarr1.Add(performanceCounterSent);
                pcarr2.Add(performanceCounterReceived);
            }

            double sum_s = 0;
            double sum_r = 0;
            string return_s = "";
            int sum_s_i = 0;
            int sum_r_i = 0;

            while(true)
            {
                if (tg.Checked == false)
                {
                    abc.Text = "NETWORK DETECTION OFF";
                    Thread.CurrentThread.Interrupt();
                    Thread.CurrentThread.Abort();
                    break;
                }
                sum_s = 0;
                sum_r = 0;
                foreach (PerformanceCounter instance in pcarr1)
                {
                    sum_s += instance.NextValue();
                }
                foreach (PerformanceCounter instance in pcarr2)
                {
                    sum_r += instance.NextValue();
                }
                sum_s_i = (int)(sum_s / 1024);
                sum_r_i = (int)(sum_r / 1024);
                if (sum_s_i > 1024)
                    nf.ShowBalloonTip(2000, "WARNING", "Send data over 1MB", ToolTipIcon.Warning);
                return_s = "sent: " + (sum_s_i).ToString() + "KB \nreceived: " + (sum_r_i).ToString() + "KB";
                abc.Text = return_s;
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
