Feature: MC-BookStore
	Adding a bunch of books to my collection and changing the rows view value.

@MC-TC2
Scenario: Add books to my collection to validate rows number view
	Given I send a POST request to <https://demoqa.com/Account/v1/User> with body
		"""
		{
			"userName": "BigFoot",
			"password": "Contr01-885*"
		}
		"""
		And I send a POST request to <https://demoqa.com/BookStore/v1/Books> with body
			"""
			{
				"userId": "BigFoot",
				"collectionOfIsbns": 
				[
					{
						"isbn": "9781449331818"
					},
					{
						"isbn": "9781449325862"
					},
					{
						"isbn": "9781449337711"
					},
					{
						"isbn": "9781449365035"
					},
					{
						"isbn": "9781491904244"
					},
					{
						"isbn": "9781491950296"
					},
					{
						"isbn": "9781593275846"
					}
				]
			}
			"""
		And I navigate to <https://demoqa.com/login> url
		And I login with the following credentials
			| Field    | Value        |
			| UserName | BigFoot      |
			| Password | Contr01-885* |
		And I navigate to https://demoqa.com/profile> url
	Then I should see the following number of rows displayed in the "Book Collection" table
		| Field | Value |
		| Rows  | 5     |
	Then I should see the following number of rows displayed with content in the "Book Collection" table
		| Field | Value |
		| Rows  | 5     |
		And I click on the "Rows" dropdown and select the following number
			| Option | Value |
			| Rows   | 10    |
	Then I should see the following number of rows displayed in the "Book Collection" table
		| Field | Value |
		| Rows  | 10    |
	Then I should see the following number of rows displayed with content in the "Book Collection" table
		| Field | Value |
		| Rows  | 7     |
		# Deleting the user created on this TC via UI
		And I navigate to <https://demoqa.com/profile> url
		And I click "Delete Account" button




