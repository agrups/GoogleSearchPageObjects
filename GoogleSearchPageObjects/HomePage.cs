using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GoogleSearchPageObjects
{
    public class HomePage
    {
        String test_url = "https://www.google.com";

        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public By elem_search_text = By.Name("q");

        public void goToPage()
        {
            driver.Navigate().GoToUrl(test_url);
        }

        public String getPageTitle()
        {
            return driver.Title;
        }
        public void test_search(string input_search)
        {
            var search = driver.FindElement(elem_search_text);
            search.SendKeys(input_search);
            //wait.Until(ExpectedConditions.ElementToBeClickable(elem_submit_button)).Submit();
            search.Submit();
        }
    }
}
