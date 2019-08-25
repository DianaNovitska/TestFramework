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

    class LoremPage
    {

      
        private IWebDriver driver;
        private string url = @"https://www.lipsum.com/";
       
       public LoremPage(IWebDriver driver)
        {
            this.driver = driver;       
            this.driver.Manage().Window.Maximize();
            InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//input[@id='amount']")]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Panes']/div[4]/form/table/tbody/tr[1]/td[2]/table/tbody/tr[3]/td[2]/label")]
        public IWebElement SearchType { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Generate Lorem Ipsum']")]
        public IWebElement SearchButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@value='Generate Lorem Ipsum']")]
        public IWebElement SearchText { get; set; }

        public SearchResultPage Search(string textToType)
        {
            Navigate();
            SearchBox.Clear();
            SearchBox.SendKeys(textToType);
            SearchType.Click();
            SearchButton.Click();
            return new SearchResultPage(this.driver);
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

    }
    
}
