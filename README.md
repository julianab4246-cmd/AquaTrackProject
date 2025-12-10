For Week 14, I implemented structured logging in AquaTrack.
I created a new FeedingController that records feeding events for fish. Within this controller, I injected ILogger<FeedingController> and added structured logs that capture key context fields including fishId, foodType, fedAt, and requestId.
A success log is created whenever a feeding event is saved. I updated the FishController to log whenever a user views the details page for any fish. 
I also added a new view Views/Feeding/Create.cshtml allowing users to record feeding events.

For Week 15, I implemented a feature that retrieves and displays the Top 5 Oldest Fish using a SQL stored procedure.
I created a new DTO OldestFishResult and mapped it within AquariumContext
I created a new Razor view TopOldest.cshtml that keeps the results in a table
