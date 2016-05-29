using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageAnalysis
{
    class CompareImages
    {
        public double TotalPercentageDifference;
        public Bitmap SquareImage; 

        public CompareImages(Bitmap RefrenceImage, Bitmap ComparisonImage, int N)
        {
            if (RefrenceImage.PhysicalDimension != ComparisonImage.PhysicalDimension)
            {
                Image OriginalImage = new Bitmap(ComparisonImage);

                ComparisonImage = new Bitmap(OriginalImage, RefrenceImage.Size);
            }

            //getAverage ARGB values 
            AverageARGBValues averageARGBval1 = new AverageARGBValues(RefrenceImage, N);
            AverageARGBValues averageARGBval2 = new AverageARGBValues(ComparisonImage, N);

            double[] AlphaAverage1 = averageARGBval1.AlphaAverage;
            double[] RedAverage1 = averageARGBval1.RedAverage;
            double[] GreenAverage1 = averageARGBval1.GreenAverage;
            double[] BlueAverage1 = averageARGBval1.BlueAverage;

            double[] AlphaAverage2 = averageARGBval2.AlphaAverage;
            double[] RedAverage2 = averageARGBval2.RedAverage;
            double[] GreenAverage2 = averageARGBval2.GreenAverage;
            double[] BlueAverage2 = averageARGBval2.BlueAverage;

            // Bitmap Img1grayscaled = MakeGrayscale(image1); //grayscale image

            //comparing the two images together by doing the difference between the pixel values and dividing by 255
            PercentageDifference percentageDifference = new PercentageDifference(AlphaAverage1, AlphaAverage2, RedAverage1, RedAverage2, GreenAverage1, GreenAverage2, BlueAverage1, BlueAverage2, averageARGBval1.Arraysize);

             TotalPercentageDifference = percentageDifference.TotalPercentageDifference; //14% negative (so 86% similar), positive 17.85% (so 82.15% similar). 

            //Re drawing the image

             //creating the image again using average values 
             //resetting values 

             int TotalArea1 = ComparisonImage.Height * ComparisonImage.Width;
             double SquareArea1 = (double)TotalArea1 / N;
             double pixelDistance1 = Math.Round(Math.Sqrt(SquareArea1), MidpointRounding.AwayFromZero); //Rounded
             int HorizontalSquares1 = (int)Math.Floor((double)ComparisonImage.Width / pixelDistance1); //how many squares can fit Horizontally 
             int VerticalSquares1 = (int)Math.Floor((double)ComparisonImage.Height / pixelDistance1); //how many squares can fit Vertically 

             int startingpositionx1 = 0;
             int endpositionx1 = (int)pixelDistance1;
             int startingposy1 = 0;
             int endposy1 = (int)pixelDistance1;

             Bitmap AverageBitMap1 = new Bitmap(ComparisonImage.Width, ComparisonImage.Height);

             for (int m = 0; m < N; m++)
             {
                 CreateAverageImage createaverageimage = new CreateAverageImage(startingpositionx1, endpositionx1, startingposy1, endposy1, m, RedAverage2, BlueAverage2, GreenAverage2, AverageBitMap1);
                 startingpositionx1 = startingpositionx1 + (int)pixelDistance1; //should start at the appropriate time... 
                 endpositionx1 = startingpositionx1 + (int)pixelDistance1;

                 if (endpositionx1 >= (pixelDistance1 * HorizontalSquares1) + pixelDistance1)
                 {
                     //restart the horizontal axis
                     startingpositionx1 = 0;
                     endpositionx1 = (int)pixelDistance1;

                     //increment the vertical  axis
                     startingposy1 = startingposy1 + (int)pixelDistance1;
                     endposy1 = endposy1 + (int)pixelDistance1;
                 }

                 if (endposy1 >= (pixelDistance1 * VerticalSquares1) + pixelDistance1)
                 {
                     //end loop when maximum height is reached 
                     break;
                 }
             }
  
             SquareImage = AverageBitMap1;
             AverageBitMap1.Save("testImage.jpg");

        }
    }
}
