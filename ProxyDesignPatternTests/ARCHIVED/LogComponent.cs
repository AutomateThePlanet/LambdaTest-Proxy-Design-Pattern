﻿//using AngleSharp.Dom;

//namespace DecoratorDesignPatternTests.ARCHIVED;

//public class LogComponent : ComponentDecorator
//{
//    public LogComponent(IWebElement element)
//    : base(element)
//    {
//    }

//    public override By By => Element?.By;

//    public override string Text
//    {
//        get
//        {
//            Console.WriteLine($"Element Text = {Element?.Text}");
//            return Element?.Text;
//        }
//    }

//    public override bool? Enabled
//    {
//        get
//        {
//            Console.WriteLine($"Element Enabled = {Element?.Enabled}");
//            return Element?.Enabled;
//        }
//    }

//    public override bool? Displayed
//    {
//        get
//        {
//            Console.WriteLine($"Element Displayed = {Element?.Displayed}");
//            return Element?.Displayed;
//        }
//    }

//    public override void Click()
//    {
//        Console.WriteLine($"Element Clicked");
//        Element?.Click();
//    }

//    public override IWebElement FindElement(By locator)
//    {
//        return Element?.FindElement(locator);
//    }

//    public override List<IWebElement> FindElements(By locator)
//    {
//        return Element?.FindElements(locator);
//    }

//    public override string GetAttribute(string attributeName)
//    {
//        Console.WriteLine($"Get Element's Attribute = {attributeName}");
//        return Element?.GetAttribute(attributeName);
//    }

//    public override void Hover()
//    {
//        Element?.Hover();
//    }

//    public override void SendKeys(string text)
//    {
//        Console.WriteLine($"Type Text = {text}");
//        Element?.SendKeys(text);
//    }
//}
