@login @ui
Feature: Login
	In order to login in NewBookModels
	As a client of NewBookModels
	I want to be logged in NewBookModels

@pozitive
Scenario: It is possible to login in NewBookModels with valid data
	Given Client is created
	And Sign in page is opened
	When I input email of created client in email field
	And I input password of created client in password field
	And I click Log in button
	Then Successfully logged in NewBookModels as created client

@pozitive
Scenario: It is possible to login in NewBookModels with valid data in table
	Given Client is created
	And Sign in page is opened
	When I login with data
	| email                | password                |
	| current client email | default client password |
	Then Successfully logged in NewBookModels as created client

@negative
Scenario Outline: The client cannot enter the page in NewBookModels with negative data
	Given Sign in page is opened
	When I login with infalid data
	| email   | password   |
	| <email> | <password> |
	Then Unsuccessfuly login in NewBookModels with invalid data
	And <messageEmail> invalid email message is displayed
	And <messagePassword> invalid password message is displayed
Examples:
	| email           | password | messageEmail  | messagePassword |
	| will            | qwe12    | Invalid Email |                 |
	| will @          | qwe12    | Invalid Email |                 |
	| will.com.ua     | qwe12    | Invalid Email |                 |
	| will            |          | Invalid Email | Required        |
	|                 |          | Required      | Required        |
	|                 | qwe12    | Required      |                 |
	| will@sdf.com.ua |          |               | Required        |