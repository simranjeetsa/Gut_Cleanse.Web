using Microsoft.AspNetCore.Identity.UI.Services;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace Gut_Cleanse.Web.Helpers
{
    public class EmailSender
    {
        public static void Mail(string email, string Subject, string body, string fromEmail = "vermahimanshi648@gmail.com", List<string> path = null)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var host = "smtp.gmail.com";
                var port = 587;
                var Username = "oneliftpartners@gmail.com";
                var Password = "agiyjkyucfzhysou";
                var SSL = true;

                var networkCredential = new NetworkCredential
                {
                    UserName = Username,
                    Password = Password
                };

                SmtpClient smtpClient = new SmtpClient(host, port);
                smtpClient.EnableSsl = SSL;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;

                MailMessage message = new MailMessage();
                if (email.Contains(";"))
                {
                    var ToEmails = email.ToLower().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (ToEmails != null && ToEmails.Any())
                    {
                        foreach (var item in ToEmails)
                        {
                            message.To.Add(item);
                        }
                    }
                }
                else
                {
                    message.To.Add(email);
                }
                if (path != null && path.Count > 0)
                {
                    foreach (string att in path)
                    {
                        if (!string.IsNullOrEmpty(att))
                        {
                            message.Attachments.Add(new Attachment(att));
                        }
                    }
                }
                if (!string.IsNullOrEmpty(fromEmail))
                {
                    message.From = new MailAddress(fromEmail, fromEmail);
                    message.ReplyToList.Add(fromEmail);
                }

                message.Subject = Subject;
                //Set IsBodyHtml to true means you can send HTML email.
                message.IsBodyHtml = true;

                message.Body = body;

                try
                {
                    smtpClient.Send(message);
                    message.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
