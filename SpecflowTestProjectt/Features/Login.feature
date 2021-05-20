@login @ui
Feature: Login
	In order to login in NewBookModels
	As a client of NewBookModels
	I want to be logged in NewBookModels

Scenario Outline: It is possible to login in NewBookModels with valid data
	Given Client is created
	And Sign in page is opened
	When I login with data
	| email   | password   |
	| <email> | <password> |
	Then Successfully logged in NewBookModels as created client
Examples:
	| email  | password |
	| asdasd | asd      |
	| asdasd | asd      |
	| asd    | asd      |
	| 343324 | asd      |

@negative
Scenario Outline: It is impossible to login in NewBookModels with invalid data
	Given Sign in page is opened
	When I login with data
	| email   | password   |
	| <email> | <password> |
	Then Unsuccessfuly login in NewBookModels with invalid data
	And <invalidEmailmessage> invalid email message is displayed
	And <invalidPasswordMessage> invalid password message is displayed
Examples:
	| email    | password | invalidEmailmessage | invalidPasswordMessage |
	| asdasd   |          | Invalid Email       | Required               |
	|          | asd      | Required            |                        |
	| asd      | asd      | Invalid Email       |                        |
	| 343324@  | asd      | Invalid Email       |                        |
	| qwrw.com | asd      | Invalid Email       |                        |
	|          |          | Required            | Required               |