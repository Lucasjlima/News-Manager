# 📰 News Manager

## 👥 Integrantes do Grupo
## 2TDSPA

### RM : 561160 Lucas José Lima

### RM : 560547 Rangel Bernardi Jordao

---

## 🎯 Objetivo do Projeto

O **News Manager** é uma aplicação web desenvolvida em **ASP.NET Core MVC** que realiza as operações básicas de **CRUD** (Create, Read, Update e Delete) sobre um conjunto de notícias, além de permitir a **pesquisa** por título ou autor.  
O sistema foi construído **sem uso de banco de dados**, armazenando as informações **em memória**, conforme exigido pelo checkpoint.

O projeto foi criado com foco em:
- Implementar as principais funcionalidades do padrão **MVC (Model-View-Controller)**;
- Utilizar **Tag Helpers** do ASP.NET Core;
- Aplicar **validação de dados** no Model;
- Criar **layout responsivo** com Bootstrap;
- Garantir a **confirmação de exclusão** de registros;
- Demonstrar o uso de diferentes tipos de dados (ex.: string, DateTime, enum).

---

## 🧩 Estrutura do Projeto

- **News-Manager/**
  - **Controllers/**
    - `HomeController.cs`
    - `NewsController.cs`
  - **Models/**
    - `News.cs`
  - **Repositories/**
    - `InMemoryNewsRepository.cs`
  - **Views/**
    - **Home/**
      - `Index.cshtml`
    - **News/**
      - `Index.cshtml`
      - `Create.cshtml`
      - `Edit.cshtml`
      - `Delete.cshtml`
      - `Details.cshtml`
    - **Shared/**
      - `_Layout.cshtml`
      - `_ValidationScriptsPartial.cshtml`
  - **wwwroot/**
    - **css/**
    - **js/**
    - **lib/**
  - `Program.cs`



---

## ⚙️ Tecnologias e Dependências

| Tecnologia / Pacote | Descrição |
|----------------------|-----------|
| **.NET 8.0 / ASP.NET Core MVC** | Framework base do projeto |
| **Bootstrap 5 (CDN)** | Estilização e layout responsivo |
| **Tag Helpers** | Ligação entre Controller e View |
| **C# 12** | Linguagem utilizada |
| **Visual Studio 2022** | IDE de desenvolvimento |
| **NuGet Packages** | `Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation` |

---

## 🧱 Modelos e Tipos de Dados

### Classe `News`
| Propriedade | Tipo | Descrição |
|--------------|------|-----------|
| `Id` | `int` | Identificador único |
| `Title` | `string` | Título da notícia |
| `Author` | `string` | Nome do autor |
| `PublishDate` | `DateTime` | Data de publicação |
| `Category` | `NewsCategory (enum)` | Categoria da notícia |
| `Content` | `string` | Texto completo da notícia |

### Enum `NewsCategory`
```csharp
public enum NewsCategory
{
    Politica,
    Tecnologia,
    Esportes,
    Entretenimento,
    Economia
}

[Controller] → chama → [Repository] → manipula → [Model] → exibe → [View]

+-------------------+
|  NewsController   |
|-------------------|
| Index()           |
| Create()          |
| Edit()            |
| Delete()          |
+-------------------+
          |
          v
+-------------------+
| InMemoryNewsRepo  |
|-------------------|
| Add()             |
| Update()          |
| Delete()          |
| Search()          |
| GetAll()          |
+-------------------+
          |
          v
+-------------------+
|      News         |
|-------------------|
| Id, Title, etc... |
+-------------------+


## 🧭 Endpoints e Funcionalidades

| **Endpoint**                | **Método** | **Função**          | **Descrição**                                      |
|-----------------------------|-------------|----------------------|----------------------------------------------------|
| `/News`                     | GET         | Index               | Lista todas as notícias                            |
| `/News?search=algo`         | GET         | Index               | Pesquisa por título ou autor                       |
| `/News/Create`              | GET / POST  | Create              | Criação de nova notícia                            |
| `/News/Edit/{id}`           | GET / POST  | Edit                | Edição de notícia existente                        |
| `/News/Delete/{id}`         | GET         | Delete              | Página de confirmação de exclusão                  |
| `/News/DeleteConfirmed`     | POST        | DeleteConfirmed     | Executa a exclusão                                 |
| `/News/Details/{id}`        | GET         | Details             | Exibe detalhes da notícia                          |

---

## 🖼️ Layout e Telas

📌 O layout utiliza **Bootstrap 5**, com **header fixo** e **footer ajustado**.  
📌 Todas as páginas herdam o layout `_Layout.cshtml` via `@RenderBody()`.

---

### 🏠 Tela Inicial (Home)
Apresenta uma breve descrição do sistema e um link para a listagem de notícias.

---

### 📰 Lista de Notícias (Index)
- Exibe todas as notícias cadastradas.  
- Possui campo de **pesquisa** e botões de ação:  
  - 🔍 **Detalhes**  
  - ✏️ **Editar**  
  - ❌ **Excluir**

---

### ➕ Criar Notícia (Create)
- Formulário com **validação de campos**.  
- Uso de **Tag Helpers** do ASP.NET.  
- Dropdown de **categoria** (enum).  

---

### ✏️ Editar Notícia (Edit)
- Permite alterar os dados de uma notícia existente.  
- Validação automática nos campos obrigatórios.

---

### 🔍 Detalhes da Notícia (Details)
- Exibe todas as informações completas da notícia selecionada.  
- Acesso via botão "Detalhes" na página de listagem.

---

### ❌ Confirmação de Exclusão (Delete)
- Tela que solicita confirmação antes de remover uma notícia.  
- Após confirmar, redireciona de volta para a listagem.

---

## 🔍 Pesquisa
A página **Index** contém um campo de pesquisa que filtra as notícias pelo **título** ou **autor**.  
A funcionalidade foi implementada no método `Search()` do **repositório** e tratada no **NewsController**.

---

## ✅ Validação de Dados

A classe `News` contém anotações de validação:

```csharp
[Required(ErrorMessage = "O campo Título é obrigatório.")]
[StringLength(100)]
[DataType(DataType.Date)]


🖼️ Layout e Telas

📌 O layout utiliza Bootstrap 5 com header fixo e footer ajustado.
📌 Todas as páginas herdam o layout _Layout.cshtml via @RenderBody().
📌 As views utilizam Tag Helpers para navegação entre controladores e ações.

🏠 Tela Inicial (Home)

Apresenta uma breve descrição do sistema e links para a listagem e criação de notícias.
Utiliza o layout principal (_Layout.cshtml) e Tag Helpers para redirecionamento.

<img width="1919" height="1019" alt="home" src="https://github.com/user-attachments/assets/7c49ae38-5c34-4942-a549-9795267abf6d" />



📰 Lista de Notícias (Index)

Exibe todas as notícias cadastradas no sistema.
Possui campo de pesquisa e botões de ação (Detalhes, Editar, Excluir).
A pesquisa é feita por título ou autor, utilizando o método Search() no repositório.


<img width="1919" height="1020" alt="ListAll" src="https://github.com/user-attachments/assets/aa4cdf61-49a0-4933-be0a-7ebc9caadb0a" />



➕ Criar Notícia (Create)

Formulário com validação de dados, uso de Tag Helpers e dropdown de categoria (enum).
Os campos obrigatórios utilizam anotações como [Required] e [StringLength].

<img width="1919" height="908" alt="Create" src="https://github.com/user-attachments/assets/6bbc1a4f-3f2e-410c-8634-1fc1255a17e1" />



✏️ Editar Notícia (Edit)

Permite alterar os dados de uma notícia existente.
Utiliza o mesmo modelo de validação da tela de criação e reaproveita o layout.

<img width="1919" height="905" alt="Edit" src="https://github.com/user-attachments/assets/a5eea049-c1a7-402c-9ece-024558192d43" />


🔍 Detalhes da Notícia (Details)

Mostra todas as informações completas da notícia, como título, conteúdo, autor e data.
É acessada através do botão Detalhes na listagem principal.

<img width="1919" height="909" alt="Details" src="https://github.com/user-attachments/assets/d27fb58b-6863-4109-b9f4-3f735b227982" />


❌ Confirmação de Exclusão (Delete)

Exibe uma tela de confirmação antes de remover definitivamente uma notícia.
A exclusão é feita via método POST com ação DeleteConfirmed.

<img width="1919" height="1020" alt="Remove" src="https://github.com/user-attachments/assets/029fc7a2-b32b-4f7a-95af-8c5c595ffe27" />


🔎 Pesquisa

A tela de listagem (Index) contém um campo de busca que filtra as notícias pelo título ou autor.
A pesquisa é implementada no repositório (InMemoryNewsRepository) e tratada no NewsController.

<img width="1919" height="1019" alt="Search_By" src="https://github.com/user-attachments/assets/c8e4ec27-8704-495f-94d0-4aa14bd667fc" />





