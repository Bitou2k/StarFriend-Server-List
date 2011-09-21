using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Client
{
    public partial class Main : Form
    {

        private String serverURL = "http://cabrita.prefiber.nl/starfriend/";
        private String logFolder;
        private bool started = false;
        private String fileReading;
        private long lastPosition = 0;
        private bool settingsOpen = false;

        private String version;
        private int maxDelay;
        private int playersIn = 0;

        public Main()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            String path = sfpath.Text;

            if (!Directory.Exists(path))
            {
                log("Invalid StarFriend Directory.");
                return;
            }
            else
            {
                if (!Directory.Exists(path + "/serverLog"))
                {
                    log("serverLog Directory not found! Start the server first!");
                    return;
                }
            }

            logFolder = path + "/serverLog";

            if (!started)
            {
                startSync();
            }
            else
            {
                stopSync();
            }
        }


        private void stopSync()
        {
            Log.ResetText();
            browser.Stop();
            closeServer();
        }

        private void startSync()
        {
            Log.ResetText();
            Start.Text = "Stop";
            sfpath.Enabled = false;
            started = true;
            IPOverride.Enabled = false;
            Description.Enabled = false;

            StreamWriter propwriter = new StreamWriter("settings.txt", false);
            propwriter.WriteLine(sfpath.Text);
            propwriter.WriteLine(IPOverride.Text);
            propwriter.WriteLine(Description.Text);
            propwriter.Close();

            String[] files = Directory.GetFiles(logFolder);

            DateTime time = DateTime.MinValue;
            String resultFile = null;
            foreach (String s in files)
            {
                if (File.GetCreationTime(s) > time)
                {
                    resultFile = s;
                }
            }

            fileWatcher.Path = logFolder;

            fileReading = resultFile;
            parseText();

            fileWatcher.EnableRaisingEvents = true;
        }

        private void log(String message)
        {
            Log.AppendText(message + "\r\n");
        }

        private void logappend(String message)
        {
            Log.AppendText(message);
        }

        private void fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            parseText();
        }

        private void parseText()
        {
            FileStream stream = new FileStream(fileReading, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader reader = new StreamReader(stream);

            if (lastPosition != 0)
                stream.Position = lastPosition;

            bool changed = false;
            while (!reader.EndOfStream)
            {
                String line = reader.ReadLine();

                if (line.Contains("StarFriend"))
                {
                    String result = line.Substring(line.IndexOf("StarFriend") + 11);
                    log("StarFriend Version " + result);
                    version = result;
                    changed = true;
                }
                else
                    if (line.Contains("StarFriend server"))
                    {
                        String result = line.Substring(line.IndexOf("StarFriend") + 11);
                        log("StarFriend server closed.");
                        closeServer();
                    }
                    else
                        if (line.Contains("Delay Time"))
                        {
                            String result = line.Substring(line.IndexOf("is ") + 3);
                            log("Max Latency is " + result);
                            maxDelay = Convert.ToInt32(result.Substring(0, result.Length - 3));
                            changed = true;
                        }
                        else
                            if (line.Contains("connect as"))
                            {
                                playersIn += 1;
                                log("Player Connected! Total: " + playersIn);
                                changed = true;
                            }
                            else
                                if (line.Contains("disconnect"))
                                {
                                    playersIn -= 1;
                                    log("Player Disconnected! Total: " + playersIn);
                                    changed = true;
                                }
            }
            if (changed)
            {
                lastPosition = stream.Position;
                updateServer();
                updatePlayerLabel();
                log("---------------------------------------------------------");
            }
            reader.Close();
            stream.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (File.Exists("settings.txt"))
            {
                StreamReader reader = new StreamReader("settings.txt");
                sfpath.Text = reader.ReadLine();
                IPOverride.Text = reader.ReadLine();
                Description.Text = reader.ReadLine();
                reader.Close();
            }
        }

        private void updateServer()
        {
            log("Sending Data to Server");
            String link = serverURL + "update.php?version=" + version + "&delay=" + maxDelay + "&players=" + playersIn;
            if (IPOverride.TextLength > 0)
            {
                IPAddress ip;
                if (!IPAddress.TryParse(IPOverride.Text, out ip) || IPOverride.TextLength < 7)
                {
                    log("Error: Invalid IP Address!");
                    return;
                }
                link += "&ip=" + IPOverride.Text;
            }
            if (Description.TextLength > 0) {
                if (Description.TextLength > 20)
                {
                    log("Error: Description must be less than 20 characters!");
                    return;
                }
                link += "&description=" + Description.Text;
            }
            browser.Navigate(link);
        }

        public void closeServer()
        {
            log("Closing Server");
            String link = serverURL + "stop.php";
            if (IPOverride.TextLength > 0)
            {
                IPAddress ip;
                if (!IPAddress.TryParse(IPOverride.Text, out ip) || IPOverride.TextLength < 7)
                {
                    log("Error: Invalid IP Address!");
                    return;
                }
                link += "?ip=" + IPOverride.Text;
            }
            browser.Navigate(link);
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            log(browser.DocumentText);
            if (browser.DocumentText.Equals("Server Closed!"))
            {
                log("Restarting Application...");
                Application.Restart();
            }
        }

        private void updatePlayerLabel()
        {
            playerLabel.Text = "Players: " + playersIn;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            if (!settingsOpen)
            {
                Main.ActiveForm.Size = new Size(410, 230);
                Settings.Text = "Close Settings";
                settingsOpen = true;
                Description.Visible = true;
                IPOverride.Visible = true;
                label4.Visible = true;
                label3.Visible = true;
                label2.Visible = true;
            }
            else
            {
                Settings.Text = "Open Settings";
                Main.ActiveForm.Size = new Size(410, 170);
                settingsOpen = false;
                Description.Visible = false;
                IPOverride.Visible = false;
                label4.Visible = false;
                label3.Visible = false;
                label2.Visible = false;
            }
        }
    }
}
