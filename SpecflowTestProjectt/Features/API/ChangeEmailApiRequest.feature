@changeEmail @api
Feature: ChangeEmailApiRequest

#не нашла метод для трансформации, поэтому в фф креды описаны так
@positive @postMethod
Scenario: Update client email using Api request POST client/change_email
Given Client is created
	When I change email to <email> using Api request POST client/change_email
	| email     |
	| uniqEmail |
	Then OK status code is recieved from the Api request
	And message OK is recieved from the Api request