using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMPLib;
using System.Drawing.Drawing2D;
using System.IO;

namespace LFR_Radio
{
    public partial class Form1 : Form
    {
        Point currentPoint;
        Point finishPoint;

        private bool bDragStatus;
        private Point clickPoint;

        GraphicsPath border ;
        Region region;

        bool isPlaying = true;
        bool MuteBool = true;
       
        WindowsMediaPlayer wmp = new WindowsMediaPlayer();
        int i=100;

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            this.Region = region;
        }

        public Form1()
        {
            InitializeComponent();
                SetSkin();
                border = GetRoundedRectanglePath(this.Bounds, new SizeF(10, 10));
                region = new Region(border);
                RoundForm();

        }

        private GraphicsPath GetRoundedRectanglePath(RectangleF rect, SizeF roundSize)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(rect.Left + roundSize.Width / 100, rect.Top, rect.Right + roundSize.Width / 100, rect.Top);
            path.AddArc(rect.Right - roundSize.Width, rect.Top, roundSize.Width, roundSize.Height, 270, 90);
            path.AddLine(rect.Right, rect.Top + roundSize.Height / 100, rect.Right, rect.Bottom - roundSize.Height / 100);
            path.AddArc(rect.Right - roundSize.Width, rect.Bottom - roundSize.Height, roundSize.Width, roundSize.Height, 0, 90);
            path.AddLine(rect.Right - roundSize.Width / 100, rect.Bottom, rect.Left + roundSize.Width / 100, rect.Bottom);
            path.AddArc(rect.Left, rect.Bottom - roundSize.Height, roundSize.Width, roundSize.Height, 90, 90);
            path.AddLine(rect.Left, rect.Bottom - roundSize.Height / 100, rect.Left, rect.Top + roundSize.Height / 100);
            path.AddArc(rect.Left, rect.Top, roundSize.Width, roundSize.Height, 180, 90);
            path.CloseFigure();
            return path;
        }
        public void Play()
        {
            if (isPlaying == true)
            {
                try
                {
                    wmp.controls.stop();
                    MainButton.BackgroundImage = Properties.Resources.play;
                    isPlaying = false;
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    if (Properties.Settings.Default.Theme == "Orange")
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Orange/PlayingSmall_Playing.png");
                    }
                    else if (Properties.Settings.Default.Theme == "Aqua")
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Aqua/PlayingSmall_Playing.png");
                    }
                    else if (Properties.Settings.Default.Theme == "Red")
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Red/PlayingSmall_Playing.png");
                    }
                }
                catch
                {
                    MessageBox.Show("Возникла непредвиденная ошибка.Отсутсвует интернет подключение.\nПроверьте интернет подключение или перезапустите приложение", "Ошибка");
                }
            }
            else if (isPlaying == false)
            {
                try
                {
                    wmp.controls.play();
                    MainButton.BackgroundImage = Properties.Resources.pause;
                    isPlaying = true;
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    if (Properties.Settings.Default.Theme == "Orange")
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Orange/PlayingSmall_Pause.png");
                    }
                    else if (Properties.Settings.Default.Theme == "Aqua")
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Aqua/PlayingSmall_Pause.png");
                    }
                    else if (Properties.Settings.Default.Theme == "Red")
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Red/PlayingSmall_Pause.png");
                    }
                }
                catch
                {
                    MessageBox.Show("Возникла непредвиденная ошибка.Отсутсвует интернет подключение.\nПроверьте интернет подключение или перезапустите приложение", "Ошибка");
                }
            }
        }

        public void SetSkin()
        {
            String dir = @"Skins";
            if (Directory.Exists(dir))
            {
                if (Properties.Settings.Default.Theme == "Orange")
                {
                    DragBox.BackgroundImage = Image.FromFile(@"Skins/Orange/DragBox.png");
                    DragBox.BackgroundImageLayout = ImageLayout.Stretch;
                    RightBox.BackgroundImage = Image.FromFile(@"Skins/Orange/main.png");
                    RightBox.BackgroundImageLayout = ImageLayout.Stretch;
                    LeftBox.BackgroundImage = Image.FromFile(@"Skins/Orange/main.png");
                    LeftBox.BackgroundImageLayout = ImageLayout.Stretch;
                    DownBox.BackgroundImage = Image.FromFile(@"Skins/Orange/main.png");
                    DownBox.BackgroundImageLayout = ImageLayout.Stretch;
                    DownBox1.BackgroundImage = Image.FromFile(@"Skins/Orange/main.png");
                    DownBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    ExitBox.BackgroundImage = Image.FromFile(@"Skins/Orange/exit.png");
                    ExitBox.BackgroundImageLayout = ImageLayout.Stretch;
                    Minimize_Box.BackgroundImage = Image.FromFile(@"Skins/Orange/minimize.png");
                    Minimize_Box.BackgroundImageLayout = ImageLayout.Stretch;
                    MenuBox.BackgroundImage = Image.FromFile(@"Skins/Orange/menu.png");
                    MenuBox.BackgroundImageLayout = ImageLayout.Stretch;
                    HiddenMenuBox.BackgroundImageLayout = ImageLayout.Stretch;

                    //StationAdd.ForeColor = Color.Orange;
                    RadioListView.ForeColor = Color.Orange;


                    if (Properties.Settings.Default.Autostart == false)
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Orange/PlayingSmall_Playing.png");
                    }
                    else if (Properties.Settings.Default.Autostart == true)
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Orange/PlayingSmall_Pause.png");
                    }


                    Mute.BackgroundImage = Image.FromFile(@"Skins/Orange/MuteOff.png");
                    Mute.BackgroundImageLayout = ImageLayout.Stretch;

                    SoundLevelChanger.ElapsedInnerColor = Color.Orange;
                    SoundLevelChanger.ElapsedOuterColor = Color.Orange;
                    SoundLevelChanger.BarInnerColor = Color.Gray;
                    SoundLevelChanger.BarOuterColor = Color.Gray;
                    SoundLevelChanger.ThumbOuterColor = Color.Orange;
                    SoundLevelChanger.ThumbInnerColor = Color.Orange;
                    label1.ForeColor = Color.Orange;
                    label2.ForeColor = Color.Orange;
                    label3.ForeColor = Color.Orange;
                    label4.ForeColor = Color.Orange;
                }
                else if (Properties.Settings.Default.Theme == "Aqua")
                {
                    DragBox.BackgroundImage = Image.FromFile(@"Skins/Aqua/DragBox.png");
                    DragBox.BackgroundImageLayout = ImageLayout.Stretch;
                    RightBox.BackgroundImage = Image.FromFile(@"Skins/Aqua/main.png");
                    RightBox.BackgroundImageLayout = ImageLayout.Stretch;
                    LeftBox.BackgroundImage = Image.FromFile(@"Skins/Aqua/main.png");
                    LeftBox.BackgroundImageLayout = ImageLayout.Stretch;
                    DownBox.BackgroundImage = Image.FromFile(@"Skins/Aqua/main.png");
                    DownBox.BackgroundImageLayout = ImageLayout.Stretch;
                    DownBox1.BackgroundImage = Image.FromFile(@"Skins/Aqua/main.png");
                    DownBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    ExitBox.BackgroundImage = Image.FromFile(@"Skins/Aqua/exit.png");
                    ExitBox.BackgroundImageLayout = ImageLayout.Stretch;
                    Minimize_Box.BackgroundImage = Image.FromFile(@"Skins/Aqua/minimize.png");
                    Minimize_Box.BackgroundImageLayout = ImageLayout.Stretch;
                    MenuBox.BackgroundImage = Image.FromFile(@"Skins/Aqua/menu.png");
                    MenuBox.BackgroundImageLayout = ImageLayout.Stretch;
                    HiddenMenuBox.BackgroundImageLayout = ImageLayout.Stretch;
                    //StationAdd.ForeColor = Color.Orange;
                    RadioListView.ForeColor = Color.DarkTurquoise;


                    if (Properties.Settings.Default.Autostart == false)
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Aqua/PlayingSmall_Playing.png");
                    }
                    else if (Properties.Settings.Default.Autostart == true)
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Aqua/PlayingSmall_Pause.png");
                    }

                    Mute.BackgroundImage = Image.FromFile(@"Skins/Aqua/MuteOff.png");
                    Mute.BackgroundImageLayout = ImageLayout.Stretch;

                    SoundLevelChanger.ElapsedInnerColor = Color.DarkTurquoise;
                    SoundLevelChanger.ElapsedOuterColor = Color.DarkTurquoise;
                    SoundLevelChanger.BarInnerColor = Color.Gray;
                    SoundLevelChanger.BarOuterColor = Color.Gray;
                    SoundLevelChanger.ThumbOuterColor = Color.DarkTurquoise;
                    SoundLevelChanger.ThumbInnerColor = Color.DarkTurquoise;
                    label1.ForeColor = Color.DarkTurquoise;
                    label2.ForeColor = Color.DarkTurquoise;
                    label3.ForeColor = Color.DarkTurquoise;
                    label4.ForeColor = Color.DarkTurquoise;
                }
                else if (Properties.Settings.Default.Theme == "Red")
                {
                    DragBox.BackgroundImage = Image.FromFile(@"Skins/Red/DragBox.png");
                    DragBox.BackgroundImageLayout = ImageLayout.Stretch;
                    RightBox.BackgroundImage = Image.FromFile(@"Skins/Red/main.png");
                    RightBox.BackgroundImageLayout = ImageLayout.Stretch;
                    LeftBox.BackgroundImage = Image.FromFile(@"Skins/Red/main.png");
                    LeftBox.BackgroundImageLayout = ImageLayout.Stretch;
                    DownBox.BackgroundImage = Image.FromFile(@"Skins/Red/main.png");
                    DownBox.BackgroundImageLayout = ImageLayout.Stretch;
                    DownBox1.BackgroundImage = Image.FromFile(@"Skins/Red/main.png");
                    DownBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    ExitBox.BackgroundImage = Image.FromFile(@"Skins/Red/exit.png");
                    ExitBox.BackgroundImageLayout = ImageLayout.Stretch;
                    Minimize_Box.BackgroundImage = Image.FromFile(@"Skins/Red/minimize.png");
                    Minimize_Box.BackgroundImageLayout = ImageLayout.Stretch;
                    MenuBox.BackgroundImage = Image.FromFile(@"Skins/Red/menu.png");
                    MenuBox.BackgroundImageLayout = ImageLayout.Stretch;
                    HiddenMenuBox.BackgroundImageLayout = ImageLayout.Stretch;
                    //StationAdd.ForeColor = Color.Orange;
                    RadioListView.ForeColor = Color.Red;


                    if (Properties.Settings.Default.Autostart == false)
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Red/PlayingSmall_Playing.png");
                    }
                    else if (Properties.Settings.Default.Autostart == true)
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Red/PlayingSmall_Pause.png");
                    }

                    Mute.BackgroundImage = Image.FromFile(@"Skins/Red/MuteOff.png");
                    Mute.BackgroundImageLayout = ImageLayout.Stretch;


                    SoundLevelChanger.ElapsedInnerColor = Color.Red;
                    SoundLevelChanger.ElapsedOuterColor = Color.Red;
                    SoundLevelChanger.BarInnerColor = Color.Gray;
                    SoundLevelChanger.BarOuterColor = Color.Gray;
                    SoundLevelChanger.ThumbOuterColor = Color.Red;
                    SoundLevelChanger.ThumbInnerColor = Color.Red;
                    label1.ForeColor = Color.Red;
                    label2.ForeColor = Color.Red;
                    label3.ForeColor = Color.Red;
                    label4.ForeColor = Color.Red;
                }
                else if (Properties.Settings.Default.Theme == "Lines")
                {
                    DragBox.BackgroundImage = Image.FromFile(@"Skins/Lines/DragBox.png");
                    DragBox.BackgroundImageLayout = ImageLayout.Stretch;
                    RightBox.BackgroundImage = Image.FromFile(@"Skins/Lines/main.png");
                    RightBox.BackgroundImageLayout = ImageLayout.Stretch;
                    LeftBox.BackgroundImage = Image.FromFile(@"Skins/Lines/main.png");
                    LeftBox.BackgroundImageLayout = ImageLayout.Stretch;
                    DownBox.BackgroundImage = Image.FromFile(@"Skins/Lines/DownBox.png");
                    DownBox.BackgroundImageLayout = ImageLayout.Stretch;
                    DownBox1.BackgroundImage = Image.FromFile(@"Skins/Lines/main.png");
                    DownBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    ExitBox.BackgroundImage = Image.FromFile(@"Skins/Lines/exit.png");
                    ExitBox.BackgroundImageLayout = ImageLayout.Stretch;
                    Minimize_Box.BackgroundImage = Image.FromFile(@"Skins/Lines/minimize.png");
                    Minimize_Box.BackgroundImageLayout = ImageLayout.Stretch;
                    MenuBox.BackgroundImage = Image.FromFile(@"Skins/Lines/menu.png");
                    MenuBox.BackgroundImageLayout = ImageLayout.Stretch;
                    HiddenMenuBox.BackgroundImageLayout = ImageLayout.Stretch;

                    //StationAdd.ForeColor = Color.Orange;


                    if (Properties.Settings.Default.Autostart == false)
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Lines/PlayingSmall_Playing.png");
                    }
                    else if (Properties.Settings.Default.Autostart == true)
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Lines/PlayingSmall_Pause.png");
                    }


                    Mute.BackgroundImage = Image.FromFile(@"Skins/Lines/MuteOff.png");
                    Mute.BackgroundImageLayout = ImageLayout.Stretch;

                    SoundLevelChanger.ElapsedInnerColor = Color.DarkTurquoise;
                    SoundLevelChanger.ElapsedOuterColor = Color.DarkTurquoise;
                    SoundLevelChanger.BarInnerColor = Color.Gray;
                    SoundLevelChanger.BarOuterColor = Color.Gray;
                    SoundLevelChanger.ThumbOuterColor = Color.DarkTurquoise;
                    SoundLevelChanger.ThumbInnerColor = Color.DarkTurquoise;
                    label1.ForeColor = Color.BurlyWood;
                    label2.ForeColor = Color.OrangeRed;
                    label3.ForeColor = Color.Coral;
                    label4.ForeColor = Color.Red;
                    RadioListView.ForeColor = Color.Violet;
                }
            }
            else if (!Directory.Exists(dir))
            {
                MessageBox.Show("Отсутсвуют нужные файлы. Переустановите приложение", "Ошибка", MessageBoxButtons.OK);
                
                    Application.ExitThread();
                
            }
        }
        public void ApplicationExit()
        {
            wmp.close();
            Properties.Settings.Default.Save();
            Application.ExitThread();
        }
        public void AboutProgram()
        {
            MessageBox.Show("AKM-SOFT 2013 ", "О программе");
        }
        public void RoundForm()
        {
             
                 this.Size = new Size(292, 294);
                 if (Properties.Settings.Default.Theme == "Orange")
                 {
                     if (Properties.Settings.Default.HiddenMenu == true)
                     {
                         this.Size = new Size(292, 294);
                         HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Orange/HiddenMenuUp.png");
                     }
                     else if (Properties.Settings.Default.HiddenMenu == false)
                     {
                         this.Size = new Size(292, 152);
                         HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Orange/HiddenMenuDown.png");
                     }
                 }
                 else if (Properties.Settings.Default.Theme == "Aqua")
                 {
                     if (Properties.Settings.Default.HiddenMenu == true)
                     {
                         this.Size = new Size(292, 294);
                         HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Aqua/HiddenMenuUp.png");
                     }
                     else if (Properties.Settings.Default.HiddenMenu == false)
                     {
                         this.Size = new Size(292, 152);
                         HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Aqua/HiddenMenuDown.png");
                     }
                 }
                 else if (Properties.Settings.Default.Theme == "Red")
                 {
                     if (Properties.Settings.Default.HiddenMenu == true)
                     {
                         this.Size = new Size(292, 294);
                         HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Red/HiddenMenuUp.png");
                     }
                     else if (Properties.Settings.Default.HiddenMenu == false)
                     {
                         this.Size = new Size(292, 152);
                         HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Red/HiddenMenuDown.png");
                     }
                 }
                 else if (Properties.Settings.Default.Theme == "Lines")
                 {
                     if (Properties.Settings.Default.HiddenMenu == true)
                     {
                         this.Size = new Size(292, 294);
                         HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Lines/HiddenMenuUp.png");
                     }
                     else if (Properties.Settings.Default.HiddenMenu == false)
                     {
                         this.Size = new Size(292, 152);
                         HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Lines/HiddenMenuDown.png");
                     }
                 }
             
        }
        public void SelectRadio()
        {
            try
            {
                if (RadioListView.SelectedItems[0].Text == "EuropaPlus")
                {
                    wmp.URL = "http://cast.radiogroup.com.ua:8000/europaplus";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://cast.radiogroup.com.ua:8000/europaplus";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "Наше Радио")
                {
                    wmp.URL = "http://cast.radiogroup.com.ua:8000/nashe";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://cast.radiogroup.com.ua:8000/nashe";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "Premium")
                {
                    wmp.URL = "http://listen.rpfm.ru:9000/premium64";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://listen.rpfm.ru:9000/premium64";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "EuropaPlus2")
                {
                    wmp.URL = "http://onair.eltel.net:80/europaplus-128k";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://onair.eltel.net:80/europaplus-128k";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "RRadio")
                {
                    wmp.URL = "http://online.radiorecord.ru:8101/rr_128";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://online.radiorecord.ru:8101/rr_128";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "Kazantip")
                {
                    wmp.URL = "http://radio.kazantip-fm.ru:8000/mp3";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://radio.kazantip-fm.ru:8000/mp3";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "Kiss FM")
                {
                    wmp.URL = "http://stream.kissfm.ua:8000/kiss";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://stream.kissfm.ua:8000/kiss";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "Radio Record")
                {
                    wmp.URL = "http://online.radiorecord.ru:8102/club_128";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://online.radiorecord.ru:8102/club_128";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "Horizon FM")
                {
                    wmp.URL = "http://uk1.internet-radio.com:15614";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://uk1.internet-radio.com:15614/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "Best FM")
                {
                    wmp.URL = "http://radio.bestfm.fm:8080/bestfm64";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://radio.bestfm.fm:8080/bestfm64";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "Abc Christmas")
                {
                    wmp.URL = "http://uk3.internet-radio.com:10911/";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://uk3.internet-radio.com:10911/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "Amazing Smooth And Jazz")
                {
                    wmp.URL = "http://uk1.internet-radio.com:4086/";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://uk1.internet-radio.com:4086/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "PARTY VIBE RADIO")
                {
                    wmp.URL = "http://www.partyvibe.com:8008/";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://www.partyvibe.com:8008/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "North Pole Radio")
                {
                    wmp.URL = "http://ophanim.net:9790/";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://ophanim.net:9790/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "GrooveFM")
                {
                    wmp.URL = "http://stream.groovefm.de:10028/";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://stream.groovefm.de:10028/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "DubstepLive")
                {
                    wmp.URL = "http://173.236.56.82:8004/";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://173.236.56.82:8004/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "BlackBeats")
                {
                    wmp.URL = "http://stream2.blackbeats.fm/";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://stream2.blackbeats.fm/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "Radio Traditional Hip Hop")
                {
                    wmp.URL = "http://traditionalhiphop.zapto.org:7500/";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://traditionalhiphop.zapto.org:7500/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "WHAT! Radio")
                {
                    wmp.URL = "http://whatradio.neostreams.org:9119/";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://whatradio.neostreams.org:9119/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "Pinoy Rap Radio")
                {
                    wmp.URL = "http://s9.voscast.com:7200/";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://s9.voscast.com:7200/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "Heartbeatz.Fm")
                {
                    wmp.URL = "http://heartbeatz.fm:8008/";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://heartbeatz.fm:8008/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "181.FM - PARTY 181")
                {
                    wmp.URL = "http://uplink.duplexfx.com:8036/";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://uplink.duplexfx.com:8036/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "BVRadioUK")
                {
                    wmp.URL = "http://s5.voscast.com:7590/";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://s5.voscast.com:7590/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "Tay Bridges Radio")
                {
                    wmp.URL = "http://orange.citrus3.com:8294/";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://orange.citrus3.com:8294/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                else if (RadioListView.SelectedItems[0].Text == "RepFm")
                {
                    wmp.URL = "http://184.107.202.178:8022/";
                    wmp.controls.play();
                    Properties.Settings.Default.LastRadio = "http://184.107.202.178:8022/";
                    label1.Text = wmp.currentPlaylist.Item[0].name;
                    Properties.Settings.Default.Save();
                }
                
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NotifyIcon.ContextMenu = this.TrayMenu;
            wmp.URL = Properties.Settings.Default.LastRadio;
            wmp.settings.volume = Properties.Settings.Default.Volume;
            SoundLevelChanger.Value = Properties.Settings.Default.Volume;
            i = wmp.settings.volume;
            label3.Text = Convert.ToString(i) + "%";
            if (Properties.Settings.Default.AutoPlayRadio == false)
            {
                try
                {
                    wmp.controls.stop();
                    isPlaying = false;
                    MainButton.BackgroundImage = Properties.Resources.play;
                    if (Properties.Settings.Default.Theme == "Orange")
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Orange/PlayingSmall_Playing.png");
                    }
                    else if (Properties.Settings.Default.Theme == "Aqua")
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Aqua/PlayingSmall_Playing.png");
                    }
                    else if (Properties.Settings.Default.Theme == "Red")
                    {
                        PlayState.BackgroundImage = Image.FromFile("Skins/Red/PlayingSmall_Playing.png");
                    }
                 }
                 catch
                 {
                     isPlaying = false;
                     MainButton.BackgroundImage = Properties.Resources.play;
                     MessageBox.Show("Возникла непредвиденная ошибка.Отсутсвует интернет подключение.\nПроверьте интернет подключение или перезапустите приложение", "Ошибка");
                 }
             }
             else if (Properties.Settings.Default.AutoPlayRadio == true)
             {
                 try
                 {
                     wmp.controls.play();
                     isPlaying = true;
                     MainButton.BackgroundImage = Properties.Resources.pause;
                     if (Properties.Settings.Default.Theme == "Orange")
                     {
                          PlayState.BackgroundImage = Image.FromFile("Skins/Orange/PlayingSmall_Pause.png");
                     }
                     else if (Properties.Settings.Default.Theme == "Aqua")
                     {
                          PlayState.BackgroundImage = Image.FromFile("Skins/Aqua/PlayingSmall_Pause.png");
                     }
                     else if (Properties.Settings.Default.Theme == "Red")
                     {
                          PlayState.BackgroundImage = Image.FromFile("Skins/Red/PlayingSmall_Pause.png");
                     }
                  }
                  catch
                  {
                      isPlaying = false;
                      MainButton.BackgroundImage = Properties.Resources.play;
                      MessageBox.Show("Возникла непредвиденная ошибка.Отсутсвует интернет подключение.\nПроверьте интернет подключение или перезапустите приложение", "Ошибка");
                  }
            }
            label1.Text = wmp.currentPlaylist.Item[0].name;
            this.Text = "Радио :  " + wmp.currentPlaylist.Item[0].name;
            NotifyIcon.Text = "Радио :  " + wmp.currentPlaylist.Item[0].name;
            timer1.Start();
        }
        
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                NotifyIcon.ContextMenu = this.TrayMenu;
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Show();
            }
        }
        private void menuItem1_Click(object sender, EventArgs e)
        {
            ApplicationExit();
            Properties.Settings.Default.Volume = SoundLevelChanger.Value;
            Properties.Settings.Default.Save();
        }
        private void menuItem2_Click(object sender, EventArgs e)
        {
            AboutProgram();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = wmp.status.ToString();
        }
        private void menuItem3_Click(object sender, EventArgs e)
        {
            Play();
        }
        private void MainButton_Click(object sender, EventArgs e)
        {
            Play();
        }
        private void MainButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (isPlaying == true)
            {
                if (Properties.Settings.Default.Theme == "Orange")
                {
                    MainButton.BackgroundImage = Image.FromFile(@"Skins/Orange/play.png");
                }
                else if (Properties.Settings.Default.Theme == "Aqua")
                {
                    MainButton.BackgroundImage = Image.FromFile(@"Skins/Aqua/play.png");
                }
                else if (Properties.Settings.Default.Theme == "Red")
                {
                    MainButton.BackgroundImage = Image.FromFile(@"Skins/Red/play.png");
                }
            }
            else if (isPlaying == false)
            {
                if (Properties.Settings.Default.Theme == "Orange")
                {
                    MainButton.BackgroundImage = Image.FromFile(@"Skins/Orange/pause.png");
                }
                else if (Properties.Settings.Default.Theme == "Aqua")
                {
                    MainButton.BackgroundImage = Image.FromFile(@"Skins/Aqua/pause.png");
                }
                else if (Properties.Settings.Default.Theme == "Red")
                {
                    MainButton.BackgroundImage = Image.FromFile(@"Skins/Red/pause.png");
                }
            }
        }
        private void DragBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bDragStatus = true;
                clickPoint = new Point(e.X, e.Y);
            }
            else
            {
                bDragStatus = false;
            }
        }
        private void DragBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (bDragStatus)
            {
                Point pointMoveTo;
                pointMoveTo = this.PointToScreen(new Point(e.X, e.Y));
                pointMoveTo.Offset(-clickPoint.X, -clickPoint.Y);
                this.Location = pointMoveTo;
            }
        }
        private void DragBox_MouseUp(object sender, MouseEventArgs e)
        {
            bDragStatus = false;
        }
        private void Minimize_Box_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ExitBox_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void MenuBox_Click(object sender, EventArgs e)
        {
            MainMenu.Show(MenuBox,new Point(10,10));
        }
        private void HiddenMenuBox_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.HiddenMenu == false)
            {
                Properties.Settings.Default.HiddenMenu = true;
                this.Size = new Size(292, 294);
                if (Properties.Settings.Default.Theme == "Orange")
                {
                    HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Orange/HiddenMenuUp.png");
                }
                else if (Properties.Settings.Default.Theme == "Aqua")
                {
                    HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Aqua/HiddenMenuUp.png");
                }
                else if (Properties.Settings.Default.Theme == "Red")
                {
                    HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Red/HiddenMenuUp.png");
                }
                else if (Properties.Settings.Default.Theme == "Lines")
                {
                    HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Lines/HiddenMenuUp.png");
                }
                Properties.Settings.Default.Save();
            }
            else if (Properties.Settings.Default.HiddenMenu == true)
            {
                Properties.Settings.Default.HiddenMenu = false;
                this.Size = new Size(292, 152);
                if (Properties.Settings.Default.Theme == "Orange")
                {
                    HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Orange/HiddenMenuDown.png");
                }
                else if (Properties.Settings.Default.Theme == "Aqua")
                {
                    HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Aqua/HiddenMenuDown.png");
                }
                else if (Properties.Settings.Default.Theme == "Red")
                {
                    HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Red/HiddenMenuDown.png");
                }
                else if (Properties.Settings.Default.Theme == "Lines")
                {
                    HiddenMenuBox.BackgroundImage = Image.FromFile(@"Skins/Lines/HiddenMenuDown.png");
                }
                Properties.Settings.Default.Save();
            }
        }
        private void menuItem4_Click(object sender, EventArgs e)
        {
            ApplicationExit();
            Properties.Settings.Default.Volume = SoundLevelChanger.Value;
            Properties.Settings.Default.Save();
        }
        private void RadioListView_DoubleClick(object sender, EventArgs e)
        {
            SelectRadio();
        }
        private void menuItem5_Click(object sender, EventArgs e)
        {
            AboutProgram();
        }
        private void menuItem6_Click(object sender, EventArgs e)
        {
            Play();
        }
        private void menuItem7_Click(object sender, EventArgs e)
        {
            Settings SettingsForm = new Settings();
            SettingsForm.ShowDialog();
        }
        private void SoundLevelChanger_Scroll(object sender, ScrollEventArgs e)
        {
            wmp.settings.volume = SoundLevelChanger.Value;
            label3.Text = Convert.ToString(wmp.settings.volume) + "%";
        }
        private void Mute_Click(object sender, EventArgs e)
        {
            if (MuteBool == true)
            {
                if (Properties.Settings.Default.Theme == "Orange")
                {
                    Mute.BackgroundImage = Image.FromFile(@"Skins/Orange/MuteOff.png");
                }
                else if (Properties.Settings.Default.Theme == "Aqua")
                {
                    Mute.BackgroundImage = Image.FromFile(@"Skins/Aqua/MuteOff.png");
                }
                else if (Properties.Settings.Default.Theme == "Red")
                {
                    Mute.BackgroundImage = Image.FromFile(@"Skins/Red/MuteOff.png");
                }
                wmp.settings.mute = false;
                MuteBool = false;
            }
            else if (MuteBool == false)
            {
                if (Properties.Settings.Default.Theme == "Orange")
                {
                    Mute.BackgroundImage = Image.FromFile(@"Skins/Orange/MuteOn.png");
                }
                else if (Properties.Settings.Default.Theme == "Aqua")
                {
                    Mute.BackgroundImage = Image.FromFile(@"Skins/Aqua/MuteOn.png");
                }
                else if (Properties.Settings.Default.Theme == "Red")
                {
                    Mute.BackgroundImage = Image.FromFile(@"Skins/Red/MuteOn.png");
                }
                wmp.settings.mute = true;
                MuteBool = true;
            }
        }

        //Будет нужно в будущем.

        /*
        private char[] symb = { '!', '@', '&', '#', '%', '*', '"' };
        public bool CheckFields()
        {
            string t1 = StationAdd.Text;
            if ((t1.Length == 0 )
                || (t1.Length > 100 ))
                return false;
            if (t1.IndexOfAny(symb) != -1 )
                return false;
            return true;
        }
         */

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                string[] items = { StationAdd.Text };
                ListViewItem lv = new ListViewItem(items);
                RadioListView.Items.Add(lv);
            }
        }*/
    }
}
