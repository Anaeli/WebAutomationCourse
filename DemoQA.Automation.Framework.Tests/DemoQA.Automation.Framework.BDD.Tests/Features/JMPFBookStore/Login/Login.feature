Feature: Login
	Login page to insert UserName and Password of a user

@mytag
Scenario: Login is possible
	Given I insert my username is Jess
	And I insert my password is Control123!
	When I press on the Login button
	Then I go to the Profile Page

@mytag
Scenario: Login is not possible1  
    Given I insert my username is Jess
	And I do not insert my password 
	When I press on the Login button
	Then The password should show me in red

@mytag
Scenario: Login is not possible2
	Given I do not insert my username 
	And I insert my password is Control123!
	When I press on the Login button
	Then The username should show me in red

@mytag
Scenario: Login is not possible3
	Given I do not insert my username
	And I do not insert my password 
	When I press on the Login button
	Then The username and password should show me in red