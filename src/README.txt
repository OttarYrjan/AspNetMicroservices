
** LOCAL **
IDENTITY_SERVER			https://localhost:4000 
						https://github.com/aspnetrun/run-aspnet-identityserver4.git

CATALOG.API:			http://localhost:5000
BASKET.API:				http://localhost:5001
DISCOUNT.API:			http://localhost:5002
DISCOUNT.GRPC:			http://localhost:5003
ORDERING.API:			http://localhost:5004
SHOPPING.AGGREGATOR:	http://localhost:5005
OCELOT_GW:				http://localhost:5010


** DOCKER-COMPOSE **
CATALOG.API:			http://localhost:8000, http://localhost:8000/api/v1/Catalog
BASKET.API:				http://localhost:8001, http://localhost:8001/api/v1/Basket
DISCOUNT.API:			http://localhost:8002, http://localhost:8002/api/v1/Discount
DISCOUNT.GRPC:			http://localhost:8003
ORDERING.API:			http://localhost:8004, http://localhost:8004/api/v1/Order
SHOPPING.AGGREGATOR:	http://localhost:8005
ASPNETRUNBASICS:		http://localhost:8006

OCELOT_GW:				http://localhost:8010/Catalog
						http://localhost:8010/Basket
						http://localhost:8010/Ordering

** CLIENTS **
CATALOG.CLIENT:			http://localhost:5800
ASPNETRUNBASICS:		http://localhost:5801


RABBIT_MQ ADMIN:      http://localhost:15672

POSTGRES URL:	http://localhost:5050
      - POSTGRES_USER=admin
      - POSTGRES_PASSWORD=admin1234
      - POSTGRES_DB=DiscountDb

REDIS:			docker exec -it <container> redis-cli
PORTAINER:		http://localhost:9000


https://jsonformatter.org/
https://jwt.io/

TEST:
	POST Basket - Discount (Grpc) - MSQ - Order (userName)


docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build


docker-compose  -f docker-compose.yml -f docker-compose.override.yml up -d basketdb portainer rabbitmq


docker run -d -p 27017:27017 --name shopping-mongo mongo
docker start <image>
mongo command
	show dbs
	use CatalogDb
	db.CreateCollection('table')
	
docker ps -aq
docker stop $(docker ps -aq)	
docker rm $(docker ps -aq)	
docker rmi $(docker ps -aq)	
docker system prune
docker run -d -p 6379:6379 --name aspnetrun-redis redis
docker exec -it aspnetrun-redis /bin/bash (redis-cli)

docker-compose  -f docker-compose.yml -f docker-compose.override.yml up -d basketdb discountdb orderdb portainer rabbitmq



docker exec -it a37543ce94f8 /bin/bash

docker exec -it a37543ce94f8 redis-cli