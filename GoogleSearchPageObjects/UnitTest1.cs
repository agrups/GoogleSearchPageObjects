using System;
using OpenQA.Selenium;
using NUnit.Framework;
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

            public FinalPage FinalPage;
            public HomePage HomePage;

            public SearchPage SearchPage;
           // String web_page_title = "Google";

        [SetUp]
        public void CreateDriver()
        {
            driver = new TWebDriver();
            FinalPage = new FinalPage(driver);
            SearchPage = new SearchPage(driver);
            HomePage = new HomePage(driver);
        }

        [Test, Parallelizable]
        public void SearchLT_Google()
        {
            var expected_PageTitle = "asdf - Dictionary.com";

            HomePage.goToPage();
            HomePage.test_search(search_string);

            SearchPage.click_search_results();

            //As the web page is loaded, we just check if the page title matches or not.
            var result = FinalPage.getPageTitle();

            Assert.That(result, Is.EqualTo(expected_PageTitle), "SearchLT_Google Failed");
        }

        [OneTimeTearDown]
        public void CloseTest()
        {
            driver.Close();
        }
    }
}