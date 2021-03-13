using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;namespace FetchRewards
    {
    public class Browser : IBrowser
        {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public Browser(IWebDriver driver, WebDriverWait wait)
            {
            _driver = driver;
            _wait = wait;
            }

        public void KillBrowser()
            {
            _driver.Quit();
            }

        public IBrowser MaximzeWindow()
            {
            _driver.Manage().Window.Maximize();
            return this;
            }

        public T NavigateTo<T>(string url) where T : IBasePage
            {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
            return (T)Activator.CreateInstance(typeof(T), _driver, _wait);
            }

        public string GetAlertText() => _driver.SwitchTo().Alert().Text;
        }
    }
