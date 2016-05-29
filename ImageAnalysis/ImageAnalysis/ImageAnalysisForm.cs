using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;

//notes:

// online and offline now works (must ensure that only e-mail with attachements are there or the online part will not work)
//The programs does not overwrite old comparison percentages with new ones. This needs to be fixed.
//The Squares Decomposition only works with images with white bakckgrounds (I think). 
namespace ImageAnalysis
{
    public partial class ImageAnalysisForm : Form
    {
        int ImageNumber=0;
        int TotalImages;
        List<string> NameList = new List<string>();
        List<string> EmailList = new List<string>();
        List<string> PhoneNumberList = new List<string>();
        List<string> MsgBodyList = new List<string>();
        List<double> CompareResults = new List<double>();
        string refrenceImageFileName = "RefrenceImage1.jpg";
        Bitmap RefrenceImage;
        string response;
        string flagstring = "";
        bool flag=false;
        bool InternetCon=false;
        int TotalNumberofImages = 0;
        
 
      
        public ImageAnalysisForm()
        {
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //load the refrence image
            RefrenceImageBox.ImageLocation = refrenceImageFileName;
 
            //check internet connection;
            WebClient web = new WebClient();
            try
            {  web.OpenRead("http://www.google.com");
                 InternetCon = true;
            }
            catch
            {
                InternetCon = false;
            }

            InternetTextBox.Text = InternetCon.ToString();

            try
            {
                //if an Internet connection is availible. 
                //Updating Images 
                Communications comms = new Communications();
                comms.UpdateEmail();
                TotalImages = comms.messagecount;
                //Loading Image into picturebox 
                Image DeviceImage0 = new Bitmap("DeviceImage0.jpg");
                ReceivedImageBox.Image = DeviceImage0;
                //updating information 
                NameList = comms.NameList;
                EmailList = comms.EmailFromList;
                PhoneNumberList = comms.PhoneNumberList;
            }

            catch
            {
                //Populating NameList, EmailList and PhoneNumberList when there is no Internet connection
                int i = 0; 
                try
                {
                    while (true)
                    {
                        //setting the first image. 
                        ReceivedImageBox.ImageLocation = "DeviceImage0.jpg";
                        StreamReader tempreader = new StreamReader("RawEmailData" + i + ".txt");
                        string RawEmailString = tempreader.ReadToEnd();
                        //populating NameList
                        Regex tempregs = new Regex("From:");
                        string[] TempSenderName = tempregs.Split(RawEmailString);
                        Regex tempregs1 = new Regex("<");
                        string[] SenderName = tempregs1.Split(TempSenderName[1]);
                        NameList.Add(SenderName[0]);

                        //Populating EmailList
                        Regex tempregs2 = new Regex(">");
                        string[] EmailAddress = tempregs2.Split(SenderName[1]);
                        EmailList.Add(EmailAddress[0]);
                        //Populating PhoneNumberList
                        Regex tempregs3 = new Regex("Subject:");
                        string[] TempPhoneNumber = tempregs3.Split(RawEmailString);
                        Regex tempregs4 = new Regex("\r\n");
                        string[] PhoneNumber = tempregs4.Split(TempPhoneNumber[1]);
                        PhoneNumberList.Add(PhoneNumber[0]);
                        i++;
                        TotalImages = i;
                    }

                }

                catch
                {
                  
                }

            }

            //checking the total number of images;

            try
            {
                while (true)
                {
                    Bitmap tempbitmap = new Bitmap("DeviceImage" + TotalNumberofImages + ".jpg");
                    TotalNumberofImages++;
                }
            }
            catch
            {
                ImageNumberLabel.Text = "Device " + ImageNumber + " out of: " +(TotalNumberofImages-1);
            }

            //Checking total number of images is done. 

            //read flag from file 
            StreamReader reader = new StreamReader("flaglist.txt");
            string tempflaglist = reader.ReadToEnd();
            reader.Close();


            Regex regx = new Regex("Device" + ImageNumber + "true ");
            //set flag 
            if (regx.IsMatch(tempflaglist))
            {
                flag = true;
            }

            else
            {
                flag = false;
            }

            //check if the user has responded to the patient 

            StreamReader reader1 = new StreamReader("Responselist.txt");
            string tempResponselist = reader1.ReadToEnd();
            reader1.Close();

            Regex regs0 = new Regex("Device" + ImageNumber + "Email ");
            Regex reg1 = new Regex("Device" + ImageNumber + "SMS ");
            Regex regs3 = new Regex("Device" + ImageNumber + "SMS and Email ");


            response = "No"; //default response. 

            if (regs0.IsMatch(tempResponselist))
            {
                response = "Yes - Email";
            }

            if (reg1.IsMatch(tempResponselist))
            {
                response = "Yes - SMS";
            }

            if (regs3.IsMatch(tempResponselist) | (regs0.IsMatch(tempResponselist)) & (reg1.IsMatch(tempResponselist)))
            {
                response = "Yes - SMS & Email";
            }

            InformationTextBox.Text = "Name: " + NameList[0] + "\r\nEmail: " + EmailList[0] + "\r\nPhone Number: " + PhoneNumberList[0] + 
            " \r\nResponded to: " + response + "\r\nFlag: " + flag;


            StreamReader reader0 = new StreamReader("PercentageList.txt");
            string read = reader0.ReadToEnd();
            reader0.Close();

            Regex regs1 = new Regex("Device" + ImageNumber + "=");
            Regex regs2 = new Regex("\r\n");
            if (regs1.IsMatch(read))
            {
                string[] temp = regs1.Split(read);
                string[] temp1 = regs2.Split(temp[1]);

                PercentageTextBox.Text = temp1[0];

            }

            //checking if the sample is a positive/negative match. 
            if (GreenCheckbox.Checked & !SquaresCheckbox.Checked)
            {
                //checking if the sample is a positive/negative match 
                try
                {
                    if ((float.Parse(PercentageTextBox.Text) >= 4) & (float.Parse(PercentageTextBox.Text) <= 8) | (float.Parse(PercentageTextBox.Text) >= 11) & (float.Parse(PercentageTextBox.Text) <= 16))
                    {
                        CheckBoxFalse.Checked = false;
                        CheckBoxTrue.Checked = true;
                    }

                    else
                    {
                        CheckBoxFalse.Checked = true;
                        CheckBoxTrue.Checked = false;
                    }
                }

                catch
                {
                    CheckBoxFalse.Checked = false;
                    CheckBoxTrue.Checked = false;
                }

            }


            if (!GreenCheckbox.Checked & SquaresCheckbox.Checked)
            {
                //checking if the sample is a positive/negative match 
                try
                {
                    if (10 > double.Parse(PercentageTextBox.Text))
                    {
                        CheckBoxFalse.Checked = false;
                        CheckBoxTrue.Checked = true;
                    }

                    else
                    {
                        CheckBoxFalse.Checked = true;
                        CheckBoxTrue.Checked = false;
                    }
                }

                catch
                {
                    CheckBoxFalse.Checked = false;
                    CheckBoxTrue.Checked = false;
                }

            }
          
             
        }

