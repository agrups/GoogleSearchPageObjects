using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GoogleSearchPageObjects.Infrastructure
{
    public class TestBase
    {
        public IWebDriver Driver;

        public TestBase()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }
    }
}