@AccountSettings  @api
Feature: AccountSettingsViaApi

Scenario: It is possible to change client email with valid data in NewBookModels Account
	Given Client is created
	When I send POST request client change_email with new email client
	Then Client email was successfully changed in NewBookModels Account

Scenario: It is possible to change client phone number with valid data in NewBookModels Account
	Given Client is created
	When I send POST request client change_phone with new phone '7777777777'
	Then Successfully changed  phone number in NewBookModels Account

Scenario: It is possible to change client first name and last name with valid data in NewBookModels Account
	Given Client is created
	When I send PATCH request client change_first_name change_last_name with new first name Taras, with new last name Shevchenko
	Then Client first name and last name successfully changed in NewBookModels Account




