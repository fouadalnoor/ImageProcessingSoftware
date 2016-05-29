using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageAnalysis
{
    class CreateAverageImage
    {
        public CreateAverageImage(int startingposx, int endpositionx, int startingposy, int endposy, int SquareNum, double[] Red, double[] Blue, double[] Green, Bitmap AverageBitMap)
        {
            for (int j = startingposy; j < endposy; j++)
            {
                for (int i = startingposx; i < endpositionx; i++)
                {
                    Color AverageColour = Color.FromArgb((int)Red[SquareNum], (int)Green[SquareNum], (int)Blue[SquareNum]);
                    AverageBitMap.SetPixel(i, j, AverageColour);

                }
            }
        }
    }
}
