#!/bin/sh

dotnet ef migrations add InitialMigration
dotnet ef migrations list
dotnet ef database update InitialMigration
