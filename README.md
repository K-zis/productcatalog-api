# 📦 Product Catalog API (Mini Backend Project)

## ✨ Overview

This is a lightweight RESTful API built with .NET 8 (C#), designed as a backend mini project simulating a basic Product Catalog. It supports full CRUD operations over products, deployed on Microsoft Azure via GitHub Actions.

The goal of the project is to showcase backend development skills with modern .NET technologies and deployment pipelines, simulating real-world consulting scenarios.

---

## 🔧 Technologies Used

| Layer              | Technology                         |
|--------------------|-------------------------------------|
| Language           | C# (.NET 8)                         |
| Framework          | ASP.NET Core (Minimal APIs)         |
| Persistence        | SQLite (dev) / SQL Server-ready     |
| ORM                | Dapper (fast micro-ORM)             |
| Hosting            | Azure App Service (Windows)         |
| CI/CD              | GitHub Actions + Azure integration  |
| Documentation      | Swagger (OpenAPI)                   |

---

## 🚀 API Features

- ✅ Create / Read / Update / Delete products
- ✅ Minimal API approach with clean RESTful routes
- ✅ Swagger UI for interactive API testing
- ✅ Validation on input (via DataAnnotations)
- ✅ Ready for SQL Server & Azure deployment
- ✅ Clean CI/CD pipeline to Azure Web App

---

## 📂 Endpoints (v1)

| Verb     | Route             | Description             |
|----------|------------------|-------------------------|
| `GET`    | `/products`       | Get all products        |
| `GET`    | `/products/{id}`  | Get product by ID       |
| `POST`   | `/products`       | Create new product      |
| `PUT`    | `/products/{id}`  | Update existing product |
| `DELETE` | `/products/{id}`  | Delete a product        |

---

## 🧪 How to Test (Local)

1. Clone the repo  
2. Run `dotnet run`  
3. Open browser: `https://localhost:5035/swagger`

---

## ☁️ Deployment

- Deployed via GitHub Actions to Azure Web App (`[productcatalog-api.azurewebsites.net](https://productcatalog-api-ckdhejayeeanhddg.canadacentral-01.azurewebsites.net/swagger/index.html)`)
- Publish Profile used for secrets (securely stored in GitHub)
- Auto-deployment triggered on push to `main`

---

## 🧠 Future Enhancements

- Add Azure SQL or Microsoft SQL Server support
- Add JWT authentication and role-based access
- Add ProductCategory relationship (1:n)
- Add logging with Serilog + AppInsights
- Unit & integration tests with xUnit or NUnit

---

## 🏁 Why This Project?

This project was designed to align with the expectations of a junior backend dev:

- ✅ Demonstrates use of Microsoft stack (Azure, C#, SQL)
- ✅ Reflects modern cloud-oriented backend development
- ✅ Deploys infrastructure via CI/CD
- ✅ Shows structured, documented, modular thinking

---

## 📬 Author

**Kyriakos Zisios**  
`zisios.kyriakos@gmail.com`  
GitHub: [K-zis](https://github.com/K-zis)
