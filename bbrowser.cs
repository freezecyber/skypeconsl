using System;
using System.Windows.Forms;

namespace server
{
    public partial class bbrowser : Form
    {
        System.Speech.Synthesis.SpeechSynthesizer say = new System.Speech.Synthesis.SpeechSynthesizer();
        public bbrowser()
        {
            InitializeComponent();
        }

        private void skype_Load(object sender, EventArgs e)
        {
            
            try
            {
                this.Text = "SKYPE";
                this.webBrowser1.ScriptErrorsSuppressed = true;
                webBrowser1.ObjectForScripting = true;

                if (textBox1.Text != "")
                    webBrowser1.Navigate(textBox1.Text);

                webBrowser1.ProgressChanged +=
                new WebBrowserProgressChangedEventHandler(webpage_ProgressChanged);
                webBrowser1.DocumentTitleChanged +=
                new EventHandler(webpage_DocumentTitleChanged);
                webBrowser1.StatusTextChanged += new EventHandler(webpage_StatusTextChanged);
                webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(webpage_Navigated);
                webBrowser1.DocumentCompleted +=
                new WebBrowserDocumentCompletedEventHandler(webpage_DocumentCompleted);



                webBrowser1.Navigate(skypconsol.Properties.Settings.Default.skype1);
                say.SpeakAsync("skype loading");
            }
            catch { }
        }
        private void webpage_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.CanGoBack) backToolStripMenuItem.Enabled = true;
            else backToolStripMenuItem.Enabled = false;

            if (webBrowser1.CanGoForward) forwrdToolStripMenuItem.Enabled = true;
            else forwrdToolStripMenuItem.Enabled = false;
            textToolStripMenuItem.Text = "Done";
        }

        private void webpage_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.Text = webBrowser1.DocumentTitle.ToString();
        }

        private void webpage_StatusTextChanged(object sender, EventArgs e)
        {
            textToolStripMenuItem.Text = webBrowser1.StatusText;
        }

        private void webpage_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            progressBar1.Maximum = (int)e.MaximumProgress;
            progressBar1.Value = ((int)e.CurrentProgress < 0 ||
            (int)e.MaximumProgress < (int)e.CurrentProgress) ?
            (int)e.MaximumProgress : (int)e.CurrentProgress;
        }

        private void webpage_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
          
            textToolStripMenuItem.Text = webBrowser1.Url.ToString();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                say.SpeakAsync("ok");
                webBrowser1.Navigate(textBox1.Text);
            }
        }

        private void changeUrlToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            say.SpeakAsync("saving");
            panel2.Visible = true;
            skypconsol.Properties.Settings.Default.skype1 = webBrowser1.Url.ToString();
            skypconsol.Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            say.SpeakAsync("reset");
            webBrowser1.Navigate(skypconsol.Properties.Settings.Default.skype1);

        }

        private void backToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            say.SpeakAsync("back");
            webBrowser1.GoBack();

            

        }

        private void panelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if(panel2.Visible)
            {
                say.SpeakAsync("off");
                panel2.Visible = false;
            }
            else
            {
                say.SpeakAsync("on");
                panel2.Visible = true;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void forwrdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            say.SpeakAsync("avant");
            webBrowser1.GoForward();
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            say.SpeakAsync("ok");
            Clipboard.SetText(textToolStripMenuItem.Text);
          
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            say.SpeakAsync("refresh");
            webBrowser1.Refresh();
        }

        private void webbrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            say.SpeakAsync("home");
            webBrowser1.GoHome();
        }
    }
}
