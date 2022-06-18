using GlintsMailBoxFrameWork.Hooks;
using NUnit.Framework;
using ObjectRepositoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GlintsMailBoxFrameWork.StepDefination
{
    [Binding]
    public class MailBoxStepDefinitions
    {
        private ScenarioContext _scenarioContext;

        public MailBoxStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"user can enter valid mail as (.*)")]
        public void GivenUserCanEnterValidMailAs(string p0)
        {
            _scenarioContext[Constants.email] = p0;
            MyHook.help.EnterEmailorMobile(SignInPageRepo.elementEmailorPhone, p0);
        }
        [Given(@"Launch the Application and Click on Register Link")]
        public void GivenLaunchTheApplicationAndClickOnRegisterLink()
        {
            MyHook.help.ButtonClick(RegisterPageRepo.elementRegisterLink);
        }

        [When(@"click on Next button")]
        public void WhenClickOnNextButton()
        {
            MyHook.help.ButtonClick(SignInPageRepo.elementNext);
        }
      
        [When(@"Fill all mandatory data and Click on Continue")]
        public void WhenFillAllMandatoryDataAndClickOnContinue()
        {
            MyHook.help.NewRegistration();
        }

        [When(@"user enter One Time Password")]
        public void WhenUserEnterOneTimePassword()
        {            
            string OTP = MyHook.help.GetOTPfromEmailbody(_scenarioContext[Constants.email].ToString());
            MyHook.help.EnterOTP(OTP);
        }
        [When(@"Get the OTP from Mailbox and Enter into OTP field")]
        public void WhenGetTheOTPFromMailboxAndEnterIntoOTPField()
        {
            string OTP = MyHook.help.GetOTPfromEmailbody(Constants.newEmail);
            MyHook.help.EnterOTP(OTP);
        }

        [Then(@"Verify user can successfully login into application")]
        public void ThenVerifyUserCanSuccessfullyLoginIntoApplication()
        {
            if (_scenarioContext["Email"].ToString()==Constants.email1)
            {
                string hometext = MyHook.help.GetText(SignInPageRepo.elementHomePage);
                string complete = MyHook.help.GetText(SignInPageRepo.elementCompleteForm);
                Assert.AreEqual(hometext, Constants.home);
                Assert.AreEqual(complete, Constants.Complete);
            }
            else 
            {
                string start = MyHook.help.GetText(SignInPageRepo.elementgetStarted);
                Assert.AreEqual(start, Constants.getStarted);
            }

        }
              

        [Then(@"Verify user registered successfully")]
        public void ThenVerifyUserRegisteredSuccessfully()
        {
            string start = MyHook.help.GetText(RegisterPageRepo.elementContinue);
            Assert.AreEqual(start, Constants.Continue);
        }

    }
}
