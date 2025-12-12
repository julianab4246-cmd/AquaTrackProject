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
Resource Group	AquaTrack-RG
Then,click Review, Create, and hit Create

Step 3. Provision the Azure SQL Database

AquaTrack requires a database for the Fish, Tank, and Feeding tables.

From the Azure Portal, click Create a resource

Choose SQL Database

Set:

Database name: AquaTrackDB

Resource group: AquaTrack-RG

Create a SQL Server:

Server name: aquatrack-sqlserver

Authentication: SQL Auth (username + password)

Region: same as App Service

Choose the Basic tier

After creation, open the database → Connection strings

Copy the ADO.NET string (to be used later in App Settings)

4. Configure Environment Variables / Secrets

Inside your App Service:

Go to Configuration

Under Application Settings, add:

ASPNETCORE_ENVIRONMENT = Production


Add the connection string:

ConnectionStrings:AquariumContext = <your Azure SQL connection string>


Save and restart the App Service

5. Publish AquaTrack Using Visual Studio

Open Visual Studio

Right-click the AquaTrack project → Publish

Choose Azure → Azure App Service

Sign in and select:

Resource group: AquaTrack-RG

App: aquatrack-appservice

Click Finish

Click Publish

Visual Studio will build the project, package it, upload it, and launch the site.

6. Publish Using Azure CLI (Alternative)

If publishing manually:

az webapp up \
  --name aquatrack-appservice \
  --resource-group AquaTrack-RG \
  --runtime "DOTNETCORE:8.0"


This sends the compiled AquaTrack app directly to Azure.
