using ObjectRepositoryLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public class PageHelper
    {

        IWebDriver webdriver;
        CommonUtility Commonobj;
        /// <summary>
        /// Button Click method
        /// </summary>
        /// <param name="locator"></param>
        public void ButtonClick(By by)
        {
            Commonobj.ClickElement(by);
        }
        /// <summary>
        /// Take Screen shot method : This method will call when the scenario fails
        /// </summary>
        /// <returns></returns>
        public String TakeScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot)webdriver).GetScreenshot();
            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\", "");
            string path = path1 + "\\Screenshots\\" + RondomNum() + ".png";
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }

        public void EnterEmailorMobile(By by, string text)
        {
            Commonobj.SendText(by, text);
        }

        /// <summary>
        /// Get the Web Element Text
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public string GetText(By by)
        {
            try { return Commonobj.getElementText(by); }
            catch { return "NotMactch"; }
       
        }
        /// <summary>
        /// This method define the Enter the OTP into OTP field
        /// </summary>
        /// <param name="OTP"></param>
        public void EnterOTP(string OTP)
        {
            Actions act = new Actions(webdriver);
            string[] chars = OTP.ToCharArray().Select(c => c.ToString()).ToArray();

            foreach (string c in chars)
            {
                act.SendKeys(c).Build();
            }
            act.Perform();

            System.Threading.Thread.Sleep(Constants.waittime);

        }

        /// <summary>
        /// Get the OTP from the Given Email
        /// </summary>
        /// <returns></returns>
        public string GetOTPfromEmailbody(string email)
        {
            String OTPValue = string.Empty;
            System.Threading.Thread.Sleep(Constants.waittime);
           OTPValue = EmilAuthOTP.GetOTPfromEmailbody(email);
            return OTPValue;
        }

        /// <summary>
        /// New Registrations, Enter all mandatory data by Using Data driven
        /// </summary>
        /// <returns></returns>
        public void NewRegistration()
        {
            try
            {
                System.Threading.Thread.Sleep(Constants.waittime);
                Commonobj.ClickElement(RegisterPageRepo.elementBusinessType);
                Commonobj.pageScroll(RegisterPageRepo.elementContinue);
                Commonobj.ClickElement(RegisterPageRepo.elementContinue);
                System.Threading.Thread.Sleep(Constants.waittime);
                Commonobj.SendText(RegisterPageRepo.elementFullName, "New Sdet Role");
                Commonobj.SendText(RegisterPageRepo.elementPrefferedName, "Test Automation");
                Commonobj.SendText(RegisterPageRepo.elementEmail, "newTest@gmail.com");
                Constants.newEmail = "newTest@gmail.com";
                Constants.newPassWord = "Test1233";
                Commonobj.pageScroll(RegisterPageRepo.elementPhone);
                Commonobj.SendText(RegisterPageRepo.elementPhone, "90908877");
                Commonobj.SelectValue(RegisterPageRepo.elementSpcialSiteName, "LinkedIn");                
                Commonobj.ClickElement(RegisterPageRepo.elementTC);
                Commonobj.pageScroll(RegisterPageRepo.elementContinue);
                Commonobj.ClickElement(RegisterPageRepo.elementContinue);
            }
            catch (Exception ex) { }
            


        }
        public string RondomNum()
        {

            string datetime = DateTime.Now.ToString();
            return datetime.Replace("/", "").Replace(":", "");
        }

        public PageHelper(IWebDriver driver)
        {
            this.webdriver = driver;
            Commonobj = new CommonUtility(webdriver);
        }
    }
}
