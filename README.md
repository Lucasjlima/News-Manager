# 📰 News Manager — Checkpoint 2 (ASP.NET Core MVC)

## 👥 Integrantes do Grupo
## 2TDSPA

### RM : 561160 Lucas José Lima

### RM : 560547 Rangel Bernardi Jordao

### RM : 559755 Eduardo Osterloh Bindo

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

News-Manager/
├── Controllers/
│ ├── HomeController.cs
│ └── NewsController.cs
├── Models/
│ └── News.cs
├── Repositories/
│ └── InMemoryNewsRepository.cs
├── Views/
│ ├── Home/
│ │ └── Index.cshtml
│ ├── News/
│ │ ├── Index.cshtml
│ │ ├── Create.cshtml
│ │ ├── Edit.cshtml
│ │ ├── Delete.cshtml
│ │ └── Details.cshtml
│ └── Shared/
│ ├── _Layout.cshtml
│ └── _ValidationScriptsPartial.cshtml
├── wwwroot/
│ ├── css/
│ ├── js/
│ └── lib/
└── Program.cs


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
