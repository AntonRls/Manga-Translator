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
    public partial class GetText : Form
    {
        LanguageModel languageModel;
        public GetText(LanguageModel model)
        {
            InitializeComponent();
            languageModel = model;
        }
        public string Enter()
        {
            ShowDialog();
            return text;
        }
        string text;

        private void GetText_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.languageProgramm == "en")
            {
                label1.Text = languageModel.English[0];
                button1.Text = languageModel.English[1];
            }
            else
            {
                label1.Text = languageModel.Russia[0];
                button1.Text = languageModel.Russia[1];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            text = textBox1.Text;
            Close();
        }
    }
}
