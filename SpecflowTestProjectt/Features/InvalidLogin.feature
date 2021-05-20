@login @ui
Feature: InvalidLogin
	In order to login in NewBookModels
	As a client of NewBookModels
	I want to be logged in NewBookModels

Scenario Outline:  Impossibility to login in NewBookModels with invalid data
	Given Client is created
	And Sign in page is opened
	When I login with data
	| email   | password   |
	| <email> | <password> |
	Then  An error message <message> is displayed in Login Page
Examples:
	| email             | password   | message                                   | 
	| testrun@gmail.com | 123456789  | Please enter a correct email and password | 
	| testrun@gmailcom  | 123qweQWE! | Invalid email                             | 
	| testrungmail.com  | 123qweQWE! | Invalid email                             | 
	|                   |            | Required                                  | 
	| testrun@gmail.com |            | Required                                  | 
	|                   | 123qweQWE! | Required                                  | 
	| t                 | q          | Invalid email                             | 