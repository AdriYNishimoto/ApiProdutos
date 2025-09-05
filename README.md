API de Produtos em .NET 8
📄 Sobre o Projeto
Este repositório contém o código-fonte de uma API RESTful completa desenvolvida com ASP.NET Core 8 e C#. O projeto serve como um exemplo prático e robusto de como construir APIs modernas, seguras e bem estruturadas, seguindo as melhores práticas do ecossistema .NET.

A API gerencia um cadastro de produtos, implementando todas as operações de um CRUD (Create, Read, Update, Delete) e incluindo funcionalidades essenciais como autenticação, validação de dados, logging e tratamento de erros centralizado.

✨ Funcionalidades
O projeto demonstra a implementação das seguintes funcionalidades e conceitos:

✅ CRUD Completo: Operações para criar, ler, atualizar e deletar produtos.

✅ Arquitetura Baseada em Controladores: Organização lógica e escalável dos endpoints.

✅ Persistência de Dados com Entity Framework Core 8: Mapeamento objeto-relacional (ORM) para interagir com um banco de dados SQL Server.

✅ Migrations: Gerenciamento de versionamento e evolução do esquema do banco de dados.

✅ Injeção de Dependência (DI): Gerenciamento desacoplado de serviços e dependências.

✅ Autenticação e Autorização com JWT: Proteção de endpoints usando JSON Web Tokens.

✅ Validação de Dados: Validação automática de modelos de entrada usando Data Annotations.

✅ Tratamento de Erros Centralizado: Middleware customizado para capturar exceções e retornar respostas padronizadas.

✅ Logging Estruturado: Registro de informações, avisos e erros para monitoramento e depuração.

✅ Documentação de API com Swagger/OpenAPI: Interface interativa para visualizar e testar os endpoints.

🚀 Tecnologias Utilizadas
.NET 8

ASP.NET Core 8

C# 12

Entity Framework Core 8

SQL Server (via LocalDB)

Swagger (Swashbuckle)

JWT (JSON Web Tokens) para autenticação

Endpoints da API
Abaixo está a documentação de todos os endpoints disponíveis na API.

Verbo

Endpoint

Descrição

Requer Autenticação?

POST

/api/auth/login

Autentica um utilizador e retorna um token JWT.

❌ Não

GET

/api/produtos

Lista todos os produtos cadastrados.

❌ Não

GET

/api/produtos/{id}

Busca um produto específico pelo seu ID.

❌ Não

POST

/api/produtos

Cria um novo produto.

✅ Sim

PUT

/api/produtos/{id}

Atualiza um produto existente.

✅ Sim

DELETE

/api/produtos/{id}

Exclui um produto.

✅ Sim

⚙️ Pré-requisitos
Antes de começar, precisará ter as seguintes ferramentas instaladas na sua máquina:

.NET 8 SDK

Visual Studio 2022 com a carga de trabalho "Desenvolvimento de ASP.NET e para a Web"

(Opcional) SQL Server Management Studio para visualizar a base de dados.

▶️ Como Executar o Projeto
Siga os passos abaixo para configurar e executar o projeto localmente.

Clone o repositório:

git clone [https://github.com/seu-utilizador/ApiProdutos.git](https://github.com/seu-utilizador/ApiProdutos.git)
cd ApiProdutos

Configure a Conexão com a Base de Dados:

O projeto está configurado para usar o SQL Server LocalDB. A string de conexão padrão encontra-se no arquivo appsettings.json.

Caso precise, pode alterar a string DefaultConnection para apontar para uma instância diferente do SQL Server.

Aplique as Migrations para Criar a Base de Dados:

Via Visual Studio 2022:

Abra a solução (.sln) no Visual Studio.

Vá a Exibir > Outras Janelas > Console do Gestor de Pacotes.

Na console, execute o comando:

Update-Database

Via Linha de Comando (CLI do .NET):

Abra o terminal na pasta raiz do projeto e execute:

dotnet ef database update

Execute a Aplicação:

Via Visual Studio 2022:

Pressione F5 ou clique no botão de play verde ("Iniciar Depuração").

Via Linha de Comando (CLI do .NET):

Execute o comando:

dotnet run

Aceda à Documentação Swagger:

Após a execução, o navegador será aberto automaticamente na interface do Swagger, geralmente no endereço: https://localhost:<PORTA>/swagger/index.html.

🔑 Autenticação
Para aceder aos endpoints protegidos (POST, PUT, DELETE), precisa de um token de autenticação.

Obtenha o Token:

No Swagger, execute o endpoint POST /api/auth/login.

Use as seguintes credenciais no corpo da requisição (definidas em AuthController.cs para fins de demonstração):

{
  "username": "admin",
  "password": "senha123"
}

A resposta conterá o token JWT. Copie este valor.

Autorize as suas Requisições:

No topo da página do Swagger, clique no botão "Authorize".

Na janela que abrir, cole o token no campo de texto no formato Bearer <seu_token_aqui>.

Clique em "Authorize" e feche a janela. Agora pode executar os endpoints protegidos.

📂 Estrutura do Projeto
/
├── Controllers/    # Contém os controladores da API
├── Data/           # Contém o DbContext do Entity Framework
├── Middleware/     # Contém middlewares customizados (ex: tratamento de erros)
├── Migrations/     # Arquivos de migration gerados pelo EF Core
├── Models/         # Contém as classes de modelo (entidades)
├── appsettings.json # Arquivo de configuração
├── Program.cs      # Ponto de entrada da aplicação e configuração dos serviços
└── ApiProdutos.csproj # Arquivo de projeto do .NET

📜 Licença
Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

Desenvolvido com ❤️ e C#!
