using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cg_task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Draw();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            DrawGradientImage(bmp, Color.Aqua, Color.Yellow);
            Graphics g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Red);
            g.FillRectangle(Brushes.Red, 10, 50, 1, 1);
            g.DrawLine(pen, 10, 10, 100, 100);
            g.DrawRectangle(pen, 300, 50, 100, 300);
            g.DrawEllipse(pen, 150, 100, 100, 60);
            pictureBox.Image = bmp;
        }

        private static void DrawGradientImage(Bitmap bmp,Color startColor, Color endColor)
        {
            for (int x = 0; x < bmp.Width; x++)
            {
                int r = (int)Math.Floor((double)(startColor.R + (endColor.R - startColor.R) * x / bmp.Width));
                int g = (int)Math.Floor((double)(startColor.G + (endColor.G - startColor.G) * x / bmp.Width));
                int b = (int)Math.Floor((double)(startColor.B + (endColor.B - startColor.B) * x / bmp.Width));
                Color current = Color.FromArgb(r, g, b);

                for (int y = 0; y < bmp.Height; y++)
                {
                    bmp.SetPixel(x, y, current);
                }
            }
        }
    }
}
