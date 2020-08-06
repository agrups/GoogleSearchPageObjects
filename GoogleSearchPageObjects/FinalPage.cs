using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GoogleSearchPageObjects
{
    public class FinalPage
    {
        private IWebDriver driver;
        Int32 timeout = 10000; // in milliseconds

        public FinalPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public String getPageTitle()
        {
            load_complete();
            return driver.Title;
        }

        public void load_complete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
