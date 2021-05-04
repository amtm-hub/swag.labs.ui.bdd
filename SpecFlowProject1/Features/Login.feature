Feature: Login
	As a user, I would like to be able to ensure that I can log into Facebook only when I provide the correct credentials

@mytag
Scenario: Susie logs in with blank username and password
	Given Susie is on login screen
	When she logs in with blank username and password
	Then the email error message "The email address or mobile number you entered isn't connected to an account. Find your account and log in." will be displayed

@mytag
Scenario: Susie logs in with incorrect username
	Given Susie is on login screen
	When she logs in with
		| values             |
		| amtm.hub_gmail.com |
		| hub123             |
	Then the email error message "The email address or mobile number you entered isn't connected to an account. Find your account and log in." will be displayed

@mytag
Scenario: Susie logs in with incorrect password
	Given Susie is on login screen
	When she logs in with
		| values             |
		| amtm.hub@gmail.com |
		| hub123x            |
	Then the password error message "The password that you've entered is incorrect. Forgotten password?" will be displayed

@mytag
Scenario: Susie logs in successfully
	Given Susie is on login screen
	When she logs in with
		| values             |
		| amtm.hub@gmail.com |
		| qwertyuiop159      |
	Then the homepage is displayed