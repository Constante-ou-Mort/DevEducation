@ChangeEmail @Api
Feature: ChangeEmailApiRequest

@Positive @Post
Scenario Outline: Update client email using Api request POST updating/updating-profile
	Given Change email using Api request POST updating/updating-profile
	| email   |
	| <email> |
	Then '200' status code is recieved from the Api request
	And message 'created' is recieved from the Api request
Examples:
	| email     |
	| uniqEmail |