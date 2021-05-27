@login @ui
Feature: Login
	In order to login in NewBookModels
	As a client of NewBookModels
	I want to be logged in NewBookModels

	#не нашла метод для трансформации, поэтому в фф креды описаны так
@positive
Scenario Outline: It is possible to login in NewBookModels with valid data
	Given Client is created
	And Sign in page is opened
	When I login with email <email> and password <password>
	Then Successfully logged in NewBookModels as created client
Examples:
	| email     | password     |
	| userEmail | userPassword |

@Negative
Scenario Outline: It is impossible to login in NewBookModels with invalid data
	Given Client is created
	And Sign in page is opened
	When I login with invalid email <email> and password <password>
	Then exception message Invalid Email is displayed on sign in page
Examples:
	| email              | password |
	| asdasd             | asd      |
	| /                  | фывапрл  |
	| .                  | фпрвирв  |
	| adsghsf@@gmail.com | 1        |