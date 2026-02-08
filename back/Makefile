run: 
	docker compose -f Infra/compose.yaml up -d
	dotnet run --project API 

docker-up: 
	docker compose -f Infra/compose.yaml up -d

docker-down:
	docker compose -f Infra/compose.yaml down

createTable-migration:
	dotnet ef database update --project Infra

enter-psql:
	docker exec -it postgres-dev psql -U Cleberson -d postgres