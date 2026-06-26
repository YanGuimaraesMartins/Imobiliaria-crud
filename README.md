# 🏠 Sistema Imobiliária - CRUD em ASP.NET MVC

Este projeto é um sistema de cadastro de imóveis desenvolvido em **ASP.NET Core MVC**, com foco em praticar conceitos de arquitetura em camadas, consumo de AJAX e operações CRUD.

---

## 🚀 Tecnologias utilizadas

- ASP.NET Core MVC
- C#
- JavaScript (jQuery)
- AJAX
- HTML5
- CSS3
- Bootstrap
- SQL Server (ou banco utilizado)

---

## 📌 Funcionalidades

- ✔ Cadastro de imóveis
- ✔ Listagem de imóveis
- ✔ Edição de imóveis
- ✔ Exclusão de imóveis
- ✔ Filtro de imóveis por bairro (AJAX)
- ✔ Interface responsiva com Bootstrap

---

## 🧱 Arquitetura do projeto

O projeto segue uma estrutura em camadas para melhor organização:

- **Controllers** → Responsáveis pelas requisições HTTP
- **Services** → Regras de negócio
- **Repositories** → Acesso ao banco de dados
- **Models** → Entidades do sistema
- **Views** → Interface do usuário (Razor Pages)

---

## 💻 Demonstração

### Tela principal
(Adicione aqui prints do sistema)

### Exemplo de filtro AJAX
O sistema permite filtrar imóveis sem recarregar a página utilizando jQuery + AJAX.

## ⚙️ Como executar o projeto

- Clonar o repositório: `git clone https://github.com/seu-usuario/imobiliaria-crud.git`
- Acessar a pasta do projeto: `cd imobiliaria-crud`
- Abrir o projeto no Visual Studio
- Configurar a string de conexão no arquivo `appsettings.json`
- Executar migrations (se necessário): `dotnet ef database update`
- Executar o projeto no Visual Studio com F5 ou via terminal com `dotnet run`
- Acessar a aplicação no navegador em `https://localhost:xxxx`
