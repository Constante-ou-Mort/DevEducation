@registration @api
Feature: RegistrationAPI

Scenario: User create new account in NewBookModels
	Given Client is created
	When I send POST request registration client with valid data 
	Then Succesfully registration client in NewBookModels