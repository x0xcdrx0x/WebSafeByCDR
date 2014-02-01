//This App is created by CDR for personal/non-commercial use. The Application is GNU/GPL Based
//and is ABSOLUTELY FREE for using, sharing and modification!
//x0xCDRx0x and or CDR
//All rights reserved February 2014
using System;
using System.IO;
using System.Net;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.Win32;  //Only for DNS Disabling
using System.Resources;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.ServiceProcess;  //Services control and modification
using System.Collections.Generic;

namespace RemoveJewishScum
{
    public partial class Form1 : Form
    {
        Feedback sendFeedback = new Feedback();
        Installer InstForm = new Installer();
        public string windir = Environment.SystemDirectory;
        public string tempPath = System.IO.Path.GetTempPath();
        public string Desktop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //Update to recent version of the hosts file
                WebClient webClient = new WebClient();
                webClient.DownloadFile("http://cdrtest.hit.bg/SkyNet/hosts", tempPath + @"\hosts");
                StreamReader Reader = new StreamReader(tempPath + @"\hosts", System.Text.Encoding.UTF8);
                textBox1.Text = Reader.ReadToEnd();
                Reader.Close();

                //Check existing of the hosts file
                if (File.Exists(windir + @"\drivers\etc\hosts") == true)
                {
                    //Load Local Host file
                    StreamReader LocalReader = new StreamReader(windir + @"\drivers\etc\hosts");
                    textBox2.Text = LocalReader.ReadToEnd();
                    LocalReader.Close();
                }
                else if (File.Exists(windir + @"\drivers\etc\hosts") == false)
                {
                    label2.Visible = false;
                    label3.Visible = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("No Network Connection or Other Problem was Found on Your System", "ERROR Message!", MessageBoxButtons.OK);
                this.Close();
            }

            //---------------------------------------Automatic-DNSCache-Disabler---------------------------------------//
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Dnscache", true);
                key.SetValue("Start", 4);
                ServiceController sc = new ServiceController("Dnscache");
                sc.Stop();
            }
            catch (System.Exception ex)
            {

            }
            //--------------------------------------Automatic-DNSCache-Disabler---------------------------------------//

            //Advanced Options Settings
            button5.Enabled = false;
            button6.Enabled = false;
            button10.Enabled = false;

