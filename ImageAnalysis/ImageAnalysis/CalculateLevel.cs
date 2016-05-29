using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageAnalysis
{
    class CalculateLevel
    {
        public string level;
        public Bitmap resultBitmap; 
        public CalculateLevel(Bitmap Image)
        {
            double levelpx = 0;  
            double ahue = 0; //average hue 
            Bitmap tempBitmap = new Bitmap(Image); //creating a temporary bitmap to store the created bitmap. 
            //getting the levels 
            for (int i = 0; i < Image.Height; i++)
            {
                for (int j = 0; j < Image.Width; j++)
                {
                    Color getGreenColor = Image.GetPixel(j, i);
                    //setting the selection of green between two values - green hue defined between 60 and 180 degrees and saturation (divided by 10) 
                    if ((getGreenColor.GetHue() >= 55) & (getGreenColor.GetHue() <= 180) & (getGreenColor.GetSaturation() < 0.7) & (getGreenColor.GetSaturation() >= 0.1) & (getGreenColor.GetBrightness() < 0.7) & (getGreenColor.GetBrightness() >= 0.2))
                    {
                        //adding all colour values.
                        ahue = ahue + getGreenColor.GetHue();
                        levelpx++;
                        tempBitmap.SetPixel(j, i, getGreenColor);//?? shall I leave this or change it to black? 
                    }

                    else
                    {
                        tempBitmap.SetPixel(j, i, Color.White);    
                    }
                }
            }


            resultBitmap = tempBitmap;
            //average colour
            ahue = ahue / levelpx;
            Bitmap temBitmap = resultBitmap;
            temBitmap.Save("tempbitmap.jpg");

            if ((ahue >= 35) & (ahue <= 74))
            {
                //neg //hue = 68-64
                level = "Neg or Trace  Hue:" + Math.Floor(ahue); ;
            }


            if ((ahue >= 75) & (ahue <= 90))
            {
                //thirty hue = 84
                level = "0.3  Hue: " + Math.Floor(ahue);
            }

            if ((ahue >= 91) & (ahue <= 140))
            {
                //hundred  hue = 136
                level = "1  Hue " + Math.Floor(ahue);
            }

            if ((ahue >= 141) & (ahue <= 170))
            {
                //threehundred  hue = 168 
                level = "3  Hue: " + Math.Floor(ahue);
            }

            if ((ahue >= 171) & (ahue <= 180))
            {
                //twothusand   174
                level = ">=20  Hue: " + Math.Floor(ahue);
            }
        }

    }
}
