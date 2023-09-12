using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mangaTranslator
{
    public partial class EnterInfoOpenAI : Form
    {
        public EnterInfoOpenAI()
        {
            InitializeComponent();
        }

        private void EnterInfoOpenAI_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.languageProgramm == "en")
            {
                label1.Text = "Enter API Token";
                label2.Text = "Enter Model";
                button1.Text = "Apply";
            }

            if(Properties.Settings.Default.OpenAIApiKey != "none")
            {
                textBox1.Text = Properties.Settings.Default.OpenAIApiKey;
            }
            if(Properties.Settings.Default.OpenAIModel != "none")
            {
                textBox2.Text = Properties.Settings.Default.OpenAIModel;
            }
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.OpenAIApiKey = textBox1.Text;
            Properties.Settings.Default.OpenAIModel = textBox2.Text;
            Properties.Settings.Default.Save();

            Close();
        }
    }
}
