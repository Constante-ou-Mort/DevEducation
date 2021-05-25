@UpdateProfile @api
Feature: UpdateProfileApiRequest

@mytag
Scenario Outline: update client email using Api request POST updating/updating-profile
	Given Change email using Api request POST updating/updating-profile
	| email   |
	| <email> |
	Then '200' status code is recieved from the Api request
	And Message 'Created' is reciieved from the Api request
Examples:
	| email           |
	| Lili@gmail.com  |
	| Marina@orf.com  |
	| ADFG@a.ua       |
	| Marinet@com.com |