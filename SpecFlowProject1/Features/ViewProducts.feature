﻿Feature: ViewProducts
	As a user, I would like to be able to view the details of the products offered by SwagLabs
	And be able to sort the products according to different sorting options

@mytag
Scenario: Susie checks information of displayed product
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@mytag
Scenario: Susie sorts product display by Name A to Z
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@mytag
Scenario: Susie sorts product display by Name Z to A
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@mytag
Scenario: Susie sorts product display by Price Low to High
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@mytag
Scenario: Susie sorts product display by Price High to Low
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120