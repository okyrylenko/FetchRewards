﻿using System;
using System.Collections.Generic;
    {
    public class BasePage : Browser, IBasePage
        {
        private readonly WebDriverWait _wait;

        public BasePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
            {
            _wait = wait;
            }
    }