Feature: Practice Form
	Fill a form to practice specflow + selenium +  XUnit 

@mytag
Scenario: Fill practice form
	Given I go to "automation-practice-form" page
	And I fill the fields on Practice Form:
		| Field       | Value           |
		| Name        | Eliana          |
		| LastName    | Navia           |
		| Email       | eliana@test.com |
		| Gender      | Female          |
		| Mobile      | 1234567890      |
		| Hobbies     | Music           |
		| DateOfBirth | 08 Aug 2021     |
		| Picture     | mando.jpeg      |
	When I click Submit button
	# Then table with submitted data should be displayed
	Then I should see the submitted data in the table
	    | Field       | Value           |
		| Name        | Eliana          |
		| LastName    | Navia           |
		| Email       | eliana@test.com |
		| Gender      | Female          |
		| Mobile      | 1234567890      |
		| Hobbies     | Music           |
		| DateOfBirth | 08 August,2021  |
		| Picture     | mando.jpeg      |