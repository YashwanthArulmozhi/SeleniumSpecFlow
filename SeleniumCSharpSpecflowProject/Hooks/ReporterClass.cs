
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumCSharpSpecflowProject
{
    [Binding]
    class ReporterClass
    {

        private static ExtentHtmlReporter htmlReporter;
        private static ExtentReports extentReports;
        static string reportCompleteFilePath;
        static string reporterNameTimeStamp;
       private static ExtentTest featureName;
       private static ExtentTest scenarioName;
       

        [BeforeTestRun]
        public static void CreateExtentHtmlReporter()
        {
  
                reporterNameTimeStamp = DateTime.Now.ToString("ddMMHHmmss");
                reportCompleteFilePath = Directory.GetParent(Environment.CurrentDirectory).FullName + @"\Reports\TestReport" + reporterNameTimeStamp + ".html";
                Console.WriteLine("Path of the Report File - > " + reportCompleteFilePath);
             htmlReporter = new ExtentHtmlReporter(reportCompleteFilePath);
             htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            htmlReporter.Config.ReportName = "Automation Report";
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void CreateFeature(FeatureContext featureContext)
        {
            featureName = extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public static void CreateScenario(ScenarioContext scenarioContext)
        {
            scenarioName = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public static void CreateStepsWithScenario(ScenarioContext scenarioContext)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (scenarioContext.TestError == null)
            {
                switch (stepType)
                {
                    case "Given":
                        scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                    case "When":
                        scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                    case "Then":
                        scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                    case "And":
                        scenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                }
                      /*  if (stepType == "Given")
                    scenarioName.CreateNode<Given>(stepContext.StepInfo.Text);
                else if(stepType == "When")
                    scenarioName.CreateNode<When>(stepContext.StepInfo.Text);
                else if(stepType == "Then")
                    scenarioName.CreateNode<Then>(stepContext.StepInfo.Text);
                else if(stepType == "And")
                            scenarioName.CreateNode<And>(stepContext.StepInfo.Text);*/
            }
            else if(scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {

                    scenarioName.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if(stepType == "When")
                {
                    scenarioName.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if(stepType == "Then") {
                    scenarioName.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if(stepType == "And")
                {
                    scenarioName.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
            }
        }

      /*  public void AddPassedStepLog(string passedDescription)
        {
            featureName.Log(Status.Pass, passedDescription);
        }

        public void AddFailedStepLog(string failedDescription)
        {
            featureName.Log(Status.Fail, failedDescription);
        }*/

        [AfterTestRun]
        public static void AfterTestReporterFlush()
        {
            try
            {
                extentReports.Flush();
                System.Diagnostics.Process.Start(reportCompleteFilePath);
            }
            catch (Exception e)
            {
               Console.WriteLine(e.GetBaseException().Message);
            }
        }
    }
}
