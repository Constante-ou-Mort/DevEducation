@Registration @api
Feature: RegistrationApiRequest

@Positive
Scenario: create client using Api request POST registration/registration-client
	Given Create client using POST method registration/registration-client with valid data
	Then '201' status code is recieved from the Api request
	And message 'Created' is recieved from the Api request
