For Week 14, I implemented structured logging in AquaTrack.
I created a new FeedingController that records feeding events for fish. Within this controller, I injected ILogger<FeedingController> and added structured logs that capture key context fields including fishId, foodType, fedAt, and requestId.
A success log is created whenever a feeding event is saved. I updated the FishController to log whenever a user views the details page for any fish. 
I also added a new view Views/Feeding/Create.cshtml allowing users to record feeding events.
