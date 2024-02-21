using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AltimetrikAssignment.PageObjects
{
    public class CartPage
    {
        [FindsBy(How = How.XPath, Using = "//div[@data-name='Active Items']//span[@class='a-truncate-cut']")]
        public IList<IWebElement> cartItemsList;

        public CartPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
