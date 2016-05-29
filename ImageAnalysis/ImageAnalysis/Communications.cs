using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using OpenPop.Pop3;
using OpenPop.Mime;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;



namespace ImageAnalysis
{
    class Communications
    {
        public int messagecount;
        public List<string> NameList = new List<string>();
        public List<string> EmailFromList = new List<string>();
        public List<string> PhoneNumberList = new List<string>();
        


        public Communications()
        {
            // Found the conversion to bitmap code here: http://stackoverflow.com/questions/5400173/converting-a-base-64-string-to-an-image-and-saving-it


        }

        public void SendEmail(string EmailAddress, string EmailSubjectline, string EmailBody)
        {

            // Only to send e-mails... 
            MailAddress mail = new MailAddress(EmailAddress); //Reciever 
            MailMessage message = new MailMessage();
            message.To.Add(mail);

            message.From = new MailAddress("fouadalnoor1@gmail.com"); //Sender
            message.Subject = EmailSubjectline;
            message.Body = EmailBody;
            SmtpClient smtpclient = new SmtpClient("smtp.gmail.com", 587);  //setting up the smtp client 
            smtpclient.Credentials = new NetworkCredential("fouadalnoor1@gmail.com", "aneoeled1");
            smtpclient.EnableSsl = true;

             smtpclient.Send(message); //sending e-mail. 
          

        }

        public void UpdateEmail()
        {

            //POP3 to recieve e-mails 

            Pop3Client pop3client = new Pop3Client();
            pop3client.Connect("pop.gmail.com", 995, true);
            pop3client.Authenticate("fouadalnoor1@gmail.com", "aneoeled1");
            messagecount = pop3client.GetMessageCount(); //messages in Inbox. 


            // We want to download all messages
            List<Message> allMessages = new List<Message>(messagecount);

            // Messages are numbered in the interval: [1, messageCount]
            // Ergo: message numbers are 1-based.
            // Most servers give the latest message the highest number

            List<MessagePart> tempList = new List<MessagePart>();
          

            for (int i = messagecount; i > 0; i--)
            {
                Pop3Client temppop3client = new Pop3Client();
                temppop3client.Connect("pop.gmail.com", 995, true);
                temppop3client.Authenticate("fouadalnoor1@gmail.com", "aneoeled1");
                tempList = temppop3client.GetMessage(i).FindAllAttachments();

                if (tempList.Count != 0)
                {
                   allMessages.Add(temppop3client.GetMessage(i)); //ArgumentNullException?  //only adds messages with attachment 


                }
            }

            messagecount = allMessages.Count; 


                string tempmessage;
      
           
            for (int i = 0; i < allMessages.Count; i++)
            {
                tempmessage = ASCIIEncoding.ASCII.GetString(allMessages[i].RawMessage); //store the e-mail in tempmessage

                NameList.Add(allMessages[(allMessages.Count-1)-i].Headers.From.DisplayName); //storing names for use in GUI.
                EmailFromList.Add(allMessages[(allMessages.Count-1) - i].Headers.From.Address); //storing e-mail addresses for use in GUI.
                PhoneNumberList.Add(allMessages[(allMessages.Count-1) - i].Headers.Subject); //storing phone number to use in GUI (the sender should write phone number in subject line). 
                

                StreamWriter StreamWriter = new StreamWriter("RawEmailData" + ((allMessages.Count-1)-i) + ".txt");
                StreamWriter.Write(tempmessage);
                StreamWriter.Close();

                if (allMessages[i].MessagePart.IsMultiPart) //check if there is an image attachement to download... 
                {
                    
                    List<MessagePart> tempmsgpart = new List<MessagePart>();
                    tempmsgpart = allMessages[i].FindAllAttachments();
                    FileInfo file = new FileInfo("DeviceImage" + ((allMessages.Count - 1) - i) + ".jpg");

                    tempmsgpart[0].Save(file); //assume one attachment 
                }
            }
        }

        public void SendSMS(string mobilenumber, string SMSmessage)
        {
            /*
            // Only to send e-mails... 
            MailAddress mail = new MailAddress("07947998867@mmsreply.t-mobile.co.uk <2Yh2UYqdKT3idEvgSBzh29C9t44~MWD803SOYRfl@mmsreply.t-mobile.co.uk>"); //Reciever, you need 
            MailMessage message = new MailMessage();                                                                                                     //need to add the WHOLE address
            message.To.Add(mail);                                                                                                                        //including the number 

            message.From = new MailAddress("fouadalnoor1@gmail.com"); //Sender
            message.Subject = "";
            message.Body = SMSmessage;

            //logging into email
            SmtpClient smtpclient = new SmtpClient("smtp.gmail.com", 587);  //setting up the smtp client 
            smtpclient.Credentials = new NetworkCredential("fouadalnoor1@gmail.com", "aneoeled1");
            smtpclient.EnableSsl = true;


            smtpclient.Send(message);  //sending SMS. 

    */

            // Find your Account Sid and Auth Token at twilio.com / user / account

            
            string AccountSid = "ACf0c643e76cdad4e4533c9e06ef564072";
            string AuthToken = "41b4b6289a04e489cd1d149303dddca7";
            var twilio = new Twilio.TwilioRestClient(AccountSid, AuthToken);

            var smsmessage = twilio.SendMessage("+441603914009", mobilenumber, SMSmessage);
            Console.WriteLine(smsmessage.Sid);

            

        }
    }
}
