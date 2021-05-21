@editUserInformation @ui
Feature: EditUserInformation
	In order to actualize my credentials in NewBookModels
	As a client of NewBookModels
	I want to be able edit information in my account page in NewBookModels

Scenario: It is possible change email to valid email in account page in NewBookModels
	Given Client is created
	And Client is authorized
	And Account settings page is opened
	When I open edit email adress block
	And I input '<password>' in Current Password field
	And I input '<newEmail>' in New E-mail Address field
	And I save changes in edit email adress block
	Then Primary Account Holder Name is changed to '<usedUniqueEmail>'
Examples:
	| password                | newEmail    | usedUniqueEmail |
	| default client password | uniqueEmail | usedUniqueEmail |