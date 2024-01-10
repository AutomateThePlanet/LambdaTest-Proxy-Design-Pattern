using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Linq;
using AngleSharp.Dom;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using ProxyDesignPatternTests.FourthVersion;
using WebDriverManager.DriverConfigs.Impl;

namespace DecoratorDesignPattern.FourthVersion;

public class WebDriverProxy : IWebDriver
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _webDriverWait;

    public WebDriverProxy(IWebDriver driver)
    {
        _driver = driver;
        var timeout = TimeSpan.FromSeconds(30);
        var sleepInterval = TimeSpan.FromSeconds(2);
        _webDriverWait = new WebDriverWait(new SystemClock(), _driver, timeout, sleepInterval);
    }

    public IWebElement FindElement(By by)
    {
        var nativeElement = _webDriverWait.Until(ExpectedConditions.ElementExists(by));
        return new WebElementProxy(nativeElement, _driver);
    }

    public ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        ReadOnlyCollection<IWebElement> nativeWebElements =
        _webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        var elements = new List<IWebElement>();
        foreach (var nativeWebElement in nativeWebElements)
        {
            var element = new WebElementProxy(nativeWebElement, _driver);
            elements.Add(element);
        }

        return nativeWebElements;
    }

    public void Dispose()
    {
        _driver.Dispose();
    }
    public void Close()
    {
        _driver.Close();
    }
    public void Quit()
    {
        _driver.Quit();
    }
    public IOptions Manage()
    {
        return _driver.Manage();
    }
    public INavigation Navigate()
    {
        return _driver.Navigate();
    }
    public ITargetLocator SwitchTo()
    {
        return _driver.SwitchTo();
    }
    public string Url
    {
        get => _driver.Url;
        set => _driver.Url = value;
    }
    public string Title
    {
        get => _driver.Title;
    }
    public string PageSource
    {
        get => _driver.PageSource;
    }
    public string CurrentWindowHandle
    {
        get => _driver.CurrentWindowHandle;
    }
    public ReadOnlyCollection<string> WindowHandles
    {
        get => _driver.WindowHandles;
    }
}
