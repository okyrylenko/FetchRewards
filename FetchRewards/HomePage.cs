using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;using OpenQA.Selenium.Support.UI;namespace FetchRewards    {
    public sealed class HomePage : BasePage        {        public HomePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        //locating elements
        private int? _fakeBar = null;
        private By leftBowl { get { return LocateElementByCssSelector(".game-board:nth-child(1) .square"); } }
        private By rightBowl { get { return LocateElementByCssSelector(".game-board:nth-child(3) .square"); } }
        private By reset { get { return LocateElementByCssSelector("#reset:nth-child(1)"); } }
        private By weigh { get { return LocateElementById("weigh"); } }
        private By weighings { get { return LocateElementByCssSelector(".game-info>ol>li"); } }
        private By coins { get { return LocateElementByCssSelector(".coins>button"); } }


        public HomePage FindFakeBarPosition()            {
            IList<int> leftPartition = new List<int>();
            IList<int> rightPartition = new List<int>();
            IList<int> bars = GetCoins().Select(c => Int32.Parse(GetElementText(c))).ToList();            /** The approach I took to solve this problem is a binary search of  devide a concur * 1. I will split 9 numbers in 2 halves of 4 and compare them. If they equal, then the 9th number is a fake bar. * 2. If one of them is smaller then the other, I will take the smaller and repeat step 1, only devide into 2 halves of 2 each. * 3. Repeat untill I get to 2 numbers and compare them * * Note: this approach the best case scenario would be f(1), and the worst is f(log base 2 of n). If I take linear approach the best case would be f(1) and the worst is f(n)*/
            while (true)                {
                //asigning left halv to left parition
                leftPartition = AssignList(bars, 0, bars.Count / 2);
                //assigning right part to right parition. If odd number, the last number will be left off
                rightPartition = bars.Count % 2 == 0 ? AssignList(bars, bars.Count / 2, bars.Count) : AssignList(bars, bars.Count / 2, bars.Count - 1);
                //entering left and right partitioning and clicking weigh
                EnterLeftBowl(leftPartition);
                EnterRightBowl(rightPartition);
                ClickElement(weigh);
                //getting the equlity sign
                var equality = GetEquality();

                if (equality.Equals('='))                    {
                    _fakeBar = bars[bars.Count - 1];
                    break;                    }
                else if (bars.Count == 2)                    {
                    _fakeBar = equality.Equals('<') ? leftPartition[0] : rightPartition[0];
                    break;                    }
                else                    {
                    bars = equality.Equals('<') ? leftPartition : rightPartition;                    }

                ClickElement(reset);                }

            FindElements(weighings).ToList().ForEach(w => Console.WriteLine(GetElementText(w)));
            return this;            }

        public HomePage ClickCoin()            {
            ClickElement(GetCoins().Where(c => GetElementText(c).Equals(_fakeBar.ToString())).First());
            return this;            }

        private IList<IWebElement> GetCoins() => FindElements(coins);
        private char GetEquality() => GetElementText(FindElements(weighings).Last()).Split(']')[1].Split('[')[0][1];
        private void EnterLeftBowl(IList<int> numbers) => EnterNumbersIntoBowl(FindElements(this.leftBowl), numbers);
        private void EnterRightBowl(IList<int> numbers) => EnterNumbersIntoBowl(FindElements(this.rightBowl), numbers);

        private void EnterNumbersIntoBowl(IList<IWebElement> bowl, IList<int> numbers)            {
            for (int i = 0; i < numbers.Count; i++)                {                EnterText(bowl[i], numbers[i].ToString());                }            }
        private List<int> AssignList(IList<int> assignFrom, int start, int end)            {
            List<int> assignTo = new List<int>();
            for (int i = start; i < end; i++)                {
                assignTo.Add(assignFrom[i]);                }

            return assignTo;            }        }    }
