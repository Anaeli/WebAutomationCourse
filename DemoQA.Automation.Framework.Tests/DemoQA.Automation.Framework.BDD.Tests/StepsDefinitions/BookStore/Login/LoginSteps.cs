using System;
using TechTalk.SpecFlow;

namespace DemoQA.Automation.Framework.BDD.Tests.StepsDefinitions.BookStore.Login
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"I insert my username is Jess")]
        public void GivenIInsertMyUsernameIsJess()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I insert my password is Control(.*)!")]
        public void GivenIInsertMyPasswordIsControl(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I do not insert my password")]
        public void GivenIDoNotInsertMyPassword()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I do not insert my username")]
        public void GivenIDoNotInsertMyUsername()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press on the Login button")]
        public void WhenIPressOnTheLoginButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I go to the Profile Page")]
        public void ThenIGoToTheProfilePage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The password should show me in red")]
        public void ThenThePasswordShouldShowMeInRed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The username should show me in red")]
        public void ThenTheUsernameShouldShowMeInRed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The username and password should show me in red")]
        public void ThenTheUsernameAndPasswordShouldShowMeInRed()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
