using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRepositoryLibrary
{
    public class CommonUtility
    {
        IWebDriver webdriver;

        public IWebElement WaitForElement(By elt)
        {

            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(5));
            return wait.Until(X => X.FindElement(elt));
        }

        public String getElementText(By elt)
        {

            return WaitForElement(elt).Text.ToString();
        }

        public void SendText(By elt, String text)
        {

            WaitForElement(elt).SendKeys(text);

        }

        public void EnterLocations(By elt, String location)
        {
            Actions act = new Actions(webdriver);
            WaitForElement(elt).SendKeys(location);
            act.SendKeys(Keys.Down);
            act.SendKeys(Keys.Enter);
            act.Perform();

        }

        public void ClickElement(By elt)
        {
            WaitForElement(elt).Click();
        }

        public void pageScroll(By elt)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            js.ExecuteScript("window.scrollBy(0, 250)", "");

        }


        public void ClickListWebElements(By by)
        {
            IList<IWebElement> elts = webdriver.FindElements(by);
            elts[elts.Count - 1].Click();
        }
        public int CountElements(By by)
        {
            IList<IWebElement> elts = webdriver.FindElements(by);
            return elts.Count;
        }
        public void SelectValue(By by, string value)
        {
            SelectElement sel = new SelectElement(WaitForElement(by));
            sel.SelectByText(value);

        }
        public void pageScrollandClick(By elt)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            js.ExecuteScript("arguments[0].click();", webdriver.FindElement(elt));

        }

        public void Mouseclick(By by)
        {
            Actions act = new Actions(webdriver);
            act.MoveToElement(WaitForElement(by)).Click();
            act.Perform();

        }
        public CommonUtility(IWebDriver driver) { this.webdriver = driver; }
    }
}
