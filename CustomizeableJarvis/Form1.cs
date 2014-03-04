using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using CustomizeableJarvis.Properties;
using System.Globalization;
using System.Threading;
using System.Diagnostics;

namespace CustomizeableJarvis
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine(); //Creates the Speech Recognition Engine and sets the default language to English-US dialect
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        SpeechSynthesizer JARVIS = new SpeechSynthesizer(); //Creates the speech synthesizer to allow the program to respond
        Grammar shellcommandgrammar; //Grammar variables allow us to load and unload words into Jarvis's vocabulary and update them during runtime without the need to restart the program
        Grammar webcommandgrammar, socialcommandgrammar, Allfiles;
        String[] ArrayShellCommands; //These arrays will be loaded with custom commands, responses, and File Locations/URLs
        String[] ArrayShellResponse;
        String[] ArrayShellLocation;
        String[] ArrayWebCommands;
        String[] ArrayWebResponse;
        String[] ArrayWebURL;
        String[] ArraySocialCommands;
        String[] ArraySocialResponse;
        String[] MyMusic; //These arrays will help load music/video file paths and filenames and write them to CSV documents
        String[] MyVideos;
        String[] AllLines; //This array stores all lines in our CSV document so we can pull substrings from it and load it into other arrays
        String[] FileNames; //This array stores filenames
        String[] FileLocations; //This array stores file paths so we can open them
        List<string> MyMusicPaths = new List<string>(); //This list will store only Music file paths
        List<string> MyVideoPaths = new List<string>(); //This list will store only Video file paths
        TagLib.File music; //This variable is for reading ID3 tags of music files so we can refer to them by Song Title and Artist
        string scpath; //These strings will be used to refer to the Shell Command text document
        string srpath; //These strings will be used to refer to the Shell Response text document
        string slpath; //These strings will be used to refer to the Shell Location text document
        string webcpath; //These strings will be used to refer to the Web Command text document
        string webrpath; //These strings will be used to refer to the Web Response text document
        string weblpath; //These strings will be used to refer to the Web URL text document
        string socpath; //These strings will be used to refer to the Social Command text document
        string sorpath; //These strings will be used to refer to the Social Response text document
        Boolean changelisten = false; //This Boolean variable tells us if the default Speech Recognition Engine is active or not
        String userName = Environment.UserName; //This variable stores the name of your computer so we can refer to specific file locations or assume your name
        String QEvent; //This variable is used periodically to determine which event we are trying to achieve when there are multiple possible outcomes
        int i = 0; //This integer variable will be used for loops and referring to specific elements in arrays
        StreamWriter sw; //Sets a variable that allows us to read and write to text documents

        public Form1()
        {
            InitializeComponent();

            JARVIS.Speak("Hello " + Settings.Default.User + ", allow me to load the necessary files");
            string[] defaultcommands = (File.ReadAllLines(@"Default Commands.txt")); //Loading all default commands into an array
            foreach (string command in defaultcommands)
            {
                lstCommands.Items.Add(command); //We load them into the listbox on start up just in case someone forgets the commands and they can say, "Show listbox"
            }

            Directory.CreateDirectory(@"C:\Users\" + userName + "\\Documents\\Jarvis Custom Commands"); //We create 'Jarvis Custom Commands' folder in the My Documents folder so we have a place to store our text documents
            Settings.Default.ShellC = @"C:\Users\" + userName + "\\Documents\\Jarvis Custom Commands\\Shell Commands.txt"; //We save the text document file locations into our settings even before they've been created so we can refer to them easily and globally
            Settings.Default.ShellR = @"C:\Users\" + userName + "\\Documents\\Jarvis Custom Commands\\Shell Response.txt";
            Settings.Default.ShellL = @"C:\Users\" + userName + "\\Documents\\Jarvis Custom Commands\\Shell Location.txt";
            Settings.Default.WebC = @"C:\Users\" + userName + "\\Documents\\Jarvis Custom Commands\\Web Commands.txt";
            Settings.Default.WebR = @"C:\Users\" + userName + "\\Documents\\Jarvis Custom Commands\\Web Response.txt";
            Settings.Default.WebL = @"C:\Users\" + userName + "\\Documents\\Jarvis Custom Commands\\Web URL.txt";
            Settings.Default.SocC = @"C:\Users\" + userName + "\\Documents\\Jarvis Custom Commands\\Social Commands.txt";
            Settings.Default.SocR = @"C:\Users\" + userName + "\\Documents\\Jarvis Custom Commands\\Social Response.txt";
            Settings.Default.Save();

            scpath = Settings.Default.ShellC; //The text document file locations are passed on to these variables because they are easier to refer to but admittedly is an unnecessary step
            srpath = Settings.Default.ShellR;
            slpath = Settings.Default.ShellL;
            webcpath = Settings.Default.WebC;
            webrpath = Settings.Default.WebR;
            weblpath = Settings.Default.WebL;
            socpath = Settings.Default.SocC;
            sorpath = Settings.Default.SocR;

            if (!File.Exists(scpath)) //This is used to create the Custom Command text documents if they don't already exist and write in default commands so we don't encounter any errors. These text documents should always have at least one valid line in them
            { sw = File.CreateText(scpath); sw.Write("My Documents"); sw.Close(); }
            if (!File.Exists(srpath))
            { sw = File.CreateText(srpath); sw.Write("Right away"); sw.Close(); }
            if (!File.Exists(slpath))
            { sw = File.CreateText(slpath); sw.Write(@"C:\Users\" + userName + "\\Documents"); sw.Close(); }
            if (!File.Exists(webcpath))
            { sw = File.CreateText(webcpath); sw.Write("Open Google"); sw.Close(); }
            if (!File.Exists(webrpath))
            { sw = File.CreateText(webrpath); sw.Write("Very well"); sw.Close(); }
            if (!File.Exists(weblpath))
            { sw = File.CreateText(weblpath); sw.Write("http://www.google.com"); sw.Close(); }
            if (!File.Exists(socpath))
            { sw = File.CreateText(socpath); sw.Write("How are you"); sw.Close(); }
            if (!File.Exists(sorpath))
            { sw = File.CreateText(sorpath); sw.Write("I'm doing well thanks for asking"); sw.Close(); }


            try
            {
                ReadDirectories(); //This procedure is used to load all of our music/video files
            }
            catch { JARVIS.SpeakAsync("You may need to restart the program in order to access music files"); } //The try catch block is in case of any unkown errors to prevent the program from crashing.


            ArrayShellCommands = File.ReadAllLines(scpath); //This loads all written commands in our Custom Commands text documents into arrays so they can be loaded into our grammars
            ArrayShellResponse = File.ReadAllLines(srpath);
            ArrayShellLocation = File.ReadAllLines(slpath);
            ArrayWebCommands = File.ReadAllLines(webcpath); //This loads all written commands in our Custom Commands text documents into arrays so they can be loaded into our grammars
            ArrayWebResponse = File.ReadAllLines(webrpath);
            ArrayWebURL = File.ReadAllLines(weblpath);
            ArraySocialCommands = File.ReadAllLines(socpath); //This loads all written commands in our Custom Commands text documents into arrays so they can be loaded into our grammars
            ArraySocialResponse = File.ReadAllLines(sorpath);

            //The following try catch blocks load our custom commands into our grammars. The catch block is in case of any blank lines or other unforseeable errors
            try
            { shellcommandgrammar = new Grammar(new GrammarBuilder(new Choices(ArrayShellCommands))); _recognizer.LoadGrammarAsync(shellcommandgrammar); }
            catch
            { JARVIS.SpeakAsync("I've detected an in valid entry in your shell commands, possibly a blank line. Shell commands will cease to work until it is fixed."); }
            try
            { webcommandgrammar = new Grammar(new GrammarBuilder(new Choices(ArrayWebCommands))); _recognizer.LoadGrammarAsync(webcommandgrammar); }
            catch
            { JARVIS.SpeakAsync("I've detected an in valid entry in your web commands, possibly a blank line. Web commands will cease to work until it is fixed."); }
            try
            { socialcommandgrammar = new Grammar(new GrammarBuilder(new Choices(ArraySocialCommands))); _recognizer.LoadGrammarAsync(socialcommandgrammar); }
            catch
            { JARVIS.SpeakAsync("I've detected an in valid entry in your social commands, possibly a blank line. Social commands will cease to work until it is fixed."); }

            _recognizer.SetInputToDefaultAudioDevice(); //Sets Mic input to the default Mic
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"Default Commands.txt"))))); //Load our Default Commands text document so we have commands to start with
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(AlarmAM)))); //Loads AM times for our alarm feature
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(AlarmPM)))); //Loads PM times for our alarm feature *Might consider combining them
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Shell_SpeechRecognized); //These are event handlers that are responsible for carrying out all necessary tasks if a speech event is recognized
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Social_SpeechRecognized);
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Web_SpeechRecognized);
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(PlayFile_SpeechRecognized);
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(AlarmClock_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple); //This allows the Speech recognition engine to listen for multiple phrases and continue working rather than just one and quiting

            startlistening.SetInputToDefaultAudioDevice();
            startlistening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices("JARVIS Come Back Online")))); //Loads a grammar choice into the speech recognition engine
            startlistening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startlistening_SpeechRecognized); //The event handler that allows us to say "JARVIS Come Back Online". Only one Speech Recognition Engine is active at a time.

            JARVIS.SpeakAsync("I am online and ready");
            if (Settings.Default.User.ToString() == String.Empty) //Checks for user info. If none is available it sets to default
            { Settings.Default.User = userName; Settings.Default.Save(); }
            if (Settings.Default.AClockEnbl == true) //Enables the clock if it has been set so you don't have to reset it everytime you open and close the program
            { AlarmTimer.Enabled = true; }
        }

        void Shell_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text; //Sets the SpeechRecognized event variable to a string variable called speech
            i = 0; //Ensures "i" is = to 0 so we can start our loop from the beginning of our arrays
            try
            {
                foreach (string line in ArrayShellCommands)
                {
                    if (line == speech) //If line == speech it will open the corresponding program/file
                    {
                        System.Diagnostics.Process.Start(ArrayShellLocation[i]); //Opens the program/file of the same elemental position as the ArrayShellCommands command that was equal to speech
                        JARVIS.SpeakAsync(ArrayShellResponse[i]); //Gives the response of the same elemental position as the ArrayShellCommands command that was equal to speech
                    }
                    i += 1; //if the line in ArrayShellCommands does not equal speech it will add 1 to "i" and go through the loop until it finds a match between the line and spoken event
                }
            }
            catch
            {
                i += 1;
                JARVIS.SpeakAsync("Im sorry it appears the shell command " + speech + " on line " + i + " is accompanied by either a blank line or an incorrect file location");
            }
        }

        void Social_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            i = 0;
            try
            {
                foreach (string line in ArraySocialCommands)
                {
                    if (line == speech)
                    {
                        JARVIS.SpeakAsync(ArraySocialResponse[i]);
                    }
                    i += 1;
                }
            }
            catch
            {
                i += 1;
                JARVIS.SpeakAsync("Please check the " + speech + " social command on line " + i + ". It appears to be missing a proper response");
            }
        }

        void Web_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            i = 0;
            try
            {
                foreach (string line in ArrayWebCommands)
                {
                    if (line == speech)
                    {
                        System.Diagnostics.Process.Start(ArrayWebURL[i]);
                        JARVIS.SpeakAsync(ArrayWebResponse[i]);
                    }
                    i += 1;
                }
            }
            catch
            {
                i += 1;
                JARVIS.SpeakAsync("Please check the " + speech + "web command on line " + i + ". It appears to be missing a proper response or web U R L");
            }
        }

        void PlayFile_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "Play music")
            {
                QEvent = speech; //Sets the QEvent variable to "Play music" so it can differentiate between music and video files
                JARVIS.SpeakAsync("Which song");
            }
            if (speech == "Play video")
            {
                QEvent = speech; //Sets the QEvent variable to "Play video" so it can differentiate between music and video files
                JARVIS.SpeakAsync("Which video");
            }
            try
            {
                i = 0;
                foreach (string line in FileNames)
                {
                    //If there is a match between a Filename and speech, QEvent wants to play music, and the Filename has a music file extension it will play the correct song
                    if (line == speech && QEvent == "Play music" && (AllLines[i].Contains(".mp3") || AllLines[i].Contains(".m4a") || AllLines[i].Contains(".wav")))
                    {
                        System.Diagnostics.Process.Start(FileLocations[i]);
                        JARVIS.SpeakAsync(line);
                        QEvent = string.Empty;
                    }
                    //If there is a match between a Filename and speech, QEvent wants to play video, and the Filename has a video file extension it will play the correct video
                    else if (line == speech && QEvent == "Play video" && (AllLines[i].Contains(".mp4") || AllLines[i].Contains(".avi") || AllLines[i].Contains(".m4v")))
                    {
                        System.Diagnostics.Process.Start(FileLocations[i]);
                        JARVIS.SpeakAsync(line);
                        QEvent = string.Empty;
                    }

                    i += 1;
                }
            }
            catch { JARVIS.SpeakAsync("File names unsuccessfully loaded"); }
        }

        private void ShutdownTimer_Tick(object sender, EventArgs e)
        {
            if (timer == 0)
            {
                lblTimer.Visible = false;
                ComputerTermination();
                ShutdownTimer.Enabled = false;
            }
            else
            {
                timer = timer - 1;
                lblTimer.Text = timer.ToString();
            }
        }
        private void ComputerTermination()
        {
            switch (QEvent)
            {
                case "shutdown":
                    System.Diagnostics.Process.Start("shutdown", "-s");
                    break;
                case "logoff":
                    System.Diagnostics.Process.Start("shutdown", "-l");
                    break;
                case "restart":
                    System.Diagnostics.Process.Start("shutdown", "-r");
                    break;
            }
        }

        private void lblAdd_Click(object sender, EventArgs e)
        {
            Customize customwindow = new Customize();
            customwindow.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (changelisten == true)
            { _recognizer.RecognizeAsync(RecognizeMode.Multiple); startlistening.RecognizeAsyncCancel(); changelisten = false; }
        }

        private void lstCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCommands.SelectionMode == SelectionMode.One)
            {
                if (QEvent == "Play music file")
                {
                    int num = lstCommands.SelectedIndex;
                    try { System.Diagnostics.Process.Start(MyMusicPaths[num]); }
                    catch { JARVIS.SpeakAsync("The selected index is out of bounds"); }
                }
                else if (QEvent == "Play video file")
                {
                    int num = lstCommands.SelectedIndex;
                    try { System.Diagnostics.Process.Start(MyVideoPaths[num]); }
                    catch { JARVIS.SpeakAsync("The selected index is out of bounds"); }
                }
                else if (QEvent == "Checkfornewemails")
                {
                    int num = lstCommands.SelectedIndex;
                    try { Process.Start(MsgLink[num]); }
                    catch { JARVIS.SpeakAsync("The selected index is out of bounds"); }
                }
            }
        }

        void ReadDirectories()
        {
            //The first time the program starts it will attempt to load music and video files from your My Videos and My Music directories
            try
            {
                if (Settings.Default.MusicFolder == String.Empty)
                {
                    Settings.Default.MusicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                    Settings.Default.VideoFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                    Settings.Default.Save();
                }

                if (!File.Exists(@"C:\Users\" + userName + "\\Documents\\Jarvis Custom Commands\\Filenames.txt") || QEvent == "ReadDirectories")
                {
                    JARVIS.SpeakAsync("I need a few seconds to load audio and video files");
                    sw = File.CreateText(@"C:\Users\" + Environment.UserName + "\\Documents\\Jarvis Custom Commands\\Filenames.txt");
                    MyMusic = Directory.GetFiles(Settings.Default.MusicFolder, "*.mp3", SearchOption.AllDirectories);
                    MyVideos = Directory.GetFiles(Settings.Default.VideoFolder, "*.mp4", SearchOption.AllDirectories);
                    WriteDirectories();
                    MyMusic = Directory.GetFiles(Settings.Default.MusicFolder, "*.m4a", SearchOption.AllDirectories);
                    MyVideos = Directory.GetFiles(Settings.Default.VideoFolder, "*.avi", SearchOption.AllDirectories);
                    WriteDirectories();
                    MyMusic = Directory.GetFiles(Settings.Default.MusicFolder, "*.wav", SearchOption.AllDirectories);
                    MyVideos = Directory.GetFiles(Settings.Default.VideoFolder, "*.mkv", SearchOption.AllDirectories);
                    WriteDirectories();
                    sw.Close();
                    JARVIS.SpeakAsync("Your libraries have been updated");
                }
                AllLines = File.ReadAllLines(@"C:\Users\" + userName + "\\Documents\\Jarvis Custom Commands\\Filenames.txt");
                FileNames = new String[AllLines.Count()];
                FileLocations = new String[AllLines.Count()];
                i = 0;
                foreach (string line in AllLines)
                {
                    string[] separator = new string[] {"$%$%$"};
                    string fullline = AllLines[i];
                    string[] data = fullline.Split(separator, StringSplitOptions.None);
                    FileNames[i] = data[0];
                    FileLocations[i] = data[1];
                    i += 1;
                }
                foreach (string file in FileLocations)
                {
                    if (file.Contains(".mp3") || file.Contains(".m4a") || file.Contains(".wav"))
                    {
                        MyMusicPaths.Add(file);
                    }
                }
                foreach (string file in FileLocations)
                {
                    if (file.Contains(".mp4") || file.Contains(".avi") || file.Contains(".mkv"))
                    {
                        MyVideoPaths.Add(file);
                    }
                }
                try
                { Allfiles = new Grammar(new GrammarBuilder(new Choices(FileNames))); _recognizer.LoadGrammarAsync(Allfiles); }
                catch { JARVIS.SpeakAsync("Unable to load files from Music and Video Directories"); }
            }
            catch 
            { 
                JARVIS.SpeakAsync("You do not have permission to access this folder. I will default your libraries back to My Music and My Videos");
                Settings.Default.MusicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                Settings.Default.VideoFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                Settings.Default.Save();
                sw.Close();
                File.Delete(@"C:\Users\" + Environment.UserName + "\\Documents\\Jarvis Custom Commands\\Filenames.txt");
            }
        }

        void WriteDirectories()
        {
            try
            {
                foreach (string file in MyMusic)
                {
                    string filename = Path.GetFileNameWithoutExtension(file);
                    music = TagLib.File.Create(file);
                    string Artist = music.Tag.FirstPerformer;
                    string Song = music.Tag.Title;
                    if (Artist == null)
                    {
                        {
                            if (Song == null)
                            { sw.WriteLine(filename.ToString().Replace("-", "") + "$%$%$" + file); }
                            else { sw.WriteLine(Song.ToString().Replace("-", "") + "$%$%$" + file); }
                        }
                    }
                    else if (Artist.Length > 0)
                    {
                        {
                            if (Song == null)
                            { sw.WriteLine(filename.ToString().Replace("-", "") + "$%$%$" + file); }
                            else { sw.WriteLine(Song.ToString().Replace("-", "") + " by " + Artist + "$%$%$" + file); }
                        }
                    }
                }
            }
            catch { JARVIS.SpeakAsync("Unable to load certain music files"); }
            try
            {
                foreach (string file in MyVideos)
                {
                    string videoname = Path.GetFileNameWithoutExtension(file);
                    sw.WriteLine(videoname.Replace("-", "") + "$%$%$" + file);
                }
            }
            catch { JARVIS.SpeakAsync("Unable to load certain video files"); }
        }

        private void tmrMailCheck_Tick(object sender, EventArgs e)
        {
            if (mailcheck == 0 && Settings.Default.GmailUser != String.Empty && Settings.Default.GmailPassword != String.Empty)
            {
                EmailNum = 0;
                CheckForEmails();
                mailcheck = 300;
            }
            else if (mailcheck != 0)
            { mailcheck -= 1; }
            else { mailcheck = 300; }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
