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
    class Driver
    {

        private IWebDriver driver;
        private string url = @"https://www.lipsum.com/";

        public Driver(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Window.Maximize();
            InitElements(driver, this);
        }
    }
}
