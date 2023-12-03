FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Restoring packages can be done from just csproj
COPY BestFootForwardApi.sln ./
COPY ./src/Application/Application.csproj ./app/src/Application
COPY ./src/Domain/Domain.csproj ./app/src/Domain
COPY ./src/Infrastructure/Infrastructure.csproj ./app/src/Infrastructure
COPY ./src/Web/Web.csproj ./app/src/Web
COPY ./tests/Application.FunctionalTests/Application.FunctionalTests.csproj ./app/tests/Application.FunctionalTests
COPY ./tests/Application.UnitTests/Application.UnitTests.csproj ./app/tests/Application.UnitTests
COPY ./tests/Domain.UnitTests/Domain.UnitTests.csproj ./app/tests/Domain.UnitTests
COPY ./tests/Infrastructure.IntegrationTests/Infrastructure.IntegrationTests.csproj ./app/tests/Infrastructure.IntegrationTests

RUN dotnet restore ./BestFootForwardApi.sln

# Copy everything else to build/publish
COPY . ./
RUN dotnet publish -c Release -o out --no-restore

# Build runtime image containing build/publish output
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet","BestFoodForwardApi.dll"]
