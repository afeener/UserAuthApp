##  API Endpoints

- POST /api/Auth/login

##  Build and Run

```bash
# Navigate to root
cd path/to/UserAuthApp

# Restore dependencies
dotnet restore

# Build solution
dotnet build

# Run the API
dotnet run --project UserAuthApp.API

# Run unit tests
dotnet test UserAuthApp.Tests