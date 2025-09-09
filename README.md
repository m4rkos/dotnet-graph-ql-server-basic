# Movie Catalog GraphQL Microservice

[![.NET 9](https://img.shields.io/badge/.NET-9.0-blueviolet?logo=dotnet)](https://dotnet.microsoft.com/)  
[![GraphQL](https://img.shields.io/badge/GraphQL-HotChocolate-E10098?logo=graphql)](https://chillicream.com/docs/hotchocolate)  
[![Docker](https://img.shields.io/badge/Docker-ready-blue?logo=docker)](https://www.docker.com/)  

A lightweight **GraphQL microservice** built with **.NET 8 Minimal APIs** and **HotChocolate**.  
It provides a simple `Movie` catalog with **queries**, **mutations**, **filtering**, **sorting**, and **paging**.  
Ready to run locally or inside Docker. 🚀  

---

## Features  

- ⚡ **GraphQL server** with [HotChocolate](https://chillicream.com/docs/hotchocolate)  
- 🗄️ **In-memory database** (easy to replace with PostgreSQL or SQL Server)  
- 🔎 **Queries** with filtering, sorting, and pagination  
- ✏️ **Mutations**: add, update, and delete movies  
- 📊 **Apollo Tracing** for debugging and performance monitoring  
- 🐳 **Dockerfile** for containerized deployment  

---

## Project Structure  

```
Catalog.GraphQL/
  Program.cs
  Data/
    AppDbContext.cs
  Models/
    Movie.cs
  GraphQL/
    Query.cs
    Mutation.cs
```

---

## Getting Started  

### 1. Clone & Install  
```bash
  git clone git@github.com:m4rkos/dotnet-graph-ql-server-basic.git
  cd dotnet-graph-ql-server-basic/videos_graph_ql
  dotnet restore
```

### 2. Run locally  
```bash 
  dotnet run
```

GraphQL endpoint: [http://localhost:5000/graphql](http://localhost:5000/graphql)  
Playground: Banana Cake Pop (opens automatically in browser).  

---

## Example Queries  

### Get Movies (with paging & sorting)  
```graphql
query {
  movies(first: 5, order: { year: DESC }) {
    totalCount
    nodes {
      id
      title
      year
      rating
    }
  }
}
```

### Filter Movies (rating > 8)  
```graphql
query {
  movies(where: { rating: { gt: 8 } }) {
    nodes { title year rating }
  }
}
```

### Get Movie by ID  
```graphql
query {
  movieById(id: 1) {
    id
    title
    year
    rating
  }
}
```

---

## Example Mutations  

### Add Movie  
```graphql
mutation {
  addMovie(title: "Interstellar", year: 2014, rating: 8.6) {
    id
    title
  }
}
```

### Update Movie  
```graphql
mutation {
  updateMovie(id: 1, rating: 9.0) {
    id
    title
    rating
  }
}
```

### Delete Movie  
```graphql
mutation {
  deleteMovie(id: 2)
}
```

---

## Docker Setup  

### Build Image  
```bash
  docker build -t catalog-graphql .
```

### Run Container  
```bash
  docker run --rm -p 8080:8080 catalog-graphql
```

GraphQL endpoint: [http://localhost:8080/graphql](http://localhost:8080/graphql)  

---

## Preview  

> A screenshot of Banana Cake Pop Playground here 👇  

![GraphQL Playground Preview](Assets/screenshot.png)  

> Or the real app running

![GraphQL Playground Preview](Assets/screenshot_real.png)

---

## Next Steps  

- 🔄 Replace **InMemory DB** with PostgreSQL or SQL Server  
- 🔐 Add **authentication & authorization** (`[Authorize]` attributes)  
- 📈 Enable **metrics & logging** (Prometheus, OpenTelemetry, Serilog)  
- 🌐 Deploy behind **NGINX** or **API Gateway**  

---

## License  
MIT License © 2025  

---
#### Author: **Marcos Eduardo**