# Clean Architecture

## O que é?
É um padrão de aqruitetura de software que nos permite separar cada stack em camadas.
Sempre iniciando pela camada de Dominio que é a camada onde vai ficar o core da nossa 
aplicação, todas as regras de negócio ficam nela, sendo assim a nossa camada de Dominio
não pode depender de outras camadas.
Em volta da camada de dominio temos a camada de Infraestrutura e camada de Application.
A camada de Infraestrutura deve ter a implementação da nossa conexão com o banco de dados.
A camada de Application deve ter a implementação das nossas services.
E por fim temos a camada de Presentation que é a última camada, onde será a "porta de entrada",
No meu contexto seria a WebApi.

## Por quê usar clean architecture
Com a clean architecture fica muito mais fácil se quisermos atualizar o nosso projeto.
Digamos que a partir de agora não queremos mais usar uma base relacional, e queremos usar não relacional.
A migração fica muito mais fácil pois podemos alterar nossa camada de Infraestrutura sem afetar as outras camadas.
Mesma coisa para a camada de Application e de Presentation, se quisermos mudar para uma nova tecnologia fica muito
mais simples fazer a alteração pois as camadas estão separadas.
A ideia é manter a camada core sem impacto nenhum, podemos alterar qualquer tecnologia da nossa aplicação sem ter que
alterar nosso core.

## Projeto que irei trabalhar usando clean architecture

 - Domain: Core/Regras de negócio da aplicação
 - Application: Implementação das Services
 - Persistence: Conexão com Banco de dados
 - WebApi: Entry point da nossa aplicação

## Deploy da aplicação
Essa sessão ainda está pendete... Futuramente irei atualizar com minhas anotações sobre o deploy dessa aplicação.
