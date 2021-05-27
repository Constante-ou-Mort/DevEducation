@changeEmail @api
Feature: ChangeEmailApiRequest

@positive @postMethod
Scenario: Client able to change email
	Given Client is created
	When I change email to <email> via API request
	| email          |
	| nice@gmail.com |
	Then OK status in response