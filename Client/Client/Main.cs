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

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            browser.Navigate(browser.Url);
            refreshTimeLeft = 60;
            lastRefresh.Text = "Last Refresh 0 Seconds Ago";
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
                    doc.GetElementById("latency" + index).InnerText = "Failed";
                }
                index++;
            }
            if (RefreshTimer.Interval == 1000) {
                RefreshTimer.Start();
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            refreshTimeLeft -= 1;
            lastRefresh.Text = "Last Refresh " + (60 - refreshTimeLeft) + " Seconds Ago";

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
    }
}
