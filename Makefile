.PHONY: runpostgres

clean:
	dotnet clean
	rm -rf obj/
	rm -rf bin/
	rm -rf node_modules/
	rm -rf Frontend/node_modules/

getdeps:
	./install-dependencies.sh

gencontrollers:
	./generate-controllers.sh

runpostgres:
	docker run \
		--name postgres \
		--rm -p 5432:5432 \
		-e POSTGRES_PASSWORD=Apasswd \
		-e POSTGRES_USER=tester \
		postgres:latest \
		-c log_statement=all

runallmigrations:
	./migrations.sh

runapitest:
	./test-questions.sh
