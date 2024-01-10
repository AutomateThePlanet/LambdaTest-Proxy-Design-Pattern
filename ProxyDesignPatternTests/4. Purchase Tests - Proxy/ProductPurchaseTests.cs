using DecoratorDesignPatternTests.FourthVersion;
using DecoratorDesignPatternTests.Models;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace DecoratorDesignPattern.FourthVersion;

[TestFixture]
public class ProductPurchaseTests
{
    private WebSite _webSite;
    private IWebDriver _driverProxy;

    [SetUp]
    public void TestInit()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        var webDriver = new ChromeDriver();
        _driverProxy = new WebDriverProxy(webDriver);
        //_driverProxy.Start(Browser.Chrome);
        _webSite = new WebSite(_driverProxy);
        _driverProxy.Navigate().GoToUrl("https://ecommerce-playground.lambdatest.io/");
    }

    [TearDown]
    public void TestCleanup()
    {
        _driverProxy.Quit();
    }

    [Test]
    public void CorrectInformationDisplayedInCompareScreen_WhenOpenProductFromSearchResults_TwoProducts()
    {
        // Arrange
        var expectedProduct1 = new ProductDetails
        {
            Name = "iPod Touch",
            Id = 32,
            Price = "$194.00",
            Model = "Product 5",
            Brand = "Apple",
            Weight = "5.00kg"
        };

        var expectedProduct2 = new ProductDetails
        {
            Name = "iPod Shuffle",
            Id = 34,
            Price = "$182.00",
            Model = "Product 7",
            Brand = "Apple",
            Weight = "5.00kg"
        };

        _webSite.HomePage.SearchProduct("ip");
        _webSite.ProductPage.SelectProductFromAutocomplete(expectedProduct1.Id);
        _webSite.ProductPage.CompareLastProduct();
        _webSite.HomePage.SearchProduct("ip");
        _webSite.ProductPage.SelectProductFromAutocomplete(expectedProduct2.Id);
        _webSite.ProductPage.CompareLastProduct();

        _webSite.ProductPage.GoToComparePage();

        _webSite.ProductPage.AssertCompareProductDetails(expectedProduct1, 1);
        _webSite.ProductPage.AssertCompareProductDetails(expectedProduct2, 2);
    }

    [Test]
    public void PurchaseTwoSameProduct()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "iPod Touch",
            Id = 32,
            Price = "$194.00",
            Model = "Product 5",
            Brand = "Apple",
            Weight = "5.00kg",
            Quantity = "2"
        };

        var userDetails = new UserDetails
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@example.com",
            Telephone = "1234567890",
            Password = "password123",
            ConfirmPassword = "password123",
            AccountType = AccountOption.Register
        };

        var billingAddress = new BillingAddress
        {
            FirstName = "John",
            LastName = "Doe",
            Company = "Acme Corp",
            Address1 = "123 Main St",
            Address2 = "Apt 4",
            City = "Metropolis",
            PostCode = "12345",
            Country = "United States",
            Region = "Alabama"
        };

        _webSite.HomePage.SearchProduct("ip");
        _webSite.ProductPage.SelectProductFromAutocomplete(expectedProduct1.Id);
        _webSite.ProductPage.AddToCart(expectedProduct1.Quantity);
        _webSite.CartPage.ViewCart();
        _webSite.CartPage.AssertTotalPrice("$388.00");

        _webSite.CartPage.Checkout();
        _webSite.CheckoutPage.FillUserDetails(userDetails);
        _webSite.CheckoutPage.FillBillingAddress(billingAddress);
        _webSite.CheckoutPage.AssertTotalPrice("$396.00");

        _webSite.CheckoutPage.AgreeToTerms();
        _webSite.CheckoutPage.CompleteCheckout();
    }
}
