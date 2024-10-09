using LearningSelenium.Pages;
using OpenQA.Selenium;

namespace LearningSelenium
{
    [Parallelizable(ParallelScope.Children)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class SimplegloboticketsTests : BaseTest
    {
        private OrderPage orderPage;

        [SetUp]
        public new void SetUp()
        {
            orderPage = new OrderPage(GetDriver());
        }

        [Test]
        [Category("Tests without assertion")]
        public void SimpleTest()
        {
            //TestContext.Progress.WriteLine("SimpleTest");

            orderPage.EnterName("Josh Smith");
            orderPage.ClickAddButton();

        }

        [Test]
        [Category("Tests without assertion")]
        [Category("TestID=123")]
        public void UsingRelativeLocatorsTest() 
        {
            //GetDriver().FindElement(RelativeBy
            //    .WithLocator(By.TagName("textarea"))
            //    .Below(By.Id("full-name")))
            //    .SendKeys("Something Important");

            //GetDriver().FindElements(RelativeBy
            //    .WithLocator(By.CssSelector("input[type='checkbox']"))
            //    .Above(By.Id("add-btn")))
            //    .First()
            //    .Click();
            orderPage.EnterNotes("Something important");

            orderPage.SelectWorkshop(0);
        }

        [Test]
        [Category("Tests with assertion")]
        public void SimpleTestWithAssertion()
        {
            //GetDriver().FindElement(By.Id("full-name")).SendKeys("Josh Smith");
            //GetDriver().FindElement(By.Id("add-btn")).Click();

            orderPage.EnterName("Josh Smith");
            orderPage.ClickAddButton();
            //var totalPrice = GetDriver().FindElement(By.CssSelector("tfoot tr th:nth-child(3)"));
            Assert.That(orderPage.GetTotalPrice(),  Is.EqualTo("$100.00"), "Total price is not valid.");

        }
    }
}
