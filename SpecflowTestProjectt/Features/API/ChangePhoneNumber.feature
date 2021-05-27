@ChangePhone @Api
Feature: ChangePhoneNumberApiRequest

@Positive @Post
Scenario Outline: Update client phone number using Api request POST client/change_phone
	When Change phone to <phone_number> using Api request POST client/change_phone
	| phone_number   |
	| <phone_number> |
	Then OK status code is recieved from the Api request
Examples:
	| phone_number |
	| 1234567890   |
	| 0987654321   |
	| 1111111111   |
	| 0000000000   |