using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ISampleMovieDb.Api.Util.Mail
{
    public class SendMail
    {
        public bool Send(string subject, string message, List<string> bccList, string senderMail, string password, string server, int port, string displayName, bool ssl)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(senderMail, displayName, System.Text.Encoding.UTF8);
                SmtpClient smtp = new SmtpClient();

                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailMessage.Body = message;
                mailMessage.Priority = MailPriority.High;

                

                if (bccList != null)
                {
                    if (bccList.Count > 0)
                    {
                        foreach (var bcc in bccList)
                        {
                            mailMessage.Bcc.Add(bcc);
                        }
                    }
                }

                smtp.Credentials = new System.Net.NetworkCredential(senderMail, password);
                smtp.Port = port;
                smtp.Host = server;
                smtp.EnableSsl = ssl;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(mailMessage);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
