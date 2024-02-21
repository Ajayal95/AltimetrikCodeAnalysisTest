using AltimetrikAssignment.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AltimetrikAssignment.StepDefinitions
{
    [Binding]
    public class AmazonStepDefinitions
    {
        HomePage homePage;
        ProductDetailsPage productDetailsPage;
        CartPage cartPage;
        static IWebDriver driver;

        [Given(@"Application url is '([^']*)'")]
        public void GivenApplicationUrlIs(string url)
        {
            ScenarioContext.Current["url"] = url;
        }

        [When(@"Launch the application")]
        public void LaunchApplication()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + @"\Drivers\");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl((string)ScenarioContext.Current["url"]);
            homePage = new HomePage(driver);
            productDetailsPage = new ProductDetailsPage(driver);
            cartPage = new CartPage(driver);
        }

        [Then(@"Validate amazon logo in top left corner of the application")]
        public void ValidateAmazonLogo()
        {
            Assert.That(homePage.logo.Displayed, "Amazon logo not displayed in home page");
        }

        [When(@"Search for a product: '([^']*)'")]
        public void SearchProduct(string product)
        {
            ScenarioContext.Current["product"] = product;
            homePage.SearchProduct(product);
        }

        [Then(@"Validate the searched product from Result bar info")]
        public void ValidateTheSearchedProductFromResultBarInfo()
        {
            Assert.That(homePage.resultInfoBar.Text.Contains((string)ScenarioContext.Current["product"]), "Product name not displayed in Result Info Bar");
        }

        [When(@"Select the first product")]
        public void SelectTheFirstProduct()
        {
            homePage.SelectFirstProduct();
        }

        [When(@"Click add to cart button")]
        public void ClickAddToCartButton()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            ScenarioContext.Current["product"] = productDetailsPage.GetProductTitle();
            productDetailsPage.ClickAddToCartBtn();
            Assert.That(productDetailsPage.addedToCartMsg.Displayed, "Added to cart message not displayed");
        }

        [When(@"Goto shopping cart")]
        public void GotoShoppingCart()
        {
            homePage.ClickOnCartBtn();
        }

        [Then(@"Validate the above added item is present in the shopping cart")]
        public void ValidateAddedItemInShoppingCart()
        {
            bool flag = false;
            foreach(var items in cartPage.cartItemsList)
            {
                var itemName = items.Text.Trim();
                if (itemName.Contains((string)ScenarioContext.Current["product"]))
                {
                    flag = true;
                    break;
                }
            }
            Assert.IsTrue(flag, "Added product not listed in cart items");
        }

        [When(@"Select the Hamburger Menu button from the main navigation bar")]
        public void ClickOnHamburgerMenu()
        {
            homePage.ClickHamburgerMenu();
        }

        [When(@"Select option - Mobiles, Computers")]
        public void ClickOnMobilesOption()
        {
            homePage.ClickMobilesOptionInHamburgerMenu();
        }

        [When(@"Select option - Software")]
        public void ClickOnSelectOption()
        {
            homePage.ClickSoftwareOptinInHamburgerMenu();
        }

        [Then(@"Validate the logo is present under Top categories section")]
        public void ValidateLogosUnderTopCategories()
        {
            Assert.True(homePage.antivirusImage.Displayed, "Antivirus logo not displayed under Top categries of Software");
            Assert.True(homePage.elearningImage.Displayed, "Elearning logo not displayed under Top categries of Software");
            Assert.True(homePage.enterpriseSoftwareImage.Displayed, "Enterprise software logo not displayed under Top categries of Software");
            Assert.True(homePage.officeImage.Displayed, "Office logo not displayed under Top categries of Software");
        }

        [AfterScenario]
        public static void CloseBrowser()
        {
            driver.Quit();
        }

    }
}
