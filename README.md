# adopse-2021
ergasia adopse earino 2022.
Working Name: BeepBoopEvaluation

# Deployment
There are two docker images for this project, one for the backend and one for the fronted and they're deployed to a Linode VPS

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

## Development
A simple `dotnet run` will start the backend and use the in-memory database

## Production

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
Might need to change `PostgreSQLConnection` connection string in `appsettings.json`

# Interacting with the web API
Instructions for how to explore and use the web API.

## Swagger
After starting the application in development mode using `dotnet run`,
you can visit [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)
to interact with the API explorer.

## JSON structure
Order of methods follows the Swagger docs mentioned above for consistency

### Open Questions
Open questions CRUD

#### Read All Open Questions
method: `GET`
endpoint: `/api/openquestion`

receive:
```json
[
  {
    "answer": {
      "contentFromEvaluee": "hello world",
      "id": 1,
      "isCorrectAnswer": true,
      "grade": 0
    },
    "id": 1,
    "heading": "say hello world",
    "grade": 1,
    "isGraded": true
  },
  {
    "answer": {
      "contentFromEvaluee": "hello world!",
      "id": 2,
      "isCorrectAnswer": false,
      "grade": 0
    },
    "id": 2,
    "heading": "say hello world without an exclamation point",
    "grade": 1.5,
    "isGraded": true
  }
]
```

#### Create Open Question
method: `POST`
endpoint: `/api/openquestion`

send:
```json
{
  "heading": "say hello world",
  "grade": 1,
  "isGraded": true,
  "answer": {
    "isCorrectAnswer": true,
    "contentFromEvaluee": "hello world"
  }
}
```

receive:
```json
{
  "answer": {
    "contentFromEvaluee": "hello world",
    "id": 1,
    "isCorrectAnswer": true,
    "grade": 0
  },
  "id": 1,
  "heading": "say hello world",
  "grade": 1,
  "isGraded": true
}
```

#### Read One Open Question
method: `GET`
endpoint: `/api/openquestion/1`

receive:
```json
{
  "answer": {
    "contentFromEvaluee": "hello world",
    "id": 1,
    "isCorrectAnswer": true,
    "grade": 0
  },
  "id": 1,
  "heading": "say hello world",
  "grade": 1,
  "isGraded": true
}
```

#### Update Open Question

#### Delete Open Question
method: `DELETE`
endpoint: `/api/openquestion/1`


### Multiple-Choice Questions
Multiple-choice questions CRUD

#### Read All Multiple-Choice Questions
method: `GET`
endpoint: `/api/multiplechoicequestion`

```json
[
  {
    "hasCorrectAnswer": true,
    "answers": [
      {
        "content": "never gonna let you down",
        "selectedByEvaluee": false,
        "id": 1,
        "isCorrectAnswer": true,
        "grade": 3
      },
      {
        "content": "never run around and desert you",
        "selectedByEvaluee": true,
        "id": 2,
        "isCorrectAnswer": false,
        "grade": -0.5
      },
      {
        "content": "never gonna make you cry",
        "selectedByEvaluee": false,
        "id": 3,
        "isCorrectAnswer": false,
        "grade": -1
      },
      {
        "content": "never gonna say goodbye",
        "selectedByEvaluee": false,
        "id": 4,
        "isCorrectAnswer": false,
        "grade": -1.5
      },
      {
        "content": "never gonna tell a lie and hurt you",
        "selectedByEvaluee": false,
        "id": 5,
        "isCorrectAnswer": false,
        "grade": -2
      }
    ],
    "id": 1,
    "heading": "never gonna give you up",
    "grade": 3,
    "isGraded": true
  },
  {
    "hasCorrectAnswer": true,
    "answers": [
      {
        "content": "bat",
        "selectedByEvaluee": false,
        "id": 6,
        "isCorrectAnswer": false,
        "grade": -0.5
      },
      {
        "content": "dolphin",
        "selectedByEvaluee": true,
        "id": 7,
        "isCorrectAnswer": true,
        "grade": 1
      },
      {
        "content": "Narwhal",
        "selectedByEvaluee": false,
        "id": 8,
        "isCorrectAnswer": false,
        "grade": -0.2
      }
    ],
    "id": 2,
    "heading": "from the following select the one most resembling a whale",
    "grade": 1,
    "isGraded": false
  }
]
```

