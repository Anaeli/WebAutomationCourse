Feature: TC2
	

@mytag
Scenario: Create user by API
	Given user "Ruddy" and password "Control123*"
    When i resquest a POST https://demoqa.com/Account/v1/User
	Then a 201 response. 

Scenario: Add 7 or more Book to collection by API
	Given user "Ruddy" and password "Control123*"
	And i authenticate in swagger the POST https://demoqa.com/BookStore/v1/Books
	When i make a request to https://demoqa.com/BookStore/v1/Books with  
    
    """
    {
  "userId": "string",
  "collectionOfIsbns": [
    {
      "isbn": "Book1"
    }
    {
      "isbn": "Book2"
    }
    .
    .
    .
    .

    {
      "isbn": "Book7"
    }
                       ]
     } 
    """

	Then 7 books are on my collection
	

Scenario: Change rows per page on books grid
    Given user "Ruddy" and password "Control123*"
	And I log in to Book Store application  
    When I increase the Rows per Page value to 10
    Then up to 10 books should be visible on the grid

Scenario: Delete user account
    Given user "Ruddy" and password "Control123*"
	And I log in to Book Store application 
    And i go to profile page
    When I click Delete Account button
    And i confirm the message.
    Then the login screen should be display.
    And user "Ruddy" and password "Control123*" cant log in