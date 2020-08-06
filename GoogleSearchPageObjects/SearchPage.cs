using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using GoogleSearchPageObjects.Infrastructure;

namespace GoogleSearchPageObjects
{
    public class SearchPage : PageBase
    {
        int timeout = 10000; // in milliseconds

        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        private By _linkList = By.CssSelector("div.g>div.rc>div.r>a");

        public void click_search_results()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            Elements(_linkList)[1].Click();
        }
    }
}
