@registration @api
Feature: RegistrationAPI

Scenario: User create new account
	When I send valid registration request  
	Then The server should handle it and return a success status

