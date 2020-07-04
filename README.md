# Favo-de-mel - API

Projeto restaurante favo de mel.

## Tecnologias

**.NET Core 3.1** <br>
**Testes de Unidade** <br>
**Conteinerização** <br>
**REST** <br>
**DDD** <br>
**CQRS** <br>
**Swagger** <br>
**EntityFramework** <br>
**Sql Server** <br>

## Funcionalidades

###  Abrir/ Fechar Comanda
Funcionalidade base, onde é possível abrir uma comanda vinculada a mesa (sem necessidade de cadastro de clientes). Após fechada a comanda vai para status fechada, gerando assim um histórico na própria entidade. Ao fechar uma comanda é calculado o total a pagar com base nos pedidos que não foram cancelados.

### Adicionar Item (produto)
Funcionalidade que permite o restaurante Favo de Mel adicionar seus itens do cardápio, os itens que precisam de preparo na cozinha vão com flag cozinha true. Como implementação futura fica a edição e soft exclusão dos itens.

### Fazer Pedido
Funcionalidade onde o garçon faz a criação do pedido vinculando a uma comanda, para cada pedido somente um tipo de item pode ser adicionado, com sua respectiva quantidade. 

# Executar o Projeto

Para executar o projeto, é necessário [docker](https://app.dbdesigner.net/signup  "docker")

Gerar Imagem container
```
docker image build -t favodemel-api:dev -f docker/Dockerfile .
```

Inicia o container:
```
docker-compose -f docker/docker-compose-dev.yml up -d
```

Finaliza o container caso necessário:
```
docker-compose -f docker/docker-compose-dev.yml down
```

Após :
- api : clicando [aqui](http://localhost:5000/swagger  "aqui").
