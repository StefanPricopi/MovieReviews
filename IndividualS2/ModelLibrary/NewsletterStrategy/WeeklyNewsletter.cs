using ModelLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.NewsletterStrategy
{
    using System;
    using System.Threading;
    using System.Net;
    using System.Net.Mail;

    public class WeeklyNewsletter : INewsletterStrategy
    {

        public WeeklyNewsletter()
        {

        }
        public void SendNewsletter()
        {
            try
            {
                // Modify the content, recipient, subject, etc. as needed
                string senderEmail = "alin13032001asd@gmail.com";
                string recipientEmail = "pricopi.stefan.alin@gmail.com";
                string subject = "New Daily Newsletter Subject";
                string body = "This is your updated  weekly newsletter content.";

                using (var message = new MailMessage(senderEmail, recipientEmail))
                {
                    message.Subject = subject;
                    message.Body = body;

                    using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential("smtp", "yzkpi sovm jfyr ssyz");
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(message);
                    }
                }

                Console.WriteLine("Updated Email sent: This is your updated weekly newsletter content.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending updated email: {ex.Message}");
            }
        }
    
    }

}
