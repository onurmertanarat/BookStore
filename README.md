# BookStore API - A Clean Architecture .NET Project

This project is a comprehensive BookStore REST API built with ASP.NET Core. It is designed to showcase a professional, multi-layered application architecture based on **Clean Architecture** principles and the **CQRS (Command Query Responsibility Segregation)** pattern.

<p>
  <img src="https://github.com/onurmertanarat/BookStore/blob/main/assets/book-store.gif" alt="Swagger UI Demo GIF">
</p>

---

## Architectural Overview

The application is built with a clear separation of concerns, dividing the logic into distinct, decoupled layers. This makes the codebase scalable, maintainable, and highly testable.

A typical request flows through the application as follows:
`Request -> Middleware -> Controller -> Application (Command/Query) -> DbContext -> Database`

* **Controllers:** A thin layer responsible only for receiving HTTP requests and returning responses. It delegates all business logic to the Application layer.
* **Application:** The core business logic layer. It is strictly divided into:
    * **Commands:** Operations that change the state of the application (Create, Update, Delete).
    * **Queries:** Operations that read and return data without changing state.
* **DBOperations & Entities:** The data access and domain layer, built with Entity Framework Core. It defines the database context, entities, and data seeding logic.
* **Common, Services, Middlewares:** Cross-cutting concerns such as object mapping (AutoMapper), custom logging, and global exception handling.

---

## Key Features & Patterns Implemented

* **CQRS Pattern:** Clean separation of read and write operations for better performance and scalability.
* **Dependency Injection:** Heavily used throughout the application (e.g., `IBookStoreDbContext`, `ILoggerService`) to create a decoupled and testable codebase.
* **AutoMapper:** For clean and automated mapping between database entities and view models (DTOs).
* **FluentValidation:** For externalized, readable, and powerful validation rules.
* **Custom Middleware:** A custom middleware handles global exception catching and provides detailed request/response logging, including request duration.
* **Soft Deletes:** The `Genre` entity uses an `IsActive` flag, and queries are filtered to exclude inactive records, demonstrating a robust data management strategy.
* **In-Memory Database:** Utilizes an in-memory database for easy setup, development, and testing without requiring an external database connection.
* **Swagger/OpenAPI:** Automatic and interactive API documentation is generated for all endpoints.

---

## Technology Stack

* .NET 6 (or your version)
* ASP.NET Core
* Entity Framework Core (with In-Memory Provider)
* AutoMapper
* FluentValidation
* Swagger (Swashbuckle)

---

## Setup and Usage

### Prerequisites

* .NET SDK 6.0 (or your version)
* A code editor like Visual Studio or VS Code

### Installation

1.  **Clone the repository:**
    ```sh
    git clone [https://github.com/onurmertanarat/BookStore.git](https://github.com/onurmertanarat/BookStore.git)
    cd BookStore
    ```

2.  **Restore dependencies:**
    ```sh
    dotnet restore
    ```

### Running the Application

1.  **Run the project from the terminal:**
    ```sh
    dotnet run
    ```

2.  The application will start, automatically seed the in-memory database with sample data, and listen on the configured ports (e.g., `http://localhost:5000` and `https://localhost:5001`).

3.  **Explore the API with Swagger:**
    Open your browser and navigate to **`http://localhost:5000/swagger`**. You will see an interactive UI where you can explore and test all the API endpoints.

---

## API Endpoints

The API provides full CRUD functionality for `Books`, `Authors`, and `Genres`.

**Example Endpoints for Books:**
* `GET /Books`
* `GET /Books/{id}`
* `POST /Books`
* `PUT /Books/{id}`
* `DELETE /Books/{id}`

---

## Contact

Onur Mert Anarat

[linkedin.com/in/onurmertanarat](https://www.linkedin.com/in/onurmertanarat)
