namespace DecoratorDesignPatternTests.FourthVersion;
public class CartPage : WebPage
{
    public CartPage(IWebDriver driver) 
        : base(driver)
    {
    }

    public IWebElement ViewCartButton => Driver.FindElement(By.XPath("//a[normalize-space(.)='View Cart']"));
    public IWebElement CheckoutButton => Driver.FindElements(By.XPath("//a[normalize-space(.)='Checkout']")).Last();
    public List<IWebElement> CartItems => Driver.FindElements(By.CssSelector("div.cart-item")).ToList();
    public IWebElement TotalPrice => Driver.FindElements(By.XPath("//td[text()='Total:']/following-sibling::td/strong")).Last();

    public void ViewCart()
    {
        ViewCartButton.Click();
    }

    public void Checkout()
    {
        CheckoutButton.Click();
    }

    public void UpdateQuantity(int itemIndex, int quantity)
    {
        var quantityField = CartItems[itemIndex].FindElement(By.XPath(".//input[@type='number']"));
        //quantityField.Clear();
        quantityField.SendKeys(quantity.ToString());
    }

    public void RemoveItem(int itemIndex)
    {
        var removeButton = CartItems[itemIndex].FindElement(By.XPath(".//button[@title='Remove']"));
        removeButton.Click();
    }

    public void AssertTotalPrice(string expectedPrice)
    {
        Assert.That(TotalPrice.Text, Is.EqualTo(expectedPrice));
    }
}
