using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using CustomizeableJarvis.Properties;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;

namespace CustomizeableJarvis
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        List<string> MsgList = new List<string>();
        List<string> MsgLink = new List<string>();
        int count = 1;
        int timer = 11;
        int EmailNum = 0;
        int mailcheck = 300;
        DateTime now = DateTime.Now;
        String Temperature, Condition, Humidity, WinSpeed, TFCond, TFHigh, TFLow, Town;

        void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int ranNum;
            string speech = e.Result.Text;
            switch (speech)
            {

                //GREETINGS
                case "Hello":
                case "Hello Jarvis":
                    now = DateTime.Now;
                    if (now.Hour >= 5 && now.Hour < 12)
                    { JARVIS.SpeakAsync("Goodmorning " + Settings.Default.User); }
                    if (now.Hour >= 12 && now.Hour < 18)
                    { JARVIS.SpeakAsync("Good afternoon " + Settings.Default.User); }
                    if (now.Hour >= 18 && now.Hour < 24)
                    { JARVIS.SpeakAsync("Good evening " + Settings.Default.User); }
                    if (now.Hour < 5)
                    { JARVIS.SpeakAsync("Hello " + Settings.Default.User + ", it's getting late"); }
                    break;

                case "Goodbye":
                case "Goodbye Jarvis":
                case "Close Jarvis":
                case "go offline":
                    JARVIS.Speak("Farewell");
                    Close();
                    break;

                case "Jarvis":
                case "hey":
                    ranNum = rnd.Next(1, 5);
                    if (ranNum == 1) { QEvent = ""; JARVIS.SpeakAsync("Yes sir"); }
                    else if (ranNum == 2) { QEvent = ""; JARVIS.SpeakAsync("Yes?"); }
                    else if (ranNum == 3) { QEvent = ""; JARVIS.SpeakAsync("How may I help?"); }
                    else if (ranNum == 4) { QEvent = ""; JARVIS.SpeakAsync("How may I be of assistance?"); }
                    break;

                case "What's my name?":
                    JARVIS.SpeakAsync(Settings.Default.User);
                    break;
                
                case "Stop talking":
                case "Shut up":
                case "be quiet":
                case "not now":
                    JARVIS.SpeakAsyncCancelAll();
                    ranNum = rnd.Next(1, 5);
                    if (ranNum == 5)
                    { JARVIS.Speak("fine"); }
                    break;

                //CONDITION OF DAY
                case "What time is it":
                case "time check":
                case "What is the time":
                case "give me the time":
                case "check the time for me":
                case "check the time":
                case "check the clock":

                    now = DateTime.Now;
                    string time = now.GetDateTimeFormats('t')[0];
                    JARVIS.SpeakAsync(time);
                    break;

                case "What day is it":
                case "What day of the week is it":
                case "Which day is today":
                case "What weekday is it":
                    JARVIS.SpeakAsync(DateTime.Today.ToString("dddd"));
                    break;

                case "Whats the date":
                case "Whats todays date":
                case "What day of the month is it":
                    JARVIS.SpeakAsync(DateTime.Today.ToString("dd-MM-yyyy"));
                    break;

                case "Hows the weather":
                case "Whats the weather like":
                case "Whats it like outside":
                case "Weather report":
                case "Whats the weather status":

                    GetWeather();
                    if (QEvent == "connected")
                    { JARVIS.SpeakAsync("The weather in " + Town + " is " + Condition + " at " + Temperature + " degrees. There is a humidity of " + Humidity + " and a windspeed of " + WinSpeed + " miles per hour"); }
                    else if (QEvent == "failed")
                    { JARVIS.SpeakAsync("I seem to be having a bit of trouble connecting to the server. would you like me to run a diagnostic?"); }
                    break;

                case "What will tomorrow be like":
                case "Whats tomorrows forecast":
                case "Whats the forcast":
                case "Whats tomorrow like":
                    GetWeather();
                    if (QEvent == "connected")
                    { JARVIS.SpeakAsync("Tomorrows forecast is " + TFCond + " with a high of " + TFHigh + " and a low of " + TFLow); }
                    else if (QEvent == "failed")
                    { JARVIS.SpeakAsync("I could not access the server."); }
                    break;

                case "Whats the temperature":
                case "Whats the temperature outside":
                    GetWeather();
                    if (QEvent == "connected")
                    {JARVIS.SpeakAsync(Temperature + " degrees");}
                    else if (QEvent == "failed")
                    { JARVIS.SpeakAsync("I could not connect to the weather service"); }
                    break;

                //APPLICATION COMMANDS
                case "Switch Window":
                    SendKeys.Send("%{TAB " + count + "}");
                    count += 1;
                    break;

                case "Close ":
                    SendKeys.Send("{{CTRL}}W");
                    JARVIS.SpeakAsync("closing");
                    break;

                case "Out of the way":
                case "offscreen":
                    if (WindowState == FormWindowState.Normal)
                    {
                        WindowState = FormWindowState.Minimized;
                        JARVIS.SpeakAsync("My apologies");
                    }
                    break;

                case "Come back":
                case "onscreen":
                    if (WindowState == FormWindowState.Minimized)
                    {
                        JARVIS.SpeakAsync("onscreen sir");
                        WindowState = FormWindowState.Normal;
                    }
                    break;

                case "Show default commands":
                    string[] defaultcommands = (File.ReadAllLines(@"Default Commands.txt"));
                    JARVIS.SpeakAsync("Very well");
                    lstCommands.Items.Clear();
                    lstCommands.SelectionMode = SelectionMode.None;
                    lstCommands.Visible = true;
                    foreach (string command in defaultcommands)
                    {
                        lstCommands.Items.Add(command);
                    }
                    lstCommands.Items.Add("JARVIS Come Back Online");
                    break;

                case "Show shell commands":
                    JARVIS.SpeakAsync("Here we are");
                    lstCommands.Items.Clear();
                    lstCommands.SelectionMode = SelectionMode.None;
                    lstCommands.Visible = true;
                    foreach (string command in ArrayShellCommands)
                    {
                        lstCommands.Items.Add(command);
                    }
                    break;

                case "Show social commands":
                    JARVIS.SpeakAsync("Alright");
                    lstCommands.Items.Clear();
                    lstCommands.SelectionMode = SelectionMode.None;
                    lstCommands.Visible = true;
                    foreach (string command in ArraySocialCommands)
                    {
                        lstCommands.Items.Add(command);
                    }
                    break;

                case "Show web commands":
                    JARVIS.SpeakAsync("here are the web commands sir");
                    lstCommands.Items.Clear();
                    lstCommands.SelectionMode = SelectionMode.None;
                    lstCommands.Visible = true;
                    foreach (string command in ArrayWebCommands)
                    {
                        lstCommands.Items.Add(command);
                    }
                    break;
                case "Show Music Library":
                    JARVIS.SpeakAsync("your music library sir");
                    lstCommands.SelectionMode = SelectionMode.One;
                    lstCommands.Items.Clear();
                    lstCommands.Visible = true;
                    i = 0;
                    foreach (string file in FileLocations)
                    {
                        if (file.Contains(".mp3") || file.Contains(".m4a") || file.Contains(".wav"))
                        { lstCommands.Items.Add(FileNames[i]); i += 1; }
                        else { i += 1; }
                    }
                    QEvent = "Play music ";
                    break;

                case "Show Video Library":
                    JARVIS.SpeakAsync("you Video library is loaded sir");
                    lstCommands.SelectionMode = SelectionMode.One;
                    lstCommands.Items.Clear();
                    lstCommands.Visible = true;
                    i = 0;
                    foreach (string file in FileLocations)
                    {
                        if (file.Contains(".mp4") || file.Contains(".avi") || file.Contains(".mkv"))
                        { lstCommands.Items.Add(FileNames[i]); i += 1; }
                        else { i += 1; }
                    }
                    QEvent = "Play a video";
                    break;

                case "Show Email List":
                    lstCommands.SelectionMode = SelectionMode.One;
                    lstCommands.Items.Clear();
                    lstCommands.Visible = true;
                    foreach (string line in MsgList)
                    {
                        lstCommands.Items.Add(line);
                    }
                    QEvent = "Checkfornewemails";
                    break;

                case "Show listbox":
                    lstCommands.Visible = true;
                    break;

                case "Hide listbox":
                    lstCommands.Visible = false;
                    break;

                //SHUTDOWN RESTART LOG OFF
                case "Shutdown":
                    if (ShutdownTimer.Enabled == false)
                    {
                        QEvent = "shutdown";
                        JARVIS.SpeakAsync("I will shutdown shortly");
                        lblTimer.Visible = true;
                        ShutdownTimer.Enabled = true;
                    }
                    break;

                case "Log off":
                    if (ShutdownTimer.Enabled == false)
                    {
                        QEvent = "logoff";
                        JARVIS.SpeakAsync("Logging off");
                        lblTimer.Visible = true;
                        ShutdownTimer.Enabled = true;
                    }
                    break;

                case "Restart":
                    if (ShutdownTimer.Enabled == false)
                    {
                        QEvent = "restart";
                        JARVIS.SpeakAsync("I will be back shortly");
                        lblTimer.Visible = true;
                        ShutdownTimer.Enabled = true;
                    }
                    break;

                case "Abort":
                    if (ShutdownTimer.Enabled == true)
                    {
                        timer = 11;
                        lblTimer.Text = timer.ToString();
                        ShutdownTimer.Enabled = false;
                        lblTimer.Visible = false;
                    }
                    break;

                    //OTHER
                case "add custom commands":
                case "new command":
                case "add a command":
                    Customize customwindow = new Customize();
                    customwindow.Show();
                    break;

                case "reload them":
                case "update commands":
                case "refresh commands":
                case "lets try that":
                case "ok i'm done":
                    JARVIS.SpeakAsync("This may take a few seconds");
                    _recognizer.UnloadGrammar(shellcommandgrammar);
                    _recognizer.UnloadGrammar(webcommandgrammar);
                    _recognizer.UnloadGrammar(socialcommandgrammar);
                    ArrayShellCommands = File.ReadAllLines(scpath);
                    ArrayShellResponse = File.ReadAllLines(srpath);
                    ArrayShellLocation = File.ReadAllLines(slpath);
                    ArrayWebCommands = File.ReadAllLines(webcpath);
                    ArrayWebResponse = File.ReadAllLines(webrpath);
                    ArrayWebURL = File.ReadAllLines(weblpath);
                    ArraySocialCommands = File.ReadAllLines(socpath);
                    ArraySocialResponse = File.ReadAllLines(sorpath);
                    try
                    { shellcommandgrammar = new Grammar(new GrammarBuilder(new Choices(ArrayShellCommands))); _recognizer.LoadGrammar(shellcommandgrammar); }
                    catch
                    { JARVIS.SpeakAsync("I've detected an in valid entry in your shell commands, possibly a blank line. Shell commands will cease to work until it is fixed."); }
                    try
                    { webcommandgrammar = new Grammar(new GrammarBuilder(new Choices(ArrayWebCommands))); _recognizer.LoadGrammar(webcommandgrammar); }
                    catch
                    { JARVIS.SpeakAsync("I've detected an in valid entry in your web commands, possibly a blank line. Web commands will cease to work until it is fixed."); }
                    try
                    { socialcommandgrammar = new Grammar(new GrammarBuilder(new Choices(ArraySocialCommands))); _recognizer.LoadGrammar(socialcommandgrammar); }
                    catch
                    { JARVIS.SpeakAsync("I've detected an in valid entry in your social commands, possibly a blank line. Social commands will cease to work until it is fixed."); }
                    JARVIS.SpeakAsync("All commands updated");
                    break;
                case "Reload libraries":
                case "update libraries":
                case "Refresh libraries":
                    JARVIS.SpeakAsync("Loading libraries");
                    try { _recognizer.UnloadGrammar(Allfiles); }
                    catch { JARVIS.SpeakAsync("Previous grammar was invalid"); }
                    QEvent = "ReadDirectories";
                    ReadDirectories();
                    break;
                case "Change the video directory":
                    JARVIS.SpeakAsync("Please choose a directory to load your video files");
                    VideoFBD.SelectedPath = Settings.Default.VideoFolder;
                    VideoFBD.Description = "Please select your video directory";
                    DialogResult videoresult = VideoFBD.ShowDialog();
                    if (videoresult == DialogResult.OK)
                    {
                        Settings.Default.VideoFolder = VideoFBD.SelectedPath; Settings.Default.Save();
                        QEvent = "ReadDirectories";
                        ReadDirectories();
                    }
                    break;
                case "Change the music directory":
                    JARVIS.SpeakAsync("Please choose a directory to load your music files");
                    MusicFBD.SelectedPath = Settings.Default.MusicFolder;
                    MusicFBD.Description = "Please select your music directory";
                    DialogResult musicresult = MusicFBD.ShowDialog();
                    if (musicresult == DialogResult.OK)
                    {
                        Settings.Default.MusicFolder = MusicFBD.SelectedPath; Settings.Default.Save();
                        QEvent = "ReadDirectories";
                        ReadDirectories();
                    }
                    break;

                case "Stop listening":
                    JARVIS.SpeakAsync("I will await further commands");
                    _recognizer.RecognizeAsyncCancel();
                    startlistening.RecognizeAsync(RecognizeMode.Multiple);
                    changelisten = true;
                    break;

                    //GMAIL NOTIFICATION
                case "Check for new emails":
                    QEvent = "Checkfornewemails";
                    JARVIS.SpeakAsyncCancelAll();
                    EmailNum = 0;
                    CheckForEmails();
                    break;
                case "Open the email":
                    try
                    {
                        JARVIS.SpeakAsyncCancelAll();
                        JARVIS.SpeakAsync("Very well");
                        System.Diagnostics.Process.Start(MsgLink[EmailNum]);
                    }
                    catch { JARVIS.SpeakAsync("There are no emails to read"); }
                    break;
                case "Read the email":
                    JARVIS.SpeakAsyncCancelAll();
                    try
                    {
                        JARVIS.SpeakAsync(MsgList[EmailNum]);
                    }
                    catch { JARVIS.SpeakAsync("There are no emails to read"); }
                    break;
                case "Next email":
                    JARVIS.SpeakAsyncCancelAll();
                    try
                    {
                        EmailNum += 1;
                        JARVIS.SpeakAsync(MsgList[EmailNum]);
                    }
                    catch { EmailNum -= 1; JARVIS.SpeakAsync("There are no further emails"); }
                    break;
                case "Previous email":
                    JARVIS.SpeakAsyncCancelAll();
                    try
                    {
                        EmailNum -= 1;
                        JARVIS.SpeakAsync(MsgList[EmailNum]);
                    }
                    catch { EmailNum += 1; JARVIS.SpeakAsync("There are no previous emails"); }
                    break;
                case "Clear email list":
                    JARVIS.SpeakAsyncCancelAll();
                    MsgList.Clear(); MsgLink.Clear(); lstCommands.Items.Clear(); EmailNum = 0; JARVIS.SpeakAsync("Email list has been cleared");
                    break;
            }
        }
        void startlistening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            switch (speech)
            {
                case "JARVIS Come Back Online":
                        changelisten = false; _recognizer.RecognizeAsync(RecognizeMode.Multiple); startlistening.RecognizeAsyncCancel(); JARVIS.SpeakAsync("Online and ready");
                    break;
            }
        }
        
        private void GetWeather()
        {
            try
            {
                string query = String.Format("http://weather.yahooapis.com/forecastrss?w=" + Settings.Default.WOEID.ToString() + "&u=" + Settings.Default.Temperature);
                XmlDocument wData = new XmlDocument();
                wData.Load(query);

                XmlNamespaceManager man = new XmlNamespaceManager(wData.NameTable);
                man.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

                XmlNode channel = wData.SelectSingleNode("rss").SelectSingleNode("channel");
                XmlNodeList nodes = wData.SelectNodes("/rss/channel/item/yweather:forecast", man);

                Temperature = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", man).Attributes["temp"].Value;

                Condition = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", man).Attributes["text"].Value;

                Humidity = channel.SelectSingleNode("yweather:atmosphere", man).Attributes["humidity"].Value;

                WinSpeed = channel.SelectSingleNode("yweather:wind", man).Attributes["speed"].Value;

                Town = channel.SelectSingleNode("yweather:location", man).Attributes["city"].Value;

                TFCond = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", man).Attributes["text"].Value;

                TFHigh = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", man).Attributes["high"].Value;

                TFLow = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", man).Attributes["low"].Value;

                QEvent = "connected";
            }
            catch { QEvent = "failed"; }
        }

        private void CheckForEmails()
        {
            string GmailAtomUrl = "https://mail.google.com/mail/feed/atom";

            XmlUrlResolver xmlResolver = new XmlUrlResolver();
            xmlResolver.Credentials = new NetworkCredential(Settings.Default.GmailUser, Settings.Default.GmailPassword);
            XmlTextReader xmlReader = new XmlTextReader(GmailAtomUrl);
            xmlReader.XmlResolver = xmlResolver;
            try
            {
                XNamespace ns = XNamespace.Get("http://purl.org/atom/ns#");
                XDocument xmlFeed = XDocument.Load(xmlReader);


                var emailItems = from item in xmlFeed.Descendants(ns + "entry")
                                 select new
                                 {
                                     Author = item.Element(ns + "author").Element(ns + "name").Value,
                                     Title = item.Element(ns + "title").Value,
                                     Link = item.Element(ns + "link").Attribute("href").Value,
                                     Summary = item.Element(ns + "summary").Value
                                 };
                MsgList.Clear(); MsgLink.Clear();
                foreach (var item in emailItems)
                {
                    if (item.Title == String.Empty)
                    {
                        MsgList.Add("Message from " + item.Author + ", There is no subject and the summary reads, " + item.Summary);
                        MsgLink.Add(item.Link);
                    }
                    else
                    {
                        MsgList.Add("Message from " + item.Author + ", The subject is " + item.Title + " and the summary reads, " + item.Summary);
                        MsgLink.Add(item.Link);
                    }
                }

                if (emailItems.Count() > 0)
                {
                    if (emailItems.Count() == 1)
                    {
                        JARVIS.SpeakAsync("You have 1 new email");
                    }
                    else { JARVIS.SpeakAsync("You have " + emailItems.Count() + " new emails"); }
                    lstCommands.SelectionMode = SelectionMode.One;
                    lstCommands.Items.Clear();
                    lstCommands.Visible = true;
                    foreach (string line in MsgList)
                    {
                        lstCommands.Items.Add(line);
                    }
                }
                else if (QEvent == "Checkfornewemails" && emailItems.Count() == 0)
                { JARVIS.SpeakAsync("You have no new emails"); QEvent = String.Empty; }
            }
            catch { JARVIS.SpeakAsync("You have submitted invalid log in information"); }
        }
    }
}
