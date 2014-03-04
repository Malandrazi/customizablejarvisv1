namespace CustomizeableJarvis
{
    partial class Customize
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customize));
            this.txtHelp = new System.Windows.Forms.RichTextBox();
            this.lblHelp = new System.Windows.Forms.Label();
            this.lblSL = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtShellLocation = new System.Windows.Forms.RichTextBox();
            this.lblSR = new System.Windows.Forms.Label();
            this.lblSC = new System.Windows.Forms.Label();
            this.txtShellResponse = new System.Windows.Forms.RichTextBox();
            this.txtShellCommands = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSocialResponse = new System.Windows.Forms.RichTextBox();
            this.txtWebCommands = new System.Windows.Forms.RichTextBox();
            this.txtSocialCommands = new System.Windows.Forms.RichTextBox();
            this.txtWebResponse = new System.Windows.Forms.RichTextBox();
            this.txtWebURL = new System.Windows.Forms.RichTextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblWOEID = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtWOEID = new System.Windows.Forms.TextBox();
            this.txtWOEIDSearch = new System.Windows.Forms.RichTextBox();
            this.rbCelsius = new System.Windows.Forms.RadioButton();
            this.rbFahrenheit = new System.Windows.Forms.RadioButton();
            this.lblGmail = new System.Windows.Forms.Label();
            this.lblGmailPassword = new System.Windows.Forms.Label();
            this.txtGmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.tabCommands = new System.Windows.Forms.TabControl();
            this.tabShell = new System.Windows.Forms.TabPage();
            this.btnFileBrowse = new System.Windows.Forms.Button();
            this.tabWeb = new System.Windows.Forms.TabPage();
            this.lblWebL = new System.Windows.Forms.Label();
            this.lblWebR = new System.Windows.Forms.Label();
            this.lblWebC = new System.Windows.Forms.Label();
            this.tabSocial = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.oFDSelectFile = new System.Windows.Forms.OpenFileDialog();
            this.tabCommands.SuspendLayout();
            this.tabShell.SuspendLayout();
            this.tabWeb.SuspendLayout();
            this.tabSocial.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHelp
            // 
            this.txtHelp.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtHelp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHelp.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.txtHelp.Location = new System.Drawing.Point(43, 35);
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.ReadOnly = true;
            this.txtHelp.Size = new System.Drawing.Size(396, 115);
            this.txtHelp.TabIndex = 25;
            this.txtHelp.Text = resources.GetString("txtHelp.Text");
            this.txtHelp.Visible = false;
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.BackColor = System.Drawing.Color.Black;
            this.lblHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblHelp.Location = new System.Drawing.Point(14, 19);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(29, 13);
            this.lblHelp.TabIndex = 24;
            this.lblHelp.Text = "Help";
            this.lblHelp.MouseEnter += new System.EventHandler(this.lblHelp_MouseEnter);
            this.lblHelp.MouseLeave += new System.EventHandler(this.lblHelp_MouseLeave);
            // 
            // lblSL
            // 
            this.lblSL.AutoSize = true;
            this.lblSL.BackColor = System.Drawing.Color.Black;
            this.lblSL.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblSL.Location = new System.Drawing.Point(508, 12);
            this.lblSL.Name = "lblSL";
            this.lblSL.Size = new System.Drawing.Size(51, 13);
            this.lblSL.TabIndex = 22;
            this.lblSL.Text = "Location:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTitle.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblTitle.Location = new System.Drawing.Point(258, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(139, 13);
            this.lblTitle.TabIndex = 23;
            this.lblTitle.Text = "Creating Custom Commands";
            // 
            // txtShellLocation
            // 
            this.txtShellLocation.Location = new System.Drawing.Point(433, 37);
            this.txtShellLocation.Name = "txtShellLocation";
            this.txtShellLocation.Size = new System.Drawing.Size(205, 148);
            this.txtShellLocation.TabIndex = 16;
            this.txtShellLocation.Text = "";
            this.txtShellLocation.WordWrap = false;
            // 
            // lblSR
            // 
            this.lblSR.AutoSize = true;
            this.lblSR.BackColor = System.Drawing.Color.Black;
            this.lblSR.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblSR.Location = new System.Drawing.Point(291, 12);
            this.lblSR.Name = "lblSR";
            this.lblSR.Size = new System.Drawing.Size(58, 13);
            this.lblSR.TabIndex = 21;
            this.lblSR.Text = "Response:";
            // 
            // lblSC
            // 
            this.lblSC.AutoSize = true;
            this.lblSC.BackColor = System.Drawing.Color.Black;
            this.lblSC.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblSC.Location = new System.Drawing.Point(71, 12);
            this.lblSC.Name = "lblSC";
            this.lblSC.Size = new System.Drawing.Size(62, 13);
            this.lblSC.TabIndex = 20;
            this.lblSC.Text = "Commands:";
            // 
            // txtShellResponse
            // 
            this.txtShellResponse.Location = new System.Drawing.Point(220, 37);
            this.txtShellResponse.Name = "txtShellResponse";
            this.txtShellResponse.Size = new System.Drawing.Size(205, 148);
            this.txtShellResponse.TabIndex = 15;
            this.txtShellResponse.Text = "";
            this.txtShellResponse.WordWrap = false;
            // 
            // txtShellCommands
            // 
            this.txtShellCommands.Location = new System.Drawing.Point(6, 37);
            this.txtShellCommands.Name = "txtShellCommands";
            this.txtShellCommands.Size = new System.Drawing.Size(205, 148);
            this.txtShellCommands.TabIndex = 14;
            this.txtShellCommands.Text = "";
            this.txtShellCommands.WordWrap = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(282, 299);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSocialResponse
            // 
            this.txtSocialResponse.Location = new System.Drawing.Point(371, 38);
            this.txtSocialResponse.Name = "txtSocialResponse";
            this.txtSocialResponse.Size = new System.Drawing.Size(205, 148);
            this.txtSocialResponse.TabIndex = 28;
            this.txtSocialResponse.Text = "";
            this.txtSocialResponse.WordWrap = false;
            // 
            // txtWebCommands
            // 
            this.txtWebCommands.Location = new System.Drawing.Point(6, 37);
            this.txtWebCommands.Name = "txtWebCommands";
            this.txtWebCommands.Size = new System.Drawing.Size(205, 148);
            this.txtWebCommands.TabIndex = 29;
            this.txtWebCommands.Text = "";
            this.txtWebCommands.WordWrap = false;
            // 
            // txtSocialCommands
            // 
            this.txtSocialCommands.Location = new System.Drawing.Point(66, 38);
            this.txtSocialCommands.Name = "txtSocialCommands";
            this.txtSocialCommands.Size = new System.Drawing.Size(205, 148);
            this.txtSocialCommands.TabIndex = 30;
            this.txtSocialCommands.Text = "";
            this.txtSocialCommands.WordWrap = false;
            // 
            // txtWebResponse
            // 
            this.txtWebResponse.Location = new System.Drawing.Point(220, 37);
            this.txtWebResponse.Name = "txtWebResponse";
            this.txtWebResponse.Size = new System.Drawing.Size(205, 148);
            this.txtWebResponse.TabIndex = 31;
            this.txtWebResponse.Text = "";
            this.txtWebResponse.WordWrap = false;
            // 
            // txtWebURL
            // 
            this.txtWebURL.DetectUrls = false;
            this.txtWebURL.Location = new System.Drawing.Point(433, 37);
            this.txtWebURL.Name = "txtWebURL";
            this.txtWebURL.Size = new System.Drawing.Size(205, 148);
            this.txtWebURL.TabIndex = 32;
            this.txtWebURL.Text = "";
            this.txtWebURL.WordWrap = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Black;
            this.lblName.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblName.Location = new System.Drawing.Point(22, 45);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 34;
            this.lblName.Text = "Name:";
            // 
            // lblWOEID
            // 
            this.lblWOEID.AutoSize = true;
            this.lblWOEID.BackColor = System.Drawing.Color.Black;
            this.lblWOEID.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblWOEID.Location = new System.Drawing.Point(13, 75);
            this.lblWOEID.Name = "lblWOEID";
            this.lblWOEID.Size = new System.Drawing.Size(47, 13);
            this.lblWOEID.TabIndex = 35;
            this.lblWOEID.Text = "WOEID:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(66, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(196, 20);
            this.txtName.TabIndex = 36;
            // 
            // txtWOEID
            // 
            this.txtWOEID.Location = new System.Drawing.Point(66, 72);
            this.txtWOEID.Name = "txtWOEID";
            this.txtWOEID.Size = new System.Drawing.Size(196, 20);
            this.txtWOEID.TabIndex = 37;
            // 
            // txtWOEIDSearch
            // 
            this.txtWOEIDSearch.BackColor = System.Drawing.Color.Black;
            this.txtWOEIDSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWOEIDSearch.ForeColor = System.Drawing.SystemColors.Window;
            this.txtWOEIDSearch.Location = new System.Drawing.Point(84, 112);
            this.txtWOEIDSearch.MaximumSize = new System.Drawing.Size(148, 22);
            this.txtWOEIDSearch.MinimumSize = new System.Drawing.Size(148, 22);
            this.txtWOEIDSearch.Name = "txtWOEIDSearch";
            this.txtWOEIDSearch.ReadOnly = true;
            this.txtWOEIDSearch.Size = new System.Drawing.Size(148, 22);
            this.txtWOEIDSearch.TabIndex = 38;
            this.txtWOEIDSearch.Text = "http://woeid.rosselliot.co.nz/";
            this.txtWOEIDSearch.Click += new System.EventHandler(this.txtWOEIDSearch_Click);
            // 
            // rbCelsius
            // 
            this.rbCelsius.AutoSize = true;
            this.rbCelsius.BackColor = System.Drawing.Color.Black;
            this.rbCelsius.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.rbCelsius.Location = new System.Drawing.Point(272, 93);
            this.rbCelsius.Name = "rbCelsius";
            this.rbCelsius.Size = new System.Drawing.Size(58, 17);
            this.rbCelsius.TabIndex = 39;
            this.rbCelsius.TabStop = true;
            this.rbCelsius.Text = "Celsius";
            this.rbCelsius.UseVisualStyleBackColor = false;
            // 
            // rbFahrenheit
            // 
            this.rbFahrenheit.AutoSize = true;
            this.rbFahrenheit.BackColor = System.Drawing.Color.Black;
            this.rbFahrenheit.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.rbFahrenheit.Location = new System.Drawing.Point(272, 72);
            this.rbFahrenheit.Name = "rbFahrenheit";
            this.rbFahrenheit.Size = new System.Drawing.Size(75, 17);
            this.rbFahrenheit.TabIndex = 40;
            this.rbFahrenheit.TabStop = true;
            this.rbFahrenheit.Text = "Fahrenheit";
            this.rbFahrenheit.UseVisualStyleBackColor = false;
            // 
            // lblGmail
            // 
            this.lblGmail.AutoSize = true;
            this.lblGmail.BackColor = System.Drawing.Color.Black;
            this.lblGmail.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblGmail.Location = new System.Drawing.Point(390, 45);
            this.lblGmail.Name = "lblGmail";
            this.lblGmail.Size = new System.Drawing.Size(36, 13);
            this.lblGmail.TabIndex = 41;
            this.lblGmail.Text = "Gmail:";
            // 
            // lblGmailPassword
            // 
            this.lblGmailPassword.AutoSize = true;
            this.lblGmailPassword.BackColor = System.Drawing.Color.Black;
            this.lblGmailPassword.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblGmailPassword.Location = new System.Drawing.Point(370, 75);
            this.lblGmailPassword.Name = "lblGmailPassword";
            this.lblGmailPassword.Size = new System.Drawing.Size(56, 13);
            this.lblGmailPassword.TabIndex = 42;
            this.lblGmailPassword.Text = "Password:";
            // 
            // txtGmail
            // 
            this.txtGmail.Location = new System.Drawing.Point(432, 42);
            this.txtGmail.Name = "txtGmail";
            this.txtGmail.Size = new System.Drawing.Size(196, 20);
            this.txtGmail.TabIndex = 43;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(432, 72);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(196, 20);
            this.txtPassword.TabIndex = 44;
            // 
            // tabCommands
            // 
            this.tabCommands.Controls.Add(this.tabShell);
            this.tabCommands.Controls.Add(this.tabWeb);
            this.tabCommands.Controls.Add(this.tabSocial);
            this.tabCommands.Controls.Add(this.tabUser);
            this.tabCommands.Location = new System.Drawing.Point(17, 57);
            this.tabCommands.Name = "tabCommands";
            this.tabCommands.SelectedIndex = 0;
            this.tabCommands.Size = new System.Drawing.Size(652, 240);
            this.tabCommands.TabIndex = 45;
            // 
            // tabShell
            // 
            this.tabShell.BackgroundImage = global::CustomizeableJarvis.Properties.Resources.Jarvis2;
            this.tabShell.Controls.Add(this.btnFileBrowse);
            this.tabShell.Controls.Add(this.txtShellCommands);
            this.tabShell.Controls.Add(this.lblSL);
            this.tabShell.Controls.Add(this.txtShellResponse);
            this.tabShell.Controls.Add(this.txtShellLocation);
            this.tabShell.Controls.Add(this.lblSR);
            this.tabShell.Controls.Add(this.lblSC);
            this.tabShell.Location = new System.Drawing.Point(4, 22);
            this.tabShell.Name = "tabShell";
            this.tabShell.Padding = new System.Windows.Forms.Padding(3);
            this.tabShell.Size = new System.Drawing.Size(644, 214);
            this.tabShell.TabIndex = 0;
            this.tabShell.Text = "Shell Commands";
            this.tabShell.UseVisualStyleBackColor = true;
            // 
            // btnFileBrowse
            // 
            this.btnFileBrowse.Location = new System.Drawing.Point(509, 188);
            this.btnFileBrowse.Name = "btnFileBrowse";
            this.btnFileBrowse.Size = new System.Drawing.Size(50, 23);
            this.btnFileBrowse.TabIndex = 48;
            this.btnFileBrowse.Text = "Browse";
            this.btnFileBrowse.UseVisualStyleBackColor = true;
            this.btnFileBrowse.Click += new System.EventHandler(this.btnFileBrowse_Click);
            // 
            // tabWeb
            // 
            this.tabWeb.BackgroundImage = global::CustomizeableJarvis.Properties.Resources.Jarvis2;
            this.tabWeb.Controls.Add(this.txtWebURL);
            this.tabWeb.Controls.Add(this.txtWebResponse);
            this.tabWeb.Controls.Add(this.txtWebCommands);
            this.tabWeb.Controls.Add(this.lblWebL);
            this.tabWeb.Controls.Add(this.lblWebR);
            this.tabWeb.Controls.Add(this.lblWebC);
            this.tabWeb.Location = new System.Drawing.Point(4, 22);
            this.tabWeb.Name = "tabWeb";
            this.tabWeb.Padding = new System.Windows.Forms.Padding(3);
            this.tabWeb.Size = new System.Drawing.Size(644, 214);
            this.tabWeb.TabIndex = 1;
            this.tabWeb.Text = "Web Commands";
            this.tabWeb.UseVisualStyleBackColor = true;
            // 
            // lblWebL
            // 
            this.lblWebL.AutoSize = true;
            this.lblWebL.BackColor = System.Drawing.Color.Black;
            this.lblWebL.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblWebL.Location = new System.Drawing.Point(508, 12);
            this.lblWebL.Name = "lblWebL";
            this.lblWebL.Size = new System.Drawing.Size(51, 13);
            this.lblWebL.TabIndex = 35;
            this.lblWebL.Text = "Location:";
            // 
            // lblWebR
            // 
            this.lblWebR.AutoSize = true;
            this.lblWebR.BackColor = System.Drawing.Color.Black;
            this.lblWebR.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblWebR.Location = new System.Drawing.Point(291, 12);
            this.lblWebR.Name = "lblWebR";
            this.lblWebR.Size = new System.Drawing.Size(58, 13);
            this.lblWebR.TabIndex = 34;
            this.lblWebR.Text = "Response:";
            // 
            // lblWebC
            // 
            this.lblWebC.AutoSize = true;
            this.lblWebC.BackColor = System.Drawing.Color.Black;
            this.lblWebC.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblWebC.Location = new System.Drawing.Point(71, 12);
            this.lblWebC.Name = "lblWebC";
            this.lblWebC.Size = new System.Drawing.Size(62, 13);
            this.lblWebC.TabIndex = 33;
            this.lblWebC.Text = "Commands:";
            // 
            // tabSocial
            // 
            this.tabSocial.BackColor = System.Drawing.Color.Transparent;
            this.tabSocial.BackgroundImage = global::CustomizeableJarvis.Properties.Resources.Jarvis2;
            this.tabSocial.Controls.Add(this.label1);
            this.tabSocial.Controls.Add(this.label2);
            this.tabSocial.Controls.Add(this.txtSocialCommands);
            this.tabSocial.Controls.Add(this.txtSocialResponse);
            this.tabSocial.Location = new System.Drawing.Point(4, 22);
            this.tabSocial.Name = "tabSocial";
            this.tabSocial.Size = new System.Drawing.Size(644, 214);
            this.tabSocial.TabIndex = 2;
            this.tabSocial.Text = "Social Commands";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.label1.Location = new System.Drawing.Point(447, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Response:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.label2.Location = new System.Drawing.Point(140, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Commands:";
            // 
            // tabUser
            // 
            this.tabUser.BackgroundImage = global::CustomizeableJarvis.Properties.Resources.Jarvis2;
            this.tabUser.Controls.Add(this.txtName);
            this.tabUser.Controls.Add(this.txtWOEIDSearch);
            this.tabUser.Controls.Add(this.txtWOEID);
            this.tabUser.Controls.Add(this.lblWOEID);
            this.tabUser.Controls.Add(this.lblName);
            this.tabUser.Controls.Add(this.rbCelsius);
            this.tabUser.Controls.Add(this.lblGmail);
            this.tabUser.Controls.Add(this.rbFahrenheit);
            this.tabUser.Controls.Add(this.lblGmailPassword);
            this.tabUser.Controls.Add(this.txtPassword);
            this.tabUser.Controls.Add(this.txtGmail);
            this.tabUser.Location = new System.Drawing.Point(4, 22);
            this.tabUser.Name = "tabUser";
            this.tabUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabUser.Size = new System.Drawing.Size(644, 214);
            this.tabUser.TabIndex = 3;
            this.tabUser.Text = "User Info";
            this.tabUser.UseVisualStyleBackColor = true;
            // 
            // oFDSelectFile
            // 
            this.oFDSelectFile.CheckFileExists = false;
            this.oFDSelectFile.ValidateNames = false;
            // 
            // Customize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CustomizeableJarvis.Properties.Resources.Jarvis1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 328);
            this.Controls.Add(this.txtHelp);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabCommands);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 367);
            this.MinimumSize = new System.Drawing.Size(700, 347);
            this.Name = "Customize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customize";
            this.tabCommands.ResumeLayout(false);
            this.tabShell.ResumeLayout(false);
            this.tabShell.PerformLayout();
            this.tabWeb.ResumeLayout(false);
            this.tabWeb.PerformLayout();
            this.tabSocial.ResumeLayout(false);
            this.tabSocial.PerformLayout();
            this.tabUser.ResumeLayout(false);
            this.tabUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtHelp;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RichTextBox txtShellLocation;
        private System.Windows.Forms.Label lblSR;
        private System.Windows.Forms.Label lblSC;
        private System.Windows.Forms.RichTextBox txtShellResponse;
        private System.Windows.Forms.RichTextBox txtShellCommands;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox txtSocialResponse;
        private System.Windows.Forms.RichTextBox txtWebCommands;
        private System.Windows.Forms.RichTextBox txtSocialCommands;
        private System.Windows.Forms.RichTextBox txtWebResponse;
        private System.Windows.Forms.RichTextBox txtWebURL;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblWOEID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtWOEID;
        private System.Windows.Forms.RichTextBox txtWOEIDSearch;
        private System.Windows.Forms.RadioButton rbCelsius;
        private System.Windows.Forms.RadioButton rbFahrenheit;
        private System.Windows.Forms.Label lblGmail;
        private System.Windows.Forms.Label lblGmailPassword;
        private System.Windows.Forms.TextBox txtGmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TabControl tabCommands;
        private System.Windows.Forms.TabPage tabShell;
        private System.Windows.Forms.TabPage tabWeb;
        private System.Windows.Forms.TabPage tabSocial;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.Label lblWebL;
        private System.Windows.Forms.Label lblWebR;
        private System.Windows.Forms.Label lblWebC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFileBrowse;
        private System.Windows.Forms.OpenFileDialog oFDSelectFile;
    }
}