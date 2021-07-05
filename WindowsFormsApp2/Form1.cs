using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Resources;

namespace WindowsFormsApp2
{
    public partial class Multilingual : Form
    {
        public string language = Properties.Settings.Default.Language;
        public Multilingual()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int noItem;
            //decimal priceItem, price;
            //noItem = Convert.ToInt16(NoItems.Text);
            //priceItem = Convert.ToDecimal(PriceItem.Text);
            //price = priceItem * noItem;
            //lblDisplay.Text = price.ToString("C", CultureInfo.CurrentUICulture);

            ComponentResourceManager resources = new ComponentResourceManager(typeof(Multilingual));
            String msg = resources.GetString("MensagemErro");
            MessageBox.Show(msg);
        }

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(Multilingual));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgChangeLanguage dialog = new dlgChangeLanguage();
            if (dialog.ShowDialog() == DialogResult.Yes)
            {
                //Change Language to English
                language = "en-US";
                englishToolStripMenuItem.Checked = true;
                frenchToolStripMenuItem.Checked = false;
                españolToolStripMenuItem.Checked = false;

                //Save user choice in settings
                Properties.Settings.Default.Language = "en-US";
                Properties.Settings.Default.Save();

                Application.Restart();
            }
        }


        private void frenchToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dlgChangeLanguage dialog = new dlgChangeLanguage();
            if (dialog.ShowDialog() == DialogResult.Yes)
            {
                //Change Language to French
                language = "fr-FR";
                englishToolStripMenuItem.Checked = false;
                frenchToolStripMenuItem.Checked = true;
                españolToolStripMenuItem.Checked = false;

                //Save user choice in settings
                Properties.Settings.Default.Language = "fr-FR";
                Properties.Settings.Default.Save();

                Application.Restart();
            }
        }

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgChangeLanguage dialog = new dlgChangeLanguage();
            if (dialog.ShowDialog() == DialogResult.Yes)
            {
                //Change Language to Spanish
                language = "es-ES";
                englishToolStripMenuItem.Checked = false;
                frenchToolStripMenuItem.Checked = false;
                españolToolStripMenuItem.Checked = true;

                //Save user choice in settings
                Properties.Settings.Default.Language = "es-ES";
                Properties.Settings.Default.Save();

                Application.Restart();
            }
        }

        private void NoItems_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                dlgChangeLanguage dialog = new dlgChangeLanguage();
                dialog.ShowDialog();
                e.Handled = true;
            }
        }


    }
}
