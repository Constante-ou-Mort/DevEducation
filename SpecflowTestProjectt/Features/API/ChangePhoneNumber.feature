@ChangePhone @Api
Feature: ChangePhoneNumberApiRequest

@Positive @Post
Scenario Outline: Update client phone number using Api request POST updating/updating-profile
	Given Change phone to <phone_number> using Api request POST updating/updating-profile
	| phone_number   |
	| <phone_number> |
	Then <status_code> status code is recieved from the Api request
	| status_code |
	| OK          |
Examples:
	| phone_number |
	| 1234567890   |
	| 0987654321   |
	| 1111111111   |
	| 0000000000   |