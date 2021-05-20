@updatingProfile @ui
Feature: SignUp
	In order to set new information about myself in NewBookModels
	As a client of NewBookModels
	I want update my profile in NewBookModels

@Positive
Scenario Outline: Update GeneralInfo with valid data
	Given Client is authorized
	And Update Profile page is opened
	When I update profile with data
	| name   | last_name   | industry   | company_location   |
	| <name> | <last_name> | <industry> | <company_location> |
	Then Successfully registrated in NewBookModels as new client
Examples:
	| name  | last_name | industry   | company_location   |
	| Lilit | Bool      | <industry> | <company_location> |