using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LFR_Radio
{
    public partial class Settings : Form
    {
        string ThemeNow = Properties.Settings.Default.Theme;
        public Settings()
        {
            InitializeComponent();
        }
        Form1 MainForm = new Form1();

        public bool SetAutorunValue(bool autorun, string npath)
        {
            const string name = "Radio";
            string ExePath = npath;
            RegistryKey reg;

            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                    reg.SetValue(name, ExePath);
                else
                    reg.DeleteValue(name);
                reg.Flush();
                reg.Close();
            }
            catch
            {
                return false;
            }
            return true;

        }
        public void Parameter1()
        {
            if (Properties.Settings.Default.Autostart == false)
            {
                AutoStartCheckBox.Checked = false;
            }
            else if (Properties.Settings.Default.Autostart == true)
            {
                AutoStartCheckBox.Checked = true;
            }
        }
        public void Parameter2()
        {
            if (Properties.Settings.Default.AutoPlayRadio == false)
            {
                AutoRadioPlay.Checked = false;
            }
            else if (Properties.Settings.Default.AutoPlayRadio == true)
            {
                AutoRadioPlay.Checked = true;
            }
        }
        public void Parameter3()
        {
            if (Properties.Settings.Default.Theme == "Aqua")
            {
                comboBox1.Text = "Aqua";
            }
            else if (Properties.Settings.Default.Theme == "Orange")
            {
                comboBox1.Text = "Orange";
            }
            else if (Properties.Settings.Default.Theme == "Red")
            {
                comboBox1.Text = "Red";
            }
            else if (Properties.Settings.Default.Theme == "Lines")
            {
                comboBox1.Text = "Lines";
            }
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            Parameter1();
            Parameter2();
            Parameter3();
        }

        private void AutoStartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Autostart == false)
            {
                Properties.Settings.Default.Autostart = AutoStartCheckBox.Checked;
                SetAutorunValue(true , "Radio");
                Properties.Settings.Default.Save();
            }
            else if (Properties.Settings.Default.Autostart == true)
            {
                Properties.Settings.Default.Autostart = AutoStartCheckBox.Checked;
                SetAutorunValue(false,"Radio");
                Properties.Settings.Default.Save();
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MainForm.SetSkin();
                Properties.Settings.Default.Theme = "Orange";
                Properties.Settings.Default.Save();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                MainForm.SetSkin();
                Properties.Settings.Default.Theme = "Aqua";
                Properties.Settings.Default.Save();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                MainForm.SetSkin();
                Properties.Settings.Default.Theme = "Red";
                Properties.Settings.Default.Save();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                MainForm.SetSkin();
                Properties.Settings.Default.Theme = "Lines";
                Properties.Settings.Default.Save();
            }
        }
        private void Accept_Click(object sender, EventArgs e)
        {
            if (ThemeNow == Properties.Settings.Default.Theme)
            {
                Properties.Settings.Default.Save();
            }
            else if (ThemeNow != Properties.Settings.Default.Theme)
            {
                Properties.Settings.Default.Save();
                Application.Restart();
                //MessageBox.Show("Тема изменена успешно.Чтобы изменения вступили в силу\nперезапустите приложение", "Успешно");
                //MainForm.SetSkin();
            }
        }
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AutoRadioPlay_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AutoPlayRadio == true)
            {
                Properties.Settings.Default.AutoPlayRadio = AutoRadioPlay.Checked;
                Properties.Settings.Default.Save();
            }
            else if (Properties.Settings.Default.AutoPlayRadio == false)
            {
                Properties.Settings.Default.AutoPlayRadio = AutoRadioPlay.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/AkmSoft");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Otziv aa = new Otziv();
            aa.ShowDialog();
        }


    }
}
