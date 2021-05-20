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
	