@registration @ui
Feature: Registration
	In order to Registration on NewBookModels
	As a client
	I want to create own account

@pozitive
Scenario Outline: Registration client with valid data
	Given Sign Up page is open
	When I filled the <first_name> in first name
	And I filled the <last_name> in last name
	And I filled the <email> in email
	And I filled the <password> in password
	And I confirm <password>
	And I filled the <number> in number
	And I click Next button
	Then Succesfully registration in NewBookModels
Examples:
	| first_name | last_name  | password   | email                      | number     |
	| Taras      | Shevchenko | 123QWEewq@ | TarasShevchenko1@gmail.com | 1927463018 |