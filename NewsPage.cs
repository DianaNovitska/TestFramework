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
    class NewsPage
    {
        private IWebDriver driver;
        public NewsPage(IWebDriver driver)
        {
            this.driver = driver;

            InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//span[@class = 'gel-long-primer gs-u-ph']")]
        public IWebElement MoreLink { get; set; }
        [FindsBy(How = How.XPath, Using = "(//a[@class ='nw-o-link'])[18]")]
        public IWebElement HaveYouSayLink { get; set; }
        [FindsBy(How = How.XPath, Using = "(//span[@aria-hidden='true'])[7]")]
        public IWebElement SearchWord { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='orb-search-q']")]
        public IWebElement SearchField { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@id='orb-search-button']")]
        public IWebElement SearchButton { get; set; }
        [FindsBy(How = How.XPath, Using = "(//h1 [@itemprop = 'headline'])[1]")]
        public IWebElement SearchedTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//h3 [@class='gs - c - promo - heading__title gel - paragon - bold nw - o - link - split__text']")]
        public IWebElement FirstTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-entityid=\"container-top-stories#1\"]")]
        public IWebElement TopNews { get; set; }


        public HaveYouSayPage GotoHaveYouSayPage()
        {
            MoreLink.Click();
            this.HaveYouSayLink.Click();
            return new HaveYouSayPage(this.driver);
        }
        public string Search()
        {
            string searchText = SearchWord.Text;
            SearchField.Click();
            SearchField.SendKeys(searchText);
            SearchButton.Click();
            return SearchedTitle.Text;
        }
       
        

    }
}
