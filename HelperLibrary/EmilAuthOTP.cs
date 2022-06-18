using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectRepositoryLibrary;
namespace HelperLibrary
{
    public class EmilAuthOTP
    {

        public static string EmailSubject { get; set; }
        public static string EmailBody { get; set; }
        public static string GetOTPfromEmailbody(string email)
        {
            String OTPValue = string.Empty;
            ExchangeService exchangeService = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            if (email == Constants.email1)
            {
                exchangeService.Credentials = new WebCredentials(Constants.email1, Constants.password1, Constants.outlook);
                exchangeService.AutodiscoverUrl(Constants.email1);
            }
            else if (email == Constants.email2)
            { 
                exchangeService.Credentials = new WebCredentials(Constants.email2, Constants.password2, Constants.outlook);
                exchangeService.AutodiscoverUrl(Constants.email2);
            }
             else
            {
                exchangeService.Credentials = new WebCredentials(Constants.newEmail, Constants.newPassWord, Constants.outlook);
                exchangeService.AutodiscoverUrl(Constants.newEmail);
            }

            if (exchangeService != null)
            {
                FindItemsResults<Item> results = exchangeService.FindItems(WellKnownFolderName.Inbox, new ItemView(100));

                foreach (Item item in results)
                {
                    EmailMessage message = EmailMessage.Bind(exchangeService, item.Id);

                    EmailSubject = message.Subject;

                    if (EmailSubject.Contains(Constants.otp))
                    {
                        EmailBody = message.Body;
                        OTPValue = ExtractOTPValue(EmailBody);
                        break;
                    }

                }
            }
            return OTPValue;
        }

        public static string ExtractOTPValue(string html)
        {
            int bodyBegin = html.IndexOf("<h1>") + "<h1>".Length;
            int bodyEnd = html.IndexOf("</h1>");
            int bodyLength = bodyEnd - bodyBegin;

            return html.Substring(bodyBegin, bodyLength);
        }
    }
}
