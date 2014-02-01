using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;

namespace RemoveJewishScum
{
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void Feedback_Load(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                button1.Enabled = false;
            }
            else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Extracting the current version of the Client
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;

            //Email Feedback System
            MailMessage objeto_mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.Port = 587; //Only for Gmail
            client.Host = "smtp.gmail.com";
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("User", "Password");
            objeto_mail.From = new MailAddress("feedbackurmail@gmail.com");
            objeto_mail.To.Add(new MailAddress("projectmail@mail.com"));
            objeto_mail.Subject = textBox1.Text + ", " + textBox2.Text;
            objeto_mail.Body = textBox3.Text + ".This is Send from Client Version " + version;
            client.Send(objeto_mail);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                button1.Enabled = false;
            }
            else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                button1.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                button1.Enabled = false;
            }
            else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                button1.Enabled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                button1.Enabled = false;
            }
            else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                button1.Enabled = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
