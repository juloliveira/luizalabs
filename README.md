# Desafio Técnico Luizalabs

Este repositório é meu projeto para o desafio técnico da Luizalabs. Espero que através desse projeto eu possa demonstrar um pouco das minhas habilidades como arquiteto e desenvolvedor de software.

Este projeto foi desenvolvido através do Microsoft **Visual Studio Community 2019** e a versão do framework é **.NET Core 3.1**


Algumas considerações que acredito serem importantes de serem mencionadas comentar sobre meu projeto:
- Projeto Luizalabs.Challenge foi escrito utilizando a arquitetura Domain-Driven Design do Eric Evans
- Para autenticação eu utilizei JWT mas não fiz um cadastro de usuários. O usuário está hardcoded (user: luizalabs, password: luizalabs@1234)
- Adicionei no projeto um arquivo do Postman. A ideia é que vocês importem no Postman e já consigam imediatamente testar.
- Adicionei também um dump do banco de dados gerado pelo phpMyAdmin.
- O projeto é clonar o repositório, abrir no Visual Studio e rodar.
- Para acesso aos dados utilizei o micro-ORM Dapper. Ele é rápido e vai agilizar o meu trabalho.
- Estou utilizando o FluentValidator para as validações. As validações são feitas em tempo de requisição, ou seja, se o modelo não for válido a Action requisitada não será executada fazendo uma validação prévia dos dados enviados para o serviço.
- O banco de dados é MySQL. Utilizei um serviço https://remotemysql.com/ onde criei um banco de dados free para demonstração. O serviço é free, até por isso, é um pouco lento.
- A atualização (HTTP PUT) do modelo Customer eu propositalmente não permiti a alteração do E-mail para demonstrar um modelo diferente de POST e PUT.
- Eu costumo criar construtores para minhas entidades para que elas só possam ser construidas com todos os dados necessários. Criei um construtor publico para facilitar o trabalho já que eu não tenho muito tempo para trabalhar no projeto.
- A forma como fiz a média do Score do produto através de LINQ não é o ideal. Fiz dessa forma por causa de tempo. Seria necessário um refactoring.
- Eu adicionei um método Update() à classe Entity para atulizar o campo UpdatedAt das entidades. Normalmente eu utilizaria um recurso mais elegante, como Listeners do NHibernate ou um Data Tracking para detectar a mudança no valor dos campos das entidades.
- Eu iniciei o projeto pensando em DDD, centralizando no meu domínio as regras de negócio (ao incluir um produto favorito, por exemplo). Porém, durante o processo eu resolvi usar micro-ORM Dapper e como ele não possui um "cascade" para salvar minhas entidades e seus filhos e eu não implementei um Data Tacker o domínio ficou sem regras de negócio ao incluir um produto favorito. Esse processo de incluir um favorito e validações, por exemplo, ficou direto no serviço IFavoriteService e não na classe de domínio Customer em um método AddFavorite(Product product) que é a forma como costumo trabalhar em meus projetos.
- Esse projeto tem diversas débitos técnicos como por exemplo, não implementei uma convensão para respostas de erro.
- Esse projeto foi escrito em dois dias.
- Por favor, eu fiz esse projeto correndo pois estou essa semana do ano novo com minha filha em casa e moro sozinho. Peço a compreenção de quem revisar o código. 


Seria legal se após testarem o projeto vocês fizessem um PR neste arquito README, assim eu tenho um feedback de vocês.

