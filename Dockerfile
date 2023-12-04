FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Restoring packages can be done from just csproj
COPY BestFootForwardApi.sln ./
COPY ./src/Application/Application.csproj ./src/Application/Application.csproj
COPY ./src/Domain/Domain.csproj ./src/Domain/Domain.csproj
COPY ./src/Infrastructure/Infrastructure.csproj ./src/Infrastructure/Infrastructure.csproj
COPY ./src/Web/Web.csproj ./src/Web/Web.csproj
COPY ./tests/Application.FunctionalTests/Application.FunctionalTests.csproj ./tests/Application.FunctionalTests/Application.FunctionalTests.csproj
COPY ./tests/Application.UnitTests/Application.UnitTests.csproj ./tests/Application.UnitTests/Application.UnitTests.csproj
COPY ./tests/Domain.UnitTests/Domain.UnitTests.csproj ./tests/Domain.UnitTests/Domain.UnitTests.csproj
COPY ./tests/Infrastructure.IntegrationTests/Infrastructure.IntegrationTests.csproj ./tests/Infrastructure.IntegrationTests/Infrastructure.IntegrationTests.csproj
COPY Directory.Build.props ./

RUN dotnet restore ./BestFootForwardApi.sln

# Copy everything else to build/publish
COPY . ./
RUN dotnet publish -c Release -o out --no-restore

# Build runtime image containing build/publish output
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet","BestFoodForwardApi.dll"]
