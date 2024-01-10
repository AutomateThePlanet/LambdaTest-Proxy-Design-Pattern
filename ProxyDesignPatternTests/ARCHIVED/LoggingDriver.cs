//namespace DecoratorDesignPatternTests.ARCHIVED;

//public class LoggingDriver : DriverDecorator
//{
//    public override string Url => throw new NotImplementedException();

//    public LoggingDriver(WebDriverProxy driver)
//    : base(driver)
//    {
//    }

//    public override void Quit()
//    {
//        Console.WriteLine("Close browser");
//        Driver?.Quit();
//    }

//    public override void GoToUrl(string url)
//    {
//        Console.WriteLine($"Go to URL = {url}");
//        Driver?.GoToUrl(url);
//    }

//    public override IWebElement FindElement(By locator)
//    {
//        Console.WriteLine($"Find Element -> by {locator}");
//        return Driver?.FindElement(locator);
//    }

//    public override List<IWebElement> FindElements(By locator)
//    {
//        Console.WriteLine($"Find elements -> by {locator}");
//        return Driver?.FindElements(locator);
//    }

//    public override void Refresh()
//    {
//        Console.WriteLine("refresh");
//        Driver?.Refresh();
//    }

//    public override bool ComponentExists(IWebElement component)
//    {
//        Console.WriteLine("check if the component exists");
//        return (bool)Driver?.ComponentExists(component);
//    }
//}
