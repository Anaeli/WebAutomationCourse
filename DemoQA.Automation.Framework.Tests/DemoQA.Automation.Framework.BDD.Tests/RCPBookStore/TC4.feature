Feature: TC4
 
Scenario: Delete user account
    Given I login into Book Store application
    And I open Profile screen
    And I click on Delete Account button
    When I login using "RCPTEST" account
    Then message Invalid User should be displayed