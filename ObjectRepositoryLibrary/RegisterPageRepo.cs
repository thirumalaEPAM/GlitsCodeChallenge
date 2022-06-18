using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRepositoryLibrary
{
    public class RegisterPageRepo
    {
        public static By elementRegisterLink = By.XPath("//span[text()='Register']");
        public static By elementBusinessType = By.XPath("//div[text()='Incorporate a business in Singapore']");
        public static By elementContinue = By.XPath("//span[text()='Continue']");
        public static By elementFullName = By.Name("full_name");
        public static By elementPrefferedName = By.Name("preferred_name");
        public static By elementEmail = By.Name("email");
        public static By elementPhone = By.XPath("//input[@name='phone']");
        public static By elementSpcialSiteName = By.XPath("//input[@class='q-field__input q-placeholder col']");
        public static By elementTC = By.XPath("//div[@class='q-checkbox__bg absolute']");


    }
}
