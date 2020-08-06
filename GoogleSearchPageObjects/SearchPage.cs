using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading.Tasks;

namespace GoogleSearchPageObjects
{
    public class SearchPage
    {
        private IWebDriver driver;
        Int32 timeout = 10000; // in milliseconds

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By _linkList = By.CssSelector("div.g>div.rc>div.r>a");

        async void async_delay()
        {
            await Task.Delay(50);
        }

        public void click_search_results()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            driver.FindElements(_linkList)[1].Click();
        }
    }
}
