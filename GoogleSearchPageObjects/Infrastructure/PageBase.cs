using System.Collections.Generic;
using OpenQA.Selenium;

namespace GoogleSearchPageObjects.Infrastructure
{
    public class PageBase
    {
        public IWebDriver Driver;

        public PageBase(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement Element(By by)
        {
            return Driver.FindElement(by);
        }

        public IList<IWebElement> Elements(By by)
        {
            return Driver.FindElements(by);
        }

        public void Click(By by)
        {
            Element(by).Click();
        }
    }
}