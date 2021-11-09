Feature: HelloWorld
	Simple calculator for adding two numbers

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Add two numbers failed test case
	Given the first number is 60
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario Outline: Add numbers
	Given the first number is <Num1>
	And the second number is <Num2>
	When the two numbers are added
	Then the result should be <Result>
	
	Examples: 
	| Num1 | Num2 | Result |
	| 50   | 70   | 120    |
	| 70   | 70   | 140    |
	| 90   | 10   | 100    |