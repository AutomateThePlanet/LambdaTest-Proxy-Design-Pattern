namespace DecoratorDesignPatternTests.FourthVersion;
public class HomePage : WebPage
{
    public HomePage(IWebDriver driver) 
        : base(driver)
    {
    }

    public IWebElement SearchInput => Driver.FindElement(By.XPath("//input[@name='search']"));

    public void SearchProduct(string searchText)
    {
        //SearchInput.Clear();
        SearchInput.SendKeys(searchText);
        //SearchInput.SendKeys(Keys.Enter);
    }
}
