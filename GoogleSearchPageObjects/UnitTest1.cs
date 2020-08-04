using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
// For supporting Page Object Model
// Obsolete - using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;

namespace GoogleSearchPageObjects
{

        [TestFixture(typeof(ChromeDriver))]
        [TestFixture(typeof(InternetExplorerDriver))]
        public class TestWithMultipleBrowsers<TWebDriver> where TWebDriver : IWebDriver, new()
        {
            private IWebDriver driver;
            String search_string = "asdf";
           // String web_page_title = "Google";

        [SetUp]
            public void CreateDriver()
            {
                this.driver = new TWebDriver();
            }

        [Test, Parallelizable]
        public void SearchLT_Google()
        {
            String expected_PageTitle = "asdf - Dictionary.com";
            String result_PageTitle;

            HomePage home_page = new HomePage(driver);
            home_page.goToPage();
            home_page.test_search(search_string);

            SearchPage search_page = new SearchPage(driver); ;
            FinalPage final_page = search_page.click_search_results();

            //As the web page is loaded, we just check if the page title matches or not.
            result_PageTitle = final_page.getPageTitle();

            // Ensure that the page load is complete    
            final_page.load_complete();

            if (result_PageTitle == expected_PageTitle)
            {
                Console.WriteLine("SearchLT_Google Failed");
            }
            else
            {
                Console.WriteLine("SearchLT_Google Passed");
            }
        }

        [OneTimeTearDown]
        public void CloseTest()
        {
            driver.Close();
        }
    }
}