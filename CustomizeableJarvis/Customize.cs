using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CustomizeableJarvis.Properties;
using System.Speech.Synthesis;

namespace CustomizeableJarvis
{
    public partial class Customize : Form
    {
        string userName = Environment.UserName;
        string scpath = Settings.Default.ShellC.ToString();
        string srpath = Settings.Default.ShellR.ToString();
        string slpath = Settings.Default.ShellL.ToString();
        string webcpath = Settings.Default.WebC.ToString();
        string webrpath = Settings.Default.WebR.ToString();
        string weblpath = Settings.Default.WebL.ToString();
        string socpath = Settings.Default.SocC.ToString();
        string sorpath = Settings.Default.SocR.ToString();
        StreamReader sr;

        public Customize()
        {
            InitializeComponent();
            txtGmail.Text = Settings.Default.GmailUser;
            txtPassword.Text = Settings.Default.GmailPassword;
            sr = new StreamReader(scpath); txtShellCommands.Text = sr.ReadToEnd(); sr.Close();
            sr = new StreamReader(srpath); txtShellResponse.Text = sr.ReadToEnd(); sr.Close();
            sr = new StreamReader(slpath); txtShellLocation.Text = sr.ReadToEnd(); sr.Close();
            sr = new StreamReader(webcpath); txtWebCommands.Text = sr.ReadToEnd(); sr.Close();
            sr = new StreamReader(webrpath); txtWebResponse.Text = sr.ReadToEnd(); sr.Close();
            sr = new StreamReader(weblpath); txtWebURL.Text = sr.ReadToEnd(); sr.Close();
            sr = new StreamReader(socpath); txtSocialCommands.Text = sr.ReadToEnd(); sr.Close();
            sr = new StreamReader(sorpath); txtSocialResponse.Text = sr.ReadToEnd(); sr.Close();

            
            
            txtName.Text = Settings.Default.User.ToString(); txtWOEID.Text = Settings.Default.WOEID.ToString();
            if (Settings.Default.Temperature.ToString() == "f")
            { rbFahrenheit.Checked = true; }
            else if (Settings.Default.Temperature.ToString() == "c")
            { rbCelsius.Checked = true; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                using (StreamWriter sw = File.CreateText(scpath))
                { sw.Write(txtShellCommands.Text); sw.Close(); }
                using (StreamWriter sw = File.CreateText(srpath))
                { sw.Write(txtShellResponse.Text); sw.Close(); }
                using (StreamWriter sw = File.CreateText(slpath))
                { sw.Write(txtShellLocation.Text); sw.Close(); }
                using (StreamWriter sw = File.CreateText(webcpath))
                { sw.Write(txtWebCommands.Text); sw.Close(); }
                using (StreamWriter sw = File.CreateText(webrpath))
                { sw.Write(txtWebResponse.Text); sw.Close(); }
                using (StreamWriter sw = File.CreateText(weblpath))
                { sw.Write(txtWebURL.Text); sw.Close(); }
                using (StreamWriter sw = File.CreateText(socpath))
                { sw.Write(txtSocialCommands.Text); sw.Close(); }
                using (StreamWriter sw = File.CreateText(sorpath))
                { sw.Write(txtSocialResponse.Text); sw.Close(); }
            
            if (txtName.Text == String.Empty)
            { Settings.Default.User = userName; txtName.Text = userName; }
            else { Settings.Default.User = txtName.Text; }
            if (txtWOEID.Text == String.Empty)
            { Settings.Default.WOEID = "2347562"; txtWOEID.Text = "2347562"; }
            else { Settings.Default.WOEID = txtWOEID.Text; }
            if (rbFahrenheit.Checked == true)
            { Settings.Default.Temperature = "f"; }
            else if (rbCelsius.Checked == true)
            { Settings.Default.Temperature = "c"; }
            Settings.Default.GmailUser = txtGmail.Text;
            Settings.Default.GmailPassword = txtPassword.Text;
            Settings.Default.Save();
        }

        private void lblHelp_MouseEnter(object sender, EventArgs e)
        {
            txtHelp.Visible = true;
            if (tabUser.ContainsFocus == true)
            { txtHelp.Text = "A WOEID stands for 'Where On Earth Identifier'. This allows you to let the program know where on Earth you are so it can read you your local weather. You can find your WOEID by clicking on the link below and using your zipcode to search for your city. The example '2442047' is for Los Angeles."; }
            if (tabShell.ContainsFocus == true || tabSocial.ContainsFocus == true || tabWeb.ContainsFocus == true)
            { txtHelp.Text = "This feature allows you to create custom commands. Each command should be on it's own line just like the example. The response, file location, and URL should be on the same line as its corresponding command. Blank lines occasionally cause errors, try to avoid them. When you are done, click Save and say 'Update Commands'."; }
        }

        private void lblHelp_MouseLeave(object sender, EventArgs e)
        {
            txtHelp.Visible = false;
        }

        private void txtWOEIDSearch_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://woeid.rosselliot.co.nz/");
        }

        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = oFDSelectFile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                using (StreamWriter sw = File.CreateText(slpath))
                { sw.Write(txtShellLocation.Text); sw.Write(oFDSelectFile.FileName); sw.Close(); }
                sr = new StreamReader(slpath);
                txtShellLocation.Text = sr.ReadToEnd();
                sr.Close();
            }
        }
    }
}
