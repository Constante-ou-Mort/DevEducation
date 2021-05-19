@login
@ui
Feature: Login
In order to login in NewBookModels
As a client of NewBookModels
I want to be logged in NewBookModels

    Scenario Outline: It is impossible to login in NewBookModels with invalid data
        Given Client is created
        And Sign in page is opened
        When I login with data
          | email   | password   |
          | <email> | <password> |
        Then Error message showed

        Examples:
          | email          | password |
          | test@gmail.com |          |
          | asdasd         | asd      |
          | asd            | asd      |
          | 343324         | asd      |