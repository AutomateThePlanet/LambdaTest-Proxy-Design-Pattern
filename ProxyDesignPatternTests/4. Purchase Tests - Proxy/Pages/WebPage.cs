namespace DecoratorDesignPatternTests.FourthVersion;
public abstract class WebPage
{
    protected readonly IWebDriver Driver;

    public WebPage(IWebDriver driver)
    {
        Driver = driver;
    }
}
