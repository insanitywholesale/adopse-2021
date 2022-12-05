#!/bin/sh

curl -s -X 'POST' \
  'http://localhost:5000/api/openquestion' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "heading": "say hello world",
  "grade": 1,
  "isGraded": true,
  "answer": {
    "isCorrectAnswer": true,
    "contentFromEvaluee": "hello world"
  }
}' | jq

curl -s -X 'POST' \
  'http://localhost:5000/api/openquestion' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "heading": "say hello world without an exclamation point",
  "grade": 1.5,
  "isGraded": true,
  "answer": {
    "isCorrectAnswer": false,
    "contentFromEvaluee": "hello world!"
  }
}' | jq

curl -s -X 'GET' \
  'http://localhost:5000/api/openquestion' \
  -H 'accept: text/plain' | jq

curl -s -X 'POST' \
  'http://localhost:5000/api/multiplechoicequestion' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
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
}' | jq

curl -s -X 'POST' \
  'http://localhost:5000/api/multiplechoicequestion' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "heading": "from the following select the one most resembling a whale",
  "grade": 1,
  "hasCorrectAnswer": true,
  "answers": [
    {
      "isCorrectAnswer": false,
	  "grade": -0.5,
      "content": "bat",
      "selectedByEvaluee": false
    },
    {
      "isCorrectAnswer": true,
	  "grade": 1,
      "content": "dolphin",
      "selectedByEvaluee": true
    },
    {
      "isCorrectAnswer": false,
	  "grade": -0.2,
      "content": "Narwhal",
      "selectedByEvaluee": false
    }
  ]
}' | jq

curl -s -X 'GET' \
  'http://localhost:5000/api/multiplechoicequestion' \
  -H 'accept: text/plain' | jq

curl -s -X 'GET' \
  'http://localhost:5000/api/q' \
  -H 'accept: text/plain' | jq
