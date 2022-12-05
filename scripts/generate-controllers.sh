#!/bin/sh

echo "Controllers have already been generated, no need to run this"
echo "If you know what you're doing, edit the script"
exit

# delet dis
#rm Controllers/*

# person
dotnet aspnet-codegenerator controller -async -api \
	-name PersonController \
	-m Person \
	-dc QuizContext \
	-outDir Controllers
# evaluee participation
dotnet aspnet-codegenerator controller -async -api \
	-name EvalueeParticipationController \
	-m EvalueeParticipation \
	-dc QuizContext \
	-outDir Controllers
# evaluation event
dotnet aspnet-codegenerator controller -async -api \
	-name EvaluationEventController \
	-m EvaluationEvent \
	-dc QuizContext \
	-outDir Controllers
# evaluation
dotnet aspnet-codegenerator controller -async -api \
	-name EvaluationController \
	-m Evaluation \
	-dc QuizContext \
	-outDir Controllers
# questions
dotnet aspnet-codegenerator controller -async -api \
	-name MultipleChoiceQuestionController \
	-m MultipleChoiceQuestion \
	-dc QuizContext \
	-outDir Controllers
# answers
dotnet aspnet-codegenerator controller -async -api \
	-name MultipleChoiceAnswerController \
	-m MultipleChoiceAnswer \
	-dc QuizContext \
	-outDir Controllers

# needed cause otherwise there are a lot of whitespace changes
dotnet format
