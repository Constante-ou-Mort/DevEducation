@SignUp @ui
Feature: Sign Up
	In order to have personal Account in NewBookModels
	As a client of NewBookModels
	I want to be registered in NewBookModels

@positive
Scenario: It is possible to Sign Up in NewBookModels with valid data
	Given Sign Up page is opened
	When I input 'David' in first name field on Sign Up page
	And I input 'Jonson' in last name field on Sign Up page
	And I input new client email in email field on Sign Up page
	And I input current client password in password field on Sign Up page
	And I input current client password in password confirm field on Sign Up page
	And I input '2255884466' in phone field on Sign Up page
	And I click Next button on Sign Up page
	Then New client is successfully registrated in NewBookModels

@negative
Scenario Outline: Client sees error messages when tries to Sign Up in NewBookModels with invalid data
	Given Sign Up page is opened
	When I input '<first_name>' in first name field on Sign Up page
	And I input '<last_name>' in last name field on Sign Up page
	And I input <email> in email field on Sign Up page
	And I input <password> in password field on Sign Up page
	And I input <password_confirm> in password confirm field on Sign Up page
	And I input '<phone>' in phone field on Sign Up page
	And I click Next button on Sign Up page
	Then New client sees error message - <message> near field with invalid data
Examples:
	| first_name | last_name | email          | password | password_confirm | phone            | message                 |
	|            | Jonson    | ktgh@gmail.com | !QA2wsxc | !QA2wsxc         | new client phone | Required                |
	| David      |           | ktgh@gmail.com | !QA2wsxc | !QA2wsxc         | new client phone | Required                |
	| David      | Jonson    | ktgh@gmail     | !QA2wsxc | !QA2wsxc         | new client phone | Invalid Email           |
	| David      | Jonson    | ktgh@gmail.com | 12       | 12               | new client phone | Invalid password format |
	| David      | Jonson    | ktgh@gmail.com | !QA2wsxc | 2wsxc            | new client phone | Passwords must match    |
	| David      | Jonson    | ktgh@gmail.com | !QA2wsxc | !QA2wsxc         | 552235           | Invalid phone format    |