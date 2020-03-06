using System;
using OpenCvSharp;
namespace CVIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Mat foreground = Cv2.ImRead(@"D:\OneDrive\Pictures\butterflyGreenScreen.jpg");
            //Mat background = Cv2.ImRead(@"D:\OneDrive\Pictures\city.jpg");
            Mat foregroundHSV = foreground.CvtColor(ColorConversionCodes.BGR2HSV);
            
            Mat mask = foregroundHSV.InRange(new Scalar(65, 180, 160), new Scalar(80, 255, 230));
            Mat invertMask = new Mat();
            Cv2.BitwiseNot(mask, invertMask);

            Mat finalForeground = new Mat();
            foreground.CopyTo(finalForeground, invertMask);

            //Mat finalBackground = new Mat();
            //background.CopyTo(finalBackground, mask);

            //Mat finalImage = new Mat();
            //Cv2.BitwiseOr(finalForeground, finalBackground, finalImage);

            Cv2.NamedWindow("Display", WindowMode.AutoSize);

            Cv2.SetMouseCallback("Display", (evnt, x, y, flags, _) =>
            {
                if (x < 0 || x >= foregroundHSV.Width || y < 0 || y >= foregroundHSV.Height)
                {
                    return;
                }

                Vec3b hsv = foregroundHSV.At<Vec3b>(y, x);

                Console.WriteLine($"H: {hsv.Item0}, S: {hsv.Item1}, V: {hsv.Item2}");
            });

            VideoCapture capture = new VideoCapture(0);
            capture.Set(CaptureProperty.FrameWidth, 640);
            capture.Set(CaptureProperty.FrameHeight, 360);
            Mat background = new Mat();
            Mat finalBackground = new Mat();
            Mat finalImage = new Mat();

            while(true)
            {
                if(!capture.Read(background))
                {
                    continue;
                }
                background.CopyTo(finalBackground, mask);
                Cv2.BitwiseOr(finalForeground, finalBackground, finalImage);
                Cv2.ImShow("Display", finalBackground);
                Cv2.WaitKey(1);
            }

            //Cv2.ImShow("Display", finalImage);

            //Cv2.WaitKey(0);
        }
    }
}
