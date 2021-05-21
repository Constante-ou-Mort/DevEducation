@AccountSettings
Feature: AccountSettings
	In order to update my account data in NewBookModels
	As a client of NewBookModels
	I want to change my account in NewBookModels

@api
Scenario: It is possible to change client email with valid data in NewBookModels Account
	Given Client is created
	When I send POST request client/change_email/ with new client email
	Then Client email was successfully changed in NewBookModels Account

@api
Scenario: It is possible to change client phone number with valid data in NewBookModels Account
	Given Client is created
	When I send POST request client/change_phone/ with new phone '7531592580'
	Then Client phone number successfully changed in NewBookModels Account

@ui
Scenario Outline: It is impossible to change client password with invalid current password in NewBookModels Account
	Given Client is created
	And Client is authorized
	And Account Settings page is opened
	When I click on edit password button on Account Settings page
	And I input client '123' at Current password field in the Password Edit Block
	And I input new password '!QA2wsxc' at New password field in the Password Edit Block
	And I input new password '!QA2wsxc' at New password confirm field in the Password Edit Block
	And I click Save changes button at at the Edit Password Block
	Then I see error message 'Invalid old password' on the Account Settings page
