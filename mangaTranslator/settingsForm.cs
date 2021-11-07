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
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/toshadev");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/toshadev");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        
            System.Diagnostics.Process.Start("https://vk.com/id214330981");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.languageProgramm == "en")
            {
                textBox1.Text = "This program is free, if it was sold to you, then you were deceived.\n\n Using the program is very simple. In the text field with the name \"enter the original path to the manga\" you need to specify the path to the folder where the manga is located, in the original language. In the text field with the name \"enter the path to save the manga\" you need to specify the path to the folder where the translated manga will be saved. As soon as you fill in these two fields and click on the \"Apply\" button, in the left part of the program you will see a picture in the original language, select the part of the picture where you need to translate (only one phrase. For a more accurate translation, try not to include anything except the text in the area you selected), then in the right part of the program you will be shown the area that will be translated, if everything is in order, then click the \"Select\" button and after a while you will see the result, if the translation is incorrect, then in the field that is under the \"Select\" button, enter the correct translation, and then click on the \"Save and next\" button, the picture with the translation will be saved";
                button1.Text = "Contact the developer";


            }
            else if (Properties.Settings.Default.languageProgramm == "ru")
            {
                textBox1.Text = "Эта программа бесплатна, если она была продана вам, значит, вас обманули.\n\nПользоваться программой очень просто. В текстовом поле с названием \"Введите путь к оригинальной манги\" вам необходимо указать путь к папке, в которой находится манга, на оригинальном языке. В текстовом поле с названием \"Введите путь, куда будет сохранена манга\" вам необходимо указать путь к папке, в которой будет сохранена переведенная манга. Как только вы заполните эти два поля и нажмете на кнопку  \"Применить\", в левой части программы у вас появится картинка на оригинальном языке, выберите ту часть картинки, где вам нужно перевести (только одну фразу. Для более точного перевода, постарайтесь что бы кроме текста в выбранной вами области ничего не входило ), затем в правой части программы вам будет показана область, которая будет переведена, если все в порядке, затем нажмите кнопку \"Выбрать\" и через некоторое время вы увидите результат, если перевод неверен, то в поле, которое находится под кнопкой \"Выбрать\", введите правильный перевод, а затем нажмите на кнопке \"Сохранить и далее\", картинка с переводом будет сохранена";
                button1.Text = "Связаться с разработчиком";
            }

        }
    }
}
