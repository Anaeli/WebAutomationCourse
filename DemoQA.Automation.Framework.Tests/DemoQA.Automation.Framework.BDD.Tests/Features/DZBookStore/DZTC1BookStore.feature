Feature: DZTC1BookStore
	Adding books to the user collection and validate that the correct message is displayed if the user tries to add the same book again.

Scenario: Add a book to my collection
	Given I send a POST request to <https://demoqa.com/Account/v1/User> with body
		"""
		{
			"userName": "Dan",
			"password": "Control123!"
		}
		"""
	And I open the Address <https://demoqa.com/login>
	And I login with the following credentials
		| Field    | Value        |
		| UserName | Dan          |
		| Password | Control123!  |
	And I go to https://demoqa.com/books> url
	And I click on the link <Git Pocket Guide>
	When I click "Add To Your Collection" button
	Then I should see a dialog with following message
		| Field   | Value                          |
		| Message | Book added to your collection. |
		And I click on "OK" button in the dialog box
	Then I should see the following information in the "Book info" page
		| Field       | Value                                                          |
		| ISBN        | 9781449325862                                                  |
		| Title       | Learning JavaScript Design Patterns                            |
		| Sub Title   | A Working Introduction                                         |
		| Author      | Richard E. Silverman                                           |
		| Publisher   | O'Reilly Media                                                 |
		| Total pages | 234                                                            |
		| Website     | http://chimera.labs.oreilly.com/books/1230000000561/index.html |

Scenario: Add the same book twice
	When I click "Add To Your Collection" button
	Then I should see a Modal with following message
		| Field   | Value                                        |
		| Message | Book already present in the your collection! |
	And I click on "OK" button in the Modal dialog


Scenario: Validated added book is present in collection
	When I go to <https://demoqa.com/profile> url
	Then I should see the following information in the "Book Collection" grid
		| Column      | Value                               |
		| Title       | Learning JavaScript Design Patterns |
		| Author      | Addy Osmani                         |
		| Publisher   | O'Reilly Media                      |
		# Deleting the book added on this TC via API
	And I send a DELETE request to <https://demoqa.com/BookStore/v1/Book> with body
		"""
		{
			"isbn": "9781449325862",		
			"userId": "UserID"		
		}
		"""
 Scenario: Deleting the user created on this TC via UI
	Then I go to <https://demoqa.com/profile> url
	And I Click "Delete Account" button
	And I Click on the "Accept" Button inside the Alert Dialog