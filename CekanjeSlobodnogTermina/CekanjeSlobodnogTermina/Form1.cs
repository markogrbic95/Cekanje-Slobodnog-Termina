using CekanjeSlobodnogTermina.Properties;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace CekanjeSlobodnogTermina
{
    public partial class MainForm : Form
    {
        WebBrowser chrome;

        System.Windows.Forms.Timer serachWebsiteTimer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer waitTimer = new System.Windows.Forms.Timer();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MainForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
          int nLeftRect,
          int nTopRect,
          int nRightRect,
          int nBottomRect,
          int nWidthEllipse,
          int nHeightEllipse
        );

        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void setStartUpLocation()
        {
            Rectangle hostScreen = Screen.FromControl(this).Bounds;
            this.Location = new Point(hostScreen.Width - this.Width - 40, 40);
        }

        public MainForm()
        {
            InitializeComponent();

            this.Icon = Resources.icon;
            this.Opacity = .85;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 5, 5));

            this.BackColor = Color.FromArgb(61, 201, 154);
            headPanel.BackColor = Color.FromArgb(41, 181, 134);
            colorButton.BackColor = this.BackColor;            

            waitTimer.Interval = 500;
            waitTimer.Tick += new EventHandler(waitTimer_Tick);
            waitTimer.Start();

            serachWebsiteTimer.Interval = 60000;
            serachWebsiteTimer.Tick += new EventHandler(serachWebsiteTimer_Tick);
            serachWebsiteTimer.Start();
            serachWebsiteTimer_Tick(null,null);

            setStartUpLocation();                 
        }

        private void serachWebsiteTimer_Tick(object sender, EventArgs e)
        {
            chrome = new WebBrowser();
            chrome.Navigate("http://gim.ftn.uns.ac.rs/Prijava");
            chrome.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(chrome_DocumentCompleted);
        }

        private void chrome_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            switch (((WebBrowser)sender).Url.ToString())
            {
                case "http://gim.ftn.uns.ac.rs/Prijava":
                    {
                        StreamReader sr = new StreamReader("userpass.txt");

                        ((WebBrowser)sender).Document.GetElementsByTagName("input").GetElementsByName("korisnickoIme")[0].SetAttribute("value", sr.ReadLine());
                        ((WebBrowser)sender).Document.GetElementsByTagName("input").GetElementsByName("lozinka")[0].SetAttribute("value", sr.ReadLine());

                        sr.Close();

                        foreach (HtmlElement item in ((WebBrowser)sender).Document.GetElementsByTagName("input"))
                        {
                            if (item.GetAttribute("value") == "Prijava")
                            {
                                item.InvokeMember("click");
                                break;
                            }
                        }
                    }
                    break;

                case "http://gim.ftn.uns.ac.rs/Index":
                    {
                        chrome.Navigate("http://gim.ftn.uns.ac.rs/IzmenaZakazanogTermina");
                    }
                    break;

                case "http://gim.ftn.uns.ac.rs/IzmenaZakazanogTermina":
                    {
                        string lastDate = "";

                        foreach (HtmlElement item in ((WebBrowser)sender).Document.GetElementsByTagName("select").GetElementsByName("datum")[0].All)
                        {
                            lastDate = item.GetAttribute("value");
                        }

                        dateLabel.Text = lastDate.Replace('.', '/');
                        
                        chrome.Navigate("http://gim.ftn.uns.ac.rs/IzmenaZakazanogTermina?nastavnik=1&datum=" + lastDate);
                    }
                    break;

                default:
                    {
                        bool foundSpanMessage = false;

                        foreach (var value in ((WebBrowser)sender).Document.GetElementsByTagName("span"))
                        {
                            if (((HtmlElement)value).InnerText.Contains("zauzeti"))
                                foundSpanMessage = true;
                        }

                        if (!foundSpanMessage)
                        {
                            waitTimer.Stop();
                            statusLabel.TextAlign = ContentAlignment.MiddleCenter;

                            System.Windows.Forms.Timer waitTimer2 = new System.Windows.Forms.Timer();
                            waitTimer2.Tick += new EventHandler(waitTimer2_Tick);
                            waitTimer2.Interval = 1000;
                            waitTimer2.Start();

                            statusLabel.Text = "Found available appointment!";
                        }
                    }
                    break;
            }
        }

        private void waitTimer2_Tick(object sender, EventArgs e)
        {
            statusLabel.Visible = !statusLabel.Visible;

            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = "feedback.mp3";
            wplayer.controls.play();
        }

        private void waitTimer_Tick(object sender, EventArgs e)
        {
            uint dotCounter = 0;
            foreach(char c in statusLabel.Text)
            {
                if (c == '.')
                    dotCounter++;
            }

            if(dotCounter == 3)
                statusLabel.Text = statusLabel.Text.Substring(0,statusLabel.Text.Length-2);
            else
                statusLabel.Text += ".";
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.FromArgb(61, 201, 154))
            {
                this.BackColor = Color.FromArgb(205, 75, 116);
                headPanel.BackColor = Color.FromArgb(185, 55, 96);
                colorButton.BackColor = this.BackColor;
            }
            else if(this.BackColor == Color.FromArgb(205, 75, 116))
            {
                this.BackColor = Color.FromArgb(77, 73, 147);
                headPanel.BackColor = Color.FromArgb(57, 53, 127);
                colorButton.BackColor = this.BackColor;
            }
            else if(this.BackColor == Color.FromArgb(77, 73, 147))
            {
                this.BackColor = Color.FromArgb(233, 76, 61);
                headPanel.BackColor = Color.FromArgb(213, 56, 41);
                colorButton.BackColor = this.BackColor;
            }
            else
            {
                this.BackColor = Color.FromArgb(61, 201, 154);
                headPanel.BackColor = Color.FromArgb(41, 181, 134);
                colorButton.BackColor = this.BackColor;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButton_MouseHover(object sender, EventArgs e)
        {
            closeButton.Cursor = Cursors.Hand;
            closeButton.BackgroundImage = Resources.close_hover;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.Cursor = Cursors.Default;
            closeButton.BackgroundImage = Resources.close;
        }
    }
}
