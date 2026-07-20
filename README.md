# BookStore - Modular .NET 9.0 Backend System

BookStore is a modern, modular backend application built with **.NET 9.0**, designed to demonstrate scalable system design using **Clean Architecture principles** and secure RESTful APIs.

The project focuses on maintainability, separation of concerns, and production-inspired backend design practices.

---

## 🚀 Overview

BookStore is a backend system for managing books, authors, and categories with secure authentication and role-based authorization.
It is designed with a clean modular structure that separates business logic from infrastructure concerns, making it highly scalable and easy to extend.

---

## 🏗️ Architecture
This project is structured using **Clean Architecture**, ensuring clear separation of responsibilities:

- Domain Layer (Core business logic)
- Application Layer (Use cases & business rules)
- Infrastructure Layer (Data access & external services)
- API Layer (Presentation / Controllers)

---

## 🗝️ Key Features

- 🔐 **JWT Authentication & Authorization**
  - Secure login system
  - Role-based access control

- 📚 **Book Management**
  - CRUD operations for books
  - Authors and categories management

- 🧩 **Modular Architecture**
  - Fully separated layers for scalability and maintainability

- 🗄️ **Entity Framework Core**
  - Efficient ORM-based data access

- ⚙️ **.NET 9.0 Modern Stack**
  - Clean and minimal API design

---

## 🧠 Design Principles

- Clean Architecture
- Separation of Concerns
- SOLID Principles
- Dependency Injection
- Modular Monolith Structure

---

## 🛠 Tech Stack

- ASP.NET Core (.NET 9)
- Entity Framework Core
- SQL Server
- JWT Authentication

---

## 🚀 Getting Started

### Prerequisites
- .NET 9 SDK
- SQL Server

### Run the project

```bash
dotnet restore
dotnet run
