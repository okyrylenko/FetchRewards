﻿using System;
using System.Collections.Generic;
    {
    public interface IBasePage
        {

        By LocateElementByCssSelector(string css);
        IBasePage EnterText(By locator, string text);
        IBasePage EnterText(IWebElement element, string text);
        IBasePage ClickElement(By locator);
        IBasePage ClickElement(IWebElement element);
        string GetElementText(By locator);
        string GetElementText(IWebElement element);
        }
    }