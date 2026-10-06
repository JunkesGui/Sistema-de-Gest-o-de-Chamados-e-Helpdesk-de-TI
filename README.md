# 🎧 Sistema de Gestão de Chamados e Helpdesk de TI


Mini projeto desenvolvido em **C#** durante o curso da **SCTec**. O sistema é uma API para gestão de chamados de suporte técnico (Helpdesk de TI), permitindo registrar, acompanhar e resolver solicitações de usuários de forma organizada.

---

## 📑 Sumário

- [Sobre o projeto](#-sobre-o-projeto)
- [Funcionalidades](#-funcionalidades)
- [Tecnologias](#-tecnologias)
- [Estrutura do projeto](#-estrutura-do-projeto)
- [Pré-requisitos](#-pré-requisitos)
- [Como executar](#-como-executar)
- [Endpoints](#-endpoints)
- [Roadmap](#-roadmap)
- [Contribuindo](#-contribuindo)
- [Licença](#-licença)
- [Autor](#-autor)

---

## 📖 Sobre o projeto

Equipes de TI costumam lidar com solicitações de suporte espalhadas por e-mail, mensagens e planilhas, o que gera atrasos, retrabalho e falta de histórico. Este projeto propõe uma solução centralizada: um sistema onde os chamados são abertos, categorizados, atribuídos e acompanhados até o encerramento.

## ✨ Funcionalidades

- 🎫 Abertura de chamados de suporte
- 📋 Listagem e consulta de chamados
- ✏️ Atualização de informações e status do chamado
- ✅ Encerramento de chamados
- 🗂️ Organização por categoria, prioridade e status *(ajuste conforme o que foi implementado)*
- 👤 Gestão de usuários e técnicos *(ajuste conforme o que foi implementado)*


## 🛠️ Tecnologias

- [C#](https://learn.microsoft.com/dotnet/csharp/)
- [.NET / ASP.NET Core Web API](https://dotnet.microsoft.com/apps/aspnet)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/) 
- [Swagger / OpenAPI](https://swagger.io/)
- Banco de dados: `SQL Server`

## 📂 Estrutura do projeto

```
Sistema-de-Gest-o-de-Chamados-e-Helpdesk-de-TI/
├── HelpDesk.API/      # Projeto principal da API
├── .gitignore
├── LICENSE
└── README.md
```

## ✅ Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) (versão compatível com o projeto)
- [Git](https://git-scm.com/)
- Um banco de dados configurado
- IDE recomendada: [Visual Studio](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

## 🚀 Como executar

1. **Clone o repositório**

   ```bash
   git clone https://github.com/JunkesGui/Sistema-de-Gest-o-de-Chamados-e-Helpdesk-de-TI.git
   cd Sistema-de-Gest-o-de-Chamados-e-Helpdesk-de-TI
   ```

2. **Acesse a pasta da API**

   ```bash
   cd HelpDesk.API
   ```

3. **Restaure as dependências**

   ```bash
   dotnet restore
   ```

4. **Configure a conexão com o banco**

   Edite o arquivo `appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "SUA_STRING_DE_CONEXAO"
     }
   }
   ```

5. **Aplique as migrations** 

   ```bash
   dotnet ef database update
   ```

6. **Execute a aplicação**

   ```bash
   dotnet run
   ```

7. **Acesse a documentação da API** 

   ```
   https://localhost:<porta>/swagger
   ```

## 🔌 Endpoints

> Exemplo ilustrativo. Substitua pelos endpoints reais da API.

| Método   | Rota                | Descrição                    |
| -------- | ------------------- | ---------------------------- |
| `GET`    | `/api/chamados`     | Lista todos os chamados      |
| `GET`    | `/api/chamados/{id}`| Retorna um chamado por ID    |
| `POST`   | `/api/chamados`     | Abre um novo chamado         |
| `PUT`    | `/api/chamados/{id}`| Atualiza um chamado          |
| `DELETE` | `/api/chamados/{id}`| Remove/encerra um chamado    |

**Exemplo de requisição (`POST /api/chamados`):**

```json
{
  "titulo": "Computador não liga",
  "descricao": "A máquina do setor financeiro não inicia após queda de energia.",
  "prioridade": 2
}
```

##  Autor

**Guilherme Junkes**
