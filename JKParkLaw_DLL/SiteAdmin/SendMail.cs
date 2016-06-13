using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using NLog;

namespace SiteAdmin
{
    public class SendMail
    {
        static Logger logger = LogManager.GetLogger("MyClass");

        public static string sSMTP = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"];

        public static bool SendMailMessage(string fromEmail, string destEmail, string sSubject, string sBody, string messageFormat, string mailToType)
        {
            try
            {
                logger.Debug("SMTPServer " + sSMTP);
                logger.Debug("fromEmail " + fromEmail);
                logger.Debug("destEmail " + destEmail);

                SmtpClient client = new SmtpClient(sSMTP);
                //SmtpClient client = new SmtpClient("localhost");

                // Specify the e-mail sender.
                // Create a mailing address that includes a UTF8 character
                // in the display name.
                MailAddress from = new MailAddress(fromEmail);
                // Set destinations for the e-mail message.
                MailAddress to = new MailAddress(destEmail);

                // Specify the message content.
                MailMessage message = new MailMessage(from, to);
                message.Body = sBody;
                // Include some non-ASCII characters in body and subject.
                //string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
                message.Body += Environment.NewLine;// +someArrows;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Subject = sSubject;// +someArrows;
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                if (messageFormat == "HTML")
                {
                    message.IsBodyHtml = true;
                }

                client.Send(message);

                // Clean up.
                message.Dispose();

            }
            catch (Exception e)
            {
                logger.Error("Mail Sending error! " + e.Message);
                return false;
                //throw e;
            }

            return true;
        }

        public static void Main(string[] args)
        {
            string fromEmail = "noreply@localhost.com";
            string destEmail = "mjkwak7@hotmail.com";
            string sSubject = "Test message!";
            string sBody = "This is a test message.";
            string messageFormat = "HTML";
            string mailToType = "";
            bool result = SendMailMessage(fromEmail, destEmail, sSubject, sBody, messageFormat, mailToType);

            //Console.WriteLine(result);
        }
    }
}
