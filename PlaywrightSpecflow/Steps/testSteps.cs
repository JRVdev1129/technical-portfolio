using TechTalk.SpecFlow;

namespace Playwright_Specflow.Steps
{
    [Binding]
    public sealed class testSteps
    {

        private readonly ScenarioContext _scenarioContext;

        public testSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the user navigates to the playwright page")]
        public void GivenTheUserNavigatesToThePlaywrightPage()
        {

            _scenarioContext.Pending();
        }

        [Given("the page is loaded")]
        public void GivenThePageIsLoaded()
        {

            _scenarioContext.Pending();
        }

        [When("the user clicks get started button")]
        public void WhenTheUserClicksGetStartedButton()
        {

            _scenarioContext.Pending();
        }

        [Then("the user should redirect to get started page")]
        public void ThenUserShouldRedirectToGetStartedPage()
        {

            _scenarioContext.Pending();
        }
    }
}
