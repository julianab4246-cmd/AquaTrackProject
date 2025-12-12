For Week 14, I implemented structured logging in AquaTrack.
I created a new FeedingController that records feeding events for fish. Within this controller, I injected ILogger<FeedingController> and added structured logs that capture key context fields including fishId, foodType, fedAt, and requestId.
A success log is created whenever a feeding event is saved. I updated the FishController to log whenever a user views the details page for any fish. 
I also added a new view Views/Feeding/Create.cshtml allowing users to record feeding events.

For Week 15, I implemented a feature that retrieves and displays the Top 5 Oldest Fish using a SQL stored procedure.
I created a new DTO OldestFishResult and mapped it within AquariumContext
I created a new Razor view TopOldest.cshtml that keeps the results in a table

Week 16 – Deployment to Azure (Simulated)
My Azure credits were exhausted, so I created the simulation. https://github.com/julianab4246-cmd/AquaTrackProject/blob/master/DEPLOYMENT.md 
Even though I was unable to perform an actual deployment, I completed every step of the deployment except executing the final publish. The project includes all required files to support production deployment.
I removed the secrets of appsettings.Production.json
I made the code Deployment-ready

Summary of the Deployment Process
I would: 
Create AquaTrack-RG to hold all Azure resources
Create aquatrack-appservice using the .NET 8 runtime.
Provision AquaTrackDB to support EF Core and AquaTrack’s models.
Store the SQL connection string securely in App Service Configuration.
Publish the project using:
Visual Studio
Restart the App Service and verify the application loads successfully.
Test /healthz, Fish CRUD pages, and feeding logs in production.
