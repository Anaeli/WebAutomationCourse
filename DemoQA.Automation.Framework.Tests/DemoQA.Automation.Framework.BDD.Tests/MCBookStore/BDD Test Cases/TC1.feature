Feature: MC-BookStore
	Adding a book to my collection with correct info and validate that the same book cannot be added twice.

@MC-TC1
Scenario: Add a book to my collection
	Given I send a POST request to <https://demoqa.com/Account/v1/User> with body
		"""
		{
			"userName": "BigFoot",
			"password": "Contr01-885*"
		}
		"""
		And I navigate to <https://demoqa.com/login> url
		And I login with the following credentials
		| Field    | Value        |
		| UserName | BigFoot      |
		| Password | Contr01-885* |
		And I navigate to https://demoqa.com/books> url
		And I click on the link <Learning JavaScript Design Patterns>
	When I click "Add To Your Collection" button
	Then I should see a dialog with following message
		| Field   | Value                          |
		| Message | Book added to your collection. |
		And I click on "OK" button in the dialog box
	Then I should see the following information in the "Book info" page
		| Field       | Value                                                               |
		| ISBN        | 9781449331818                                                       |
		| Title       | Learning JavaScript Design Patterns                                 |
		| Sub Title   | A JavaScript and jQuery Developer's Guide                           |
		| Author      | Addy Osmani                                                         |
		| Publisher   | O'Reilly Media                                                      |
		| Total pages | 254                                                                 |
		| Website     | http://www.addyosmani.com/resources/essentialjsdesignpatterns/book/ |

Scenario: Add same book twice
	When I click "Add To Your Collection" button
	Then I should see a dialog with following message
		| Field   | Value                                        |
		| Message | Book already present in the your collection! |
		And I click on "OK" button in the dialog box


Scenario: Validated added book is present in collection
	When I navigate to <https://demoqa.com/profile> url
	Then I should see the following info in the "Book Collection" table
		| Column      | Value                               |
		| Title       | Learning JavaScript Design Patterns |
		| Author      | Addy Osmani                         |
		| Publisher   | O'Reilly Media                      |
		# Deleting the book added on this TC via API
		And I send a DELETE request to <https://demoqa.com/BookStore/v1/Book> with body
		"""
		{
			"isbn": "9781449331818",		
			"userId": "BigFoot"		
		}
		"""
		# Deleting the user created on this TC via UI
		And I navigate to <https://demoqa.com/profile> url
		And I click "Delete Account" button

