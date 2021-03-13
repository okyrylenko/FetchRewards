using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FetchRewards    {
    public class BasePage : Browser, IBasePage        {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public BasePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)            {
            _driver = driver;
            _wait = wait;            }

        public By LocateElementByCssSelector(string css) => By.CssSelector(css);
        public By LocateElementById(string id) => By.Id(id);

        public IWebElement FindNestedElement(IWebElement parent, By child) => parent.FindElement(child);
        public IList<IWebElement> FindElements(By locator) => _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator)); //wait returns elements when found. No need to invoke driver.FindElements

        public IBasePage EnterText(By locator, string text)            {
            FindElement(locator).SendKeys(text);
            return this;            }
        public IBasePage EnterText(IWebElement element, string text)            {
            element.SendKeys(text);
            return this;            }
        public IWebElement FindElement(By locator) => _wait.Until(ExpectedConditions.ElementIsVisible(locator));

        public IBasePage ClickElement(By locator)            {
            ClickElement(FindElement(locator));
            return this;            }

        public IBasePage ClickElement(IWebElement element)            {
            element.Click();
            return this;            }

        public string GetElementText(By locator) => GetElementText(FindElement(locator));
        public string GetElementText(IWebElement element) => element.Text;        }    }
