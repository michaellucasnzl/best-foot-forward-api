FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Restoring packages can be done from just csproj
COPY BestFootForwardApi.sln .
COPY Directory.Build.props ./
COPY ./src ./src
COPY ./tests ./tests
RUN dotnet restore ./BestFootForwardApi.sln

# Copy everything else to build/publish
COPY . ./
RUN dotnet publish -c Release -o out --no-restore

# Build runtime image containing build/publish output
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/out .
COPY appsettings*.json .
RUN mkdir logs
ENTRYPOINT ["dotnet","BestFoodForwardApi.dll"]
