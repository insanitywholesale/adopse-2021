#!/bin/sh

# for modelscontext.cs
dotnet add package Microsoft.EntityFrameworkCore

# for controller generation
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet tool install -g dotnet-aspnet-codegenerator

# for in-memory database (also needed for basic controller codegen)
dotnet add package Microsoft.EntityFrameworkCore.InMemory

#future stuff. shhhh...
#dotnet tool install -g dotnet-format
#dotnet tool install -g Microsoft.dotnet-httprepl
#dotnet tool install --global dotnet-ef
