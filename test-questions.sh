#!/bin/sh

curl -X 'POST' \
  'http://localhost:5000/api/openquestion' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 0,
  "heading": "say hello world",
  "answer": {
    "id": 0,
    "isCorrectAnswer": true,
    "contentFromEvaluee": "hello world"
  }
}'

sleep 3

curl -X 'GET' \
  'http://localhost:5000/api/openquestion' \
  -H 'accept: text/plain'
