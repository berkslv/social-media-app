

docker build --rm -t collegehub-service:1.0.0 .
docker build --rm -t collegehub-client:1.0.0 .

docker run -p 3000:80 -d --name client sma-client

docker run --name some-mysql -e MYSQL_ROOT_PASSWORD=12345678 -d 3306:3306 mysql:8.0.30


