# Use the .NET 9 SDK image for building, .NET 10 is a few months away still
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /scr

# Copy csproj and restore dependencies (better layer caching)
COPY *.csproj ./
RUN dotnet restore

# Copy source code and build
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Use the ASP.NET Core runtime image for running
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy the published app
COPY --from=build /app/publish .

# Expose port 80
EXPOSE 80

# Set the entry point
ENTRYPOINT ["dotnet", "SportsGeneratorApi.dll"]