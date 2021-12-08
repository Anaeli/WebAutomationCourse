Feature: ProfileDeleteAccount
	Delete my Account 

@mytag
Scenario: Delete my Account
	Given I click on the 'Profile'
	And I click on 'Delete Account'
	And I see 'Do you want to delete your account?'
	When I click on 'Ok'
	And I click on the 'Aceptar' message
	Then I go to Login page