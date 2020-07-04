# Favo-de-mel - API

![](repositoriourl)

Projeto restaurante favo de mel.

### Tecnologias

**.NET Core**
**Testes de Unidade**
**Conteinerização**
**REST**
**DDD**
**CQRS**

##### Instalação

Utilizando Docker

**Docker (DEV)**

```
docker image build -t favodemel-api:dev -f docker/Dockerfile .
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

