# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY EcoBuildAI.csproj . 
RUN dotnet restore

# Copy all files and publish
COPY . .
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "EcoBuildAI.dll"]
