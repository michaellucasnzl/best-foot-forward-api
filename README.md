# Best Foot Forward - Api

This solution was initially generated using the [Clean.Architecture.Solution.Template](https://github.com/jasontaylordev/CleanArchitecture)


## Code Styles & Formatting

The template includes [EditorConfig](https://editorconfig.org/) support to help maintain consistent coding styles for multiple developers working on the same project across various editors and IDEs. The **.editorconfig** file defines the coding styles applicable to this solution.

## Code Scaffolding

The template includes support to scaffold new commands and queries.

Start in the `.\src\Application\` folder.

Create a new command:

```
dotnet new ca-usecase --name CreateShoe --feature-name Shoes --usecase-type command --return-type guid
```

Create a new query:

```
dotnet new ca-usecase -n GetShoes -fn Shoes -ut query -rt GetShoesResult
```

If you encounter the error *"No templates or subcommands found matching: 'ca-usecase'."*, install the template and try again:

```bash
dotnet new install Clean.Architecture.Solution.Template::8.0.0
```

## Test

The solution contains unit, integration, and functional tests.

To run the tests:
```bash
dotnet test
```

## Database Migrations
To add a new database migration run
```bash
dotnet ef migrations add "MigrationName" --project src/Infrastructure --startup-project src/Web --output-dir Data\Migrations
```

## Running the API
You first need to have Docker installed on your machine. You can install Docker Desktop on any OS that it supports.
Then to run the API you just need to run the Docker Composer orchestration from the root directory:
```bash
docker-compose up
```

Now you should be able to access the API at http://localhost:5432


You can run the API without installing PostgreSQL by first running a container for Postgres. Then ensure the container connection string settings are in the appsettings.json.
1. Pull the postgres image: docker pull postgres
2. Run the image in the background: docker run --name postgres-container -e POSTGRES_PASSWORD=mysecretpassword -p 5432:5432 -d postgres
3. Run the API: dotnet run

## Next
Run the API in Docker and view the Swagger
~~~~


## Help
To learn more about the solution template go to the [project website](https://github.com/JasonTaylorDev/BestFootForwardApi). Here you can find additional guidance, request new features, report a bug, and discuss the template with other users.

