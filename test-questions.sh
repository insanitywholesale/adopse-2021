#!/bin/sh

curl -s -X 'POST' \
  'http://localhost:5000/api/openquestion' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "heading": "say hello world",
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
  "hasCorrectAnswer": true,
  "answers": [
    {
      "isCorrectAnswer": true,
      "content": "never gonna let you down",
      "selectedByEvaluee": false
    },
    {
      "isCorrectAnswer": false,
      "content": "never run around and desert you",
      "selectedByEvaluee": true
    },
    {
      "isCorrectAnswer": false,
      "content": "never gonna make you cry",
      "selectedByEvaluee": false
    },
    {
      "isCorrectAnswer": false,
      "content": "never gonna say goodbye",
      "selectedByEvaluee": false
    },
    {
      "isCorrectAnswer": false,
      "content": "never gonna tell a lie and hurt you",
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