        private void SendButtton_Click(object sender, EventArgs e)
        {
            //check internet connection//
            WebClient web = new WebClient();
            Stream myStream = null; 
            try
            {
                 myStream = web.OpenRead("http://www.google.com");
                InternetCon = true;
            }
            catch
            {
                InternetCon = false;
            }

            myStream.Close(); 

            //Checking for internet connection done//



            if ((InternetCon == true)&(!flag)) 
            {
                Communications comms = new Communications();

                if ((EmailCheckBox.Checked == false) & (SMSCheckBox.Checked == false))
                {
                    MessageTextBox.Text = "No Message Sent, please tick Email or SMS checkbox";
                    StreamWriter writer = new StreamWriter("Responselist.txt", true);
                    writer.WriteLine("Device" + ImageNumber + "No ");
                    writer.Close();
                }

                if ((EmailCheckBox.Checked == true) & (SMSCheckBox.Checked == false))
                {
                    //overwrite previous entry for that device
                    StreamReader reader = new StreamReader("Responselist.txt");
                    string tempstring0 = reader.ReadToEnd();
                    reader.Close();

                    Regex regs = new Regex("Device" + ImageNumber + "No ");
                    string tempstring1 = regs.Replace(tempstring0, "");  //deletes the "no" responses 
                    StreamWriter writer = new StreamWriter("Responselist.txt", true);
                    writer.WriteLine(tempstring1);

                    //write new entry
                    comms.SendEmail(EmailList[ImageNumber], "ImageAnalysis", MessageTextBox.Text);
                    MessageTextBox.Text = "Email Message Sent";
                    writer.WriteLine("Device" + ImageNumber + "Email ");
                    writer.Close();

                }

                if ((EmailCheckBox.Checked == false) & (SMSCheckBox.Checked == true))
                {
                    //overwrite previous entry for that device
                    StreamReader reader = new StreamReader("Responselist.txt");
                    string tempstring0 = reader.ReadToEnd();
                    reader.Close();

                    Regex regs0 = new Regex("Device" + ImageNumber + "No ");
                    string tempstring1 = regs0.Replace(tempstring0, ""); //delete all the "no" responses 
                    StreamWriter writer = new StreamWriter("Responselist.txt", true);
                    writer.WriteLine(tempstring1);

                    //write new entry 
                    comms.SendSMS(PhoneNumberList[ImageNumber], MessageTextBox.Text);
                    MessageTextBox.Text = "SMS Message Sent";
                    writer.WriteLine("Device" + ImageNumber + "SMS ");
                    writer.Close();
                }

                if ((EmailCheckBox.Checked == true) & (SMSCheckBox.Checked == true))
                {
                    //overwrite previous entry for that device
                    StreamReader reader = new StreamReader("Responselist.txt");
                    string tempstring0 = reader.ReadToEnd();
                    reader.Close();

                    Regex regs0 = new Regex("Device" + ImageNumber + "No ");
                    string tempstring1 = regs0.Replace(tempstring0, ""); //delete all the "no" responses 
                    Regex regs1 = new Regex("Device" + ImageNumber + "Email ");
                    string tempstring2 = regs0.Replace(tempstring1, ""); //delete all the "Email" Responses 
                    Regex regs2 = new Regex("Device" + ImageNumber + "SMS ");
                    string tempstring3 = regs0.Replace(tempstring2, ""); //delete all the "SMS" Responses 

                    StreamWriter writer = new StreamWriter("Responselist.txt", true);
                    writer.WriteLine(tempstring3);
                    //write new entry 
                    comms.SendEmail(EmailList[ImageNumber], "ImageAnalysis", MessageTextBox.Text);
                    comms.SendSMS(PhoneNumberList[ImageNumber], MessageTextBox.Text);
                    MessageTextBox.Text = "Email and SMS Message Sent";
                    writer.WriteLine("Device" + ImageNumber + "SMS and Email ");
                    writer.Close();
                }



                //check if the user has responded to the patient 

                StreamReader reader1 = new StreamReader("Responselist.txt");
                string tempResponselist = reader1.ReadToEnd();
                reader1.Close();

                Regex regs00 = new Regex("Device" + ImageNumber + "Email ");
                Regex reg1 = new Regex("Device" + ImageNumber + "SMS ");
                Regex regs3 = new Regex("Device" + ImageNumber + "SMS and Email ");


                response = "No"; //default response. 

                if (regs00.IsMatch(tempResponselist))
                {
                    response = "Yes - Email";
                }

                if (reg1.IsMatch(tempResponselist))
                {
                    response = "Yes - SMS";
                }

                if (regs3.IsMatch(tempResponselist) | (regs00.IsMatch(tempResponselist)) & (reg1.IsMatch(tempResponselist)))
                {
                    response = "Yes - SMS & Email";
                }

                InformationTextBox.Text = "Name: " + NameList[0] + "\r\nEmail: " + EmailList[0] + "\r\nPhone Number: " + PhoneNumberList[0] +
                " \r\nResponded to: " + response + "\r\nFlag: " + flag;
            }

            else
            {
                MessageTextBox.Text = "No Message Sent - No Internet Connection";
                //checking for Flags

                if (flag == true)
                {
                    MessageTextBox.Text = "No Message Sent - Image Flagged";
                }
                // End of Check for flags 

            }

            InternetTextBox.Text = InternetCon.ToString(); //display internet connection 
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            ComparisonProgressBar.Value=0;//resetting the progress bar 
            LevelTextBox.Clear(); //clearing Level text box and progress bar  
            LevelProgressBar.Value = 0;

            if (ImageNumber > 0)
            {
                ImageNumber--;
            }

            ImageNumberLabel.Text = "Device " + ImageNumber + " out of: " + (TotalNumberofImages - 1);// Displaying image number 

            Image DeviceImage = new Bitmap("DeviceImage"+ImageNumber+".jpg");
            ReceivedImageBox.Image = DeviceImage;

            //read flag from file 
            StreamReader reader = new StreamReader("flaglist.txt");
            string tempflaglist = reader.ReadToEnd();
            reader.Close();

            Regex regx = new Regex("Device" + ImageNumber + "true ");
            //set flag 
            if (regx.IsMatch(tempflaglist))
            {
                flag = true;
            }

            else
            {
                flag = false;
            }

            //check if the user has responded to the patient 

            StreamReader reader1 = new StreamReader("Responselist.txt");
            string tempResponselist = reader1.ReadToEnd();
            reader1.Close();

            Regex regs0 = new Regex("Device" + ImageNumber+"Email ");
            Regex reg1 = new Regex("Device" + ImageNumber + "SMS ");
            Regex regs3 = new Regex("Device" + ImageNumber + "SMS and Email ");


                response = "No"; //default response. 
            
                if (regs0.IsMatch(tempResponselist))
                {
                    response = "Yes - Email";
                }

                if (reg1.IsMatch(tempResponselist))
                {
                    response = "Yes - SMS";
                }

                if (regs3.IsMatch(tempResponselist) | (regs0.IsMatch(tempResponselist)) & (reg1.IsMatch(tempResponselist)))
                {
                    response = "Yes - SMS & Email";
                }
            

           

            InformationTextBox.Text = "Name: " + NameList[ImageNumber] + "\r\nEmail: " + EmailList[ImageNumber] + "\r\nPhone Number: " + PhoneNumberList[ImageNumber] +
            " \r\nResponded to: " + response + "\r\nFlag: " + flag;

            StreamReader reader0 = new StreamReader("PercentageList.txt");
            string read = reader0.ReadToEnd();
            reader0.Close();

            Regex regs1 = new Regex("Device" + ImageNumber + "=");
            Regex regs2 = new Regex("\r\n");
            if (regs1.IsMatch(read))
            {
                string[] temp = regs1.Split(read);
                string[] temp1 = regs2.Split(temp[1]);

                PercentageTextBox.Text = temp1[0];

            }

            else
            {

                PercentageTextBox.Text = "";
            }


            if (GreenCheckbox.Checked & !SquaresCheckbox.Checked)
            {
                //checking if the sample is a positive/negative match 
                try
                {
                    if ((float.Parse(PercentageTextBox.Text) >= 4) & (float.Parse(PercentageTextBox.Text) <= 8) | (float.Parse(PercentageTextBox.Text) >= 11) & (float.Parse(PercentageTextBox.Text) <= 16))
                    {
                        CheckBoxFalse.Checked = false;
                        CheckBoxTrue.Checked = true;
                    }

                    else
                    {
                        CheckBoxFalse.Checked = true;
                        CheckBoxTrue.Checked = false;
                    }
                }

                catch
                {
                    CheckBoxFalse.Checked = false;
                    CheckBoxTrue.Checked = false;
                }

            }


            if (!GreenCheckbox.Checked & SquaresCheckbox.Checked)
            {
                //checking if the sample is a positive/negative match 
                try
                {
                    if (10 > double.Parse(PercentageTextBox.Text))
                    {
                        CheckBoxFalse.Checked = false;
                        CheckBoxTrue.Checked = true;
                    }

                    else
                    {
                        CheckBoxFalse.Checked = true;
                        CheckBoxTrue.Checked = false;
                    }
                }

                catch
                {
                    CheckBoxFalse.Checked = false;
                    CheckBoxTrue.Checked = false;
                }

            }

            //reading Protein levels from file 
            StreamReader r = new StreamReader("ProteinLevelfile.txt");
            string ProteinFileTotal = r.ReadToEnd();
            r.Close();

            Regex regs = new Regex("DeviceImage" + ImageNumber + "=");

            if(regs.IsMatch(ProteinFileTotal))
            {
                string[] tempProteinlevel = regs.Split(ProteinFileTotal);
                LevelTextBox.Text = tempProteinlevel[1];
            }

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            ComparisonProgressBar.Value = 0;//resetting the progress bar
            LevelTextBox.Clear(); //clearing Level text box and progress bar  
            LevelProgressBar.Value = 0;
          

            if (ImageNumber < TotalImages-1)
            {
                ImageNumber++;
            }

            ImageNumberLabel.Text = "Device " + ImageNumber + " out of: " + (TotalNumberofImages - 1); //Displaying image number 

            Image DeviceImage = new Bitmap("DeviceImage" + ImageNumber + ".jpg");
            ReceivedImageBox.Image = DeviceImage;

            //read flag from file 
            StreamReader reader = new StreamReader("flaglist.txt");
            string tempflaglist = reader.ReadToEnd();
            reader.Close();
              

            Regex regx = new Regex("Device" + ImageNumber + "true ");
            //set flag 
            if (regx.IsMatch(tempflaglist))
            {
                flag = true;
            }

            else
            {
                flag = false;
            }

            //check if the user has responded to the patient 

            StreamReader reader1 = new StreamReader("Responselist.txt");
            string tempResponselist = reader1.ReadToEnd();
            reader1.Close();

            Regex regs0 = new Regex("Device" + ImageNumber + "Email ");
            Regex reg1 = new Regex("Device" + ImageNumber + "SMS ");
            Regex regs3 = new Regex("Device" + ImageNumber + "SMS and Email ");


            response = "No"; //default response. 

            if (regs0.IsMatch(tempResponselist))
            {
                response = "Yes - Email";
            }

            if (reg1.IsMatch(tempResponselist))
            {
                response = "Yes - SMS";
            }

            if (regs3.IsMatch(tempResponselist) | (regs0.IsMatch(tempResponselist)) & (reg1.IsMatch(tempResponselist)))
            {
                response = "Yes - SMS & Email";
            }
            
            //check for internet connection

            InformationTextBox.Text = "Name: " + NameList[ImageNumber] + "\r\nEmail: " + EmailList[ImageNumber] + "\r\nPhone Number: " + PhoneNumberList[ImageNumber] + 
            " \r\nResponded to: " + response + "\r\nFlag: " + flag;

            StreamReader reader0 = new StreamReader("PercentageList.txt");
            string read = reader0.ReadToEnd();
            reader0.Close();

            Regex regs1 = new Regex("Device" + ImageNumber + "=");
            Regex regs2 = new Regex("\r\n");
            if (regs1.IsMatch(read))
            {
                string[] temp = regs1.Split(read);
                string[] temp1 = regs2.Split(temp[1]);

                PercentageTextBox.Text = temp1[0];

            }

            else
            {
                PercentageTextBox.Text = "";
            }

            if (GreenCheckbox.Checked & !SquaresCheckbox.Checked)
            {
                //checking if the sample is a positive/negative match 
                try
                {
                    if ((float.Parse(PercentageTextBox.Text) >= 4) & (float.Parse(PercentageTextBox.Text) <= 8) | (float.Parse(PercentageTextBox.Text) >= 11) & (float.Parse(PercentageTextBox.Text) <= 16))
                    {
                        CheckBoxFalse.Checked = false;
                        CheckBoxTrue.Checked = true;
                    }

                    else
                    {
                        CheckBoxFalse.Checked = true;
                        CheckBoxTrue.Checked = false;
                    }
                }

                catch
                {
                    CheckBoxFalse.Checked = false;
                    CheckBoxTrue.Checked = false;
                }

            }


            if (!GreenCheckbox.Checked & SquaresCheckbox.Checked)
            {
                //checking if the sample is a positive/negative match 
                try
                {
                    if (10 > double.Parse(PercentageTextBox.Text))
                    {
                        CheckBoxFalse.Checked = false;
                        CheckBoxTrue.Checked = true;
                    }

                    else
                    {
                        CheckBoxFalse.Checked = true;
                        CheckBoxTrue.Checked = false;
                    }
                }

                catch
                {
                    CheckBoxFalse.Checked = false;
                    CheckBoxTrue.Checked = false;
                }

            }

            //reading Protein levels from file 
            StreamReader r = new StreamReader("ProteinLevelfile.txt");
            string ProteinFileTotal = r.ReadToEnd();
            r.Close();

            Regex regs = new Regex("DeviceImage" + ImageNumber + "=");

            if (regs.IsMatch(ProteinFileTotal))
            {
                string[] tempProteinlevel = regs.Split(ProteinFileTotal);
                LevelTextBox.Text = tempProteinlevel[1];
            }
           
        }

   


