@SignUp @ui
Feature: Sign Up
	In order to have personal Account in NewBookModels
	As a client of NewBookModels
	I want to be registered in NewBookModels

@positive
Scenario Outline: It is possible to Sign Up in NewBookModels with valid data
	Given Sign Up page is opened
	When I input 'David' in first name field on Sign Up page
	And I input 'Jonson' in last name field on Sign Up page
	And I input new client email in email field on Sign Up page
	And I input current client password in password field on Sign Up page
	And I input current client password in password confirm field on Sign Up page
	And I input '2255884466' in phone field on Sign Up page
	And I click Next button on Sign Up page 
	Then New client is successfully registrated in NewBookModels