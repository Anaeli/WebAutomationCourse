Feature: JCATestCase4
 
Scenario: Delete user account
    Given I log in to Book Store application
        And I open Profile screen
        And I click Delete Account button
    When I login using "jcruz" account
    Then message Invalid User should be displayed