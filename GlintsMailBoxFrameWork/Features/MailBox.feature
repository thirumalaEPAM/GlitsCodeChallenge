Feature: MailBox

A short summary of the feature

Scenario Outline: Verify user can login into Aspire application with valid email or mobile
	Given user can enter valid mail as <Email>
	When click on Next button
	And user enter One Time Password
	Then Verify user can successfully login into application

Examples:
| Email                   | 
|MynameisSdet@outlook.com| 
|thirumalasdet@outlook.com| 

Scenario: Verify new user can register his mail using register link
Given Launch the Application and Click on Register Link
When Fill all mandatory data and Click on Continue
And Get the OTP from Mailbox and Enter into OTP field
Then Verify user registered successfully
