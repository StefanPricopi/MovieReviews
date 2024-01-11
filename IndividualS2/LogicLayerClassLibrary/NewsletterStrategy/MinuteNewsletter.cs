using ModelLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LogicLayerClassLibrary.Classes;

namespace ModelLibrary.NewsletterStrategy
{

    public class MinuteNewsletter : INewsletterStrategy
    {
        public string StrategyIdentifier => "60s";
        public void SendNewsletter()
        {
           
            try
            {
                string senderEmail = "alin13032001asd@gmail.com";
                string receiverEmail = "pricopi.stefan.alin@gmail.com";
                string subject = "New minute Newsletter Subject";
                string messageBody = "This is your minute update";

                MailMessage mail = new MailMessage(senderEmail, receiverEmail);
                mail.Subject = subject;
                mail.Body = messageBody;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(senderEmail, "yzkpi sovm jfyr ssyz"), 
                    EnableSsl = true,
                };
                //smtpClient.Send(mail);
                Console.WriteLine("minute newsletter sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

    }
}


