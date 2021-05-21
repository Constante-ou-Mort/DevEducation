@registration @ui
Feature: Registration
	In order to acces to my presonal account in NewBookModels
	As a customer
	I want to be able register in NewBookModels

Scenario Outline: It is possible to register in NewBookModels with valid data
	Given Sign up page is opened
	When I register with data
	| firstName   | lastName   | email   | password   | confirmPassword | mobile   |
	| <firstName> | <lastName> | <email> | <password> | <password>      | <mobile> |
	Then Succesfully registration in NewBookModels
Examples:
	| firstName | lastName | email                       | password      | confirmPassword | mobile     |
	| John      | Tribiani | gsdgsge2352362346@gmail.com | 1Qwerty(46109 | 1Qwerty(46109   | 1231231212 |