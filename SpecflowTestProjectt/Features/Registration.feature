@registration
@ui
Feature: Registration
In order to register in NewBookModels
As a client of NewBookModels
I want to sign up to NewBookModels

    @mytag
    Scenario: It is possible to sign up to NewBookModels with valid data
        Given Sign up page is opened
        When I sign up with data
          | first_name   | last_name   | email         | password   | confirm_password | mobile     |
          | <first_name> | <last_name> | 'UniqueEmail' | QWEqwe123@ | QWEqwe123@       | 5555555555 |
        Then Next page is opened