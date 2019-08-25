using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using static OpenQA.Selenium.Support.PageObjects.PageFactory;

namespace UnitTestProject1
{
    class SearchResultPage
    {
        private IWebDriver driver;
        public SearchResultPage(IWebDriver driver)
        {
            this.driver = driver;
            InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div [@id ='lipsum']")]
        public IWebElement LipsumText { get; set; }
        public IWebElement LoremText()
        {
            return LipsumText;

        }
    }
}
