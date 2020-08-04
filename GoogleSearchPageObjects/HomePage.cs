using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleSearchPageObjects
{
    class HomePage
    {
        String test_url = "https://www.google.com";

        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        //[FindsBy(How = How.XPath, Using = "//*[@id='tsf']/div[2]/div[1]/div[1]/div/div[2]/input")]
        [FindsBy(How = How.Name, Using = "q")]
        [CacheLookup]
        private IWebElement elem_search_text;

        public void goToPage()
        {
            driver.Navigate().GoToUrl(test_url);
        }

        public String getPageTitle()
        {
            return driver.Title;
        }
        public SearchPage test_search(string input_search)
        {
            elem_search_text.SendKeys(input_search);
            //wait.Until(ExpectedConditions.ElementToBeClickable(elem_submit_button)).Submit();
            elem_search_text.Submit();
            return new SearchPage(driver);
        }
    }
}
