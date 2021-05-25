@Registration @Api
Feature: RegistrationApiRequest

@Positive @Post
Scenario: Create client using Api request POST registration/registration-client
	Given Create client using POST method registration/registration-client with valid data
	Then <status_code> status code is recieved from the Api request
	| status_code |
	| Created     |
	And message <message> is recieved from the Api request
	| message |
	| Created |