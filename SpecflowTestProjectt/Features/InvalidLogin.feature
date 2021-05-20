@login @ui
Feature: InvalidLogin
	In order to login in NewBookModels
	As a client of NewBookModels
	I want to see message if i enter invalid login

Scenario Outline: Invalid login message while login invalid
	Given Sign in page is opened
	When I enter <login> in LogIn field
	And I click Log in button 
	Then Invalid login message displayed
Examples:
	| login             |
	|                   |
	| dsadas@m@mail.com |
	| Слава Україні!    |
	| Героям слава!     |
	| @ .               |
	| my_mail.com       |