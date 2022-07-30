using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mangaTranslator
{
    public partial class settingForm : Form
    {
        public settingForm()
        {
            InitializeComponent();
         
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://ironsoftware.com/csharp/ocr/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox2.Text != null)
            {
                Properties.Settings.Default.licenseKey = textBox2.Text;
                
            }
            if (radioButton1.Checked)
            {
                Properties.Settings.Default.languageProgramm = "ru";
            }
            else if (radioButton2.Checked)
            {
                Properties.Settings.Default.languageProgramm = "en";
            }
            Properties.Settings.Default.languageTranslate = textBox5.Text;
            Properties.Settings.Default.scaningImage = checkBox1.Checked;
            Properties.Settings.Default.translate = checkBox2.Checked;
            Properties.Settings.Default.Save();
            Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
          //  radioButton1.Checked = true;
         //   radioButton2.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox2.Enabled = false;
            }
            else
            {
                checkBox2.Checked = true;
                checkBox2.Enabled = true;
            }
        }

        private void settingForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.licenseKey != "none")
            {
                textBox2.Text = Properties.Settings.Default.licenseKey;
            }
            textBox5.Text = Properties.Settings.Default.languageTranslate;
            checkBox1.Checked = Properties.Settings.Default.scaningImage;
            checkBox2.Checked = Properties.Settings.Default.translate;
            if (!checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox2.Enabled = false;
            }
            if (Properties.Settings.Default.languageProgramm == "en")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;

                textBox1.Text = "The program uses IronOCR technology to recognize text in the image. In order for the program to work normally, you need to get a license key. To get it, go to the website listed below and click on the \"Free 30 - Day Trial Key\" button, after which you will receive a message with the key in this form: IronOcr.Installation.LicenseKey = \"KEY\"; from this line you need to copy everything that is in quotes. In our case, this is the KEY label and paste it into the text field below";
                linkLabel4.Text = "Get Key";
                textBox4.Text = "Select the language into which the translation will be made, and write it down in this format: \"Russia, ru\", where \"Russia\" is the full name of the language from which the translation will be made, and \"ru\" is the two-letter country code";
                checkBox1.Text = "Scanning text from an image (Translation will not work if disabled)";
                checkBox2.Text = "Text translation";
                groupBox1.Text = "Translation service";
                groupBox2.Text = "Interface language";
                radioButton1.Text = "Russia";
                radioButton2.Text = "English";
                button1.Text = "Apply";
            }
            else if (Properties.Settings.Default.languageProgramm == "ru")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;

                textBox1.Text = "Программа использует технологию Iron OCR для распознавания текста на изображении. Для того чтобы программа работала нормально, вам необходимо получить лицензионный ключ. Чтобы получить его, перейдите на веб-сайт, указанный ниже, и нажмите кнопку \"Free 30 - Day Trial Key\", после чего вы получите сообщение с ключом в следующей форме: IronOcr.Установка.LicenseKey = \"KEY\"; из этой строки вам нужно скопировать все, что находится в кавычках. В нашем случае это KEY и вставьте его в текстовое поле ниже";
                linkLabel4.Text = "Получить ключ";
                textBox4.Text = "Выберите язык для перевода и запишите его в следующем формате: \"Russia, ru\", где \"Russia\" - полное название языка, с которого будет выполняться перевод, а \"ru\" - двухбуквенный код страны";
                checkBox1.Text = "Сканирование текста с картинки (Если отключено, то текст не будет переводиться)";
                checkBox2.Text = "Перевод текста";
                groupBox1.Text = "Сервис для перевода";
                groupBox2.Text = "Язык интерфейсаа";
                radioButton1.Text = "Русский";
                radioButton2.Text = "Английский";
                button1.Text = "Применить";
            }
         
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Properties.Settings.Default.TrasnlationService = "yandex";
                Properties.Settings.Default.Save();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Properties.Settings.Default.TrasnlationService = "google";
                Properties.Settings.Default.Save();
            }
        }
    }
}
