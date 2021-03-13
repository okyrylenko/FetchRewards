﻿using System;
using System.Collections.Generic;
    {
    public sealed class HomePage : BasePage
        {

        public HomePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        private int? _fakeBar = null;
        private By leftBowl { get { return LocateElementByCssSelector(".game-board:nth-child(1) .square"); } }
        private By rightBowl { get { return LocateElementByCssSelector(".game-board:nth-child(3) .square"); } }


        public HomePage FindFakeBarPosition()

        public HomePage ClickCoin()

        private IList<IWebElement> GetCoins() => FindElements(coins);
        private char GetEquality() => GetElementText(FindElements(weighings).Last()).Split(']')[1].Split('[')[0][1];
        private void EnterLeftBowl(IList<int> numbers) => EnterNumbersIntoBowl(FindElements(this.leftBowl), numbers);
        private void EnterRightBowl(IList<int> numbers) => EnterNumbersIntoBowl(FindElements(this.rightBowl), numbers);

        private void EnterNumbersIntoBowl(IList<IWebElement> bowl, IList<int> numbers)
        private List<int> AssignList(IList<int> assignFrom, int start, int end)
    }