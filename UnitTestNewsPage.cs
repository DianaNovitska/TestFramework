using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestNewsPage
    {
        public static IWebDriver driver = new ChromeDriver();
        HomePage home = new HomePage(driver);
        NewsPage news = new NewsPage(driver);

        [TestMethod]
        public void TestMethodFirstTitle()
        {
            home.goToNewsPage();
            Assert.AreEqual(news.TopNews.Displayed, news.TopNews);
            driver.Close();
        }

        [TestMethod]
        public void TestMethodSearchNews()
        {
            home.goToNewsPage();
            Assert.AreEqual(news.Search(), "China");
            driver.Close();
        }
    }
}