#### Create Multiple-Choice Question
method: `POST`
endpoint: `/api/multiplechoicequestion`

send:
```json
{
  "heading": "never gonna give you up",
  "grade": 3,
  "isGraded": true,
  "hasCorrectAnswer": true,
  "answers": [
    {
      "isCorrectAnswer": true,
      "grade": 3,
      "content": "never gonna let you down",
      "selectedByEvaluee": false
    },
    {
      "isCorrectAnswer": false,
      "grade": -0.5,
      "content": "never run around and desert you",
      "selectedByEvaluee": true
    },
    {
      "isCorrectAnswer": false,
      "grade": -1,
      "content": "never gonna make you cry",
      "selectedByEvaluee": false
    },
    {
      "isCorrectAnswer": false,
      "grade": -1.5,
      "content": "never gonna say goodbye",
      "selectedByEvaluee": false
    },
    {
      "isCorrectAnswer": false,
      "grade": -2,
      "content": "never gonna tell a lie and hurt you",
      "selectedByEvaluee": false
    }
  ]
}
```

receive:
```json
{
  "hasCorrectAnswer": true,
  "answers": [
    {
      "content": "never gonna let you down",
      "selectedByEvaluee": false,
      "id": 1,
      "isCorrectAnswer": true,
      "grade": 3
    },
    {
      "content": "never run around and desert you",
      "selectedByEvaluee": true,
      "id": 2,
      "isCorrectAnswer": false,
      "grade": -0.5
    },
    {
      "content": "never gonna make you cry",
      "selectedByEvaluee": false,
      "id": 3,
      "isCorrectAnswer": false,
      "grade": -1
    },
    {
      "content": "never gonna say goodbye",
      "selectedByEvaluee": false,
      "id": 4,
      "isCorrectAnswer": false,
      "grade": -1.5
    },
    {
      "content": "never gonna tell a lie and hurt you",
      "selectedByEvaluee": false,
      "id": 5,
      "isCorrectAnswer": false,
      "grade": -2
    }
  ],
  "id": 1,
  "heading": "never gonna give you up",
  "grade": 3,
  "isGraded": true
}
```

#### Read One Multiple-Choice Question
method: `GET`
endpoint: `/api/multiplechoicequestion/1`

```json
{
  "hasCorrectAnswer": true,
  "answers": [
    {
      "content": "never gonna let you down",
      "selectedByEvaluee": false,
      "id": 1,
      "isCorrectAnswer": true,
      "grade": 3
    },
    {
      "content": "never run around and desert you",
      "selectedByEvaluee": true,
      "id": 2,
      "isCorrectAnswer": false,
      "grade": -0.5
    },
    {
      "content": "never gonna make you cry",
      "selectedByEvaluee": false,
      "id": 3,
      "isCorrectAnswer": false,
      "grade": -1
    },
    {
      "content": "never gonna say goodbye",
      "selectedByEvaluee": false,
      "id": 4,
      "isCorrectAnswer": false,
      "grade": -1.5
    },
    {
      "content": "never gonna tell a lie and hurt you",
      "selectedByEvaluee": false,
      "id": 5,
      "isCorrectAnswer": false,
      "grade": -2
    }
  ],
  "id": 1,
  "heading": "never gonna give you up",
  "grade": 3,
  "isGraded": true
}
```

#### Update Multiple-Choice Question

#### Delete Multiple-Choice Question
method: `DELETE`
endpoint: `/api/multiplechoicequestion/1`


### Questions
List of all questions

#### Read All Questions
method: `GET`
endpoint: `/api/q`

