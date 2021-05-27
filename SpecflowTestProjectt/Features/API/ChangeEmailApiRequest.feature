@ChangeEmail @Api
Feature: ChangeEmailApiRequest

@Positive @Post
Scenario Outline: Update client email using Api request POST updating/updating-profile
	Given Change email to <email> using Api request POST updating/updating-profile
	| email   |
	| <email> |
	Then OK status code is recieved from the Api request
	And message <message> is recieved from the Api request
Examples:
	| email     |
	| uniqEmail |