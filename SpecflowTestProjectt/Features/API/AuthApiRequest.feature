@authorization @api
Feature: AuthApiRequest
	Simple calculator for adding two numbers

@positive @postMethod
Scenario: Authorizate existing client using Api request POST auth/auth-client
	Given Client is created
	When I authorize as an existing client using Api request POST auth/auth-client
	Then Created status code is recieved from the Api request
	And message Created is recieved from the Api request