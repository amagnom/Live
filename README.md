﻿# Live


## Descrição

Este é um projeto de desenvolvimento de uma plataforma de lives, incluindo alguns objetos e suas operações, tais como criação, deleção dentre
outras.

### Pontos de destaque
#### Os pontos abaixos são validados e verificados pelo sistema:

- Inscritos e Instrutores devem ser maiores de 18 anos.
- Uma Live só pode ser agendada para uma data maior que a atual.
- Os campos de url do Instagram e do Email são validados.
- Não é permitido criar ou editar algum dado e adicionar um email ou instagram que já exista.
- Não é possível deletar um Instrutor se houver uma live marcada com ele.
- Não é possível deletar um Inscrito ou uma Live se caso houver uma Inscrição marcada com eles.

obs: Com poucas exceções, as validações são feitas no backend por motivos de segurança.

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

Foi utilizado o design pattern estrutural **MVC**. Além disto, para o banco de dados utilizou o modelo **Code First**.

Vale ressaltar que também havia a possibilidade de se utilizar o Factory como criacional e o Strategy como comportamental.
Até outros, como o Interface. Porém, devido ao pouco tempo de desenvolvimento, estas alterações ficaram como modificações futuras.

## Pré-requisitos

É necessário ter os seguintes pré-requisitos para executar o sistema

- .Net 6 core instalado
- Visual Studio
- Sql Server
- Entity Framework

## Como executar o projeto

1. Crie um banco de dados vazio em sua instância do SQL Server.
2. Abra o arquivo "appsettings.json" e atualize a string de conexão com o nome do seu banco de dados.
3. Abra o Console do Gerenciador de Pacotes (Tools -> NuGet Package Manager -> Package Manager Console)
4. Certifique-se que esteja na pasta dentro do projeto
5. Execute o comando "dotnet ef database update" para criar as tabelas do banco de dados.
6. Execute o projeto e comece a usar.

obs: Caso não tenha o ef instalado, execute: dotnet tool install --global dotnet-ef

## Imagem do projeto
![Print do projeto](https://github.com/amagnom/SponteLive/blob/main/Pic1.PNG)
