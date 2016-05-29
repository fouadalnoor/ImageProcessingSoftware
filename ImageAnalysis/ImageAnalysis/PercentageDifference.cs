using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageAnalysis
{
    class PercentageDifference
    {
        public double TotalPercentageDifference, SquareAlphaPercent = 0, TotalAlphaPercent = 0, SquareRedPercent = 0, TotalRedPercent = 0,
               SquareGreenPercent = 0, TotalGreenPercent = 0, SquareBluePercent = 0, TotalBluePercent = 0;

        public PercentageDifference(double[] AverageAlphaImage1, double[] AverageAlphaImage2, double[] AverageRedImage1, double[] AverageRedImage2, double[] AverageGreenImage1, double[] AverageGreenImage2, double[] AverageBlueImage1, double[] AverageBlueImage2, int arraysize)
        {
            for (int i = 0; i < AverageAlphaImage1.Length - 1; i++)
            {
                SquareAlphaPercent = SquareAlphaPercent + Math.Abs((AverageAlphaImage2[i] - AverageAlphaImage1[i]) / (255));
                SquareRedPercent = SquareRedPercent + Math.Abs((AverageRedImage2[i] - AverageRedImage1[i]) / (255));
                SquareGreenPercent = SquareGreenPercent + Math.Abs((AverageGreenImage2[i] - AverageGreenImage1[i]) / (255));
                SquareBluePercent = SquareBluePercent + Math.Abs((AverageBlueImage2[i] - AverageBlueImage1[i]) / (255));
            }

            //The percentage difference between the two images. Maximum difference = 255 = 100% different 
            TotalAlphaPercent = SquareAlphaPercent / arraysize;
            TotalRedPercent = SquareRedPercent / arraysize;
            TotalGreenPercent = SquareGreenPercent / arraysize;
            TotalBluePercent = SquareBluePercent / arraysize;

            TotalPercentageDifference = ((TotalRedPercent + TotalGreenPercent + TotalBluePercent) / 3) * 100;
        }
    }
}
