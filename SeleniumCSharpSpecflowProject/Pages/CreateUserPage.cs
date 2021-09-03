using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeleniumCSharpSpecflowProject
{
    class CreateUserPage : CommonActionClass
    {


        String applicationUrl = "http://thedemosite.co.uk/login.php";
        public  static string userName = "TestUser1";
        public static string password = "Test126";

        private By link_AddUser = By.XPath("//a[contains(text(),'Add a User')]");
        private By input_EmailId = By.Name("username");
        private By input_Password = By.Name("password");
        private By button_Save = By.XPath("//input[@value='save']");
        private By label_Details = By.XPath("//b[text()='The username:']/..");
        private By link_Login = By.XPath("(//a[@href='login.php'])[1]");


        public void LaunchTheApplication()
        {
            string dataFromExcel = ReadDataFromExcel("Name");
            LaunchApplication(applicationUrl);
            Console.WriteLine("Excel data - >" + dataFromExcel);
        }

        public void CreateNewUser()
        {

            if (WaitForElement(link_AddUser) != null)
            {
                ClickElement(link_AddUser);
                if (WaitForElement(input_EmailId) != null)
                {
                    //Learning purpose code
                    /*StreamReader s = new StreamReader(Directory.GetParent(Environment.CurrentDirectory).FullName + @"\SeleniumCSharpSpecflowProject\Config.txt");
                    string line=null;
                    while(!String.IsNullOrEmpty(line = s.ReadLine()))
                    {
                        String value = line.Split("=")[1];
                        Console.WriteLine($"value is ->{value}");
                    }
                    s.Close();*/
                    
                    SendValue(input_EmailId, userName);
                    SendValue(input_Password, password);
                    ClickElement(button_Save);
                    Console.WriteLine("Successfully Clicked on Save button");
                }
            }
        }

        public void ValidateNewUser()
        {
            if (WaitForElement(label_Details) != null)
            {
                string userCreateInUI = GetTextValue(label_Details).Substring(14, 9);
               string value = userCreateInUI.Trim().Should().Contain(userName).ToString();
               // CommonActionClass.TakeScreenshotImage(Directory.GetParent(Environment.CurrentDirectory).FullName + @"Reports\Screenshots\ScreenshotImage" + DateTime.Now.ToString("ddMMHHmmss") + ".png");
              Console.WriteLine("User Created in UI - >" + userCreateInUI);
                Console.WriteLine("Validated Data - >" + value);
            }
        }


        public void CloseDriver()
        {
            CloseBrowser();
        }
    }
}
