CATALOG.API:	http://localhost:5000
BASKET.API:		http://localhost:5001
DISCOUNT.API:	http://localhost:5002

POSTGRES URL:	http://localhost:5050
      - POSTGRES_USER=admin
      - POSTGRES_PASSWORD=admin1234
      - POSTGRES_DB=DiscountDb

REDIS:			docker exec -it <container> redis-cli
PORTAINER:		http://localhost:9000

docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build