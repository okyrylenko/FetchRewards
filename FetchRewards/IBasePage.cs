using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace FetchRewards    {
    /// <summary>
    /// interface for a BasePage
    /// </summary>
    public interface IBasePage        {

        By LocateElementByCssSelector(string css);
        By LocateElementById(string id);
        IWebElement FindElement(By locator);
        IWebElement FindNestedElement(IWebElement parent, By child);
        IList<IWebElement> FindElements(By locator);
        IBasePage EnterText(By locator, string text);
        IBasePage EnterText(IWebElement element, string text);
        IBasePage ClickElement(By locator);
        IBasePage ClickElement(IWebElement element);
        string GetElementText(By locator);
        string GetElementText(IWebElement element);        }    }
