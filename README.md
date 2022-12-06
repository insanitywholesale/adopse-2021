# adopse-2021
ergasia adopse earino 2022.  
Working Name: BeepBoopEvaluation  

Pending rename to **BeepBoopQuiz**

# Deployment
There are two docker images for this project, one for the backend and one for the fronted and they're deployed to a Linode VPS.

## Warning
The database has over a million entries so some endpoints are practically unusable

## Frontend
The frontend is hosted at https://adopsefront.inherently.xyz/  
The logged-in homepage is available at https://adopsefront.inherently.xyz/#/homepage  

## Backend
The backend is hosted at https://adopseback.inherently.xyz/  
The list of all evaluations is available at https://adopseback.inherently.xyz/api/evaluation  
The list of all questions is available at https://adopseback.inherently.xyz/api/q  
And the built-in swagger documentation is available at https://adopseback.inherently.xyz/swagger/index.html  

# How to get started working on the project
Instructions for how to get started with the project for development purposes.
Use either the script or the dotnet cli command.
After doing that, run `dotnet run` and wait until the `info` messages appear on the command line.
The API server will be running at `http://localhost:5000`.

## With script
Run the `install-dependencies.sh` script by running the command `./install-dependencies` from a Git Bash terminal.
This will install dependencies as well as a few useful command-line tools.

## With dotnet command
The following will only install dependencies and not the command-line tools.
Run `dotnet restore` to make sure dependencies necessary to run the project are installed.

# How to run backend
Below there are instructions for running the backend in development and in production

## Development
A simple `dotnet run` will start the backend and use the in-memory database.

## Production
Running in production mode is a bit involved but you can do it both locally and remotely.

### Locally
This is a little more complicated.
First, run postgres.
Docker is an easy way to do it so here is a sample command:
```
docker run --rm -p 5432:5432 -e POSTGRES_PASSWORD=Apasswd -e POSTGRES_USER=tester postgres:latest postgres -c log_statement=all
```
Then run the migrations in `migrations.sh` to set up the database:
```
./migrations.sh
```
Finally start the application in production mode:
```
dotnet run --launch-profile "adopse_2021-Production"
```

### On VPS
Shortened `docker-compose.yml` that runs in production:
```yaml
version: "3.7"

services:

   adopsefront:
     container_name: adopsefront
     image: inherently/adopse-frontend:0.0.1
     restart: unless-stopped

   adopseback:
     container_name: adopseback
     image: inherently/adopse-backend:0.0.1
     restart: unless-stopped
     security_opt:
       - no-new-privileges:true
     environment:
       - "ASPNETCORE_URLS=http://*:5000"
       - "ASPNETCORE_ENVIRONMENT=Production"

   adopsedb:
     container_name: adopsedb
     image: postgres:latest
     restart: unless-stopped
     security_opt:
       - no-new-privileges:true
     environment:
       - POSTGRES_USER=tester
       - POSTGRES_PASSWORD=Apasswd
     volumes:
       - /home/user/docker/adopse:/var/lib/postgresql/data
```

# Interacting with the web API
Instructions for how to explore and use the web API.

## Swagger
After starting the application in development mode using `dotnet run`,
you can visit [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)
to interact with the API explorer.

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
