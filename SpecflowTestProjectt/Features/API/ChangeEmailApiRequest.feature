@ChangeEmail @Api
Feature: ChangeEmailApiRequest

@Positive @Post
Scenario Outline: Update client email using Api request POST updating/updating-profile
	Given Change email to <email> using Api request POST updating/updating-profile
	| email   |
	| <email> |
	Then <status_code> status code is recieved from the Api request
	| status_code |
	| OK     |
	And message <message> is recieved from the Api request
Examples:
	| email     | message |
	| uniqEmail | Created |

	#узнать за уникальный мейл