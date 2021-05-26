@AccountSettings @api
Feature: AccountSettings
	In order to update my account data in NewBookModels
	As a client of NewBookModels
	I want to change my account in NewBookModels

@positive
Scenario: It is possible to change client email with valid data in NewBookModels Account
	Given Client is created
	When I send POST request client/change_email/ with new client email
	Then Client email was successfully changed in NewBookModels Account

@positive
Scenario: It is possible to change client phone number with valid data in NewBookModels Account
	Given Client is created
	When I send POST request client/change_phone/ with new phone '7531592580'
	Then Client phone number successfully changed in NewBookModels Account

@positive
Scenario: It is possible to change client password with valid data in NewBookModels Account
	Given Client is created
	When I send POST request v1/password/change/ with new password 1qa@WSXC
	Then Client password was successfully changed in NewBookModels Account

@positive
Scenario Outline: It is possible to change client self information in NewBookModels Account
	Given Client is created
	When I send PATCH request client/self/ with <first_name> and <last_name>
	Then Client self information was successfully changed on <self_information> in NewBookModels Account
Examples:
	| first_name                | last_name                | self_information |
	| Garet                     | Hopkins                  | Garet Hopkins    |
	| current client first name | Hopkins                  | John Hopkins     |
	| Garet                     | current client last name | Garet Smith      |

@positive
Scenario Outline: It is possible to change client profile information in NewBookModels Account
	Given Client is created with added profile information
	When I send PATCH request client/profile/ with <industry> , <location_name> and <location_timezone>
	Then Client profile information was successfully changed on <ptofile_information> in NewBookModels Account
Examples:
	| industry                | location_name                | location_timezone                | ptofile_information                          |
	| Fashion                 | current client location name | current client location timezone | Fashion; New York, NY, USA; America/New_York |
	| current client industry | Nevada, USA                  | America/Los_Angeles              | Cosmetics; Nevada, USA; America/Los_Angeles  |
	| Fashion                 | Nevada, USA                  | America/Los_Angeles              | Fashion; Nevada, USA; America/Los_Angeles    |