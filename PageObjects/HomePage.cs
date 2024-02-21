using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AltimetrikAssignment.PageObjects
{
    public class HomePage
    {
        IWebDriver driver;
        WebDriverWait wait;
        IJavaScriptExecutor js;

        [FindsBy(How = How.Id, Using = "nav-logo-sprites")]
        public IWebElement logo;

        [FindsBy(How = How.Id, Using = "nav-cart")]
        public IWebElement cartBtn;
        
        [FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
        public IWebElement searchBox;

        [FindsBy(How = How.Id, Using = "nav-search-submit-button")]
        public IWebElement searchBoxBtn;

        [FindsBy(How = How.XPath, Using = "//span[@data-component-type='s-result-info-bar']//span[@class='a-color-state a-text-bold']")]
        public IWebElement resultInfoBar;

        [FindsBy(How = How.XPath, Using = "//div[@data-component-type='s-search-result']//span[@data-component-type='s-product-image']/a")]
        public IList<IWebElement> searchResultImages;

        [FindsBy(How = How.Id, Using = "nav-hamburger-menu")]
        public IWebElement hamburgerMenu;

        [FindsBy(How = How.XPath, Using = "(//a[@class='hmenu-item']/div[contains(text(), 'Mobiles, Computers')]/../i)[1]")]
        public IWebElement hamburgerMobileOption;

        [FindsBy(How = How.XPath, Using = "(//a[@class='hmenu-item' and text()=' Software '])[1]")]
        public IWebElement hamburgerSoftwareOption;

        [FindsBy(How = How.XPath, Using = "//img[@alt='Antivirus']")]
        public IWebElement antivirusImage;

        [FindsBy(How = How.XPath, Using = "//img[@alt='Elearning']")]
        public IWebElement elearningImage;

        [FindsBy(How = How.XPath, Using = "//img[@alt='Enterprise software']")]
        public IWebElement enterpriseSoftwareImage;

        [FindsBy(How = How.XPath, Using = "//img[@alt='Office']")]
        public IWebElement officeImage;
        
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            js = (IJavaScriptExecutor)driver;
        }

        public void SearchProduct(string product)
        {
            searchBox.SendKeys(product);
            searchBoxBtn.Click();
        }

        public void SelectFirstProduct()
        {
            searchResultImages[0].Click();
        }

        public void ClickHamburgerMenu()
        {
            hamburgerMenu.Click();
        }

        public void ClickMobilesOptionInHamburgerMenu()
        {
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(hamburgerMobileOption));
            js.ExecuteScript("arguments[0].click();", hamburgerMobileOption);
        }

        public void ClickSoftwareOptinInHamburgerMenu()
        {
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(hamburgerSoftwareOption));
            js.ExecuteScript("arguments[0].click();", hamburgerSoftwareOption);
        }

        public void ClickOnCartBtn()
        {
            cartBtn.Click();
        }
    }
}
