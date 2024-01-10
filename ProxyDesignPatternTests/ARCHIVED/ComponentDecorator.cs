//namespace DecoratorDesignPatternTests.ARCHIVED;

//public abstract class ComponentDecorator : IWebElement
//{
//    protected readonly IWebElement Element;

//    protected ComponentDecorator(IWebElement element)
//    {
//        Element = element;
//    }

//    public override By By => Element?.By;
//    public override IWebElement WrappedElement => Element?.WrappedElement;

//    public override string Text => Element?.Text;

//    public override bool? Enabled => Element?.Enabled;

//    public override bool? Displayed => Element?.Displayed;

//    public override void Click()
//    {
//        Element?.Click();
//    }

//    public override string GetAttribute(string attributeName)
//    {
//        return Element?.GetAttribute(attributeName);
//    }

//    public override void SendKeys(string text)
//    {
//        Element?.SendKeys(text);
//    }
//}
