Feature: JCATestCase2
 
Scenario: Change rows per page on books grid
    Given I log in to Book Store application
        And I have more than 7 books added to my Profile
    When I increase the Rows per Page value to 10
    Then up to 10 books should be visible on the grid

Scenario: Delete user account
    Given I log in to Book Store application
        And I open Profile screen
    When I click Delete Account button
        And I click OK on confrmation pop-ups
    Then the login screen should be display