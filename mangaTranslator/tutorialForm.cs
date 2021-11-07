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
    public partial class tutorialForm : Form
    {
        public tutorialForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tutorialForm_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.languageProgramm == "ru")
            {
                textBox1.Text = "Хотя сканирование текста по фотографии работает довольно хорошо, но оно не идеально. Для более четкого перевода я рекомендую использовать инструмент Прямоугольник, выделяя им только текст, затем перевести этот текст и, при необходимости, вставить его с помощью инструмента Круг. Для этого выберите инструмент \"Круг\", выберите область, в которую вы хотите вставить текст, нажмите кнопку \"Выбрать\", скорее всего, у вас будут непонятные символы в текстовом поле, чтобы изменить их, просто вставьте текст, который вы получили с помощью инструмента \"Прямоугольник\" в поле под кнопкой \"Выбрать\"";
            }
            else if(Properties.Settings.Default.languageProgramm == "en")
            { 
                textBox1.Text = "Although scanning text by photo works pretty well, but it's not perfect. For a clearer translation, I recommend using the Rectangle tool, highlighting only the text with it, then translate this text and, if appropriate, insert it using the Circle tool. To do this, select the \"Circle\" tool, select the area where you want to insert the text, click on the \"Select\" button, most likely you will have incomprehensible characters in the text field to change them, just insert the text that you got using the \"Rectangle\" tool in the field below the \"Select\" button";
            }
        }
    }
}
