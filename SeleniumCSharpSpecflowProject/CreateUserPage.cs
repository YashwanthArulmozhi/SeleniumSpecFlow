using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharpSpecflowProject
{
    class CreateUserPage
    {
        CommonActionClass commonActions = new CommonActionClass();


        String applicationUrl = "http://thedemosite.co.uk/login.php";
        public  static string userName = "TestUser001";
        public static string password = "Test126";

        private By link_AddUser = By.XPath("//a[contains(text(),'Add a User')]");
        private By input_EmailId = By.Name("username");
        private By input_Password = By.Name("password");
        private By button_Save = By.XPath("//input[@value='save']");
        private By label_Details = By.XPath("//b[text()='The username:']/..");
        private By link_Login = By.XPath("(//a[@href='login.php'])[1]");

        public void LaunchTheApplication()
        {
            commonActions.LaunchApplication("chrome", applicationUrl);
        }

        public void CreateNewUser()
        {

            if (commonActions.WaitForElement(link_AddUser) != null)
            {
                commonActions.ClickElement(link_AddUser);
                if (commonActions.WaitForElement(input_EmailId) != null)
                {
                    commonActions.SendValue(input_EmailId, userName);
                    commonActions.SendValue(input_Password, password);
                    commonActions.ClickElement(button_Save);
                    Console.WriteLine("Successfully Clicked on Save button");
                }
            }
        }

        public void ValidateNewUser()
        {
            if (commonActions.WaitForElement(label_Details) != null)
            {
                String userCreateInUI = commonActions.GetTextValue(label_Details).Substring(14, 9);
                Console.WriteLine("User Created in UI - >" + userCreateInUI);
            }
        }


        public void CloseDriver()
        {
            commonActions.CloseBrowser();
        }
    }
}
