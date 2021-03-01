# my-expenses-simple



 to run the following technologies must be installed in your machine:
 + Node.js
 + .NET Core 3.1
 + Visual Studio 2019
 + SQL Server

to run project
1. open web-api/MyExpenses.sln in Visual Studio (I'm using VS 2019 when developing this)
2. Run Nuget Restore in Web.Api project
3. Publish the App project to SQL Server
4. if the post script containing the initial sample data didn't execute when Publish was ran,
  execute it manually.
5. replace the connection string found in Web.Api/appSettings.Development.json with the database connection string that you are using
6. set Web.Api as startup project
7. Build the Solution
8. take note of the url
9. open web-ui folder in VisualStudio code or command prompt
10. run "npm install"
11. under src/package.json add a new property "proxy: [URL_FOR_Web.API]"
12. run "npm start"

NOTE: the project is based on the react and net core 3.1 template I created and updated throughout my years of software development :) 
