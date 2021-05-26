@nice
Feature: ChangeInformation
	In order to change some information in my profile
	As a user
	I want to change information in any time easy and quickly

@mytag
Scenario: Add two numbers
	Given Client is created
	And The profile page is opened
	When I click on icon to change my email
	And I write my password to the first field
	And I write new email to the second field
	And I click Submit button
	Then My email is changed
