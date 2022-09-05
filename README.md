# BookKeeping app.
## Goals
1. ~~Based on choosing year all the data populated in the grid.~~
2. ~~Predefined types for Income/Expense load in the grid (If saved then with value)~~
3. ~~User will be able to update Month wise Income/Expense in the Reconciliation portion only~~
4. ~~After changing the value in the grid, lower part value will be updated (Reconciliation Result, Final Result and Cumulative Result)~~
5. ~~In all cases Income (+) and Expense (-)~~
6. ~~Save Bookkeeping information in DB for further reference. This is the final output of the test~~
7. ~~For time limit Year/Month wise predefined Income/Expense data can be stored in DB.~~

## Steps

### At first clone the repo 
```
git clone https://github.com/minhaz1217/bookkeeping-app-vue.git

cd bookkeeping-app-vue
```

### To run the web app.
```
cd BookKeeping.Web
npm install
npm run dev
```

### To run the api
At first we need to seed the database.

#### To seed database for the api
* Open the .sln file with Visual Studio
* Open the nuget package manager console from Tools > NuGet Package Manager > Package Manager Console
* On the console change the Default Project to BookKeeping.Domain
* Run the migration commands.
```
Enable-Migrations
Add-Migration InitialMigration
Update-Database -Verbose
```

## Image
![Basic UI](https://raw.githubusercontent.com/minhaz1217/bookkeeping-app-vue/master/images/01_screenshot.png)