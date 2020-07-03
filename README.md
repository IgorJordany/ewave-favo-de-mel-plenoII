# Favo-de-mel - API

![](repositoriourl)

Projeto restaurante favo de mel.

### Tecnologias

**.NET Core**


##### Instalação

Utilizando Docker

**Docker (DEV)**

```
docker image build -t favo-de-mel-webapi:dev -f docker/Dockerfile .
```
Iniciar sql server primeiro para criação do database (primeira criação de ambiente).

```
docker-compose -f docker/docker-compose-dev.yml up -d sqlserver
```

Acessar o banco e criar database

Server=localhost
Port=1433:1433
Database=favodemel
User Id=SA
Password=@favodemel1234

```
CREATE DATABASE favodemel
```

Inicia o container

```
docker-compose -f docker/docker-compose-dev.yml up -d
```

Finaliza o container caso necessário:

```
docker-compose -f docker/docker-compose-dev.yml down
```

Para visualizar que esta executando o container digite:

```
docker container ls 
```
