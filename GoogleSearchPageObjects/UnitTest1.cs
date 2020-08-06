using System;
using GoogleSearchPageObjects.Infrastructure;
using OpenQA.Selenium;
using NUnit.Framework;

namespace GoogleSearchPageObjects
{
    public class GoogleTest : TestBase
    {
        String search_string = "asdf";

        public FinalPage FinalPage;
        public HomePage HomePage;

        public SearchPage SearchPage;

        [SetUp]
        public void Setup()
        {
            FinalPage = new FinalPage(Driver);
            SearchPage = new SearchPage(Driver);
            HomePage = new HomePage(Driver);
        }

        [Test]
        public void SearchLT_Google()
        {
            var expected_PageTitle = "asdf – Dictionary.com";

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
            Driver.Close();
        }
    }
}