# Nome do Projeto

[!(https://github.com/ArildoMagno/SponteLive)

## Descrição

Este é um projeto de desenvolvimento de uma plataforma de lives, incluindo alguns objetos e suas operações, tais como criação, deleção dentre
outras.
Realizando diversas verificações dos campos, como por exemplo

## Tecnologias utilizadas

Como questionado no momento pré desenvolvimento, foi disponibilizado a possibilidade de se desenvolver em c#, ao verificar a vaga (LinkedIn)
dizia que poderia ser desenvolvido em VB.Net(framework 4.5) e/ou .NetCore(C#).

Sendo assim, foi optado por desenvolver utilizando o .NetCore em C#.

Utilizando as tecnologias:

- C#
- SQL Server
- Entity Framework
- JavaScript
- HTML
- CSS

Obs: Também foi utilizada algumas bibliotecas externas como:

- Font Awesome
- Bootstrap

## Padrões



Foi utilizado o design pattern estrutural MVC. Vale ressaltar que também havia a possibilidade de se utilizar o 
Factory como criacional e o Strategy como comportamental.
Além disto, para o banco de dados utilizou o modelo Code First.

Devido ao pouco tempo de desenvolvimento, estas alterações ficaram como modificações futuras.

## Pré-requisitos

É necessário ter os seguintes pré-requisitos para executar o sistema

- .Net 6 core instalado
- Visual Studio
- Sql Server
- Entity Framework

## Como executar o projeto

1. Crie um banco de dados vazio em sua instância do SQL Server.
2. Abra o arquivo "appsettings.json" e atualize a string de conexão com o nome do seu banco de dados.
3. Abra o Console do Gerenciador de Pacotes (Tools -> NuGet Package Manager -> Package Manager Console) e execute o comando "Update-Database" para criar as tabelas do banco de dados.
4. Execute o projeto e comece a usar.



## Print do projeto
![Print do projeto](https://github.com/ArildoMagno/SponteLive/blob/main/ImagesRepository/InstrutoresPage.png)
