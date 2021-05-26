@registration
@ui
Feature: Registration
In order to register in NewBookModels
As a client of NewBookModels
I want to sign up to NewBookModels

@mytag
Scenario: It is possible to sign up to NewBookModels with valid data
	Given Sign up page is opened
	When I write this information on the first page
	| first_name | last_name | email      | password   | confirm_password | mobile     |
	| Den        | DenDen    | uniqueMail | QWEqwe123# | QWEqwe123#       | 4444444444 |
	And I write this information on the second page
	| company_name | company_url | Address | Industry    |
	| nice         | nice.com    | texas   | advertising |
	Then Next page is opened

