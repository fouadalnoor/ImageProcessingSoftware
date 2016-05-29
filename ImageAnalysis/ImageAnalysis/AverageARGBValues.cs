using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageAnalysis
{
    class AverageARGBValues
    {
        public double[] AlphaAverage;
        public double[] RedAverage;
        public double[] GreenAverage;
        public double[] BlueAverage;
        public int Arraysize;

        public AverageARGBValues(Bitmap image, int N)
        {
            int TotalArea = image.Height * image.Width;
            double SquareArea = (double)TotalArea / N;
            double pixelDistance = Math.Round(Math.Sqrt(SquareArea), MidpointRounding.AwayFromZero); //Rounded
            int HorizontalSquares = (int)Math.Floor((double)image.Width / pixelDistance); //how many squares can fit Horizontally 
            int VerticalSquares = (int)Math.Floor((double)image.Height / pixelDistance); //how many squares can fit Vertically 

            int startingpositionx = 0;
            int endpositionx = (int)pixelDistance;
            int startingposy = 0;
            int endposy = (int)pixelDistance;

            int arraysize = (HorizontalSquares * VerticalSquares);

            Arraysize = arraysize; //making "arraysize" availible outside class. 

            double[] Alpha = new double[arraysize];
            double[] Red = new double[arraysize];
            double[] Green = new double[arraysize];
            double[] Blue = new double[arraysize];

            //Get the average ARGB values for Image1. Note ArraySize = N; k = SquareNumber 
            for (int k = 0; k < arraysize; k++)
            {

                CalculateSquares CalculateSquares = new CalculateSquares(startingpositionx, endpositionx, startingposy, endposy, (int)pixelDistance, k, arraysize, HorizontalSquares, VerticalSquares, image);

                startingpositionx = startingpositionx + (int)pixelDistance; //should start at the appropriate time... 
                endpositionx = startingpositionx + (int)pixelDistance;

                if (endpositionx >= (pixelDistance * HorizontalSquares) + pixelDistance)
                {
                    //restart the horizontal axis
                    startingpositionx = 0;
                    endpositionx = (int)pixelDistance;

                    //increment the vertical  axis
                    startingposy = startingposy + (int)pixelDistance;
                    endposy = endposy + (int)pixelDistance;
                }


                Alpha[k] = CalculateSquares.AlphaSquaresFinal[k];
                Red[k] = CalculateSquares.RedSquaresFinal[k];
                Green[k] = CalculateSquares.GreenSquaresFinal[k];
                Blue[k] = CalculateSquares.BlueSquaresFinal[k];

                if (endposy >= (pixelDistance * VerticalSquares) + pixelDistance)
                {
                    //end loop when maximum height is reached 
                    break;
                }


            }

            AlphaAverage = Alpha;
            RedAverage = Red;
            GreenAverage = Green;
            BlueAverage = Blue;
        }
    }
}
