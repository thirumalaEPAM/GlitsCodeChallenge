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
        /// <summary>
        /// Web driver should wait untill element found : Explicite wait
        /// </summary>
        /// <param name="elt"></param>
        /// <returns></returns>
        public IWebElement WaitForElement(By elt)
        {

            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(5));
            return wait.Until(X => X.FindElement(elt));
        }

        /// <summary>
        /// Get the web element text using element.text method
        /// </summary>
        /// <param name="elt"></param>
        /// <returns></returns>
        public String getElementText(By elt)
        {

            return WaitForElement(elt).Text.ToString();
        }

        /// <summary>
        /// Enter the text into input Webelement
        /// </summary>
        /// <param name="elt"></param>
        /// <param name="text"></param>
        public void SendText(By elt, String text)
        {

            WaitForElement(elt).SendKeys(text);

        }
        /// <summary>
        /// Web Element Click
        /// </summary>
        /// <param name="elt"></param>
        public void ClickElement(By elt)
        {
            WaitForElement(elt).Click();
        }
        /// <summary>
        /// Page scroll to perticular location
        /// </summary>
        /// <param name="elt"></param>
        public void pageScroll(By elt)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            js.ExecuteScript("window.scrollBy(0, 250)", "");

        }

      /// <summary>
      /// Select the Drop down value
      /// </summary>
      /// <param name="by"></param>
      /// <param name="value"></param>
        public void SelectValue(By by, string value)
        {
            SelectElement sel = new SelectElement(WaitForElement(by));
            sel.SelectByText(value);

        }

        /// <summary>
        /// Page scroll to webelement and perform the click
        /// </summary>
        /// <param name="elt"></param>
        public void pageScrollandClick(By elt)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            js.ExecuteScript("arguments[0].click();", webdriver.FindElement(elt));

        }

        /// <summary>
        /// WebElelement click using Actions Method
        /// </summary>
        /// <param name="by"></param>
        public void Mouseclick(By by)
        {
            Actions act = new Actions(webdriver);
            act.MoveToElement(WaitForElement(by)).Click();
            act.Perform();

        }
        public CommonUtility(IWebDriver driver) { this.webdriver = driver; }
    }
}
