#!/bin/sh

echo "Controllers have already been generated, no need to run this"
echo "If you know what you're doing, edit the script"
exit 1

# delet dis
#rm Controllers/*

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
dotnet aspnet-codegenerator controller -async -api -f \
	--no-build \
	-name QController \
	-m Q \
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
#TODO: maybe later
#dotnet aspnet-codegenerator controller -async -api -f \
#	--no-build \
#	-name AController \
#	-m A \
#	-dc EvaluationContext \
#	-outDir Controllers
