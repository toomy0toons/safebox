﻿using System;
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
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        public Form1()
        {
            //this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            //this.menuItem1 = new System.Windows.Forms.MenuItem();
            //// Initialize contextMenu1
            //this.contextMenu1.MenuItems.AddRange(
            //            new System.Windows.Forms.MenuItem[] { this.menuItem1 });

            //// Initialize menuItem1
            //this.menuItem1.Index = 0;
            //this.menuItem1.Text = "E&xit";
            //this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);

            //// Set up how the form should be displayed.
            //this.ClientSize = new System.Drawing.Size(292, 266);
            //this.Text = "Notify Icon Example";

            //// Create the NotifyIcon.
            //this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);

            //// The Icon property sets the icon that will appear
            //// in the systray for this application.
            //notifyIcon1.Icon = new Icon("appicon.ico");

            //// The ContextMenu property sets the menu that will
            //// appear when the systray icon is right clicked.
            //notifyIcon1.ContextMenu = this.contextMenu1;

            //// The Text property sets the text that will be displayed,
            //// in a tooltip, when the mouse hovers over the systray icon.
            //notifyIcon1.Text = "Form1 (NotifyIcon example)";
            //notifyIcon1.Visible = true;
            
            InitializeComponent();
        }
        private void menuItem1_Click(object Sender, EventArgs e)
        {
            // Close the form, which closes the application.
            this.Close();
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
                    process.StartInfo.CreateNoWindow = true;
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

        public string ParseExe(string filename, string arg)
        {
            Process process = new Process();
            process.StartInfo.FileName = filename;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = arg;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.Verb = "";

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

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        private void CheckCamera()
        {
            string parseString = ParseExe("handle.exe", @"-a USB#VID");

            string result;
            //extract substring

            if (parseString.Contains("No matching handles found."))
            {
                metroTextBox2.Text = "발견되지 않았습니다.";
            }
            else
            {
                if (!parseString.Contains(".exe"))
                {
                    metroTextBox2.Text = "발견되지 않았습니다.";
                }
                else
                {
                    int p1 = parseString.IndexOf(".exe");
                    int pFrom = parseString.LastIndexOf("}", p1) + 1;
                    int pEnd = parseString.IndexOf("type", pFrom);

                    //metroTextBox2.AppendText("pFrom = " + pFrom.ToString());
                    //metroTextBox2.AppendText("\npTo = " + pTo.ToString());

                    metroTextBox2.AppendText(parseString.Contains(".exe").ToString());

                    result = parseString.Substring(pFrom, pEnd - pFrom);


                    metroTextBox2.Text = "카메라 사용 감지\n" + result;
                    //metroTextBox2.Text = parseString;
                }
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
                notifyIcon1.ShowBalloonTip(2000, "SAFEBOX", "Webcam can't be used", ToolTipIcon.Warning);
                string return_s = Devcontest("disable =image");
            }
        }

        private void metroToggle2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.metroToggle2.Checked == true)
            {
                string return_s = Devcontest("enable =media");
                notifyIcon1.ShowBalloonTip(2000, "WARNING", "Audio can be used", ToolTipIcon.Warning);
            }
            else
            {
                string return_s = Devcontest("disable =media");
                notifyIcon1.ShowBalloonTip(2000, "SAFEBOX", "Audio can't be used", ToolTipIcon.Warning);

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
                notifyIcon1.ShowBalloonTip(2000, "SAFEBOX", "Network Detection OFF", ToolTipIcon.Warning);
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
                notifyIcon1.ShowBalloonTip(2000, "SAFEBOX", "USB Storage can't be used", ToolTipIcon.Warning);

            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            metroTextBox2.Text = "카메라를 사용하는 앱 검색중...";
            CheckCamera();
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
        }        

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroToggle3.Checked = false;
            this.WindowState = FormWindowState.Minimized;
            // Application.Exit();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroToggle3.Checked = false;
            this.Close();
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
