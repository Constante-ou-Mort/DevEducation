@AccountSettings @api
Feature: AccountSettings
	In order to update my account data in NewBookModels
	As a client of NewBookModels
	I want to change my account in NewBookModels

Scenario: It is possible to change client email with valid data in NewBookModels Account
	Given Client is created
	When I send POST request client/change_email/ with new email 'kthfgs@gmail.com'
	Then Client email was successfully changed in NewBookModels Account

Scenario: It is possible to change client phone number with valid data in NewBookModels Account
	Given Client is created
	When I send POST request client/change_phone/ with new phone '7531592580'
	Then Client phone number successfully changed in NewBookModels Account