        private void FlagButton_Click(object sender, EventArgs e)
        {
            //write to file
             StreamWriter writer = new StreamWriter("flaglist.txt",true);
             writer.WriteLine("Device" + ImageNumber + "true ");
             writer.Close();

             //update textbox
            Regex regs = new Regex("Device" + ImageNumber + "false ");

            if (regs.IsMatch(flagstring))
            {
                flagstring = regs.Replace(flagstring, "Device" + ImageNumber + "true ");
            }

            else
            {
                flagstring = flagstring + "Device" + ImageNumber + "true ";
            }

            flag = true;

            InformationTextBox.Text = "Name: " + NameList[ImageNumber] + "\r\nEmail: " + EmailList[ImageNumber] + "\r\nPhone Number: " + PhoneNumberList[ImageNumber] +
            " \r\nResponded to: " + response + "\r\nFlag: " + flag;

        }

        private void UnFlagButton_Click(object sender, EventArgs e)
        {
            //delete  true flags for the device
            StreamReader reader = new StreamReader("flaglist.txt");
            string tempflags = reader.ReadToEnd();
            reader.Close();

            Regex regs = new Regex("Device" + ImageNumber + "true ");
            tempflags = regs.Replace(tempflags,"");

            //write to file
            StreamWriter writer = new StreamWriter("flaglist.txt");
            writer.WriteLine(tempflags);
            writer.Close();

            //update textbox

            flag = false; 

            InformationTextBox.Text = "Name: " + NameList[ImageNumber] + "\r\nEmail: " + EmailList[ImageNumber] + "\r\nPhone Number: " + PhoneNumberList[ImageNumber] +
            " \r\nResponded to: " + response + "\r\nFlag: " + flag;
            
        }

