Feature: MC-BookStore
	Deleting a user via UI.

@MC-TC4
Scenario: Delete user account via UI
	Given I send a POST request to <https://demoqa.com/Account/v1/User> with body
		"""
		{
			"userName": "BigFoot4",
			"password": "Contr01-885*"
		}
		"""
		And I navigate to <https://demoqa.com/login> url
		And I login with the following credentials
			| Field    | Value        |
			| UserName | BigFoot4     |
			| Password | Contr01-885* |
		And I navigate to https://demoqa.com/books> url
	When I click on "Delete Account" button
	Then I should see a dialog with following message
		| Field   | Value                               |
		| Message | Do you want to delete your account? |
	Then I click on "OK" button in the dialog box
    Then I should see a dialog with following message
		| Field   | Value         |
		| Message | User Deleted. |
		And I click on "OK" button in the dialog box

Scenario: Login with credentials of a deleted account
	Given I navigate to <https://demoqa.com/login> url
	When I login with the following credentials
		| Field    | Value        |
		| UserName | BigFoot4     |
		| Password | Contr01-885* |
	Then I should see the following message
		| Field   | Value                         |
		| Message | Invalid username or password! |
		And I click on "OK" button in the dialog box
