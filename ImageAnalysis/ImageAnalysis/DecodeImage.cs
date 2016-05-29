using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MessagingToolkit.Barcode;

namespace ImageAnalysis
{
    class DecodeImage
    {
        public string DecodeDeviceImage(Bitmap ImageBitmap)
        {
            BarcodeDecoder bd = new BarcodeDecoder();
            Result res = bd.Decode(ImageBitmap);
            string DecodedResult = res.Text;

            return DecodedResult;
        }
    }
}
