Feature: DZTC2BookStore
	Adding Seven books to the user collection and changing the number of rows.

@DZ TC2
Scenario: Add Seven books to the user collection
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
		And I navigate to <https://demoqa.com/login> url
		And I login with the following credentials
			| Field    | Value       |
			| UserName | Dan         |
			| Password | Control123! |
		And I go to https://demoqa.com/profile> url
	Then I should see the following number of rows displayed in the "Book Collection" grid
		| Field | Value |
		| Rows  | 5     |
	Then I should see the following number of rows displayed with content in the "Book Collection" grid
		| Field | Value |
		| Rows  | 5     |
	And I click on the "Rows" dropdown and select the following number
		| Option | Value |
		| Rows   | 10    |
	Then I should see the following number of rows displayed in the "Book Collection" grid
		| Field | Value |
		| Rows  | 10    |
	Then I should see the following number of rows displayed with content in the "Book Collection" grid
		| Field | Value |
		| Rows  | 7     |
Scenario: Deleting the user created on this TC via UI
	And I go to <https://demoqa.com/profile> url
	And I click "Delete Account" button
	And I Click on the "Accept" Button inside the Alert Dialog