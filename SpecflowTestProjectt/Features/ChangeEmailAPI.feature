@changeProfileData @api
Feature: ChangeEmailAPI

Scenario: User change his email
	Given User is authorizated
	When I send POST request client/change_email/ with new email
	Then User`s email changed