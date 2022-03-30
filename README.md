# adopse-2021
ergasia adopse earino 2022.
Working Name: BeepBoopEvaluation

# How to get started working on the project
Instructions for how to get started with the project for development purposes.
Use either the script or the dotnet cli command.
After doing that, run `dotnet run` and wait until the `info` messages appear on the command line

## With script
Run the `install-dependencies.sh` script by running the command `./install-dependencies` from a Git Bash terminal.
This will install dependencies as well as a few useful command-line tools.

## With dotnet command
The following will only install dependencies and not the command-line tools.
Run `dotnet restore` to make sure dependencies necessary to run the project are installed.

# Interacting with the web API
Instructions for how to explore and use the web API.

## Swagger
After starting the application in development mode using `dotnet run`,
you can visit [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)
to interact with the API explorer.

## JSON structure
<!--TODO: insert examples-->

# PostgreSQL
Instructions about working with postgres in the context of this application.

## Running locally
This can be done using [docker](https://docs.docker.com/get-started/).
The ideal for testing during the design phase is a temporary database that logs all statements.
The full command to do that is the following:
```
docker run --rm -p 5432:5432 -e POSTGRES_PASSWORD=Apasswd -e POSTGRES_USER=tester postgres:latest postgres -c log_statement=all
```
It will create a user named `tester` with password `Apasswd` as well as a database named `tester` same as the user's name.

## Connection information
In the file `appsettings.Development.json`, see `DefaultConnection` under `ConnectionStrings` for the information that the application will use to connect to postgres.

## Evironment variable `USE_POSTGRES`
In order to choose to use postgres instead of the in-memory database, run `export USE_POSTGRES="true"` before running `dotnet run` in a Git Bash terminal.
Alternatively, run `USE_POSTGRES="true" dotnet run` in a Git Bash terminal.
