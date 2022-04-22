#!/bin/sh

curl -X 'POST' \
  'http://localhost:5000/api/evaluation' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "title": "mock evaluation",
  "isGraded": true,
  "questions": {
    "openQuestions": [
      {
        "heading": "say hello world",
        "grade": 1,
        "isGraded": true
      },
      {
        "heading": "say hello world without an exclamation point",
        "grade": 1.5,
        "isGraded": true,
        "answer": {
          "isCorrectAnswer": false,
          "contentFromEvaluee": "hello world!"
        }
      }
    ],
    "multipleChoiceQuestions": [
      {
        "heading": "from the following select the one most resembling a whale",
        "grade": 1,
        "hasCorrectAnswer": true,
        "answers": [
          {
            "isCorrectAnswer": false,
            "grade": -0.5,
            "content": "bat"
          },
          {
            "isCorrectAnswer": true,
            "grade": 1,
            "content": "dolphin"
          },
          {
            "isCorrectAnswer": false,
            "grade": -0.2,
            "content": "Narwhal"
          }
        ]
      },
      {
        "heading": "never gonna give you up",
        "grade": 3,
        "isGraded": true,
        "hasCorrectAnswer": true,
        "answers": [
          {
            "isCorrectAnswer": true,
            "grade": 3,
            "content": "never gonna let you down"
          },
          {
            "isCorrectAnswer": false,
            "grade": -0.5,
            "content": "never run around and desert you"
          },
          {
            "isCorrectAnswer": false,
            "grade": -1,
            "content": "never gonna make you cry"
          },
          {
            "isCorrectAnswer": false,
            "grade": -1.5,
            "content": "never gonna say goodbye"
          },
          {
            "isCorrectAnswer": false,
            "grade": -2,
            "content": "never gonna tell a lie and hurt you"
          }
        ]
      }
    ]
  }
}'
