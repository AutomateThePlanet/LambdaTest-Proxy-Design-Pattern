using System.Collections.ObjectModel;
using System.Drawing;

namespace ProxyDesignPatternTests.FourthVersion;
public class WebElementProxy : IWebElement
{
    private readonly IWebElement _element;
    private readonly WebDriverWait _wait;

    public WebElementProxy(IWebElement element, IWebDriver driver)
    {
        _element = element;
        var timeout = TimeSpan.FromSeconds(30);
        var sleepInterval = TimeSpan.FromSeconds(2);
        _wait = new WebDriverWait(driver, timeout) { PollingInterval = sleepInterval };
    }

    public string TagName => _element.TagName;

    public string Text => _element.Text;

    public bool Enabled => _element.Enabled;

    public bool Selected => _element.Selected;

    public Point Location => _element.Location;

    public Size Size => _element.Size;

    public bool Displayed => _element.Displayed;

    public void Clear()
    {
        _element.Clear();
    }

    public void Click()
    {
        _wait.Until(ExpectedConditions.ElementToBeClickable(_element));
        _element.Click();
    }

    public IWebElement FindElement(By by)
    {
        return _wait.Until(ExpectedConditions.ElementExists(by));
    }

    public ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
    }

    public string GetAttribute(string attributeName)
    {
        return _element.GetAttribute(attributeName);
    }

    public string GetCssValue(string propertyName)
    {
        return _element.GetCssValue(propertyName);
    }

    public string GetDomAttribute(string attributeName)
    {
        return _element.GetDomAttribute(attributeName);
    }

    public string GetDomProperty(string propertyName)
    {
        return _element.GetDomAttribute(propertyName);
    }

    public ISearchContext GetShadowRoot()
    {
        return _element.GetShadowRoot();
    }

    public void SendKeys(string text)
    {
        _element.SendKeys(text);
    }

    public void Submit()
    {
        _element.Submit();
    }
}
