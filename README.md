# Olympus

Este é um projeto desenvolvido para uma apresentação de ideia para os gestores de RH de uma empresa. A ideia era a construção rápida de um sistema LMS para centralizar conhecimentos de diferentes plataformas e disponibilizar as opções de curso de uma forma, visualmente, mais agradável. 

Essa aplicação foi desenvolvida com:

- dotnet core 
- angular
- cypress

## Testes

Foram desenvolvidos testes unitários (frontend e backend) e testes end-to-end (e2e) com cypress.

### Como rodar os testes

Teste unitários 

```dotnet test --no-build --verbosity normal```

## Como rodar o projeto num ambiente local
As aplicações estão sendo rodadas manualmente, mas serão migradas para docker-compose up -d em um futuro próximo.

#### Backend project (no diretório backend a.k.a. ```cd backend```)

```dotnet restore```

```dotnet run --project src/Totvs.Olympus.API/Totvs.Olympus.API.csproj```

Então acesse: <http://localhost:5000/swagger/index.html>

#### Frontend project (no diretório frontend a.k.a. ```cd frontend```)

```ng build```

```ng serve```

Então acesse: <http://localhost:4200/>
