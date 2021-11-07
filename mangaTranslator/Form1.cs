
using GoogleTranslateFreeApi;
using IronOcr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace mangaTranslator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //tools panel
            button4.BackColor = Color.White;
            button3.BackColor = Color.Gray;

            InfoSave.Add(new saveInfo
            {
                type = "first"
            });


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();

            opf.ShowDialog();

            if (opf.FileName != "")
            {
                Image img = Image.FromFile(opf.FileName);
       
                mangaPicture.Image = img;


                originalImage = mangaPicture.Image;
                originalImageForResize = originalImage;
                mangaPicture.Image = ResizeNow(originalImage.Width * trackBar1.Value / 100, originalImage.Height * trackBar1.Value / 100);

            }
        }



        private string getText(Image imgsource)
        {
            try
            {
                var Ocr = new IronTesseract();
                Ocr.Configuration.TesseractVersion = TesseractVersion.Tesseract5;
                IronOcr.Installation.LicenseKey = Properties.Settings.Default.licenseKey; 
                using (var Input = new OcrInput())
                {
                    if (checkBox1.Checked)
                    {
                        Ocr.Language = OcrLanguage.JapaneseVerticalBest;
                    }
                    else
                    {
                        Ocr.Language = OcrLanguage.JapaneseBest;
                    }
                    Input.AddImage(imgsource);
                    //  Input.Deskew();  // use if image not straight
                    //   Input.DeNoise(); // use if image contains digital noise

                    var Result = Ocr.Read(Input);

                    return Result.Text;
                }
            }
            catch
            {
                if (Properties.Settings.Default.languageProgramm == "ru")
                {
                    MessageBox.Show("Введённый вами ключ не действителен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (Properties.Settings.Default.languageProgramm == "en")
                {
                    MessageBox.Show("The key you entered is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                return "error";
            }
        }

        //crop Image
        Point p1;
        Point p2;

        bool isClicked = false;
        private void mangaPicture_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = new Point(e.Location.X, e.Location.Y);
            isClicked = true;
        }
        Rectangle cloneRect;
        private void mangaPicture_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                p2 = new Point(e.Location.X, e.Location.Y);
                if (p2.X - p1.X > 5 && isClicked || p1.X - p2.X > 5 && isClicked)
                {
                    if (e.Location.X >= mangaPicture.Width)
                    {
                        p2.X = mangaPicture.Width - 1;
                    }
                    if (e.Location.Y >= mangaPicture.Height)
                    {
                        p2.Y = mangaPicture.Height - 1;
                    }
                    if (e.Location.X <= 0)
                    {
                        p2.X = 5;
                    }
                    if (e.Location.Y <= 0)
                    {
                        p2.Y = 5;
                    }
                    isClicked = false;
                    cloneRect = GetRect(p1, p2);

                    cloneRect.Intersect(new Rectangle(cloneRect.X, cloneRect.Y, mangaPicture.Width, mangaPicture.Height));

                    Image img = (Bitmap)CropImage(new Bitmap(mangaPicture.Image, mangaPicture.Size), cloneRect);
                    imgCroped = img;
                    pictureBox1.Image = img;

                    bmp = new Bitmap(mangaPicture.Image, mangaPicture.ClientSize.Width, mangaPicture.ClientSize.Height);
                    Graphics gr = Graphics.FromImage(bmp);
                    if (currentTool == Tools.Rectangle)
                    {
                        gr.FillRectangle(new SolidBrush(backColor), cloneRect);
                    }
                    else if (currentTool == Tools.Circle)
                    {
                        gr.FillEllipse(new SolidBrush(backColor), cloneRect);
                    }
                    InfoSave.Add(new saveInfo
                    {
                        type = "addFigura",
                        rectangle = cloneRect,
                        toolC = currentTool,
                        brush = new SolidBrush(backColor)
                    });
                    mangaPicture.Image = bmp;
                
                }
            }
            catch
            {
                mangaPicture.Image = originalImage;
            }
        }
        Bitmap bmp;
        private Image CropImage(Image img, Rectangle cropArea)
        {
            try
            {
                Bitmap bmpImage = new Bitmap(img);
                Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
                return (Image)(bmpCrop);
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        Rectangle GetRect(Point p1, Point p2)
        {
            var x1 = Math.Min(p1.X, p2.X);
            var x2 = Math.Max(p1.X, p2.X);
            var y1 = Math.Min(p1.Y, p2.Y);
            var y2 = Math.Max(p1.Y, p2.Y);
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }
        private void mangaPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isClicked)
            {
                p2 = new Point(e.Location.X, e.Location.Y);
                if (e.Location.X >= mangaPicture.Width)
                {
                    p2.X = mangaPicture.Width - 1;
                }
                if (e.Location.Y >= mangaPicture.Height)
                {
                    p2.Y = mangaPicture.Height - 1;
                }
                if (e.Location.X <= 0)
                {
                    p2.X = 5;
                }
                if (e.Location.Y <= 0)
                {
                    p2.Y = 5;
                }

                mangaPicture.Invalidate();
            }
        }
        Image imgCroped;
        Graphics graphics;
        private void mangaPicture_Paint(object sender, PaintEventArgs e)
        {
            if (isClicked)
            {
                Pen blackPen = new Pen(Color.Black, 4);
                if (currentTool == Tools.Rectangle)
                {
                    e.Graphics.DrawRectangle(blackPen, GetRect(p1, p2));
                }
                if (currentTool == Tools.Circle)
                {
                    e.Graphics.DrawEllipse(blackPen, GetRect(p1, p2));
                }


                blackPen.Dispose();
                graphics = e.Graphics;
            }


        }
        //end crop image


        private void button2_Click(object sender, EventArgs e)
        {
            translate();
        }
        private async Task<string> translate()
        {
            if (Properties.Settings.Default.scaningImage)
            {
                string text = getText(imgCroped).Replace(Environment.NewLine, "");
                if (text != "error")
                {
                    label1.Text = text;
                    if (Properties.Settings.Default.translate)
                    {
                        if (Properties.Settings.Default.languageProgramm == "en")
                        {
                            label1.Text = "Translating...";
                        }
                        else if (Properties.Settings.Default.languageProgramm == "ru")
                        {
                            label1.Text = "Идёт перевод перевод...";
                        }
                        var translator = new GoogleTranslator();

                        Language from = GoogleTranslator.GetLanguageByName("Japanese");
                        string[] toLan = Properties.Settings.Default.languageTranslate.Replace(" ", "").Split(',');
                        Language to = new Language(toLan[0], toLan[1]);

                        TranslationResult result = await translator.TranslateLiteAsync(text, from, to);


                        label1.Text = result.MergedTranslation;
                    }
                }
            }
            updateFontSettings();
            mangaPicture.Image = bmp;

            return null;
            
        }
   

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm st = new settingsForm();
            st.ShowDialog();
        }
        FontStyle fs = FontStyle.Regular;
        private void label1_TextChanged(object sender, EventArgs e)
        {
            updateFontSettings();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            updateFontSettings();
        }



        private void updateFontSettings()
        {
            try
            {
                Graphics gr = Graphics.FromImage(bmp);
                if (currentTool == Tools.Rectangle)
                {
                    gr.FillRectangle(new SolidBrush(backColor), cloneRect);
                    InfoSave.Add(new saveInfo
                    {
                        brush = new SolidBrush(backColor),
                        rectangle = cloneRect,
                        type = "addFigura",
                        toolC = currentTool
                    });
                }
                else if (currentTool == Tools.Circle)
                {
                    gr.FillEllipse(new SolidBrush(backColor), cloneRect);
                    InfoSave.Add(new saveInfo
                    {
                        brush = new SolidBrush(backColor),
                        rectangle = cloneRect,
                        type = "addFigura",
                        toolC = currentTool
                    });
                }

                PrivateFontCollection font1 = new PrivateFontCollection();
                font1.AddFontFile("AnimeAce.ttf");
                Font font = new Font(font1.Families[0], (float)numericUpDown1.Value, fs);
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                gr.DrawString(label1.Text, font, new SolidBrush(fontColor), GetRect(p1, p2), sf);
                InfoSave.Add(new saveInfo
                {
                    brush = new SolidBrush(fontColor),
                    rectangle = GetRect(p1,p2),
                    type = "addText",
                    font = font,
                    text = label1.Text
                });
                mangaPicture.Image = bmp;

                float cofIdth = originalImage.Width * originalImage.Height;
                float cofHeight = mangaPicture.Width * originalImage.Height;

                float MainCof = cofIdth / cofHeight;

                Bitmap bb = new Bitmap(originalImage, originalImage.Width, originalImage.Height);
                Graphics gra = Graphics.FromImage(bb);
                Rectangle rc = cloneRect;
                rc.Width = int.Parse(Math.Round(float.Parse(cloneRect.Width.ToString()) * MainCof).ToString());
                rc.Height = int.Parse(Math.Round(float.Parse(cloneRect.Height.ToString()) * MainCof).ToString());
                rc.Y = int.Parse(Math.Round(float.Parse(cloneRect.Y.ToString()) * MainCof).ToString());
                rc.X = int.Parse(Math.Round(float.Parse(cloneRect.X.ToString()) * MainCof).ToString());
                if (currentTool == Tools.Rectangle)
                {
                    gra.FillRectangle(new SolidBrush(backColor), rc);
                }
                else if (currentTool == Tools.Circle)
                {
                    gra.FillEllipse(new SolidBrush(backColor), rc);
                }
              
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                Font font2 = new Font(font1.Families[0], int.Parse(Math.Round((float)numericUpDown1.Value * MainCof).ToString()), fs);
                gra.DrawString(label1.Text, font2, new SolidBrush(fontColor), rc, sf);
                originalImage = bb;
                mangaPicture.Image = ResizeNow(originalImage.Width * trackBar1.Value / 100, originalImage.Height * trackBar1.Value / 100);

            }
            catch {  }
        }
    
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 2)
            {
                fs = FontStyle.Regular;
                updateFontSettings();
            }
            else if (comboBox1.SelectedIndex == 0)
            {
                fs = FontStyle.Bold;
                updateFontSettings();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                fs = FontStyle.Italic;
                updateFontSettings();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                fs = FontStyle.Strikeout;
                updateFontSettings();
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                fs = FontStyle.Underline;
                updateFontSettings();
            }
            else
            {
                fs = FontStyle.Regular;
                updateFontSettings();
            }
        }
        Tools currentTool = Tools.Rectangle;
        public enum Tools
        {
            Rectangle,
            Circle
        };

        private void button3_Click(object sender, EventArgs e)
        {
            currentTool = Tools.Rectangle;
            button4.BackColor = Color.White;
            button3.BackColor = Color.Gray;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentTool = Tools.Circle;
            button3.BackColor = Color.White;
            button4.BackColor = Color.Gray;
        }
        public List<saveInfo> InfoSave = new List<saveInfo>(1);
        public struct saveInfo
        {
            public string type;
            public Rectangle rectangle;
            public Font font;
            public string text;
            public Brush brush;
            public Tools toolC;
            public Pen pen;
        }

        bool controlPress = false;
        public Image originalImage;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                controlPress = true;
           
            }
            if (e.KeyCode == Keys.Z && controlPress) 
            {
                try
                {
                    InfoSave.RemoveAt(InfoSave.Count - 1);
                    bmp = new Bitmap(originalImage, mangaPicture.ClientSize.Width, mangaPicture.ClientSize.Height);
                    Graphics gr = Graphics.FromImage(bmp);

                    foreach (saveInfo sf in InfoSave)
                    {
                        if (sf.type == "first")
                        {

                        }
                        else if (sf.type == "addFigura")
                        {

                            if (sf.toolC == Tools.Rectangle)
                            {
                                gr.FillRectangle(sf.brush, sf.rectangle);
                            }
                            else if (sf.toolC == Tools.Circle)
                            {
                                gr.FillEllipse(sf.brush, sf.rectangle);
                            }
                        }
                       
                    }
                    mangaPicture.Image = bmp;
                }
                catch
                {
                     
                }
            }
        }
       
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (controlPress)
            {
                if(e.KeyCode == Keys.ControlKey)
                {
                    controlPress = false;
                }
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new tutorialForm().ShowDialog();
        }
        string pathSaveFolder;
        string pathSourceFolder;
        string[] namesSourceFile;
        private void button6_Click(object sender, EventArgs e)
        {
            pathSaveFolder = textBox2.Text;
            pathSourceFolder = textBox1.Text;

            namesSourceFile = Directory.GetFiles(pathSourceFolder);
            mangaPicture.Image = Image.FromFile(namesSourceFile[0]);
            originalImage = mangaPicture.Image;
            originalImageForResize = originalImage;
            mangaPicture.Image = ResizeNow(originalImage.Width * trackBar1.Value / 100, originalImage.Height * trackBar1.Value / 100);
            bmp = new Bitmap(mangaPicture.Image, mangaPicture.ClientSize.Width, mangaPicture.ClientSize.Height);

        }
        int imageCount = 0;
        private void button8_Click(object sender, EventArgs e)
        {
            if(imageCount < namesSourceFile.Length-1)
            {
                imageCount++;
                Image img = Image.FromFile(namesSourceFile[imageCount]);
                mangaPicture.Width = img.Width;
                mangaPicture.Height = img.Height;
                mangaPicture.Image = img;
                
                originalImage = mangaPicture.Image;
                originalImageForResize = originalImage;
                mangaPicture.Image = ResizeNow(originalImage.Width * trackBar1.Value / 100, originalImage.Height * trackBar1.Value / 100);

                bmp = new Bitmap(mangaPicture.Image, mangaPicture.ClientSize.Width, mangaPicture.ClientSize.Height);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (imageCount > 0)
            {
                imageCount--;

                Image img = Image.FromFile(namesSourceFile[imageCount]);
                mangaPicture.Width = img.Width;
                mangaPicture.Height = img.Height;
                mangaPicture.Image = img;
                originalImage = mangaPicture.Image;
                originalImageForResize = originalImage;
                mangaPicture.Image = ResizeNow(originalImage.Width * trackBar1.Value / 100, originalImage.Height * trackBar1.Value / 100);

                bmp = new Bitmap(mangaPicture.Image, mangaPicture.ClientSize.Width, mangaPicture.ClientSize.Height);

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            mangaPicture.Image = ResizeNow(originalImage.Width, originalImage.Height);
            Bitmap bitmap = new Bitmap(mangaPicture.Image);
            bitmap.Save($"{pathSaveFolder}{imageCount}.png");
            mangaPicture.Image = ResizeNow(originalImage.Width * trackBar1.Value / 100, originalImage.Height * trackBar1.Value / 100);
            if (imageCount < namesSourceFile.Length - 1)
            {
                imageCount++;
                Image img = Image.FromFile(namesSourceFile[imageCount]);
                mangaPicture.Width = img.Width;
                mangaPicture.Height = img.Height;
                mangaPicture.Image = img;
                originalImage = mangaPicture.Image;
                originalImageForResize = originalImage;
                mangaPicture.Image = ResizeNow(originalImage.Width * trackBar1.Value / 100, originalImage.Height * trackBar1.Value / 100);

                bmp = new Bitmap(mangaPicture.Image, mangaPicture.ClientSize.Width, mangaPicture.ClientSize.Height);

            }
            else
            {
                if (Properties.Settings.Default.languageProgramm == "en")
                {
                    MessageBox.Show("The pictures are over");
                }else if (Properties.Settings.Default.languageProgramm == "ru")
                {
                    MessageBox.Show("Это была последняя картинка");
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            mangaPicture.Image = ResizeNow(originalImage.Width, originalImage.Height);
            Bitmap bitmap = new Bitmap(mangaPicture.Image);
            
            bitmap.Save($"{pathSaveFolder}{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}-{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}-{DateTime.Now.Millisecond}.png");
            mangaPicture.Image = ResizeNow(originalImage.Width * trackBar1.Value / 100, originalImage.Height * trackBar1.Value / 100);
        }
        Image originalImageForResize;
        int height;
        int width;
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            
            label5.Text = trackBar1.Value + "%";

                height = (originalImage.Height * trackBar1.Value) / 100;
                width = (originalImage.Width * trackBar1.Value) / 100;
                Bitmap bmp1 = ResizeNow(width, height);

            mangaPicture.Image = bmp1;
                
        }
        private Bitmap ResizeNow(int target_width, int target_height)
        {
            Rectangle dest_rect = new Rectangle(0, 0, target_width, target_height);
            Bitmap destImage = new Bitmap(target_width, target_height);
            destImage.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution);
            using (var g = Graphics.FromImage(destImage))
            {

                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapmode = new ImageAttributes())
                {
                    wrapmode.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(originalImage, dest_rect, 0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, wrapmode);
                }
   
               
            }
            return destImage;
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
         //   bmp.Dispose();
        }
        Color fontColor = Color.Black;
        Color backColor = Color.White;


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AnyColor = true;
            cd.AllowFullOpen = true;
            cd.Color = pictureBox2.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                fontColor = cd.Color;
                pictureBox2.BackColor = fontColor;
                updateFontSettings();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AnyColor = true;
            cd.AllowFullOpen = true;
            cd.Color = pictureBox3.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                backColor = cd.Color;
                pictureBox3.BackColor = backColor;
                updateFontSettings();
            }
        }


        void translateProgramInterface()
        {
            if (Properties.Settings.Default.languageProgramm == "en")
            {
                button1.Text = "Open one picture";
                checkBox1.Text = "Vertical text (Enable this option if the text is vertical in the manga)";
                label3.Text = "Enter source manga path to folder";
                label4.Text = "Enter save manga path to folder";
                button6.Text = "Apply";
                button5.Text = "Tutorial on tools";
                button2.Text = "Select";
                button9.Text = "Save and next";
                button10.Text = "Save";
                button3.Text = "Rectangle";
                button4.Text = "Cicrle";
                label2.Text = "Tools";
            }
            else if (Properties.Settings.Default.languageProgramm == "ru")
            {
                button1.Text = "Открыть одну картинку";
                checkBox1.Text = "Вертикальный текст (Текст в манге расположен вертикально)";
                label3.Text = "Введите путь к оригинальной манги";
                label4.Text = "Введите путь, куда будет сохранена манга";
                button6.Text = "Применить"; 
                button5.Text = "Совет по инструментам";
                button2.Text = "Выбрать";
                button9.Text = "Сохранить и далее";
                button10.Text = "Сохранить";
                button3.Text = "Прямоугольник";
                button4.Text = "Круг";
                label2.Text = "Инструменты";
            }
        }
        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new settingForm().ShowDialog();
            translateProgramInterface();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            translateProgramInterface();
        }
    }
}
