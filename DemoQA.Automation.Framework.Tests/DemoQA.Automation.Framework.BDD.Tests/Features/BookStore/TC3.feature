Feature: TC3
	

@mytag
Scenario: Create user by API
	Given user "Ruddy" and password "Control123*"
    When i resquest a POST https://demoqa.com/Account/v1/User
	Then a 201 response. 

Scenario: Search for a book
    Given user "Ruddy" and password "Control123*"
	And I log in to Book Store application 
    And I have more than 7 books in my collection
    When I type-in a book title
    Then the grid should display a matching book title
    
Scenario: Delete user account
    Given user "Ruddy" and password "Control123*"
	And I log in to Book Store application 
    And i go to profile page
    When I click Delete Account button
    And i confirm the message.
    Then the login screen should be display.
    And user "Ruddy" and password "Control123*" cant log in