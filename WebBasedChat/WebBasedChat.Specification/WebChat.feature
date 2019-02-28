Feature: WebChat
	In order to set up communication
	As a wpf application user
	I want to chat with other user

@As-a-User-I-want-to-start-application-from-Screen-1
Scenario: Start application with Screen 1
	Given User run application
	When User see application window
	Then Should see Screen 1

@As-a-User-I-want-to-put-my-nickname-on-Screen-1
Scenario: Store nickname
	Given User run application
	When User see application window
	And User put a nickname 'demo-nick'
	Then Nickname 'demo-nick' should be stored in application

@As-a-User-I-want-to-click-proceed-button-on-Screen-1-so-that-I-can-see-Screen-2
Scenario: Proceed from Screen 1 to Screen 2
	Given User run application
	And User see application window
	And User put a nickname 'demo-nick'
	When User click "Proceed" button 
	Then Should see Screen 2

@As-a-User-I-want-to-see-existing-chat-rooms-on-Screen-2
Scenario: See chat rooms on Screen 2
	Given User run application
	And User click "Create new room" button
	And User see Screen 2
	Then Should see existing chat rooms on Screen 2

@As-a-User-I-want-to-click-"Create-new-room"-button-so-that-I-can-create-new-chat-room
Scenario: Create new room
	Given User run application
	And User see Screen 2
	When User click "Create new room" button
	Then Chat room is created

@As-a-User-I-want-to-click-"Create-new-room"-button-so-that-I-can-join-selected-chat-room-and-see-Screen-3
Scenario: Join new room
	Given User run application
	And User see Screen 2
	And User click "Create new room" button
	And User select chat room 1
	When User click "Join" button
	Then User join selected chat room 
	And User see Screen 3

@As-a-User-I-want-to-enter-some-message-and-press-"submit"-button-so-that-I-can-send-message-to-other-users-in-the-room
Scenario: Send message to roommate
	Given User run application
	And User put a nickname 'demo-nick'
	And User click "Proceed" button 
	And User click "Create new room" button
	And User select chat room 0
	And User click "Join" button
	And User 1 load rooms
	And User 2 join chat room 0
	And User 3 join chat room 0
	When User enter "some text" message
	And User click "Submit" button
	Then "some text" was send to user 2
	And "some text" was send to user 3

@As-a-User-I-want-to-see-last-30-previous-messages-in-current-room-with-authors-and-timestamp
Scenario: Get last 30 messages
	Given User run application
	And User select chat room 0
	And User put a nickname 'demo-nick'
	And User click "Proceed" button 
	And User click "Create new room" button
	And User click "Join" button
	And User 2 join chat room 0
	And User 3 join chat room 0
	And User 2 submit messages
	| message | 
	| Message 1 |
	| Message 2 |
	| Message 3 |
	| Message 4 |
	| Message 5 |
	| Message 6 |
	| Message 7 |
	| Message 8 |
	| Message 9 |
	| Message 10 |
	| Message 11 |
	| Message 12 |
	| Message 13 |
	| Message 14 |
	| Message 15 |
	And User enter "some text" message
	And User click "Submit" button
	And User 3 submit messages
	| message |
	| Message 1 |
	| Message 2 |
	| Message 3 |
	| Message 4 |
	| Message 5 |
	| Message 6 |
	| Message 7 |
	| Message 8 |
	| Message 9 |
	| Message 10 |
	| Message 11 |
	| Message 12 |
	| Message 13 |
	| Message 14 |
	| Message 15 |

	Then Following messages was send to user 1
	| message   | nick   | date   |
	| Message 2 | User2 | <date> |
	| Message 3 | User2 | <date> |
	| Message 4 | User2 | <date> |
	| Message 5 | User2 | <date> |
	| Message 6 | User2 | <date> |
	| Message 7 | User2 | <date> |
	| Message 8 | User2 | <date> |
	| Message 9 | User2 | <date> |
	| Message 10 | User2 | <date> |
	| Message 11 | User2 | <date> |
	| Message 12 | User2 | <date> |
	| Message 13 | User2 | <date> |
	| Message 14 | User2 | <date> |
	| Message 15 | User2 | <date> |
	| some text | demo-nick | <date> |
	| Message 1 | User3 | <date> |
	| Message 2 | User3 | <date> |
	| Message 3 | User3 | <date> |
	| Message 4 | User3 | <date> |
	| Message 5 | User3 | <date> |
	| Message 6 | User3 | <date> |
	| Message 7 | User3 | <date> |
	| Message 8 | User3 | <date> |
	| Message 9 | User3 | <date> |
	| Message 10 | User3 | <date> |
	| Message 11 | User3 | <date> |
	| Message 12 | User3 | <date> |
	| Message 13 | User3 | <date> |
	| Message 14 | User3 | <date> |
	| Message 15 | User3 | <date> |

@As-a-User-I-want-to-click-Back-button-so-that-I-can-return-to-the-Screen-2
Scenario: Go back to screen 2
	Given User run application
	And User see Screen 3
	When User click "Back" button
	Then Should see Screen 2