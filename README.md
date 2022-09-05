# BookKeeping app.

### To run the web app.
```
cd BookKeeping.Web
npm install
npm run dev
```

### To run the api
At first we need to seed the database.

#### To seed database for the api
* Open the .sln file with visual studio
* Open the nuget package manager console from Tools > NuGet Package Manager > Package Manager Console
* On the console change the Default Project to BookKeeping.Domain
* Run the migration commands.
```
Enable-Migrations
Add-Migration InitialMigration
Update-Database -Verbose
```