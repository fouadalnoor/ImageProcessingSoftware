using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


//need to fix the algorithim since levels 3g/l and 20g/l are not detected
namespace ImageAnalysis
{
    class GetGreenPercentage
    {
       public Bitmap ResultantImage; 

        public double GetPercentage(Bitmap Image)
        {
            Bitmap tempResultantImage = new Bitmap(Image);

            //comparing the ammount of black (green in original) to the area of the image...
            double AreaofImage = Image.Width * Image.Height;
            double blackpixels = 0;
            double PercentageOfBlack = 0;

            //removing all other colours and setting the green colour to black 
            for (int i = 0; i < Image.Height; i++)
            {
                for (int j = 0; j < Image.Width; j++)
                {
                    Color getGreenColor = Image.GetPixel(j, i);
                    //setting the selection of green between two values - green hue defined between 60 and 180 degrees and saturation (divided by 10) 
                    if ((getGreenColor.GetHue() >= 60) & (getGreenColor.GetHue() <= 180) & (getGreenColor.GetSaturation() < 1) & (getGreenColor.GetSaturation() >= 0.2) & (getGreenColor.GetBrightness() < 1) & (getGreenColor.GetBrightness() >= 0.3))
                    {
                        tempResultantImage.SetPixel(j, i, Color.Black); //creating the resultant image. 
                        blackpixels++;
                    }

                    else
                    {
                        tempResultantImage.SetPixel(j, i, Color.White); //creating the resultant image
                    }
                }
            }

            ResultantImage = tempResultantImage;
            
            PercentageOfBlack = (blackpixels / AreaofImage) * 100;
            Bitmap temp = new Bitmap(ResultantImage);
            temp.Save("temp.jpg");
            return PercentageOfBlack;
        }
    }
}
