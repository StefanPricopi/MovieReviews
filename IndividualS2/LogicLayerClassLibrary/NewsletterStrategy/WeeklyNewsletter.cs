﻿using ModelLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Net;
using System.Net.Mail;
using LogicLayerClassLibrary.Classes;

namespace ModelLibrary.NewsletterStrategy
{
    public class WeeklyNewsletter : INewsletterStrategy
    {
        public string StrategyIdentifier => "weekly";
        public TimeSpan Interval => TimeSpan.FromDays(7);
        public WeeklyNewsletter()
        {

        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (WeeklyNewsletter)obj;
            return Interval == other.Interval && StrategyIdentifier == other.StrategyIdentifier;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Interval, StrategyIdentifier);
        }
        public void SendNewsletter()
        {

            try
            {
                string senderEmail = "alin13032001asd@gmail.com";
                string receiverEmail = "pricopi.stefan.alin@gmail.com";
                string subject = "New weekly Newsletter Subject";
                string messageBody = "This is your weekly update";

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
                Console.WriteLine("weekly newsletter sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    
    }

}
