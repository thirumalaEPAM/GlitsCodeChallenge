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
            string password=string.Empty;
            ExchangeService exchangeService = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            if (email == Constants.email1) password = Constants.password1;
            else if (email == Constants.email2) password = Constants.password2;
            else password = Constants.newPassWord;

            exchangeService.Credentials = new WebCredentials(email, password, Constants.outlook);
            exchangeService.AutodiscoverUrl(email);            

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
