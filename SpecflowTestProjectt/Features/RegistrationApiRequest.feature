Feature: RegistrationApiRequest

@Positive
Scenario: create client using Api request POST registration/registration-client
	Given I create client using POST method registration/registration-client with valid data
	| email   | password   | confirm_password | name   | last_name   | phone_number   |
	| <email> | <password> | <password>       | <name> | <last_name> | <phone_number> |
	Then '200' status code is recieved from the Api request
