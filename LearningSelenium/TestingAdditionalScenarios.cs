using LearningSelenium.Pages;

namespace LearningSelenium
{
    internal class TestingAdditionalScenarios : BaseTest
    {
        private OrderPage orderPage;

        [SetUp]
        public new void SetUp()
        {
            orderPage = new OrderPage(GetDriver());
        }

        [Test]
        public void ScrollingToAnElementTest()
        {
            orderPage.EnterName("John Doe");
            orderPage.SelectWorkshop(1);
            orderPage.ClickAddButton();

            Thread.Sleep(2000);
            orderPage.ScrollToTheOrderButton();
            orderPage.ClickOrderButton();
            Thread.Sleep(2000);


            Assert.That(GetDriver().Url, Contains.Substring("success"));
        }
    }
}
