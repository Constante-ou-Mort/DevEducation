@login @ui
Feature: InvalidLogin
	In order to login in NewBookModels
	As a client of NewBookModels
	I want to be logged in NewBookModels

Scenario Outline: NewBookModels cannot be logged in with invalid data
	Given Sign in page is opened
	When I enter <email> in Login field
	And I input password of created client in password field
	And I click log in button
	Then Not registered in NewBookModels as a created client
Examples:
	| email             | 
	| asdasd@@gmail.com | 
	| asdasdgmail.com   | 
	|                   | 

