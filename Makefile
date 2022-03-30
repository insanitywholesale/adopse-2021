.PHONY: runpostgres

clean:
	rm -rf obj/
	rm -rf bin/

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
