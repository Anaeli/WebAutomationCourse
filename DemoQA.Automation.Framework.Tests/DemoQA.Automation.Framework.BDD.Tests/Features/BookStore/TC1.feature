Feature: TC1
	Validate a book  can be added only once.

@mytag
Scenario: Create user by API
	Given user "Ruddy" and password "Control123*"
    When i resquest a POST https://demoqa.com/Account/v1/User
	Then a 201 response. 

Scenario: Add a Book to collection
	Given user "Ruddy" and password "Control123*"
	And I log in to Book Store application    
	Then i add 1 book to my collection 
	And validate all alerts.

Scenario: Validate Book information
	Given user "Ruddy" and password "Control123*"
	And I log in to Book Store application    
	And i have book data 
	    | Field       | Value                                                          |
	    | ISBN        | 9781449325862                                                  |
	    | Title       | Git Pocket Guide                                               |
	    | Sub Title   | A Working Introduction                                         |
	    | Author      | Richard E. Silverman                                           |
	    | Publisher   | O'Reilly Media                                                 |
	    | Total Pages | 234                                                            |
	    | Website     | http://chimera.labs.oreilly.com/books/1230000000561/index.html |
	When i search for the book "Git Pocket Guide "
	Then i validate the data.

Scenario: Add same book
	Given user "Ruddy" and password "Control123*"
	And I log in to Book Store application    
	When i add "Git Pocket Guide" to my collection 
	And i add "Git Pocket Guide" to my collection again.
	Then i validate all alerts.  Book cant be added

Scenario: Delete Book by API
	Given user "Ruddy" and password "Control123*"
	And I log in to Book Store application.
	And i add "Git Pocket Guide" book to my collection.
	And i authenticate in swagger the POST https://demoqa.com/BookStore/v1/Book
	When i make a request to https://demoqa.com/BookStore/v1/Book with 
	"""
    {
    userId = "userID",
    isbn = "9781449325862"
    };
    """
	Then "Git Pocket Guide" is deleted from user collection.