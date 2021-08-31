using System;
using TechTalk.SpecFlow;

namespace SeleniumCSharpSpecflowProject.Steps
{
    [Binding]
    public class CreateUserSteps
    {

        CreateUserPage CreateUser = new CreateUserPage();
        LoginPage login = new LoginPage();

        [Given(@"Launch the application")]
        public void GivenLaunchTheApplication()
        {
            CreateUser.LaunchTheApplication();
        }
        
        [When(@"Create a new user")]
        public void WhenCreateANewUser()
        {
            CreateUser.CreateNewUser();
        }
        
        [Then(@"Verify new user is displayed correctly")]
        public void ThenVerifyNewUserIsDisplayedCorrectly()
        {
            CreateUser.ValidateNewUser();
        }

        [When(@"Provide login details and click Login")]
        public void WhenProvideLoginDetailsAndClickLogin()
        {
            login.ProvideLoginDetails();
        }

        [Then(@"Validate the login successful message displayed in UI")]
        public void ThenValidateTheLoginSuccessfulMessageDisplayedInUI()
        {
            login.ValidateSuccessFulLogin();

        }

    }
}
