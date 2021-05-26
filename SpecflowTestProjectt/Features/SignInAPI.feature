@signin @api
Feature: SignInAPI

Scenario: User can sign in with valid data
	When I send POST request auth/signin/ with valid data
	Then User successfully logging in