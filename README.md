```markdown
# 📚 WebAPI-ASPNet8

API REST desenvolvida em **ASP.NET Core** para gerenciar **Autores** e **Livros**, com separação por camadas (Controller, Service, DTO, Model) e documentação via **Swagger**.

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- Swagger / Swashbuckle
- SQL Server
- LINQ
- Injeção de Dependência (DI)

## 📂 Estrutura do Projeto


```text

WebApi8-Video/
├── Controllers/
│   ├── AutorController.cs
│   └── LivroController.cs
├── Models/
│   ├── AutorModel.cs
│   └── LivroModel.cs
├── Services/
│   ├── Autor/
│   └── Livro/
├── Dto/
│   ├── Autor/
│   └── Livro/
├── Data/
│   └── AppDbContext.cs
├── Program.cs
├── WebApi8-Video.csproj
└── README.md

```

## 🧪 Endpoints Disponíveis

### 📘 Autores

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET    | `/api/Autor/ListarAutores` | Lista todos os autores |
| GET    | `/api/Autor/BuscarAutorPorId/{id}` | Busca um autor pelo ID |
| GET    | `/api/Autor/BuscarAutorPorIdLivro/{idLivro}` | Busca o autor de um livro |
| POST   | `/api/Autor/CriarAutor` | Cria um novo autor |
| PUT    | `/api/Autor/EditarAutor/{idAutor}` | Edita um autor existente |
| DELETE | `/api/Autor/ExcluirAutor/{idAutor}` | Exclui um autor |

### 📗 Livros

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET    | `/api/Livro/ListarLivros` | Lista todos os livros |
| GET    | `/api/Livro/BuscarLivroPorId/{idLivro}` | Busca um livro pelo ID |
| GET    | `/api/Livro/BuscarLivroPorIdAutor/{idAutor}` | Lista livros de um autor |
| POST   | `/api/Livro/CriarLivro` | Cria um novo livro |
| PUT    | `/api/Livro/EditarLivro` | Edita um livro existente |
| DELETE | `/api/Livro/ExcluirLivro/{idLivro}` | Exclui um livro |

## 📑 Documentação via Swagger

Acesse a documentação interativa da API em:

```

[https://localhost:{porta}/swagger](https://localhost:{porta}/swagger)

```
```html
<p align="center">
  <img src="https://github.com/pierrialexandervidmar/WebAPI-ASPNet8/blob/main/WebAPI-ASPNet8/Controllers/image.png?raw=true" alt="WebAPI-ASPNet8" />
</p>
```

## 🛠️ Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone git@github.com:pierrialexandervidmar/WebAPI-ASPNet8.git
````

2. Restaure os pacotes:

   ```bash
   dotnet restore
   ```

3. Execute as migrations e atualize o banco:

   ```bash
   dotnet ef database update
   ```

4. Inicie o servidor:

   ```bash
   dotnet run
   ```





