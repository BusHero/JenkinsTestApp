using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JenkinsTestApp.Specs.PageObjects;
public class EntryPageObject
{
    private const string BlogEntryUrl = "https://localhost:8081/blog/foo";

    private readonly IWebDriver _webDriver;

    private const int DefaultWaitInSeconds = 5;

    private IWebElement Title => _webDriver.FindElement(By.Id("title")); 

    public EntryPageObject(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public void Navigate()
    {
        _webDriver.Navigate().GoToUrl(BlogEntryUrl);
    }

    public string? GetTitle() => WaitUntil(
        () => Title.Text, 
        result => result != string.Empty);

    private T? WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T: class
    {
        WebDriverWait wait = new(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
        return wait.Until(driver =>
        {
            var result = getResult();
            if (!isResultAccepted(result))
                return default;
            return result;
        });
    }
}

