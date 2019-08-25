using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestSubmitQuestion
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
        public void SubmitQuestionWithoutEmail(string text, string name, string email, string age, string pospone)
        {
            WriteQuestion(text, name, email, age, pospone);
            HaveYouSay.Submit();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Thread.Sleep(5000);
            string color = HaveYouSay.EmailError();
            Assert.AreEqual("1px solid rgb(221, 0, 0)", color);
            driver.Close();
            //Assert.IsNotNull(HaveYouSay.EmailEmpty.Text);            
            //Assert.AreEqual(HaveYouSay.EmailEmpty.ToString(), "Email address can't be blank");
        }

        public void SubmitQuestionWithoutName(string text, string name, string email, string age, string pospone)
        {
            WriteQuestion(text, name, email, age, pospone);
            HaveYouSay.Submit();
            Thread.Sleep(5000);
            string color = HaveYouSay.NameError();
            Assert.AreEqual("1px solid rgb(221, 0, 0)", color);
            driver.Close();

        }
        [TestMethod]
        public void TestMethodSubmitQuestionWithEmptyName()
        {
            string text = GetTextLipsum("141");
            SubmitQuestionWithoutName(text, "", "dianka728159@gmail.com", "20", "03022");
        }

        [TestMethod]
        public void TestMethodSubmitQuestionWithEmptyEmail()
        {
            string text = GetTextLipsum("140");
            SubmitQuestionWithoutEmail(text, "Diana", "", "20", "03022");
        }
    }
}
