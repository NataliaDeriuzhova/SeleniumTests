using System;
using OpenQA.Selenium;

namespace Test.Pages
{
    public class HomePage
    {
        public HomePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        private IWebDriver Driver { get; }

        public IWebElement logInButton => Driver.FindElement(By.CssSelector(".login-link.s-btn.s-btn__filled.py8.js-gps-track"));

        public void ClickLogInButton() => logInButton.Click();
    }
}
