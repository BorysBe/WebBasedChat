Feature: WebChat
	In order to set up communication
	As a wpf application user
	I want to chat with other user

@mytag
Scenario: Start application with Screen 1
	Given User run application
	When User see application window
	Then Should see Screen 1

@mytag
Scenario: Store nickname
	Given User run application
	When User see application window
	And User put a nickname 'demo-nick'
	Then Nickname 'demo-nick' should be stored

@mytag
Scenario: Proceed from Screen 1 to Screen 2
	Given User run application
	And User see application window
	When User click proceed button 
	Then Should see Screen 2

@mytag
Scenario: See chat rooms on Screen 2
	Given User run application
	And At least one chat room exists
	And User see Screen 2
	Then Should see existing chat rooms on Screen 2

@mytag
Scenario: Create new room
	Given User run application
	And User see Screen 2
	And At least one chat room exists
	When User click "Create new room" button
	Then Chat room is created

@mytag
Scenario: Join new room
	Given User run application
	And User see Screen 2
	And At least one chat room exists
	And User select chat room 1
	When User click "Join" button
	Then User join selected chat room 
	And User see Screen 3
