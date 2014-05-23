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


        private void DrawPoints(
                        Bitmap lockSource,
                        Bitmap lockTarget,
                        string expression,
            int rotate)
        {
            string expressionLeft = expression;
            //copy the source image to target image
            Bitmap preview = lockSource.Clone(new Rectangle(0, 0, lockSource.Width, lockSource.Height), lockSource.PixelFormat);

            int charIndex = 0;
            int pixelIndex = 0;
            string result;

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

            Color colorSrc;
            Color colorNew;
            //ColorPoint newPoint = new ColorPoint();
            try
            {
                for (int y = 0; y < lockSource.Height; y++)
                {
                    for (int x = 0; x < lockSource.Width; x++)
                    {
                        if (Encoding.ASCII.GetBytes(expression[charIndex].ToString())[0] <= pixelIndex)
                        {
                            expressionLeft = expressionLeft.Remove(0, 1);
                            if (ImageUpdated != null)
                                ImageUpdated(preview.GetThumbnailImage(thumbX, thumbY, null, IntPtr.Zero), expression[charIndex], ((float)y / (float)lockSource.Height));

                            for (int i = pixelIndex; i >= 0; i--)
                            {

                                int xSrc = x - pixelIndex + i;
                                int ySrc = y;

                                if (xSrc < 0)
                                {
                                    ySrc--;
                                    xSrc = lockSource.Width + xSrc;
                                }

                                colorSrc = lockSource.GetPixel(xSrc, ySrc);
                                colorNew = Color.FromArgb(colorSrc.B, colorSrc.R, colorSrc.G);
                                int newX = x - i;
                                int newY = y;
                                if (newX < 0)
                                {
                                    newY--;
                                    newX = lockSource.Width + newX;
                                }

                                result = GetBinaryStringFromColor(colorNew);
                                //result = new string(result.Reverse().ToArray());
                                result = result.Substring(24 - rotate, rotate) + result.Substring(rotate, 24 - rotate);

                                int red = Convert.ToInt32(result.Substring(0, 8), 2);
                                int green = Convert.ToInt32(result.Substring(8, 8), 2);
                                int blue = Convert.ToInt32(result.Substring(16, 8), 2);

                                colorNew = Color.FromArgb(red, green, blue);

                                lockTarget.SetPixel(newX, newY, colorNew);
                                preview.SetPixel(newX, newY, colorNew);
                            }
                            pixelIndex = 0;
                            charIndex++;

                            //end of the text
                            if (charIndex >= expression.Length)
                            {
                                charIndex = 0;
                                expressionLeft = expression;
                            }
                        }
                        else
                        {
                            pixelIndex++;
                        }


                    }

                }
            }
            catch (Exception ex)
            {

            }

            //lockTarget.UnlockBits();
            //lockSource.UnlockBits();
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
                        int rotate)
        {
            try
            {
                using (Bitmap targetBmp = new Bitmap(canvasWidth, canvasHeight),
                              sourceBmp = new Bitmap(imageSource))
                {
                    Expression = expression;

                    //draw point on the canvas and fill the gaps between
                    DrawPoints(sourceBmp, targetBmp, expression, rotate);

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