        private void CompareButton_Click(object sender, EventArgs e)
        {
            //load the refrence image
            RefrenceImageBox.ImageLocation = refrenceImageFileName;
            RefrenceImage = new Bitmap(refrenceImageFileName);
            Bitmap ComparisonImage = new Bitmap("DeviceImage" + ImageNumber + ".jpg");

            if (LevelCheckBox.Checked)
            {
                LevelProgressBar.Value = 0; //resetting the progress bar 
                CalculateLevel getlevel = new CalculateLevel(ComparisonImage);
                LevelTextBox.Text=getlevel.level;
                LevelProgressBar.Increment(100); //incrementing the progress bar 
                ResultingImageBox.Image = getlevel.resultBitmap; //setting the resultant bitmap to imagebox. 
                //writing protein levels to file 
                StreamWriter w = new StreamWriter("ProteinLevelFile.txt",true);
                w.WriteLine("DeviceImage" + ImageNumber + "=" + getlevel.level);
                w.Close();

            }

            if (GreenCheckbox.Checked&!SquaresCheckbox.Checked)
            {
                    ComparisonProgressBar.Value = 0; //resetting progress bar 
                    //delete previous entry
                    StreamReader reader = new StreamReader("PercentageList.txt");
                    string totalfile = reader.ReadToEnd();
                    reader.Close();
                    Regex regs = new Regex("Device" + ImageNumber + "=");
                    if (regs.IsMatch(totalfile))
                    {
                        string newtotalfile =regs.Replace(totalfile, "");

                        StreamWriter tempwriter = new StreamWriter("PercentageList.txt");
                        tempwriter.WriteLine(newtotalfile);
                        tempwriter.Close();
                    }
      
                
                GetGreenPercentage getgreen = new GetGreenPercentage();
                double PercentageOfBlackOriginal = getgreen.GetPercentage(ComparisonImage); 
                if (((PercentageOfBlackOriginal >= 4) & (PercentageOfBlackOriginal <= 8)) | (PercentageOfBlackOriginal >= 11) & (PercentageOfBlackOriginal <= 16)) //setting the checkboxes to correct state. Percentages between 2-8% for positive result  
                {
                    CheckBoxFalse.Checked = false;
                    CheckBoxTrue.Checked = true;
                }

                else
                {
                    CheckBoxFalse.Checked = true;
                    CheckBoxTrue.Checked = false;
                }

                StreamWriter writer = new StreamWriter("PercentageList.txt", true);
                writer.WriteLine("Device" + ImageNumber + "=" + PercentageOfBlackOriginal);
                PercentageTextBox.Text = "" + PercentageOfBlackOriginal + "%";
                writer.Close();
                ResultingImageBox.Image = getgreen.ResultantImage;
                ComparisonProgressBar.Increment(100); //indicating the comparison is done.
            }

            if (!GreenCheckbox.Checked & SquaresCheckbox.Checked)
            {
                ComparisonProgressBar.Value = 0; //resetting progress bar 
                //delete previous entry
                StreamReader reader = new StreamReader("PercentageList.txt");
                string totalfile = reader.ReadToEnd();
                reader.Close();
                Regex regs = new Regex("Device" + ImageNumber + "=");
                if (regs.IsMatch(totalfile))
                {
                    string newtotalfile = regs.Replace(totalfile, "");

                    StreamWriter tempwriter = new StreamWriter("PercentageList.txt");
                    tempwriter.WriteLine(newtotalfile);
                    tempwriter.Close();
                    
                }

                ComparisonProgressBar.Value = 0;
                CompareImages compareImages = new CompareImages(RefrenceImage, ComparisonImage, 1000);
                ResultingImageBox.Image = compareImages.SquareImage; 
                if (compareImages.TotalPercentageDifference < 20) //setting the checkboxes to correct state  
                {
                    CheckBoxFalse.Checked = false;
                    CheckBoxTrue.Checked = true;
                }

                else
                {
                    CheckBoxFalse.Checked = true;
                    CheckBoxTrue.Checked = false;
                }

                StreamWriter writer = new StreamWriter("PercentageList.txt", true);
                writer.WriteLine("Device" + ImageNumber + "=" + compareImages.TotalPercentageDifference);
                PercentageTextBox.Text = "" + compareImages.TotalPercentageDifference + "%";
                writer.Close();
                ComparisonProgressBar.Increment(100); //indicating the comparison is done.
            }

            
            
          
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            MessageTextBox.Text = "";
        }

