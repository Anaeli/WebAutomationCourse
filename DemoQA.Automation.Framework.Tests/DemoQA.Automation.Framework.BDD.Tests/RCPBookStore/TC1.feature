Feature: TC1
	First TC of the work
 
Scenario: Add 3 books and delete ONE of them
    Given I log in to Book Store application
    And I open the 'Book Store'
    And I add 3 books to my collection
    When I click the Delete book icon button on a book row
    And I click OK on the confirmation pop-ups
    Then the selected book should be removed from User's profile
      
Scenario: Add 3 books and delete ALL of them
    Given I log in Book Store application
    And I open Book Store screen
    And I add 3 books to my collection
    When I click Delete All Books button
    And I click OK on the confirmation pop-ups
    Then all books should be removed from user's profile
    And message No rows found should be displayed
      
Scenario: Delete user account
    Given I log in to Book Store application
    And I open Profile page
    When I click Delete Account button
    And I click OK on confrmation pop-ups
    Then the login screen should be display