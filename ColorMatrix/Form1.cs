using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorMatrix
{
    public enum FillHeightMeasurment
    {
        Pixels,
        Precents
    }

    public enum FillColorType
    {
        Fix,
        Gradient
    }

    public enum BackgroundColorType
    {
        Transparent,
        Fix,
        Summary
    }

    public enum LogicCondition
    {
        OR = 0,
        AND,
        XOR,
        NOR,
        NAND,
    }

    public partial class Form1 : Form
    {

        private string sourceFileName;
        private string target;
        ColorMatrixBL colorMatrix;
        private FillHeightMeasurment fillHeightMeasure;
        private FillColorType fillColorType;
        private BackgroundColorType backgroundColorType;
        private LogicCondition logic;
        private ProcessWindow procWin;

        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Filter = "Images|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff;";
            openFileDialog1.FilterIndex = 1;

            saveFileDialog1.DefaultExt = ".tiff";
            saveFileDialog1.Filter = "Tiff|*.tiff";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.FilterIndex = 1;


            //radio buttons defaults
            fillHeightMeasure = FillHeightMeasurment.Precents;
            fillColorType = FillColorType.Gradient;
            backgroundColorType = BackgroundColorType.Fix;
            logic = LogicCondition.XOR;


            //DEBUG
            sourceFileName = @"D:\Dropbox\Code\Developing\ColorMatrix\ColorMatrix-V.3\Client\colors.xlsx";
            colorMatrix = new ColorMatrixBL();
            colorMatrix.ImageCreated += colorMatrix_ImageCreated;
            UpdatePointsAndHeight();

        }

        void colorMatrix_ImageCreated(string imageName)
        {
            if (this.InvokeRequired)
                Invoke(new Action(() =>
                {
                    lblSuccess.Text = "Image " + imageName + " was created!";
                }));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    target = saveFileDialog1.FileName;

                    UpdatePointsAndHeight();

                    //if(procWin==null || procWin.IsDisposed)
                    //{
                    //    procWin = new ProcessWindow(colorMatrix);
                    //}
                    colorMatrix.Expression = txtExpression.Text;
                    procWin = new ProcessWindow(colorMatrix);
                    procWin.Show();

                    Thread thread = new Thread(CreateImage);
                    thread.Start();

                    lblSuccess.ForeColor = Color.Green;
                    lblSuccess.Text = "Working on image " + new FileInfo(saveFileDialog1.FileName).Name + ", please wait.";
                    lblSuccess.Visible = true;
                }
                catch (Exception ex)
                {
                    lblSuccess.ForeColor = Color.Red;
                    lblSuccess.Text = "Something goes wrong...\n\rPlease check the excel file.";
                    lblSuccess.Visible = true;
                }
            }
        }

        /// <summary>
        /// Main method for proccessing image, invoked with separate thread
        /// </summary>
        private void CreateImage()
        {
            try
            {
                colorMatrix.CreateImage(target,
                                        txtExpression.Text + " ",
                                        fillHeightMeasure,
                                        fillColorType,
                                        backgroundColorType,
                                        sourceFileName,
                                        (int)numRotate.Value,
                                        (int)numExpressionLoop.Value);
            }
            catch (InvalidDataException ex)
            {
                if (InvokeRequired)
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show("The image creation aborted, try smaller image size or free computer memory.");
                    }));
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:ur92.ed@gmail.com");
        }

        private void cbStaticWidth_CheckedChanged(object sender, EventArgs e)
        {
            
            UpdatePointsAndHeight();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton rb = ((RadioButton)sender);
            if (rb.Checked)
            {
                switch (rb.Name)
                {
                    
                    default:
                        break;
                }
            }
        }

        private void numCanvasWidth_ValueChanged(object sender, EventArgs e)
        {
            //UpdatePointsAndHeight();
        }

        private void UpdatePointsAndHeight()
        {
            if (colorMatrix == null)
                return;
            try
            {
                string text = txtExpression.Text;
                text = text.Replace('\r', ' ').Replace('\n', ' ') + " ";

                int canvasHeight;
                int canvasWidth;
                colorMatrix.CalculateCanvasHeight(
                            sourceFileName,
                            text,
                            out canvasHeight,
                            out canvasWidth);

                //update the width
                lblCanvasSize.Text = canvasWidth + " * " + canvasHeight;
                lblNumberOfPoints.Text = (canvasWidth * canvasHeight).ToString();

            }
            catch (Exception ex)
            {
                lblCanvasSize.Text = "N/A";
                lblNumberOfPoints.Text = "N/A";

            }
        }

        private void btnRandomWiki_Click(object sender, EventArgs e)
        {
            txtExpression.Text = colorMatrix.GetRandomWiki();
        }

        private void txtExpression_KeyUp(object sender, KeyEventArgs e)
        {
            colorMatrix.ResetUrlToText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtExpression.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtExpression.Text = colorMatrix.GetTextFromUrl(txtUrl.Text);

        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sourceFileName = openFileDialog1.FileName;
                imgSource.Image = Image.FromFile(sourceFileName);
                UpdatePointsAndHeight();
            }
        }

        private void cbLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogicCondition result;
        }



    }


}
