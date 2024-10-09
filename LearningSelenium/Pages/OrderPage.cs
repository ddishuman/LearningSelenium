using OpenQA.Selenium;

namespace LearningSelenium.Pages
{
    internal class OrderPage : BasePage
    {
        private IWebDriver driver;

        public OrderPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement Name => driver.FindElement(By.Id("full-name"));

        private IWebElement AddButton => driver.FindElement(By.Id("add-btn"));

        private IWebElement TotalPrice => driver.FindElement(By.CssSelector("tfoot tr th:nth-child(3)"));

        private List<IWebElement> Workshops => driver.FindElements(RelativeBy
            .WithLocator(By.TagName("textarea"))
            .Below(Name))
            .ToList();

        private IWebElement Notes => driver.FindElements(RelativeBy
            .WithLocator(By.CssSelector("input[type='checkbox']"))
            .Below(Name))
            .First();

        private IWebElement OrderButton => driver.FindElement(By.Id("order-btn"));

        public void EnterName(string text)
        {
            Name.SendKeys(text);
        }

        public void ClickAddButton()
        {
            AddButton.Click();
        }

        public string GetTotalPrice()
        {
            return TotalPrice.Text;
        }

        public void EnterNotes(string text)
        {
            Notes.SendKeys(text);
        }

        public void SelectWorkshop(int workshopIndex)
        {
            Workshops[workshopIndex].Click();
        }

        internal void ClickOrderButton()
        {
            OrderButton.Click();
        }

        public void ScrollToTheOrderButton()
        {
            ScrollToElement(OrderButton);
        }
    }
}
