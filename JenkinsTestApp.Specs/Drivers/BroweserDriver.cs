using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace JenkinsTestApp.Specs.Drivers;

public class BroweserDriver : IDisposable
{
    private readonly Lazy<IWebDriver> _currentWebDriverLazy;
    private bool _isDisposed;

    public IWebDriver Current => _currentWebDriverLazy.Value;
    
    public BroweserDriver()
    {
        _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
    }

    private IWebDriver CreateWebDriver()
    {
        var chromeDriverService = ChromeDriverService.CreateDefaultService();
        var chromeOptions = new ChromeOptions();
        var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
        return chromeDriver;
    }

    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        if (_currentWebDriverLazy.IsValueCreated)
        {
            Current.Quit();
        }

        _isDisposed = true;
    }
}
