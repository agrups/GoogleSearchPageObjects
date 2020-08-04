using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearchPageObjects
{
    class SearchPage
    {
        private IWebDriver driver;
        Int32 timeout = 10000; // in milliseconds

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "div.g>div.rc>div.r>a")]
        private IList<IWebElement> linkList;

        async void async_delay()
        {
            await Task.Delay(50);
        }

        public FinalPage click_search_results()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            linkList[1].Click();

            async_delay();

            return new FinalPage(driver);
        }
    }
}
