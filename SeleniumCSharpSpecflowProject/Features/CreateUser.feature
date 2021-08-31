Feature: CreateUser
	Application to create a new user

@Scenario1
 Scenario: Launch application and Create user and validate the user is create successfully
	Given Launch the application
	When Create a new user
	Then Verify new user is displayed correctly

	@Scenario2
 Scenario: Login to the application with the newly created user and validate login successful
	Given Launch the application
	When Provide login details and click Login
	Then Validate the login successful message displayed in UI