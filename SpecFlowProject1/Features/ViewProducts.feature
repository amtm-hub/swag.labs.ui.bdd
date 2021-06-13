@viewproducts
Feature: ViewProducts
	As a user, I would like to be able to view the details of the products offered by SwagLabs
	And be able to sort the products according to different sorting options

Scenario: Susie views information of products on grid
	Given Susie is on homepage
	When she views information of products on grid
	Then the grid displays item image, item name, item description and item price with Add to Cart option

Scenario: Susie clicks on a product on grid
	Given Susie is on homepage
	When she clicks on a product on grid
	Then the page displays item image, item name, item description and item price with Add to Cart option

Scenario: Susie views sort options for products
	Given Susie is on homepage
	When she clicks on Sort dropdown
	Then she will see the following options
		| options             |
		| Name (A to Z)       |
		| Name (Z to A)       |
		| Price (low to high) |
		| Price (high to low) |

@todo @ignore
Scenario: Susie sorts product display by Name A to Z
	Given Susie is on homepage
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@todo @ignore
Scenario: Susie sorts product display by Name Z to A
	Given Susie is on homepage
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@todo @ignore
Scenario: Susie sorts product display by Price Low to High
	Given Susie is on homepage
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@todo @ignore
Scenario: Susie sorts product display by Price High to Low
	Given Susie is on homepage
	And the second number is 70
	When the two numbers are added
	Then the result should be 120