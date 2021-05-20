@registration @ui
Feature: Registration
	In order to Registration on NewBookModels
	As a client
	I want to create own account

@mytag
Scenario Outline: Registration client with valid data
	Given SignUp page is open
	When I filled the <first_name> in first name
	And I filled the <last_name> in last name
	And I filled the <email> in email
	And I filled the <password> in password
	And I confirm <password>
	And I filled the <number> in number
	And I click Next button
	Then I created an account
Examples:
	| first_name | last_name | password | email     | number     |
	| Elprimo    | Brawler   | 123Qwe!  | uniqEmail | 1927463018 |