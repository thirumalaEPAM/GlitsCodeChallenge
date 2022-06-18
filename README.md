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

###### Feature file
```
Scenario Outline: Verify user can login into Aspire application with valid email or mobile
	Given user can enter valid mail as <Email>
	When click on Next button
	And user enter One Time Password
	Then Verify user can successfully login into application
```
