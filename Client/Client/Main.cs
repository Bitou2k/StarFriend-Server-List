using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;

namespace Client
{
    public partial class Main : Form
    {

        private int refreshTimeLeft = 60;
        private String[] local;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            loadLanguage("English");
            browser.Navigate("http://cabrita.prefiber.nl/starfriend/index.php?client=1");
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            browser.Navigate(browser.Url);
            refreshTimeLeft = 60;
            lastRefresh.Text = local[2] + " 0 " + local[3];
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            treatPings();
        }

        private void treatPings() {
            HtmlDocument doc = browser.Document;

            int index = 0;

            while (true)
            {
                if (doc.GetElementById("ip" + index) == null)
                {
                    break;
                }
                String ip = doc.GetElementById("ip" + index).InnerText;

                PingReply reply = new Ping().Send(ip, 2000);

                if (reply.Status == IPStatus.Success)
                {
                    doc.GetElementById("latency" + index).InnerText = reply.RoundtripTime.ToString() + " ms";
                }
                else
                {
                    doc.GetElementById("latency" + index).InnerText = local[12];
                }
                index++;
            }
            if (RefreshTimer.Interval == 1000) {
                RefreshTimer.Start();
            }

            if (!local[0].Equals("Refresh Page"))
            {
                doc.GetElementById("version").InnerText = local[4];
                doc.GetElementById("maxlatency").InnerText = local[5];
                doc.GetElementById("players").InnerText = local[6];
                doc.GetElementById("ipaddress").InnerText = local[7];
                doc.GetElementById("description").InnerText = local[8];
                doc.GetElementById("lastupdate").InnerText = local[9];
                doc.GetElementById("latency").InnerText = local[10];
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            refreshTimeLeft -= 1;
            lastRefresh.Text = local[2] + " " + (60 - refreshTimeLeft) + " " + local[3];

            if (refreshTimeLeft <= 0)
            {
                browser.Navigate(browser.Url);
                refreshTimeLeft = 60;
            }
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            lastRefresh.Location = new Point(this.Size.Width / 2 - (lastRefresh.Size.Width/2), 3);
            lastRefresh.Update();
        }

        private void loadLanguage(String name)
        {
            if (!File.Exists("languages/" + name + ".txt"))
            {
                MessageBox.Show(local[11]);
                Application.Exit();
                return;
            }

            StreamReader reader = new StreamReader("languages/" + name + ".txt", Encoding.Default);

            local = new String[13];

            int id = 0;
            while (!reader.EndOfStream)
            {
                local[id] = reader.ReadLine();
                id++;
            }

            browser.Navigate(browser.Url);
            refreshTimeLeft = 60;
            lastRefresh.Text = local[2] + " 0 " + local[3];

            RefreshButton.Text = local[0];
            chatEnable.Text = local[1];
        }

        private void changeLanguageEnglish_Click(object sender, EventArgs e)
        {
            loadLanguage("English");
        }

        private void spanishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadLanguage("Spanish");
        }

        private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadLanguage("French");
        }
    }
}
