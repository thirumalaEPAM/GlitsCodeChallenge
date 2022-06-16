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
