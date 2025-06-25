using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public class EmailHelper
    {
        public static bool SendEmail(string to, string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("oliveshikder2018@gmail.com", "eflq rigx xpnh jktg"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("youradminemail@gmail.com", "Customer Feedback System"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(to);

                smtpClient.Send(mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
