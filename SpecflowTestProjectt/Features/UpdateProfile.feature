@update @ui
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
  Then Successfully changed General Information on update profile page
Examples:
  | name | last_name | industry | company_location          |
  | Lili | Bom       | fashion  | Gatlinburg, TN 37738, USA |