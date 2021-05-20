@registration @ui
Feature: SignUp
	In order to have personal account in NewBookModels
	As a client of NewBookModels
	I want registration page in NewBookModels

@Positive
Scenario Outline: It is possible to signup in NewBookModels with valid data
	Given Sign  up page is opened
	When I registrate with data
	| email   | password   | confirm_password | name   | last_name   | phone_number   |
	| <email> | <password> | <password>       | <name> | <last_name> | <phone_number> |
	Then Successfully registrated in NewBookModels as new client
Examples:
	| email         | password | name  | last_name | phone_number |
	| aaa@gmail.com | Aa12345^ | Lilit | Bool      | 1234567890   |