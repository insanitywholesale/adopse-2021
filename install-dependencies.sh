#!/bin/sh

# for modelscontext.cs
dotnet add package Microsoft.EntityFrameworkCore

# for controller generation
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet tool install -g dotnet-aspnet-codegenerator

#future stuff. shhhh...
#dotnet add package Microsoft.EntityFrameworkCore.InMemory
#dotnet tool install -g dotnet-format
#dotnet tool install -g Microsoft.dotnet-httprepl
