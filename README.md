# WebBasedChat

![Server and its clients (WCF)](http://matrix-reliability.eu/projects/images/ClientServer.JPG?raw=true)

Preferred technologies:
Client/Server WebApi application where server is self hosted WCF service (prefered) (or ASP.NET MVC (could be .NET Core)). Client should be WPF application. 
You can use any DB or in-memory storage.

Screen 1: 
Login form with input for nickname and "proceed" button. No authorization logic is required.

Screen 2: 
List of all existing chat rooms
Every room should have "Join button". Click on this button should open screen 3.
At the bottom of the screen "Create new room" button that should create new room.

Screen 3: 
Chat room with text messages from the users in the room. Input for a new message and submit button should be at the bottom of the screen.
Every message should have text, author and sent timestamp.
Back button should navigate to the Screen 2

Use cases:
* As a User I want to start application from Screen 1
* As a User I want to put my nickname on Screen 1
* As a User I want to click proceed button on Screen 1 so that I can see Screen 2
* As a User I want to see existing chat rooms on Screen 2
* As a User I want to click "Create new room" button so that I can create new chat room 
* As a User I want to click "Create new room" button so that I can join selected chat room and see Screen 3
* As a User I want to enter some message and press "submit" button so that I can send message to other users in the room
* As a User I want to see last 30 previous messages in current room with authors and timestamp
* As a User I want to click Back button so that I can return to the Screen 2

![Tests results](http://matrix-reliability.eu/projects/images/specification.JPG?raw=true)
![Specflow](http://matrix-reliability.eu/projects/images/specflow.JPG?raw=true)