            //Check the File if is Locked or Not
            System.IO.FileInfo fileInf = new System.IO.FileInfo(windir + @"\drivers\etc\hosts");
            if (fileInf.IsReadOnly == true)
            {
                checkBox4.Checked = true;
                button7.Visible = false;
                button7.Enabled = false;
                button8.Visible = true;
                button8.Enabled = true;
            }
            else if (fileInf.IsReadOnly == false)
            {
                checkBox4.Checked = false;
                button8.Visible = false;
                button8.Enabled = false;
                button7.Visible = true;
                button7.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Update to recent version of the hosts file
                WebClient webClient = new WebClient();
                webClient.DownloadFile("http://cdrtest.hit.bg/SkyNet/hosts", tempPath + @"\hosts");
                StreamReader Reader = new StreamReader(tempPath + @"\hosts", System.Text.Encoding.UTF8);
                textBox1.Text = Reader.ReadToEnd();
                Reader.Close();

                StreamWriter Writer = new StreamWriter(windir + @"\drivers\etc\hosts");
                Writer.Write(textBox1.Text);
                Writer.Close();
                //Re-Load the local hosts file
                cheker.Start();
                label2.Visible = true;
                label3.Visible = false;

                MessageBox.Show("Patching Done!", "Success..", MessageBoxButtons.OK);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("The Hosts File is Locked, Please Unlock it in Advanced Options tab", "Locked Hosts File..", MessageBoxButtons.OK);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = false;
            textBox2.ReadOnly = false;
            button2.Enabled = true;
            button3.Enabled = true;

            if (checkBox2.Checked == false)
            {
                if (textBox2.Text == "")
                {
                    label2.Visible = false;
                    label3.Visible = true;
                }

                textBox2.ReadOnly = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter LocalWriter = new StreamWriter(windir + @"\drivers\etc\hosts");
                LocalWriter.Write(textBox2.Text);
                LocalWriter.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("The Hosts File is Locked, Please Unlock it in Advanced Options tab", "Locked Hosts File..", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string hosts = windir + @"\drivers\etc\hosts";
            Process.Start("notepad.exe", hosts);
        }

        private void cheker_Tick(object sender, EventArgs e)
        {
            //Load Local Host file
            StreamReader LocalReader = new StreamReader(windir + @"\drivers\etc\hosts");
            textBox2.Text = LocalReader.ReadToEnd();
            LocalReader.Close();
            cheker.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Update to recent version of the hosts file
            WebClient webClient = new WebClient();
            webClient.DownloadFile("http://cdrtest.hit.bg/SkyNet/hosts", tempPath + @"\hosts");
            textBox1.Text = "Please wait for a second..";
            StreamReader Reader = new StreamReader(tempPath + @"\hosts", System.Text.Encoding.UTF8);
            textBox1.Text = Reader.ReadToEnd();
            Reader.Close();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 1;i <= 100; i++)
            {
                progressBar1.Value = i;
                timer1.Stop();
            }

            if (progressBar1.Maximum == 100)
            {
                DialogResult dialog = MessageBox.Show("Now You Have the latest version of the Host file", "Check for Host File Updates", MessageBoxButtons.OK);
                progressBar1.Value = 0;
            }
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            sendFeedback.ShowDialog();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            File.Delete(tempPath + @"\Update.txt");

            //Extracting the current version of the Client
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string AppUpadteVer;
            string version = fileVersionInfo.ProductVersion;

            try
            {

                //Download the Client Update Ver. Log
                WebClient webClient = new WebClient();
                webClient.DownloadFile("http://cdrtest.hit.bg/SkyNet/ClientUpdates/CurrentVer.txt", tempPath + @"\Update.txt");

                //Read the Update Logs
                StreamReader UpdateReader = new StreamReader(tempPath + @"\Update.txt");
                AppUpadteVer = UpdateReader.ReadLine();
                UpdateReader.Close();

                //Compare the Both versions of the Client
                if (AppUpadteVer != version)
                {
                    webClient.DownloadFile("http://cdrtest.hit.bg/SkyNet/ClientUpdates/CurrentVer.exe", Desktop + @"\AntiNSASpy" + AppUpadteVer + ".exe");
                }
                else if (AppUpadteVer == version)
                {
                    DialogResult dialog = MessageBox.Show("No new updates available for now!", "Update Checker", MessageBoxButtons.OK);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Some Kind of Server Connection Problems, Please Try Again Later", "ERROR Message!", MessageBoxButtons.OK);
            }
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            //Extracting the current version of the Client
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            DialogResult dialog = MessageBox.Show("WebSafe by CDR Version: " + version + " Final", "About..", MessageBoxButtons.OKCancel);
        }

        //Advanced Options CheckBoxes and Patching
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button5.Enabled = true;

            if (checkBox1.Checked == false)
            {
                button5.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            button6.Enabled = true;

            if (checkBox3.Checked == false)
            {
                button6.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            button7.Enabled = true;
            button8.Enabled = true;

            if (checkBox4.Checked == false)
            {
                button7.Enabled = false;
                button8.Enabled = false;
            }
            else
            {
                button7.Enabled = true;
                button8.Enabled = true;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            button10.Enabled = true;

            if (checkBox5.Checked == false)
            {
                button10.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string HostConteiner = Properties.Resources.hosts;

                StreamWriter Writer = new StreamWriter(windir + @"\drivers\etc\hosts");
                Writer.Write(HostConteiner);
                Writer.Close();
                //Re-Load the local hosts file
                cheker.Start();
                //Re-Load Success Message
                MessageBox.Show("Patching with Stock Hosts File is Done!", "Success..", MessageBoxButtons.OK);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("The Hosts File is Locked, Please Unlock it in Advanced Options tab", "Locked Hosts File..", MessageBoxButtons.OK);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string AdobeConteiner = Properties.Resources.adobe;

                StreamWriter Writer = new StreamWriter(windir + @"\drivers\etc\hosts");
                Writer.Write(AdobeConteiner);
                Writer.Close();
                //Re-Load the local hosts file
                cheker.Start();
                //Re-Load Success Message
                MessageBox.Show("Patching with Adobe Hosts Block is Done!", "Success..", MessageBoxButtons.OK);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("The Hosts File is Locked, Please Unlock it in Advanced Options tab", "Locked Hosts File..", MessageBoxButtons.OK);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            File.SetAttributes(windir + @"\drivers\etc\hosts", FileAttributes.Archive | FileAttributes.Hidden | FileAttributes.ReadOnly);
            button7.Visible = false;
            button7.Enabled = false;
            button8.Visible = true;
            button8.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            File.SetAttributes(windir + @"\drivers\etc\hosts", FileAttributes.Normal);
            button7.Visible = true;
            button7.Enabled = true;
            button8.Visible = false;
            button8.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Process.Start("UserAccountControlSettings");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                //Update to recent version of the Anti-Fishing hosts file
                WebClient webClient = new WebClient();
                webClient.DownloadFile("http://www.hostsfile.org/Downloads/hosts.txt", tempPath + @"\AntiFishingHost");
                StreamReader Reader = new StreamReader(tempPath + @"\AntiFishingHost", System.Text.Encoding.UTF8);
                textBox1.Text = Reader.ReadToEnd();
                Reader.Close();

                //Re-Write Host File
                StreamWriter Writer = new StreamWriter(windir + @"\drivers\etc\hosts");
                Writer.Write(textBox1.Text);
                Writer.Close();

                //Re-Load the local hosts file
                cheker.Start();
                label2.Visible = true;
                label3.Visible = false;
                Updater.Start();

                MessageBox.Show("Patching Done!", "Success..", MessageBoxButtons.OK);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("The Hosts File is Locked, Please Unlock it in Advanced Options tab", "Locked Hosts File..", MessageBoxButtons.OK);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Create App Download Folder Patch
            string AntiPornPatch = tempPath + @"\AntiPornSoft";
            if (!Directory.Exists(AntiPornPatch))
                Directory.CreateDirectory(AntiPornPatch);

            //Download and Install ANTI-PORN Software (CRACKED)
            WebClient webClientSetup = new WebClient();
            WebClient webClientPatch = new WebClient();
            webClientSetup.DownloadFile("http://cdrtest.hit.bg/SkyNet/AntiPorn/antiporn_setup.exe", tempPath + @"\AntiPornSoft\setup.exe");
            webClientPatch.DownloadFile("http://cdrtest.hit.bg/SkyNet/AntiPorn/patch.exe", tempPath + @"\AntiPornSoft\patch.exe");
            MessageBox.Show("Downloading is Done!", "Success..", MessageBoxButtons.OK);
            InstForm.ShowDialog();
        }

        private void Updater_Tick_1(object sender, EventArgs e)
        {
            //Update to recent version of the hosts file
            WebClient webClient = new WebClient();
            webClient.DownloadFile("http://cdrtest.hit.bg/SkyNet/hosts", tempPath + @"\hosts");
            StreamReader Reader = new StreamReader(tempPath + @"\hosts", System.Text.Encoding.UTF8);
            textBox1.Text = Reader.ReadToEnd();
            Reader.Close();

            //Stop Update Timer
            Updater.Stop();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Donate Donate = new Donate();
            Donate.ShowDialog();
        }
    }
}
