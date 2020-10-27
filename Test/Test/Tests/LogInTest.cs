using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Test.Pages;

namespace Test
{
    class LogInTest
    {
        static string path = Directory.GetCurrentDirectory();
        IWebDriver webDriver = new ChromeDriver(path);

        [SetUp]
        public void Setup()
        {
            webDriver.Navigate().GoToUrl("https://stackoverflow.com/");

        }

        [Test]
        public void LogIn()
        {
            HomePage homePage = new HomePage(webDriver);
            homePage.ClickLogInButton();

            LogInPage logInPage = new LogInPage(webDriver);
            logInPage.Login("email", "password");

            new WebDriverWait(webDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.CssSelector(".grid.fd-column.gs4.gsy.js-auth-item.has-error"))));
            Assert.That(logInPage.IsErrorMessageExist, Is.True);
        }

        [TearDown]
        public void Teatdown() => webDriver.Quit();
    }
}
