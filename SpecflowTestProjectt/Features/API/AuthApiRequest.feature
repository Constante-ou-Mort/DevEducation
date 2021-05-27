@Authorization @Api
Feature: AuthApiRequest
	Simple calculator for adding two numbers

@Positive @Post
Scenario Outline: Authorizate existing client using Api request POST auth/auth-client
	Given Authorizate existing client using Api request POST auth/auth-client
	Then OK status code is recieved from the Api reques