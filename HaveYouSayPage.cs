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
    class HaveYouSayPage
    {
        public IWebDriver driver;

        public HaveYouSayPage(IWebDriver driver)
        {
            this.driver = driver;
            InitElements(driver, this);
        }
         [FindsBy(How = How.XPath, Using = "(//a[@href='/news/uk-47933096'])[3]")]
        public IWebElement QuestionLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@class='long-text-input-container']")]
        public IWebElement QuestionField { get; set; }
        [FindsBy(How = How.XPath, Using = "//textarea [@placeholder ='What questions would you like us to investigate?']")]
        public IWebElement QuestionField1 { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[@class='text-input__input'])[1]")]
        public IWebElement Name { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[@class='text-input__input'])[2]")]
        public IWebElement Email { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[@class='text-input__input'])[3]")]
        public IWebElement Age { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[@class='text-input__input'])[4]")]
        public IWebElement Postcode { get; set; }
        [FindsBy(How = How.XPath, Using = "//div [@class='button-container']")]
        public IWebElement SubmitButton { get; set; }
        [FindsBy(How = How.XPath, Using = " //div [@class='input - error - message']")]
        public IWebElement SubmitError { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@aria-label='Name']")]
        public IWebElement NameEmpty { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@aria-label='Email address']")]
        public IWebElement EmailEmpty { get; set; }


        public void Question(string textToEnter, string name, string email, string age, string postcode)
        {
            QuestionLink.Click();
            QuestionField.Click();
            QuestionField1.SendKeys(textToEnter);
            Name.SendKeys(name);
            Email.SendKeys(email);
            Age.SendKeys(age);
            Postcode.SendKeys(postcode);
            SubmitButton.Click();
        }
        public void Submit()
        {
            SubmitButton.Click();
        }
        public string NameError()
        {
            return NameEmpty.GetCssValue("border").ToString();
        }
        public string EmailError()
        {          
            return EmailEmpty.GetCssValue("border").ToString();
        }
        public void TakeScreenshot()
        {         
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("C:\\Users\\Dianka\\Desktop\\testfile0.png", OpenQA.Selenium.ScreenshotImageFormat.Png);
        }
    }
}
