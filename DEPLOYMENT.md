Deployment Tutorial – AquaTrack

This explains the process of deploying the AquaTrack application to Azure App Service.
Step 1. Create the Azure Resource Group There will be A resource group organizes all Azure resources related to the application. Now using the Azure Portal,
Go to the Azure Portal at https://portal.azure.com , then select Create a resource then, choose Resource Group
Name it:AquaTrack-RG , then choose the region closest to you. Go to Review then to Create and Create.
Step 2. Create the Azure App Service the App Service wil host the AquaTrack application. In the Azure Portal, click Create a resource, then search for Web App and select it.
Now configure the following:
Setting	Value
Name	aquatrack-appservice
Publish	Code
Runtime Stack	.NET 8 (LTS)
Operating System	Windows or Linux
Region	Same as resource group
Resource Group	AquaTrack-RG then,click Review, Create, and hit Create

Step 3. Provision the Azure SQL Database
Create database for AquaTrack for the Fish, Tank, and Feeding tables.
From the Azure Portal, click Create a resource
Choose SQL Database
Set:
Database name: AquaTrackDB
Resource group: AquaTrack-RG
Create a SQL Server:
Server name: aquatrack-sqlserver
Authentication: SQL Auth
Region:
Choose the Basic tier
After creation, open the database → Connection strings
Copy the ADO.NET string (to be used later in App Settings)

Step 4. Configure Environment Variables / Secrets

Inside the App Service go to Configuration
Under Application Settings, add: ASPNETCORE_ENVIRONMENT = Production
Add the connection string: ConnectionStrings:AquariumContext = <your Azure SQL connection string>
Now, save and restart the App Service

Step 5. Publish AquaTrack Using Visual Studio
Open Visual Studio and click the AquaTrack project and then Publish
Now, choose Azure and Azure App Service
select: Resource group: AquaTrack-RG
App: aquatrack-appservice
Click Finish and publish
Visual Studio will build and launch
