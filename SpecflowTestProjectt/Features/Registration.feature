@registration @ui
Feature: Registration
	In order to have personal account in NewBookModels
	As a client of NewBookModels
	I want to sign up in NewBookModels

Scenario:  It is possible to sign up in NewBookModels with valid data
	Given Sign up page is opened
	When I register with data
	| first_name | last_name | email                | password  | confirm_password | mobile     |
	| Chris      | Evans     | chrisevans@gmail.com | chris26A! | chris26A!        | 1234567890 |
	Then  Successfully registration in NewBookModels as new client