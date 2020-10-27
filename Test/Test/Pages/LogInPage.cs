using System;
using OpenQA.Selenium;

namespace Test.Pages
{
    public class LogInPage
    {
        public LogInPage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        private IWebDriver Driver { get; }

        public IWebElement emailInput => Driver.FindElement(By.Id("email"));

        public IWebElement passwordInput => Driver.FindElement(By.Id("password"));

        public IWebElement submitButton => Driver.FindElement(By.Id("submit-button"));

        public IWebElement errorMessage => Driver.FindElement(By.CssSelector(".grid.fd-column.gs4.gsy.js-auth-item.has-error"));

        public bool IsErrorMessageExist() => errorMessage.Displayed;

        public void Login(string email, string password)
        {
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            submitButton.Click();
        }
    }
}
