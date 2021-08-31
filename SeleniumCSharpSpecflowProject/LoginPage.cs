using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharpSpecflowProject
{
    class LoginPage
    {

        CommonActionClass commonActions = new CommonActionClass();

        private By input_EmailId = By.Name("username");
        private By input_Password = By.Name("password");
        private By label_SuccessMsg = By.XPath("//b[contains(text(),'Successful Login')]");
        private By button_Login = By.XPath("//input[@value='Test Login']");



        public void ProvideLoginDetails()
        {
            if (commonActions.WaitForElement(input_EmailId) != null)
            {
                commonActions.SendValue(input_EmailId, CreateUserPage.userName);
                commonActions.SendValue(input_Password, CreateUserPage.password);
                commonActions.ClickElement(button_Login);
                Console.WriteLine("Successfully Clicked on Login button");
            }
        }

        public void ValidateSuccessFulLogin()
        {
            if (commonActions.WaitForElement(label_SuccessMsg) != null)
            {
                if (commonActions.GetTextValue(label_SuccessMsg).Contains("Successful Login"))
                {
                    Console.WriteLine("Passed - > " + commonActions.GetTextValue(label_SuccessMsg));
                }
                else
                {
                    Console.WriteLine("Failed - > " + commonActions.GetTextValue(label_SuccessMsg));
                }
            }
        }

    }
}
