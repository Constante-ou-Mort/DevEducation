Feature: Profile
	In order to update my profile information in NewBookModels
	As a client of NewBookModels
	I want to change my profile data in NewBookModels

@positive
Scenario Outline: Is it possible to change profile company info in NewBookModels Account
	Given Client is created with added company information
	When I send PATCH request company client/profile/ with <company_description> , <company_name> and <company_url>
	Then Client profile company info was successfully changed on <company_information> in NewBookModels Account
Examples:
	| company_description         | company_name         | company_url         | company_information                                |
	| Decription                  | current company name | current company url | Decription; John Smith's company; http://smithJ.com       |
	| current company description | Company              | current company url | Fashion company; Company; http://smithJ.com               |
	| current company description | current company name | http://company.com         | Fashion company; John Smith's company; http://company.com |
	| Decription                  | Company              | http://company.com         | Decription; Company; http://company.com                   |