using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharpSpecflowProject
{
    class LoginPage : CommonActionClass
    {

        private By input_EmailId = By.Name("username");
        private By input_Password = By.Name("password");
        private By label_SuccessMsg = By.XPath("//b[contains(text(),'Successful Login')]");
        private By button_Login = By.XPath("//input[@value='Test Login']");



        public void ProvideLoginDetails()
        {
            if (WaitForElement(input_EmailId) != null)
            {
                SendValue(input_EmailId, CreateUserPage.userName);
                SendValue(input_Password, CreateUserPage.password);
                ClickElement(button_Login);
                Console.WriteLine("Successfully Clicked on Login button");
            }
        }

        public void ValidateSuccessFulLogin()
        {
            if (WaitForElement(label_SuccessMsg) != null)
            {
                if (GetTextValue(label_SuccessMsg).Contains("Successful Login"))
                {
                    Console.WriteLine("Passed - > " + GetTextValue(label_SuccessMsg));
                }
                else
                {
                    Console.WriteLine("Failed - > " + GetTextValue(label_SuccessMsg));
                }
            }
        }

    }
}
