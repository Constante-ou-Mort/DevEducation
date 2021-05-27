@update @ui @generalInformation
Feature: UpdateProfile
  In order to set new information about myself in NewBookModels
  As a client of NewBookModels
  I want update my profile in NewBookModels

@Positive 
Scenario Outline: Update GeneralInfo with valid data
	Given Client is created
	And Update Profile page is opened
	When I update profile with data on UpdateProfile page
	| name   | last_name   | industry   | company_location   |
	| <name> | <last_name> | <industry> | <company_location> |
	Then Successfully changed name to <new_name>, industry to <industry>, company location to <company_location> on update profile page
Examples:
	| name    | last_name | industry | company_location                          | new_name       |
	| Lili    | Bom       | fashion  | Gatlinburg, TN 37738, USA                 | Lili Bom       |
	| Marina  | Top       | agsjbdj  | Parkway Bypass, Tennessee 37738, USA      | Marina Top     |
	| ADFG    | ADFG      | jdbh1234 | Ukrainian Village, Chicago, IL 60622, USA | ADFG ADFG      |