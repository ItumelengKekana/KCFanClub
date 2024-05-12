## Overview of Stack
- Server
  - ASP.NET Core
  - MySql
  - Entity Framework Core w/ EF Migrations
- Client
  - React 18
  - Vite
  - CSS Modules
  - Fetch API for REST requests

## Setup

1. Install the following:
   - [.NET Core](https://www.microsoft.com/net/core)
   - [Node.js >= v20](https://nodejs.org/en/download/)
   
2. Run `npm install && npm start`
3. Configure the database connection string in appsettings.json
4. Open browser and navigate to [https://localhost:5173](https://localhost:5173).

## Scripts

### `npm install`

When first cloning the repo or adding new dependencies, run this command.  This will:

- Install Node dependencies from package.json
- Install .NET Core dependencies from api/api.csproj and api.test/api.test.csproj (using dotnet restore)
