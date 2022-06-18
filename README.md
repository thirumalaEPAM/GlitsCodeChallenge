# # Project name : GlitsCodeChallenge
## Pre-Requisites for project execution
- Visual Studio 2022
- Latest Chrome Driver version 99.0.4844.5100

## 01 - Automation Framework design Approach

###### IDE & Language
   - Visual Studio 2022 & C#
###### Automation Tool
   - Selenium WebDriver
###### Project Type
   - BDD-SpecFlow
###### Design Pattern
   - Singleton with POM
###### DataDriven
   - Scenario Outline
###### Reports
   - Extent Reports
###### Browsers
   - Chrome Driver
## 02 - Test Scenarios
-Scenario 1 : Verify user can login into Aspire application with valid email
- Click on Next button
- Retrieve the OTP from the Mail box
- Enter that valid OTP into OTP field 
- Validate that OTP and Navigate to Next webpage

-Scenario 2 : Verify a new user can register his email by using register link
- Click on Register Link
- Retrieve the OTP from the Mail box
- Enter that valid OTP into OTP field 
- Verify that user can regester his email successfully

###### Feature file
```
Scenario Outline: Verify user can login into Aspire application with valid email or mobile
	Given user can enter valid mail as <Email>
	When click on Next button
	And user enter One Time Password
	Then Verify user can successfully login into application
Examples:
| Email                  | 
|XXXXXXX@outlook.com| 
|YYYYYYY@outlook.com| 
	
Scenario: Verify new user can register his email using register link
Given Launch the Application and Click on Register Link
When Fill all mandatory data and Click on Continue
And Get the OTP from Mailbox and Enter into OTP field
Then Verify user registered successfully

```
 ## 03 - Brief Description about framework Approach
 - Reports created using ExtentReports and ScreenShots captured for failed scenarios
 
 - In Project solution 
     ###### 1. ObjectRepsitoryLibrary : 
      which contains common utilities, locators (defined in page classfiles), SingletonBaseclass 
       
    ###### 2. HelperLibrary : 
     which contains the methods which are specific to the respective pages
       
    ###### 4. BDDFramework(SpecFlow Project) 
       Feature files
       Stepdefination files
       Hooks

