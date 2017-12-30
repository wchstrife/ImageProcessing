using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bitmap;
        Bitmap newbitmap;
        Stopwatch sw = new Stopwatch();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                bitmap = (Bitmap)Image.FromFile(path);
                pictureBox1.Image = bitmap.Clone() as Image;
            }
        }

        /**
         * 调节图像亮度，默认系数为0.6
         * */
        private void button2_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                newbitmap = bitmap.Clone() as Bitmap;
                sw.Reset();
                sw.Restart();
                Color pixel;              
                int red, green, blue;
                for (int x = 0; x < newbitmap.Width; x++)
                {
                    for (int y = 0; y < newbitmap.Height; y++)
                    {
                        pixel = newbitmap.GetPixel(x, y);
                        red = (int)(pixel.R * 0.6);
                        green = (int)(pixel.G * 0.6);
                        blue = (int)(pixel.B * 0.6);
                        newbitmap.SetPixel(x, y, Color.FromArgb(red, green, blue));
                    }
                }
                sw.Stop();
                timer.Text = sw.ElapsedMilliseconds.ToString();
                pictureBox2.Image = newbitmap.Clone() as Image;
            }
        }

        /**
         * 添加暗角
         **/
        private void button1_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                newbitmap = bitmap.Clone() as Bitmap;

                sw.Reset();
                sw.Restart();

                int width = newbitmap.Width;
                int height = newbitmap.Height;
                float cx = width / 2;
                float cy = height / 2;
                float maxDist = cx * cx + cy * cy;
                float currDist = 0, factor;
                Color pixel; 
                
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        currDist = ((float)i - cx) * ((float)i - cx) + ((float)j - cy) * ((float)j - cy);
                        factor = currDist / maxDist;

                        pixel = newbitmap.GetPixel(i, j);
                        int red = (int)(pixel.R * (1 - factor));
                        int green = (int)(pixel.G * (1 - factor));
                        int blue = (int)(pixel.B * (1 - factor));
                        newbitmap.SetPixel(i, j, Color.FromArgb(red, green, blue));
                    }
                }

                sw.Stop();
                timer.Text = sw.ElapsedMilliseconds.ToString();
                pictureBox2.Image = newbitmap.Clone() as Image;               
            }
        }

    
       
    }
}
