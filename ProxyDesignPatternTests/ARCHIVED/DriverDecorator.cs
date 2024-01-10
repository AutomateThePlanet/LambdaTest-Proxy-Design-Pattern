//namespace DecoratorDesignPatternTests.ARCHIVED;

//public abstract class DriverDecorator : WebDriverProxy
//{
//    protected readonly WebDriverProxy Driver;

//    protected DriverDecorator(WebDriverProxy driver)
//    {
//        Driver = driver;
//    }

//    public override void Start(Browser browser)
//    {
//        Driver?.Start(browser);
//    }

//    public override void Quit()
//    {
//        Driver?.Quit();
//    }

//    public override void GoToUrl(string url)
//    {
//        Driver?.GoToUrl(url);
//    }

//    public override IWebElement FindElement(By locator)
//    {
//        return Driver?.FindElement(locator);
//    }

//    public override List<IWebElement> FindElements(By locator)
//    {
//        return Driver?.FindElements(locator);
//    }

//    public override void Refresh()
//    {
//        Driver?.Refresh();
//    }

//    public override bool ComponentExists(IWebElement component)
//    {
//        return (bool)Driver?.ComponentExists(component);
//    }

//    public override void DeleteAllCookies()
//    {
//        Driver?.DeleteAllCookies();
//    }

//    public override void ExecuteScript(string script, params object[] args)
//    {
//        Driver?.ExecuteScript(script, args);
//    }
//}
