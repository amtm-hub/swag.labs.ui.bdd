Feature: Login
	As a user, I would like to be able to ensure that I can log into SwagLabs only when I provide the correct credentials

@mytag
Scenario: Susie logs in with blank username and password
	Given Susie is on login screen for "SwagLabs"
	When she logs in with blank username and password
	Then the email error message "Epic sadface: Username is required" will be displayed

@mytag
Scenario: Susie logs in with blank password
	Given Susie is on login screen for "SwagLabs"
	When she logs in with blank password
		| values         |
		| standard1_user |
	Then the email error message "Epic sadface: Password is required" will be displayed

@mytag
Scenario: Susie logs in with incorrect username
	Given Susie is on login screen for "SwagLabs"
	When she logs in with
		| values         |
		| standard1_user |
		| secret_sauce   |
	Then the email error message "Epic sadface: Username and password do not match any user in this service" will be displayed

@mytag
Scenario: Susie logs in with incorrect password
	Given Susie is on login screen for "SwagLabs"
	When she logs in with
		| values        |
		| standard_user |
		| secretx_sauce |
	Then the password error message "Epic sadface: Username and password do not match any user in this service" will be displayed

@mytag
Scenario: Susie logs in successfully
	Given Susie is on login screen for "SwagLabs"
	When she logs in with
		| values        |
		| standard_user |
		| secret_sauce  |
	Then the homepage is displayed