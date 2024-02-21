using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AltimetrikAssignment.PageObjects
{
    public class ProductDetailsPage
    {
        [FindsBy(How = How.XPath, Using = "//span[@id='productTitle']")]
        public IWebElement productTitle;

        [FindsBy(How = How.Id, Using = "add-to-cart-button")]
        public IWebElement addToCartBtn;
        
        [FindsBy(How = How.XPath, Using = "//div[@id='NATC_SMART_WAGON_CONF_MSG_SUCCESS']/h1[contains(text(), 'Added to Cart')]")]
        public IWebElement addedToCartMsg;

        public ProductDetailsPage(IWebDriver driver) {
            PageFactory.InitElements(driver, this);
        }

        public void ClickAddToCartBtn()
        {
            addToCartBtn.Click();
        }

        public string GetProductTitle()
        {
            return productTitle.Text.Trim().Substring(0, 10);
        }
    }
}
