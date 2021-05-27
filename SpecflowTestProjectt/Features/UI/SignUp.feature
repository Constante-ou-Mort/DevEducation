@registration @ui
Feature: SignUp
	In order to have personal account in NewBookModels
	As a client of NewBookModels
	I want registration page in NewBookModels

	#не нашла метод для трансформации, поэтому в фф креды описаны так
@positive
Scenario Outline: It is possible to signup in NewBookModels with valid data
	Given Sign up page is opened
	When I registrate with data
	| email     | password   | confirm_password | name   | last_name   | phone_number   |
	| uniqEmail | <password> | <password>       | <name> | <last_name> | <phone_number> |
	Then Successfully registrated in NewBookModels as new client
Examples:
	| password   | name  | last_name | phone_number |
	| Aa12345^   | Lilit | Bool      | 1234567890   |
	| Aa!@#456   | Mary  | Mary      | 1000000000   |
	| QWEqwe123$ | Liza  | Liza      | 0987654321   |