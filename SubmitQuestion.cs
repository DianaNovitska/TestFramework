using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace UnitTestProject1
{
    class SubmitQuestion
    {
        public static IWebDriver driver = new ChromeDriver();

        HomePage home = new HomePage(driver);
        NewsPage news = new NewsPage(driver);
        HaveYouSayPage HaveYouSay = new HaveYouSayPage(driver);

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
        public void SubmitQuestionWithoutEmail(string text, string name, string email, string age, string pospone)
        {
            WriteQuestion(text, name, email, age, pospone);
            HaveYouSay.Submit();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string color = HaveYouSay.EmailError();
            Assert.AreEqual("1px solid rgb(221, 0, 0)", color);
            //Assert.IsNotNull(HaveYouSay.EmailEmpty.Text);            
            //Assert.AreEqual(HaveYouSay.EmailEmpty.ToString(), "Email address can't be blank");

        }
        public void SubmitQuestionWithoutName(string text, string name, string email, string age, string pospone)
        {
            WriteQuestion(text, name, email, age, pospone);
            HaveYouSay.Submit();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string color = HaveYouSay.NameError();
            Assert.AreEqual("1px solid rgb(221, 0, 0)", color);
            driver.Close();

        }
    }
}
