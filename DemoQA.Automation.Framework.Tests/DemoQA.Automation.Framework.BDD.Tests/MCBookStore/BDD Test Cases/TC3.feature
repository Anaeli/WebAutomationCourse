Feature: MC-BookStore
	Search a book in my book collection.

@MC-TC3
Scenario: Search for a book in my collection table
	Given I send a POST request to <https://demoqa.com/Account/v1/User> with body
		"""
		{
			"userName": "BigFoot3",
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
			| UserName | BigFoot3     |
			| Password | Contr01-885* |
		And I navigate to https://demoqa.com/profile> url
		And I type the following criteria in the search box in the "Book Collection" table
			| Field      | Value |
			| Search Box | git   |
	Then I should see the following info in the "Book Collection" table
		| Column      | Value                |
		| Title       | Git Pocket Guide     |
		| Author      | Richard E. Silverman |
		| Publisher   | O'Reilly Media       |
		# Deleting the user created on this TC via UI
		And I navigate to <https://demoqa.com/profile> url
		And I click "Delete Account" button




