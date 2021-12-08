Feature: ProfileDeleteBook
	Delete books on the table

@mytag
Scenario: Delete book on the table
	Given I click on the 'Profile'
	And I click one book from table
	And I click on the 'Delete' icon
	And I see 'Do you want to delete this book?'
	When I click on 'Ok'
	And I click on the 'Aceptar' message
	Then I dont see my book on the table

	@mytag
Scenario: Delete books on the table using 'Delete All Books'
	Given I click on the 'Profile'
	And I click on 'Delete All Books'
	And I click on the 'Delete' icon
	And I see 'Do you want to delete this book?'
	When I click on 'Ok'
	And I click on the 'Aceptar' message
	Then I dont see my books on the table