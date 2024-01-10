namespace DecoratorDesignPatternTests.FourthVersion;
public class WebSite
{
    private readonly IWebDriver _driver;

    public WebSite(IWebDriver driver)
    {
        _driver = driver;

        HomePage = new HomePage(_driver);
        ProductPage = new ProductPage(_driver);
        CartPage = new CartPage(_driver);
        CheckoutPage = new CheckoutPage(_driver);
    }

    public HomePage HomePage { get; private set; }
    public ProductPage ProductPage { get; private set; }
    public CartPage CartPage { get; private set; }
    public CheckoutPage CheckoutPage { get; private set; }
}
