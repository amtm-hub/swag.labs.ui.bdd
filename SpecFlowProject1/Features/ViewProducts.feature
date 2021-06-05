@viewproducts
Feature: ViewProducts
	As a user, I would like to be able to view the details of the products offered by SwagLabs
	And be able to sort the products according to different sorting options

Scenario: Susie views information of products on grid
	Given Susie is on homepage
	When she views information of products on grid
	Then item name, item description and item price are displayed with Add to Cart option

@todo
Scenario: Susie clicks on a product on grid
	Given Susie is on homepage
	When she clicks on a product on grid
	Then the following details are displayed
		| details            |
		| item name          |
		| item description   |
		| item price         |
		| add to cart button |

@todo
Scenario: Susie sorts product display by Name A to Z
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@todo
Scenario: Susie sorts product display by Name Z to A
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@todo
Scenario: Susie sorts product display by Price Low to High
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@todo
Scenario: Susie sorts product display by Price High to Low
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120