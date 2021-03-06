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
        public Form1()
        {   
            InitializeComponent();
        }
        private void menuItem1_Click(object Sender, EventArgs e)
        {
            // Close the form, which closes the application.
            this.Close();
        }

        /* devcon을 실행하는 함수*/
        public string Devcontest(string arg)
        {
            if (!IsRunAsAdministrator()) 
            {
                /* 관리자 권한 없을때 관리자 권한 실행 */
                Process process = new Process();

                /* cmd에서 devcon disable =(하드웨어 설명)은 장치 드라이버 off
                           devcon enable  =(하드웨어 설명)은 장치 드라이버 on */ 
                process.StartInfo.FileName = "devcon.exe";
                process.StartInfo.Arguments = arg;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.Verb = "runas";

                try
                {
                    process.StartInfo.CreateNoWindow = true; /* true일 때 관리자 권한으로 실행 */
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
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.Verb = "runas"; /* cmd 관리자 권한 실행 명렁어 */

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

            //extract substring

            if (parseString.Contains("No matching handles found."))
            {

                notifyIcon1.ShowBalloonTip(2000, "카메라를 사용중인 프로세스", "감지되지 않았습니다", ToolTipIcon.Info);
            }
            else
            {
                if (!parseString.Contains(".exe"))
                {
                    notifyIcon1.ShowBalloonTip(2000, "카메라를 사용중인 프로세스", "감지되지 않았습니다", ToolTipIcon.Info);
                }
                else
                {
                    string[] lines = parseString.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                    string duple = "";

                    System.Text.StringBuilder result = new System.Text.StringBuilder();
                    foreach (string line in lines){               
                        if (line.Contains("type: Key")){

                            int p2 = line.IndexOf("type");
                            string addLine = line.Substring(0, p2) + "\n";
                            if (duple == addLine)
                            {
                                continue;
                            }
                            result.Append(addLine);
                            duple = addLine;
                        }
                    }

                    notifyIcon1.ShowBalloonTip(1000, "카메라를 사용중인 프로세스", result.ToString(), ToolTipIcon.Warning);

                }
            }
            


        }


        /* 관리자 권한 부여 함수 */
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

        /* 웹캠 제어 함수*/
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

        /* 오디오/마이크 제어 함수*/
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

        /* 네트워크 전송량 체크 함수*/
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

        /* USB 제어 함수 */
        private void metroToggle4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle4.Checked == true)
            {
                //Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR", "Start", 3, Microsoft.Win32.RegistryValueKind.DWord);
                string a = Devcontest("enable =usb");
                notifyIcon1.ShowBalloonTip(2000, "WARNING", "USB Storage can be used", ToolTipIcon.Warning);
            }
            else
            {
                //Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR", "Start", 4, Microsoft.Win32.RegistryValueKind.DWord);
                string a = Devcontest("disable =usb");
                notifyIcon1.ShowBalloonTip(2000, "SAFEBOX", "USB Storage can't be used", ToolTipIcon.Warning);

            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            CheckCamera();
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        /* 프로그램 창 켜기 */
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
        }        

        /* 프로그램 창 최소화 */
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