        private void ChangeRefButton_Click(object sender, EventArgs e)
        {
            openImageFile.ShowDialog();
            refrenceImageFileName = openImageFile.FileName;
            RefrenceImageBox.ImageLocation = openImageFile.FileName; 
        }

        private void DecodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                DecodeImage decodeimage = new DecodeImage();
                Bitmap device = new Bitmap("DeviceImage" + ImageNumber + ".jpg");
                MessageTextBox.Text = decodeimage.DecodeDeviceImage(device);
            }

            catch
            {
                MessageTextBox.Text = "Cannot Decode Image"; 
            }
        }


        private void AutoProcess_Click(object sender, EventArgs e)
        {
            //check internet connection//
            WebClient web = new WebClient();
            try
            {
                web.OpenRead("http://www.google.com");
                InternetCon = true;
            
            }
            catch
            {
                InternetCon = false;
            }

            //Checking for internet connection done//

            //count how many devices there are 
            double j = 0;
            try
            {
                while (true)
                {
                    Bitmap temp = new Bitmap("DeviceImage" + (int)j + ".jpg");
                    j++;
                }

            }

            catch
            {

            }

            //end of counting devices 

            if (InternetCon)
            {
                int i = 0;
                try
                {
                    StreamReader reader = new StreamReader("flaglist.txt");
                    string flaglist = reader.ReadToEnd();
                    reader.Close();

                    while (true)
                    {
                        //Check for flagged images

                            Bitmap image = new Bitmap("DeviceImage" + i + ".jpg");
                            Regex regs = new Regex("Device" + i + "true");

                            if (!regs.IsMatch(flaglist))
                            {
                                GetGreenPercentage getgreenpercent = new GetGreenPercentage();
                                double PercentageOfBlackOriginal = getgreenpercent.GetPercentage(image);
                                Communications comms = new Communications();
                                if (((PercentageOfBlackOriginal >= 4) & (PercentageOfBlackOriginal <= 8)) | (PercentageOfBlackOriginal >= 11) & (PercentageOfBlackOriginal <= 16)) //setting the checkboxes to correct state. Percentages between 2-8% for positive result  
                                {

                                    comms.SendEmail(EmailList[i], "Test Result: Device:" + i, "The result of your test is: Positive");

                                }

                                else
                                {
                                    comms.SendEmail(EmailList[i], "Test Result: Device:" + i, "The result of your test is: Negative");
                                }
                            }
                            i++;
                            int percentage = (int)((1 / j) * 100);
                            AutoProcessProgressBar.Increment(percentage);
                            AutoProcessProgressBar.Update();
                        
                    }
                   
                }

                catch
                {
                    AutoProcessProgressBar.Value = 0;
                }

            }

            else
            {
                MessageTextBox.Text = "Please check the Internet connection and try again";
               
            } 
        }

        private void SquaresCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (GreenCheckbox.Checked & !SquaresCheckbox.Checked)
            {
                //checking if the sample is a positive/negative match 
                try
                {
                    if ((float.Parse(PercentageTextBox.Text) >= 4) & (float.Parse(PercentageTextBox.Text) <= 8) | (float.Parse(PercentageTextBox.Text) >= 11) & (float.Parse(PercentageTextBox.Text) <= 16))
                    {
                        CheckBoxFalse.Checked = false;
                        CheckBoxTrue.Checked = true;
                    }

                    else
                    {
                        CheckBoxFalse.Checked = true;
                        CheckBoxTrue.Checked = false;
                    }
                }

                catch
                {
                    CheckBoxFalse.Checked = false;
                    CheckBoxTrue.Checked = false;
                }

            }


            if (!GreenCheckbox.Checked & SquaresCheckbox.Checked)
            {
                //checking if the sample is a positive/negative match 
                try
                {
                    if (10 > double.Parse(PercentageTextBox.Text))
                    {
                        CheckBoxFalse.Checked = false;
                        CheckBoxTrue.Checked = true;
                    }

                    else
                    {
                        CheckBoxFalse.Checked = true;
                        CheckBoxTrue.Checked = false;
                    }
                }

                catch
                {
                    CheckBoxFalse.Checked = false;
                    CheckBoxTrue.Checked = false;
                }

            }
        }

        private void GreenCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (GreenCheckbox.Checked & !SquaresCheckbox.Checked)
            {
                //checking if the sample is a positive/negative match 
                try
                {
                    if ((float.Parse(PercentageTextBox.Text) >= 4) & (float.Parse(PercentageTextBox.Text) <= 8) | (float.Parse(PercentageTextBox.Text) >= 11) & (float.Parse(PercentageTextBox.Text) <= 16))
                    {
                        CheckBoxFalse.Checked = false;
                        CheckBoxTrue.Checked = true;
                    }

                    else
                    {
                        CheckBoxFalse.Checked = true;
                        CheckBoxTrue.Checked = false;
                    }
                }

                catch
                {
                    CheckBoxFalse.Checked = false;
                    CheckBoxTrue.Checked = false;
                }

            }


            if (!GreenCheckbox.Checked & SquaresCheckbox.Checked)
            {
                //checking if the sample is a positive/negative match 
                try
                {
                    if (10 > double.Parse(PercentageTextBox.Text))
                    {
                        CheckBoxFalse.Checked = false;
                        CheckBoxTrue.Checked = true;
                    }

                    else
                    {
                        CheckBoxFalse.Checked = true;
                        CheckBoxTrue.Checked = false;
                    }
                }

                catch
                {
                    CheckBoxFalse.Checked = false;
                    CheckBoxTrue.Checked = false;
                }

            }
        }

    }
}
