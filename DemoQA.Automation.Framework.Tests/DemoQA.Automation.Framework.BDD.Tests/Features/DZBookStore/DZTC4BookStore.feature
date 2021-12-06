Feature: DZTC4BookStore
	Deleting a user account.

Scenario: Delete user account
	Given I send a POST request to <https://demoqa.com/Account/v1/User> with body
		"""
		{
			"userName": "Dan",
			"password": "Control123!"
		}
		"""
	And I go to <https://demoqa.com/login> url
	And I login with the following credentials
		| Field    | Value       |
		| UserName | Dan         |
		| Password | Control123! |
	And I navigate to https://demoqa.com/books> url
	When I click on the "Delete Account" button
	Then I should see a dialog with following message "Do you want to delete your account?"
	Then I click on "OK" button in the dialog
    And I should see an alet dialog with following message "User Deleted"
	And I click on "OK" button in the dialog box

Scenario: Login invalid credentials
	Given I navigate to <https://demoqa.com/login> url
	When I login with the following credentials
		| Field    | Value       |
		| UserName | Dan         |
		| Password | Control123! |
	Then I should see the following message "Invalid username or password!"