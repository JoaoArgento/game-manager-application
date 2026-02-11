run: 
	docker compose -f ./back/Infra/compose.yaml up -d
	cmd /c start dotnet run --project ./back/API 
	npm run dev --prefix front

docker-up: 
	docker compose -f ./back/Infra/compose.yaml up -d

docker-down:
	docker compose -f ./back/Infra/compose.yaml down

createTable-migration:
	dotnet ef database update --project Infra

enter-psql:
	docker exec -it postgres-dev psql -U Cleberson -d postgres