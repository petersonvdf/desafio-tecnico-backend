# Let's Code - Desafio Técnico - Backend - C#

API criada em ASP.NET CORE 3 que fará a persistência de dados de um quadro kanban atendendo os requisitos exigidos pelo desafio técnico da Let's Code.

## Informações adicionais

O tipo de autenticação e autorização utilizado pela API é o Bearer. As requisições para rotas protegidas devem conter o prefixo "Bearer" em seu header. Segue um exemplo:
  Authorization: Bearer <jwt_token>

O projeto contem um arquivo de configuração modelo (appsettings.Development.json), o qual contém valores exemplos para chave JWT, login e senha. É preciso alterar esses valores para as informações reais do desafio. A chave JWT pode ser um novo Guid. O login e senha serão os informados no desafio. Também é possível criar um novo arquivo de configuração para produção com os respectivos valores (appsettings.Production.json).
