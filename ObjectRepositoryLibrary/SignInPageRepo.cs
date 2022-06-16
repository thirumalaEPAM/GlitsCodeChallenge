using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRepositoryLibrary
{
    public class SignInPageRepo
    {
        public static By elementEmailorPhone = By.XPath("//input[@name='username']");
        public static By elementNext = By.XPath("//span[text()='Next']");
        public static By elementtOTP = By.XPath("//div[@class='digit-input__input-mask flex justify-between no-wrap']");
        public static By elementtNewOTP = By.XPath("//div[@class='digit-input__input flex flex-center text-weight-medium cursor-pointer digit-input__input--highlight digit-input__input--blinking']");
        public static By elementHomePage = By.XPath("//div[text()='Home']");
        public static By elementCompleteForm = By.XPath("//span[text()='Complete application']");
        public static By elementgetStarted = By.XPath("//span[text()='Get Started']");
    }
}
