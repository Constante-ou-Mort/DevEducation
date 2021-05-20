@AccountSettings @api
Feature: AccountSettings
	In order to update my account data in NewBookModels
	As a client of NewBookModels
	I want to change my account in NewBookModels

Scenario: It is possible to change client email with valid data in NewBookModels Account
	Given Client is created
	When Authorized as created client I send request for changing email with with valid data in NewBookModels Account
	Then Client email was successfully changed with valid data in NewBookModels Account