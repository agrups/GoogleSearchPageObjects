using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using GoogleSearchPageObjects.Infrastructure;

namespace GoogleSearchPageObjects
{
    public class HomePage : PageBase
    {
        String test_url = "https://www.google.com";

        private WebDriverWait wait;

        public HomePage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public By elem_search_text = By.Name("q");

        public void goToPage()
        {
            Driver.Navigate().GoToUrl(test_url);
        }

        public void test_search(string input_search)
        {
            var search = Element(elem_search_text);
            search.SendKeys(input_search);
            search.Submit();
        }
    }
}
