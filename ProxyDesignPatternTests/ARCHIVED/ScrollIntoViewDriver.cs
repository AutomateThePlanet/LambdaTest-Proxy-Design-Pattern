//namespace DecoratorDesignPatternTests.ARCHIVED;

//public class ScrollIntoViewDriver : DriverDecorator
//{
//    public override string Url => throw new NotImplementedException();

//    public ScrollIntoViewDriver(WebDriverProxy driver)
//    : base(driver)
//    {
//    }

//    public override IWebElement FindElement(By locator)
//    {
//        var element = Driver?.FindElement(locator);
//        ScrollIntoView(element);
//        return element;
//    }

//    public override List<IWebElement> FindElements(By locator)
//    {
//        var elements = Driver?.FindElements(locator);
//        if (elements.Any())
//        {
//            ScrollIntoView(elements.Last());
//        }
//        return elements;
//    }

//    private void ScrollIntoView(IWebElement element)
//    {
//        Driver.ExecuteScript("arguments[0].scrollIntoView(true);", element.WrappedElement);
//    }
//}
