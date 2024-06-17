Energy API .NET OCRE 7 with docker
Database: SQL SERVER

PARA RODAR EXECUTE OS PASSOS:

1) gerar image:
docker build --no-cache -t energyapi .

2) run image:
docker run -d -p 8080:80 -p 443:443 --name energy-container energyapi

