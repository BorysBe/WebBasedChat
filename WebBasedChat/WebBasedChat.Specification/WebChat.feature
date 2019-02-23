Feature: WebChat
	In order to set up communication
	As a wpf application user
	I want to chat with other user

@mytag
Scenario: Start application with Screen 1
	Given User run application
	When User see first screen
	Then Should see Screen 1

@mytag
Scenario: Store nickname
	Given User run application
	When User see first screen
	And User put a nickname 'demo-nick'
	Then Nickname 'demo-nick' should be stored
