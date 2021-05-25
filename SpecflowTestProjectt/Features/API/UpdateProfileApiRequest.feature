@UpdateProfile @api
Feature: UpdateProfileApiRequest

@mytag
Scenario: update client profile using Api request POST updating/updating-profile
	Given Create client using POST method registration/registration-client with valid data
	| email   | password   | confirm_password | name   | last_name   | phone_number   |
	| <email> | <password> | <password>       | <name> | <last_name> | <phone_number> |
	Then '200' status code is recieved from the Api request                   
 