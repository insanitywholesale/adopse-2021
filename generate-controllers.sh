#!/bin/sh

# delet dis
rm Controllers/*

# evaluation event
dotnet aspnet-codegenerator controller -async -api -f \
	--no-build \
	-name EvaluationEventController \
	-m EvaluationEvent \
	-dc EvaluationContext \
	-outDir Controllers
# evaluation
dotnet aspnet-codegenerator controller -async -api -f \
	--no-build \
	-name EvaluationController \
	-m Evaluation \
	-dc EvaluationContext \
	-outDir Controllers
# evaluee
dotnet aspnet-codegenerator controller -async -api -f \
	--no-build \
	-name EvalueeController \
	-m Evaluee \
	-dc EvaluationContext \
	-outDir Controllers
# evaluator
dotnet aspnet-codegenerator controller -async -api -f \
	--no-build \
	-name EvaluatorController \
	-m Evaluator \
	-dc EvaluationContext \
	-outDir Controllers
# organization
dotnet aspnet-codegenerator controller -async -api -f \
	--no-build \
	-name OrganizationController \
	-m Organization \
	-dc EvaluationContext \
	-outDir Controllers
# questions
#TODO: map questions of all types to unified
#	/api/questions and /api/evaluation/questions
#	seems like it can't be done with codegen
dotnet aspnet-codegenerator controller -async -api -f \
	--no-build \
	-name EvaluationQuestionController \
	-m EvaluationQuestion \
	-dc EvaluationContext \
	-outDir Controllers
dotnet aspnet-codegenerator controller -async -api -f \
	--no-build \
	-name OpenQuestionController \
	-m OpenQuestion \
	-dc EvaluationContext \
	-outDir Controllers
dotnet aspnet-codegenerator controller -async -api -f \
	--no-build \
	-name MultipleChoiceQuestionController \
	-m MultipleChoiceQuestion \
	-dc EvaluationContext \
	-outDir Controllers
# answers
dotnet aspnet-codegenerator controller -async -api -f \
	--no-build \
	-name EvaluationAnswerController \
	-m EvaluationAnswer \
	-dc EvaluationContext \
	-outDir Controllers
dotnet aspnet-codegenerator controller -async -api -f \
	--no-build \
	-name OpenAnswerController \
	-m OpenAnswer \
	-dc EvaluationContext \
	-outDir Controllers
dotnet aspnet-codegenerator controller -async -api -f \
	--no-build \
	-name MultipleChoiceAnswerController \
	-m MultipleChoiceAnswer \
	-dc EvaluationContext \
	-outDir Controllers
