# DataCat [![Build Status](https://travis-ci.org/NerdCats/DataCat.svg?branch=master)](https://travis-ci.org/NerdCats/DataCat)
Simple Mongodb Reports and Analytics.

### Dependencies
.net core SDK > 1.1.0, built on Visual Studio 2017 

### To build
Clone the repo in your favourite terminal.
- execute `dotnet restore` 
- change working directory to `src/DataCat`
- modify `appsettings.json` with proper connection string
- execute `dotnet run`

### Docker
 - have your docker installed installed first
 - execute `docker pull nerdcats/datacat`
 - modify `appsettings.json` with proper connection string
 - execute `docker run -v /appsettings.json:/<your apsettings.json to use> -p 5000:5000 -d --name datacat nerdcats/datacat`
 - try `localhost:5000/api/data`
