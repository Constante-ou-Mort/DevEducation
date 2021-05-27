@registration @api
Feature: RegistrationApiRequest

@positive @postMethod
Scenario: Create client using Api request POST registration/registration-client
	When I create client using POST method registration/registration-client with valid data
	Then Created status code is recieved from the Api request
	And message Created is recieved from the Api request