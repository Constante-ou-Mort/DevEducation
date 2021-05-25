@UpdateProfile @api
Feature: ChangePhoneNumberApiRequest

@mytag
Scenario Outline: update client phone number using Api request POST updating/updating-profile
	Given Change phone using Api request POST updating/updating-profile
	| phone_number   |
	| <phone_number> |
	Then '200' status code is recieved from the Api request
Examples:
	| phone_number |
	| 1234567890   |
	| 0987654321   |
	| 1111111111   |
	| 0000000000   |