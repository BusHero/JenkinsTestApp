using System;

using JenkinsTestApp.Specs.Drivers;
using JenkinsTestApp.Specs.PageObjects;

using TechTalk.SpecFlow;

namespace JenkinsTestApp.Specs.StepDefinitions
{
    [Binding]
    public class BlogStepDefinitions
    {
        private readonly EntryPageObject _entryPageObject;

        public BlogStepDefinitions(BroweserDriver browserDriver)
        {
            _entryPageObject = new EntryPageObject(browserDriver.Current);
        }

        [When(@"I navigate to the webpage corresponding to the blog with the name Foo")]
        public void WhenINavigateToTheWebpageCorrespondingToTheBlogWithTheNameFoo()
        {
            _entryPageObject.Navigate();
        }

        [Then(@"I can see a web page whose title is Foo")]
        public void ThenICanSeeAWebPageWhoseTitleIsFoo()
        {
            var actualTitle = _entryPageObject.GetTitle();
            actualTitle.Should().Be("Foo");
        }

    }
}
