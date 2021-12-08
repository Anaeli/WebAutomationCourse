Feature: TestCase1
	
Scenario: Verify book addition confirmation dialogs
    Given I log in to Book Store application
        And I go to Book Store screen
        And I click Git Pocket Guide link
    When I click Add To Your Collection button
    Then a confirmation dialog should be accepted
        And a confirmation alert should be accepted
        And the book Git Pocket Guide should be added to user's Profile

Scenario: Verify book information
    Given I have the following book data
        # Commenting out so Pickle reports doesn't fail
        #| ISBN        | 9781449325862                                              |
        #| Title       | Git Pocket Guide                                           |
        #| Sub Title   | A Working Introduction                                     |
        #| Author      | Richard E. Silverman                                       |
        #| Publisher   | O'Reilly Media                                             |
        #| Total Pages | 234                                                        |
        #| Website : http://chimera.labs.oreilly.com/books/1230000000561/index.html |
        And I log in to BookStore Application
        And I click Profile button
    When I click Git Pocket Guide title link
    Then I should see matching data in book details page

Scenario: Do not allow to add duplicate books 
    Given I log in to Book Store application
        And I have Git Pocket Guide on my collection
        And I'm on Book Store screen
        And I open Git Pocket Guide details page
    When I click Add To Your Collection button
    Then alert Book already present in the your collection! should be displayed
    
Scenario: Delete book through API
    Given user "fsivila" is authenticated for the session
        And I have Git Pocket Guide on my collection
    When a DELETE request is made to https://demoqa.com/BookStore/v1/Book with
       # Commenting out so Pickle Reports doesn't fail
       #   """
       #   {
       #       userId = "string",
       #       isbn = "9781449325862"
       #   };
       #   """
    Then Git Pocket Guide should be removed from User's profile