#!/bin/sh

dotnet ef dbcontext scaffold \
	"Server=localhost;Port=5432;Database=tester;User Id=tester;Password=Apasswd" \
	Npgsql.EntityFrameworkCore.PostgreSQL \
	-o GeneratedModels --force