receive:
```json
{
  "id": 0,
  "openQuestions": [
    {
      "answer": {
        "contentFromEvaluee": "hello world",
        "id": 1,
        "isCorrectAnswer": true,
        "grade": 0
      },
      "id": 1,
      "heading": "say hello world",
      "grade": 1,
      "isGraded": true
    },
    {
      "answer": {
        "contentFromEvaluee": "hello world!",
        "id": 2,
        "isCorrectAnswer": false,
        "grade": 0
      },
      "id": 2,
      "heading": "say hello world without an exclamation point",
      "grade": 1.5,
      "isGraded": true
    }
  ],
  "multipleChoiceQuestions": [
    {
      "hasCorrectAnswer": true,
      "answers": [
        {
          "content": "never gonna let you down",
          "selectedByEvaluee": false,
          "id": 1,
          "isCorrectAnswer": true,
          "grade": 3
        },
        {
          "content": "never run around and desert you",
          "selectedByEvaluee": true,
          "id": 2,
          "isCorrectAnswer": false,
          "grade": -0.5
        },
        {
          "content": "never gonna make you cry",
          "selectedByEvaluee": false,
          "id": 3,
          "isCorrectAnswer": false,
          "grade": -1
        },
        {
          "content": "never gonna say goodbye",
          "selectedByEvaluee": false,
          "id": 4,
          "isCorrectAnswer": false,
          "grade": -1.5
        },
        {
          "content": "never gonna tell a lie and hurt you",
          "selectedByEvaluee": false,
          "id": 5,
          "isCorrectAnswer": false,
          "grade": -2
        }
      ],
      "id": 1,
      "heading": "never gonna give you up",
      "grade": 3,
      "isGraded": true
    },
    {
      "hasCorrectAnswer": true,
      "answers": [
        {
          "content": "bat",
          "selectedByEvaluee": false,
          "id": 6,
          "isCorrectAnswer": false,
          "grade": -0.5
        },
        {
          "content": "dolphin",
          "selectedByEvaluee": true,
          "id": 7,
          "isCorrectAnswer": true,
          "grade": 1
        },
        {
          "content": "Narwhal",
          "selectedByEvaluee": false,
          "id": 8,
          "isCorrectAnswer": false,
          "grade": -0.2
        }
      ],
      "id": 2,
      "heading": "from the following select the one most resembling a whale",
      "grade": 1,
      "isGraded": false
    }
  ]
}
```

### Answers
List of all questions

#### Read All Answers
method: `GET`
endpoint: `/api/a`

receive:
```json
{
  "id": 0,
  "openAnswers": [
    {
      "contentFromEvaluee": "hello world",
      "id": 1,
      "isCorrectAnswer": true,
      "grade": 0
    },
    {
      "contentFromEvaluee": "hello world!",
      "id": 2,
      "isCorrectAnswer": false,
      "grade": 0
    }
  ],
  "multipleChoiceAnswers": [
    {
      "content": "never gonna let you down",
      "selectedByEvaluee": false,
      "id": 1,
      "isCorrectAnswer": true,
      "grade": 3
    },
    {
      "content": "never run around and desert you",
      "selectedByEvaluee": true,
      "id": 2,
      "isCorrectAnswer": false,
      "grade": -0.5
    },
    {
      "content": "never gonna make you cry",
      "selectedByEvaluee": false,
      "id": 3,
      "isCorrectAnswer": false,
      "grade": -1
    },
    {
      "content": "never gonna say goodbye",
      "selectedByEvaluee": false,
      "id": 4,
      "isCorrectAnswer": false,
      "grade": -1.5
    },
    {
      "content": "never gonna tell a lie and hurt you",
      "selectedByEvaluee": false,
      "id": 5,
      "isCorrectAnswer": false,
      "grade": -2
    },
    {
      "content": "bat",
      "selectedByEvaluee": false,
      "id": 6,
      "isCorrectAnswer": false,
      "grade": -0.5
    },
    {
      "content": "dolphin",
      "selectedByEvaluee": true,
      "id": 7,
      "isCorrectAnswer": true,
      "grade": 1
    },
    {
      "content": "Narwhal",
      "selectedByEvaluee": false,
      "id": 8,
      "isCorrectAnswer": false,
      "grade": -0.2
    }
  ]
}
```


### Evaluations
Evaluations CRUD

#### Read All Evaluations

#### Create Evaluation

#### Read One Evaluation

#### Update Evaluation

#### Delete Evaluation


### EvaluationEvents
EvaluationEvents CRUD

#### Read All EvaluationEvents

#### Create EvaluationEvent

#### Read One EvaluationEvent

#### Update EvaluationEvent

#### Delete EvaluationEvent


### EvaluationParticipations
EvaluationParticipations CRUD

#### Read All EvaluationParticipations

#### Create EvaluationParticipation

#### Read One EvaluationParticipation

#### Update EvaluationParticipation

#### Delete EvaluationParticipation


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
