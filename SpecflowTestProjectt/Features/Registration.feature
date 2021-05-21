@registration @ui
Feature: Registration
	In order to Registration on NewBookModels
	As a client
	I want to create own account

Scenario: Registration client with valid data
	Given SignUp page is open
	When I fill the Elprimo in first name
	And I fill the Brawler in last name
	And I fill the uniqEmail in email
	And I fill the 123Qwe2q_! in password
	And I confirm 123Qwe2q_!
	And I fill the 1927463018 in number
	And I click Next button
	Then Account is created

Scenario Outline: Registration client with invalid data
	Given SignUp page is open
	When I fill the <first_name> in first name
	And I fill the <last_name> in last name
	And I fill the <uniqEmail> in email
	And I fill the <password> in password
	And I confirm <confirm_password>
	And I fill the <number> in number
	And I click Next button
	Then Account is not created
Examples:
	| first_name | last_name | uniqEmail | password   | confirm_password | number     |
	| Valeri     | Zmyh      | uniqEmail | 12345Qwer! | 12345Qwer!       |            |
	| Valeri     | Zmyh      | uniqEmail | 12345Qwer! |                  | 1234567898 |
	| Valeri     | Zmyh      | uniqEmail |            | 12345Qwer!       | 1234567898 |
	| Valeri     | Zmyh      |           | 12345Qwer! | 12345Qwer!       | 1234567898 |
	| Valeri     |           | uniqEmail | 12345Qwer! | 12345Qwer!       | 1234567898 |
	|            | Zmyh      | uniqEmail | 12345Qwer! | 12345Qwer!       | 1234567898 |
	| Valeri     | Zmyh      | uniqEmail | 12345Qwer  | 12345Qwer        | 1234567898 |
	| Valeri     | Zmyh      | uniqEmail | 12345wer!  | 12345wer!        | 1234567898 |
	| Valeri     | Zmyh      | uniqEmail | 12345wer   | 12345wer         | 1234567898 |
	| Valeri     | Zmyh      | uniqEmail | 12345Qwer! | 12345            | 1234567898 |