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
    public partial class seePictureForm : Form
    {
        public seePictureForm(Image image)
        {
            InitializeComponent();

            pictureBox1.Width = image.Width;
            pictureBox1.Height = image.Height;
            pictureBox1.Image = image;
        }

        private void seePictureForm_Load(object sender, EventArgs e)
        {

        }
    }
}
