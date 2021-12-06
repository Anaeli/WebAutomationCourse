Feature: DZTC3BookStore
	Adding Seven books to the user collection and I search one of them.

Scenario: Add Seven books to the user collection and I search one of them
	Given I send a POST request to <https://demoqa.com/Account/v1/User> with body
		"""
		{
			"userName": "Dan",
			"password": "Control123!"
		}
		"""
	And I send a POST request to <https://demoqa.com/BookStore/v1/Books> with body
			"""
			{
				"userId": "UserID",
				"IsbnBookCollection": 
				[
					{"isbn": "9781449325862"},
					{"isbn": "9781449331818"},
					{"isbn": "9781449337711"},
					{"isbn": "9781449365035"},					{
					{"isbn": "9781491904244"},
					{"isbn": "9781593275846"},
					{"isbn": "9781593277574"}
				]
			}
			"""
	And I go to <https://demoqa.com/login> url
	And I login with the following credentials
			| Field    | Value       |
			| UserName | Dan         |
			| Password | Control123! |
	And I go to https://demoqa.com/profile> url
		And I populate the the search box in the "Book Collection" table with the following information
			| Field      | Value |
			| Search Box | git   |
	Then I should see the following info in the "Book Collection" table
		| Column      | Value                |
		| Title       | Git Pocket Guide     |
		| Author      | Richard E. Silverman |
		| Publisher   | O'Reilly Media       |
Scenario: Deleting the user created on this TC via UI
	Then I go to <https://demoqa.com/profile> url
	And I click "Delete Account" button
	And I Click on the "Accept" Button inside the Alert Dialog