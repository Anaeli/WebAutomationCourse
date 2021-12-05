Feature: JCATestCase3
 
Scenario: Search for a book
    Given I log in to Book Store application
        And I have more than 7 books added to my Profile
    When I type-in a book title
    Then the grid should display a matching book title
    
Scenario: Delete user account
    Given I log in to Book Store application
        And I open Profile screen
    When I click Delete Account button
    Then the login screen should be displayed