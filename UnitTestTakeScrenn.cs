using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
 
        public static IWebDriver driver = new ChromeDriver();
        LoremPage lorem = new LoremPage(driver);
        SearchResultPage Loremtext = new SearchResultPage(driver);
        HomePage home = new HomePage(driver);
        NewsPage news = new NewsPage(driver);
        HaveYouSayPage HaveYouSay = new HaveYouSayPage(driver);


        public string GetTextLipsum(string text)
        {
            lorem.Search(text);
            return Loremtext.LoremText().Text;
        }


        public void WriteQuestion(string text, string name, string email, string age, string pospone)
        {
            home.goToNewsPage();
            news.GotoHaveYouSayPage();
            HaveYouSay.Question(text, name, email, age, pospone);
        }
        public void ScreenshotOfQuestion(string text, string name, string email, string age, string pospone)
        {
            WriteQuestion(text, name, email, age, pospone);
            HaveYouSay.TakeScreenshot();
            driver.Close();
        }


        [TestMethod]
        public void TestMethodTakeScreen()
        {
            string text = GetTextLipsum("140");
            ScreenshotOfQuestion(text, "", "di.novitska@gmail.com", "20", "03022");
        }
    }
}


