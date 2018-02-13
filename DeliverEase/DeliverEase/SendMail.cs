using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DeliverEase
{
    public class SendMail
    {
        public void SendEmail(string sendAddress, string subject, string msgContent, List<string>htmlContent)
        {

            KeyManager key = new KeyManager();
            var apiKey = key.SendGridKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("invoice@DeliverEase.com", "DeliverEase");
            var to = new EmailAddress(sendAddress);
            StringBuilder str = new StringBuilder();
            str.Append("<br />" + msgContent);
            
            for (int i = 0; i < htmlContent.Count; i++)
            {
                if (i != htmlContent.Count - 1)
                {
                    str.Append("<br />" +  "-" + htmlContent[i]);
                }else
                {
                    str.Append("<br /><br />"+"<strong><u>"+"Total Cost"+"</u></strong> "+ "<br />");

                    str.Append("$" + htmlContent[i]);
                }
            }
            var htmlTextContent = str.ToString();
            var msg = MailHelper.CreateSingleEmail(from, to, subject, msgContent, htmlTextContent);
            var response = client.SendEmailAsync(msg);
        }
    }
}