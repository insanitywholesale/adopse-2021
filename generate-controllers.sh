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
	-dc EvaluationContext \
	-outDir Controllers
# evaluee participation
dotnet aspnet-codegenerator controller -async -api \
	-name EvalueeParticipationController \
	-m EvalueeParticipation \
	-dc EvaluationContext \
	-outDir Controllers
# evaluation event
dotnet aspnet-codegenerator controller -async -api \
	-name EvaluationEventController \
	-m EvaluationEvent \
	-dc EvaluationContext \
	-outDir Controllers
# evaluation
dotnet aspnet-codegenerator controller -async -api \
	-name EvaluationController \
	-m Evaluation \
	-dc EvaluationContext \
	-outDir Controllers
# questions
dotnet aspnet-codegenerator controller -async -api \
	-name OpenQuestionController \
	-m OpenQuestion \
	-dc EvaluationContext \
	-outDir Controllers
dotnet aspnet-codegenerator controller -async -api \
	-name MultipleChoiceQuestionController \
	-m MultipleChoiceQuestion \
	-dc EvaluationContext \
	-outDir Controllers
dotnet aspnet-codegenerator controller -async -api \
	-name QController \
	-m Q \
	-dc EvaluationContext \
	-outDir Controllers
# answers
dotnet aspnet-codegenerator controller -async -api \
	-name OpenAnswerController \
	-m OpenAnswer \
	-dc EvaluationContext \
	-outDir Controllers
dotnet aspnet-codegenerator controller -async -api \
	-name MultipleChoiceAnswerController \
	-m MultipleChoiceAnswer \
	-dc EvaluationContext \
	-outDir Controllers
dotnet aspnet-codegenerator controller -async -api \
	-name AController \
	-m A \
	-dc EvaluationContext \
	-outDir Controllers

# needed cause otherwise there are a lot of whitespace changes
dotnet format
