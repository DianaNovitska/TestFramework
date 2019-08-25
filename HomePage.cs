using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using static OpenQA.Selenium.Support.PageObjects.PageFactory;

namespace UnitTestProject1
{
    class HomePage
    {
        private IWebDriver driver;
        private string url = @"https://www.bbc.com";
        

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Window.Maximize();
            InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//*[@id='orb-nav-links']/ul/li[2]/a")]
        public IWebElement NewsLink { get; set; }

        public  void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

        public NewsPage goToNewsPage()
        {
            Navigate();
            this.NewsLink.Click();
            return new NewsPage(this.driver);
        }
    }
}
