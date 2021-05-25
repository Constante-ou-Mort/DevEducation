@AccountSettings @ui
Feature: AccountSettings
	In order to update my account data in NewBookModels
	As a client of NewBookModels
	I want to change my account in NewBookModels

Scenario Outline: It is impossible to change client password with invalid current password in NewBookModels Account
	Given Client is created and authorized
	And Account Settings page is opened
	When I click on edit password button on Account Settings page
	And I input client '123' at Current password field in the Password Edit Block
	And I input new password '!QA2wsxc' at New password field in the Password Edit Block
	And I input new password '!QA2wsxc' at New password confirm field in the Password Edit Block
	And I click Save changes button at at the Edit Password Block
	Then I see error message 'Invalid old password.' on the Account Settings page