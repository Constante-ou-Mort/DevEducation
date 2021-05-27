@AccountSettings  @ui
Feature: AccountSettings
	In order to update my account data in NewBookModels
	As a client of NewBookModels
	I want to change my password  in NewBookModels

@pozitive
Scenario: It is possible to change client password with valid  password in NewBookModels Account
	Given Client is created
	And Client is authorized
	And Account Settings page is opened
	When I click on edit password button on Account Settings page
	And I input at Current password in the Password Edit Block
	And I input new password '!QWEqwe2' at New password field in the Password Edit Block
	And I input new password '!QWEqwe2' at New password confirm field in the Password Edit Block
	And I click Save changes button at at the Edit Password Block
	Then Succesfully changed client password in NewBookModels

@negative
Scenario: It is impossible to change client password with invalid current password in NewBookModels Account
	Given Client is created
	And Client is authorized
	And Account Settings page is opened
	When I click on edit password button on Account Settings page
	And I input client '123' at Current password field in the Password Edit Block
	And I input new password '!QA2wsxc' at New password field in the Password Edit Block
	And I input new password '!QA2wsxc' at New password confirm field in the Password Edit Block
	And I click Save changes button at at the Edit Password Block
	Then Error message 'Invalid old password' on the Account Settings page