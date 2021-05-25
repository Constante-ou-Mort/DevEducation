@login @ui
Feature: Login
	In order to login in NewBookModels
	As a client of NewBookModels
	I want to be logged in NewBookModels

Scenario: It is possible to login in NewBookModels with valid data
	Given Client is created
	And Sign in page is opened
	When I input email of created client in email field
	And I input password of created client in password field
	And I click Log in button
	Then I successfully logged in NewBookModels as created client

@negative
Scenario Outline: It is unpossible to login in NewBookModels with invalid email
	Given Client is created
	And Sign in page is opened
	When I input '<email>' in email field
	And I input password of created client in password field
	And I click Log in button
	Then I see error message - '<message>' on the Sign In page
Examples:
	| email         | message       |
	|               | Required      |
	| !!!!          | Invalid Email |
	| kt@@gmail.com | Invalid Email |
	| kt@gmail      | Invalid Email |
	| gmail.com     | Invalid Email |