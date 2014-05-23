using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorMatrix
{
    public partial class ProcessWindow : Form
    {
        //private Graphics graph;
        Matrix matrix;
        char currentChar;
        float yIndex;
        int index;
        ColorMatrixBL colorMatrix;
        Font font = new System.Drawing.Font("Arial", 30);
        SolidBrush br = new SolidBrush(Color.White);
        bool isFullScreen;

        public ProcessWindow()
        {
            InitializeComponent();
        }

        public ProcessWindow(ColorMatrixBL cm)
            : this()
        {
            colorMatrix = cm;
            colorMatrix.ImageUpdated += colorMatrix_ImageUpdated;

            txtPreview.Text = colorMatrix.Expression;

            isFullScreen = false;
            matrix = new Matrix();

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);

        }

        void colorMatrix_ImageUpdated(Image result, char currentChar, float y)
        {
            try
            {
                if (this.IsDisposed)
                    return;

                if (this.InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        imgResult.Image = result;

                        //if (txtPreview.Text.Length > 0)
                        //{
                        //    txtPreview.Text = txtPreview.Text.Remove(0, 1);
                        //}
                        //else
                        //{
                        //    txtPreview.Text = colorMatrix.Expression;
                        //}

                    }));
                }

                AnimateCurrentChar(currentChar, y);
            }
            catch (Exception ex)
            {
                return;
            }

        }

        private void AnimateCurrentChar(char ch, float y)
        {
            currentChar = ch;
            yIndex = y;

            this.Invalidate();

            //Thread.Sleep(1);
        }

        private void ProcessWindow_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (imgResult.Image != null)
                {
                    int realY;
                    int heightMargin;
                    if (imgResult.Image.Width > imgResult.Image.Height)
                    {
                        heightMargin = (int)(imgResult.Height - (((float)imgResult.Width / (float)imgResult.Image.Width) * imgResult.Image.Height));
                    }
                    else
                    {
                        heightMargin = 0;
                    }
                    realY = (int)(yIndex * (imgResult.Height - heightMargin) + (heightMargin / 3));

                    e.Graphics.DrawString(currentChar.ToString(), font, br, new PointF(95, realY));
                }
            }
            catch (Exception ex)
            {

            }

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            colorMatrix.ImageUpdated -= colorMatrix_ImageUpdated;
        }

        private void ProcessWindow_ResizeEnd(object sender, EventArgs e)
        {
            float imgRatio = (float)imgResult.Image.Width / (float)imgResult.Image.Height;
            float clientRatio = (float)(this.Width - 130) / (float)this.Height;
            if (clientRatio > imgRatio)
            {
                float zoomRatio = (float)this.Height / imgResult.Image.Height;
                imgResult.Width = (int)Math.Round(imgResult.Image.Width * zoomRatio);
                imgResult.Height = this.Height;
            }
            else
            {
                float zoomRatio = (float)(this.Width - 130) / imgResult.Image.Width;

                imgResult.Width = this.Width - 130;
                imgResult.Height = (int)Math.Round(imgResult.Image.Height * zoomRatio);
            }

            if (this.WindowState == FormWindowState.Maximized && !isFullScreen)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                isFullScreen = true;
                btnFullScr.Text = "Exit full screen";

            }

        }

        //FullScr
        private void button1_Click(object sender, EventArgs e)
        {
            if (isFullScreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.Width = 500;
                this.Height = 300;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                isFullScreen = false;
                btnFullScr.Text = "Launch full screen";
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                isFullScreen = true;
                btnFullScr.Text = "Exit full screen";

            }


        }
    }
}
