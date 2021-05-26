@changeProfileData @api
Feature: ChangeNumberAPI
	
Scenario:  User change his phone number
	Given User is authorizated
	When I send POST request client/change_phone/ with new phone '1111122222'
	Then User`s number changed