#!/bin/sh

# for formatting
dotnet tool install -g dotnet-format

# for modelscontext.cs
dotnet add package Microsoft.EntityFrameworkCore

# for controller generation
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet tool install -g dotnet-aspnet-codegenerator

# for in-memory database (also needed for basic controller codegen)
dotnet add package Microsoft.EntityFrameworkCore.InMemory

# for postgres
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

# for testing http calls
dotnet tool install -g Microsoft.dotnet-httprepl

# for doing migrations
dotnet tool install -g dotnet-ef
