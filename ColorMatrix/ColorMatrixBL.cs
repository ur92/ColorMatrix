using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ColorMatrix
{
    public class ColorMatrixBL
    {
        private int canvasHeight;
        private int canvasWidth;
        private string url = "Text";
        private string expression;

        public string Expression
        {
            get { return expression; }
            set { expression = value; }
        }

        public void ResetUrlToText()
        {
            url = "Text";
        }

        public event Action<string> ImageCreated;
        public event Action<Image, char, float> ImageUpdated;
        public int CanvasHeight
        {
            get { return canvasHeight; }
        }


        #region Constructors
        public ColorMatrixBL()
        {

        }
        #endregion

        #region Private Methods
        private string GetBinaryStringFromPixel(Bitmap bmp, int y, int x)
        {
            string tmp;
            string binaryPixel = String.Empty;

            Color pixelColor = bmp.GetPixel(x, y);

            tmp = Convert.ToString(pixelColor.R, 2);
            while (tmp.Length < 8)
                tmp = "0" + tmp;
            binaryPixel += tmp;

            tmp = Convert.ToString(pixelColor.G, 2);
            while (tmp.Length < 8)
                tmp = "0" + tmp;
            binaryPixel += tmp;

            tmp = Convert.ToString(pixelColor.B, 2);
            while (tmp.Length < 8)
                tmp = "0" + tmp;
            binaryPixel += tmp;

            return binaryPixel;
        }

        private string GetBinaryStringFromColor(Color color)
        {
            string tmp;
            string binaryPixel = String.Empty;

            tmp = Convert.ToString(color.R, 2);
            while (tmp.Length < 8)
                tmp = "0" + tmp;
            binaryPixel += tmp;

            tmp = Convert.ToString(color.G, 2);
            while (tmp.Length < 8)
                tmp = "0" + tmp;
            binaryPixel += tmp;

            tmp = Convert.ToString(color.B, 2);
            while (tmp.Length < 8)
                tmp = "0" + tmp;
            binaryPixel += tmp;

            return binaryPixel;
        }

        private Color ColorFromExpression(string expression)
        {
            int sum = 0;

            expression.Replace('\r', ' ');
            expression.Replace('\n', ' ');
            for (int i = 0; i < expression.Length; i++)
            {
                sum += Encoding.ASCII.GetBytes(expression[i].ToString())[0];
            }

            if (sum > Math.Pow(256, 3))
                sum = (int)Math.Pow(256, 3);

            string hexNum = sum.ToString("X") + "000000";
            Color calculatedColor = Color.FromArgb(int.Parse(hexNum.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                 int.Parse(hexNum.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                  int.Parse(hexNum.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));

            return calculatedColor;
        }

        private byte GetByteFromChar(char ch)
        {
            return Encoding.ASCII.GetBytes(new char[] { ch })[0];
        }

        private void DrawPoints(
                        Bitmap lockSource,
                        Bitmap lockTarget,
                        string expression,
                        int rotate,
                        int expressionLoop)
        {
            string expressionLeft = expression;
            //copy the source image to target image
            //Bitmap preview = lockSource.Clone(new Rectangle(0, 0, (int)Math.Ceiling(canvasWidth * (1 + (1.0 / (float)expressionLoop))), lockSource.Height), lockSource.PixelFormat);

            int charIndex = 0;
            int indexSource = 0;
            int indexTarget = 0;
            Color colorSrc;
            Color colorNew;
            int newX = 0;
            int newY = 0;
            byte newR=0, newG=0, newB=0, colorValue;
            int expressionLoopCounter = 0;
            string result;
            int rotateRun=rotate;

            //thumb preview creator
            int thumbX;
            int thumbY;

            if (lockTarget.Width > lockTarget.Height)
            {
                thumbX = 450;
                thumbY = (int)Math.Ceiling(450.0 / ((double)lockTarget.Width / (double)lockTarget.Height));
            }
            else
            {
                thumbY = 450;
                thumbX = (int)Math.Ceiling(450.0 / ((double)lockTarget.Height / (double)lockTarget.Width));
            }

            //main algo
            try
            {
                for (int y = 0; y < lockSource.Height; y++)
                {
                    newX = 0;
                    indexTarget = 0;
                    rotateRun = 0;
                    //if (ImageUpdated != null)
                    //    ImageUpdated(preview.GetThumbnailImage(thumbX, thumbY, null, IntPtr.Zero), expression[charIndex], ((float)y / (float)lockSource.Height));

                    for (int x = 0; x < lockSource.Width; x++)
                    {
                        int innerIndex = 0;
                        colorValue = 0;

                        while (innerIndex < 3)
                        {
                            if ((indexSource!=0) && (indexSource % expressionLoop == 0))
                            {
                                colorValue = GetByteFromChar(Expression[charIndex]);
                                if (charIndex < Expression.Length-1)
                                {
                                    charIndex++;
                                }
                                else
                                {
                                    charIndex = 0;
                                }
                                indexSource = 0;
                            }
                            else
                            {
                                Color value = lockSource.GetPixel(x, y);
                                switch (innerIndex)
                                {
                                    case 0:
                                        colorValue = value.R;
                                        innerIndex++;
                                        break;
                                    case 1:
                                        colorValue = value.G;
                                        innerIndex++;
                                        break;
                                    case 2:
                                        colorValue = value.B;
                                        innerIndex++;
                                        break;
                                    default:
                                        break;
                                }
                                indexSource++;
                            }

                            switch (indexTarget)
                            {
                                case 0:
                                    newR = colorValue;
                                    indexTarget++;

                                    break;
                                case 1:
                                    newG = colorValue;
                                    indexTarget++;
                                    break;
                                case 2:
                                    newB = colorValue;
                                    indexTarget++;
                                    break;

                                default:
                                    break;
                            }

                            if (indexTarget % 3 == 0)
                            {
                                colorNew = Color.FromArgb(newR, newG, newB);

                                if (newX < lockTarget.Width && y < lockTarget.Height)
                                {
                                    if (rotate > 0)
                                    {
                                        result = GetBinaryStringFromColor(colorNew);
                                        result = new string(result.Reverse().ToArray());
                                        result = result.Substring(24 - rotateRun, rotateRun) + result.Substring(rotateRun, 24 - rotateRun);

                                        if (rotateRun < 23)
                                            rotateRun++;
                                        else
                                            rotateRun = 0;

                                        int red = Convert.ToInt32(result.Substring(0, 8), 2);
                                        int green = Convert.ToInt32(result.Substring(8, 8), 2);
                                        int blue = Convert.ToInt32(result.Substring(16, 8), 2);

                                        colorNew = Color.FromArgb(red, green, blue);
                                    }

                                    lockTarget.SetPixel(newX, y, colorNew);
                                    //preview.SetPixel(newX, y, colorNew);

                                    if (newX < lockTarget.Width - 1)
                                        newX++;
                                    else
                                        newX = 0;
                                }
                                indexTarget = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private bool ThumbnailCallback()
        {
            return false;
        }

        private void SaveImage(string imageFileName, Bitmap bmp, string expression)
        {
            //Save image
            var memStream = new MemoryStream();
            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Tiff);
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            System.Drawing.Imaging.Encoder qualityEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameter EncoderParameter1 = new EncoderParameter(qualityEncoder, 100L);

            myEncoderParameters.Param[0] = EncoderParameter1;
            try
            {
                //save the image
                bmp.SetResolution(300, 300);
                bmp.Save(imageFileName, jgpEncoder, myEncoderParameters);
                bmp.Dispose();

            }
            catch (Exception ex)
            {
                throw new InvalidDataException();
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public void CalculateCanvasHeight(
                           string imageSource,
                           string expression,
                           out int canvasH,
                           out int canvasW)
        {
            //convert string into points list
            try
            {
                var bitmapFrame = BitmapFrame.Create(new Uri(imageSource), BitmapCreateOptions.DelayCreation, BitmapCacheOption.None);
                canvasWidth = bitmapFrame.PixelWidth;
                canvasHeight = bitmapFrame.PixelHeight;

                canvasH = canvasHeight;
                canvasW = canvasWidth;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Methods
        public void CreateImage(
                        string imageFileName,
                        string expression,
                        FillHeightMeasurment fillHeightMeasure,
                        FillColorType fillColorType,
                        BackgroundColorType backgroundColorType,
                        string imageSource,
                        int rotate,
                        int expressionLoop)
        {
            try
            {
                using (Bitmap targetBmp = new Bitmap((int)Math.Ceiling(canvasWidth * (1+(1.0/(float)expressionLoop))), canvasHeight),
                              sourceBmp = new Bitmap(imageSource))
                {
                    Expression = expression;

                    //draw point on the canvas and fill the gaps between
                    DrawPoints(sourceBmp, targetBmp, expression, rotate, expressionLoop);

                    //save tiff image
                    SaveImage(imageFileName, targetBmp, expression);
                }

                //raise event
                if (ImageCreated != null)
                    ImageCreated(new FileInfo(imageFileName).Name);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException();
            }

        }

        public string GetRandomWiki()
        {
            string data = String.Empty;
            string urlAddress = "http://he.wikipedia.org/wiki/%D7%9E%D7%99%D7%95%D7%97%D7%93:%D7%90%D7%A7%D7%A8%D7%90%D7%99";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                url = response.ResponseUri.OriginalString;

                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }

            return data;
        }

        public string GetTextFromUrl(string url)
        {
            string data = String.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                url = response.ResponseUri.OriginalString;

                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }

            return data;
        }
        #endregion
    }
}
