# Desafio Técnico Luizalabs

Este repositório é meu projeto para o desafio técnico da Luizalabs. Espero que através desse projeto eu possa demonstrar um pouco das minhas habilidades como arquiteto e desenvolvedor de software.

Este projeto foi desenvolvido através do Microsoft **Visual Studio Community 2019** e a versão do framework é **.NET Core 3.1**


Alguns pontos que acho importante comentar sobre meu projeto:
- Projeto Luizalabs.Challenge foi escrito utilizando a arquitetura Domain-Driven Design do Eric Evans
- Para acesso aos dados utilizei o micro-ORM Dapper. Ele é rápido e vai agilizar o meu trabalho.
- Estou utilizando o FluentValidator para as validações. As validações são feitas em tempo de requisição, ou seja, se o modelo não for válido a Action requisitada não será executada fazendo uma validação prévia dos dados enviados para o serviço.
- O banco de dados é MySQL. Utilizei um serviço https://remotemysql.com/ onde criei um banco de dados free para demonstração. O serviço é free, até por isso, é um pouco lento.
- A atualização (HTTP PUT) do modelo Customer eu propositalmente não permiti a alteração do E-mail para demonstrar um modelo diferente de POST e PUT.
- Eu costumo criar construtores para minhas entidades para que elas só possam ser construidas com todos os dados necessários. Criei um construtor publico para facilitar o trabalho já que eu não tenho muito tempo para trabalhar no projeto.
- A forma como fiz a média do Score do produto através de LINQ não é o ideal. Fiz dessa forma por causa de tempo. Seria necessário um refactoring.


Seria legal se após testarem o projeto vocês fizessem um PR neste arquito README, assim eu tenho um feedback de vocês.

