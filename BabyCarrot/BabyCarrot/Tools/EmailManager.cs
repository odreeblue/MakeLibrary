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
        private MailMessage _MailMessage;
        private SmtpClient _SmtpClient;

        public EmailManager(string host, int port, string id, string password)
        {
            _SmtpClient = new SmtpClient(host, port);
            _SmtpClient.Credentials = new NetworkCredential(id, password);

            _MailMessage = new MailMessage();
            _MailMessage.IsBodyHtml = true;
            _MailMessage.Priority = MailPriority.Normal;
        }
        public string From
        {
            get { return _MailMessage.From == null? String.Empty:_MailMessage.From.Address; }
            set { _MailMessage.From = new MailAddress(value); }
        }
        public MailAddressCollection To
        {
            get { return _MailMessage.To; }
        }
        public string Subject
        {
            get { return _MailMessage.Subject; }
            set { _MailMessage.Subject = value; }
        }
        public string Body
        {
            get { return _MailMessage.Body; }
            set { _MailMessage.Body = value; }
        }
        public void Send()
        {
            _SmtpClient.Send(_MailMessage);
        }
    
        #region Static Methods
        public static void Send(string from,string to, string subject, string contents, string cc, string bcc)
        {
            if (String.IsNullOrEmpty(from))
                throw new ArgumentException("Sender is empty.");
            if (String.IsNullOrEmpty (to))
                throw new ArgumentException("To is empty.");
            //string sender = ConfigurationManager.AppSettings["SMTPSender"];

            string smtpHost = ConfigurationManager.AppSettings["SMTPHost"];

            int smtpPort = 0;
            if (ConfigurationManager.AppSettings["SMTPPort"] == null ||
                int.TryParse(ConfigurationManager.AppSettings["SMTPPort"], out smtpPort) == false)
            {
                smtpPort = 25;
            }
            //int smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);

            string smtpId = ConfigurationManager.AppSettings["SMTPID"]; ;
            string smtpPwd = ConfigurationManager.AppSettings["SMTPPassword"]; ;

            MailMessage mailMsg = new MailMessage();
            mailMsg.From = new MailAddress(from);
            mailMsg.To.Add(new MailAddress(to));

            if (!String.IsNullOrEmpty(cc))
                mailMsg.CC.Add(cc);
            if (!String.IsNullOrEmpty(bcc))
                mailMsg.Bcc.Add(bcc);

            mailMsg.Subject = subject;
            mailMsg.IsBodyHtml = true;
            mailMsg.Body = contents;
            mailMsg.Priority = MailPriority.Normal;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(smtpId, smtpPwd);
            smtpClient.Host = smtpHost;
            smtpClient.Port = smtpPort;
            smtpClient.Send(mailMsg);
        }
        public static void Send(string from, string to, string subject, string contents)
        {
            Send(from,to,subject,contents,null,null);
        }

        public static void Send(string to, string subject, string contents)
        {
            string sender = ConfigurationManager.AppSettings["SMTPSender"];
            Send(sender, to, subject, contents);
        }
        #endregion
    }
}
