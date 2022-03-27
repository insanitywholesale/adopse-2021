#!/bin/sh

dotnet ef migrations add firstmigration
dotnet ef migrations list
dotnet ef database update firstmigration
