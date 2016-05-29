using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageAnalysis
{
    class CalculateSquares
    {
        //This whole class calculates the Average ARGB values for a single square. 

        public double[] AlphaSquaresFinal;
        public double[] RedSquaresFinal;
        public double[] GreenSquaresFinal;
        public double[] BlueSquaresFinal;

        int A = 0, R = 0, G = 0, B = 0, Rtmp = 0, Btmp = 0, Gtmp = 0;


        public CalculateSquares(int startingposx, int endpositionx, int startingposy, int endposy, int pixeldistance, int SquareNum, int N, int HorizSquare, int VerticSquares, Bitmap bitMap)
        {
            Console.WriteLine("{0}", SquareNum);

            int squaresize = pixeldistance * pixeldistance;

            for (int j = startingposy; j < endposy; j++)
            {

                for (int i = startingposx; i < endpositionx; i++)
                {

                    Color pixelColor = bitMap.GetPixel(i, j);
                    Color TmpPixelColor = bitMap.GetPixel(i, j);
                    Rtmp = TmpPixelColor.R;
                    Gtmp = TmpPixelColor.G;
                    Btmp = TmpPixelColor.B;
                    A = A + pixelColor.A;
                    R = R + Rtmp;
                    G = G + Gtmp;
                    B = B + Btmp;
                }

            }


            double[] AlphaSquares = new double[N];
            double[] RedSquares = new double[N];
            double[] GreenSquares = new double[N];
            double[] BlueSquares = new double[N];

            //Average value for the colours in that square
            AlphaSquares[SquareNum] = (double)A / (double)squaresize;
            RedSquares[SquareNum] = (double)R / (double)squaresize;
            GreenSquares[SquareNum] = (double)G / (double)squaresize;
            BlueSquares[SquareNum] = (double)B / (double)squaresize;

            AlphaSquaresFinal = AlphaSquares;
            RedSquaresFinal = RedSquares;
            GreenSquaresFinal = GreenSquares;
            BlueSquaresFinal = BlueSquares;


        }
    }

}
