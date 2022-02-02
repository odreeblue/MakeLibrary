using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Configuration;
namespace BabyCarrot.Tools
{
    public class EmailManager
    {
        public static void Send(string to, string subject, string contents)
        {
            string sender = ConfigurationManager.AppSettings["SMTPSender"];
            
            string smtpHost = ConfigurationManager.AppSettings["SMTPHost"];

            int smtpPort = 0;
            if (ConfigurationManager.AppSettings["SMTPPort"]==null ||
                int.TryParse(ConfigurationManager.AppSettings["SMTPPort"],out smtpPort)==false)
            {
                smtpPort = 25;
            }
            //int smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);
            
            string smtpId = ConfigurationManager.AppSettings["SMTPID"]; ;
            string smtpPwd = ConfigurationManager.AppSettings["SMTPPassword"]; ;

            MailMessage mailMsg = new MailMessage();
            mailMsg.From = new MailAddress(sender);
            mailMsg.To.Add(new MailAddress(to));

            mailMsg.Subject = subject;
            mailMsg.IsBodyHtml = true;
            mailMsg.Body = contents;
            mailMsg.Priority = MailPriority.Normal;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(smtpId,smtpPwd);
            smtpClient.Host = smtpHost;
            smtpClient.Port = smtpPort;
            smtpClient.Send(mailMsg);
        }
    }
}
