Feature: ProfileAddBook
	Profile page shows the Book table

@mytag
Scenario: Add book on the table
	Given I click on the 'Go to Book Store'
	And I click one book
	And I click on the 'Add To your Collection'
	And I click on the Acept
	When I click on the Profile 
	Then I see my book on the table

	@mytag
Scenario: Add 3 books on the table
	Given I click on the 'Go to Book Store'
	And I click one book
	And I click on the 'Add To your Collection'
	And I click on the Acept
	And I click 2 book
	And I click on the 'Add To your Collection'
	And I click on the Acept
	And I click 3 book
	And I click on the 'Add To your Collection'
	And I click on the Acept
	When I click on the Profile 
	Then I see my books on the table

		@mytag
Scenario: Add 1 book on the table using Search
	Given I click on the 'Go to Book Store'
	And I click on 'Type to Search'
	And I insert any word
	And I click one book
	And I click on the 'Add To your Collection'
	And I click on the Acept
	When I click on the Profile 
	Then I see my book on the table