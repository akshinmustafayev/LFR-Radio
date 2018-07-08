using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace LFR_Radio
{
    public partial class Otziv : Form
    {
        public Otziv()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                SmtpClient client = new SmtpClient("smtp.mail.ru", 2525);
                client.Credentials = new System.Net.NetworkCredential(textBox1.Text, textBox2.Text);
                string msgFrom = textBox1.Text; // Указываем поле, от кого письмо 
                string msgTo = "nadoelo_1986@mail.ru"; // Указываем поле, кому письмо будет отправлено 
                string msgSubject = textBox3.Text; // Указываем тему пиьсма 
                string msgBody = String.Format("Сообщение {0}\n", ToString(), textBox4.Text);
                MailMessage msg = new MailMessage(msgFrom, msgTo, msgSubject, msgBody);
                try
                {
                    client.Send(msg);
                }
                catch { }
            }
        }
    }
}
