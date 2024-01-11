# Hell Garage App - Backend Overview

## Description

Welcome to the Hell Garage Backend repository! This backend is designed to support the Hell Garage App, a project that follows the principles of Clean Architecture, Domain-Driven Design (DDD), Command Query Responsibility Segregation (CQRS), and is implemented using .NET 8. The project also adheres to best practices, including the use of the Unit of Work pattern to ensure data consistency.

## Technologies Used

- **.NET 8:** The backend is built on the .NET 8 framework, leveraging its latest features and improvements.

- **Clean Architecture:** The project is structured based on Clean Architecture principles, promoting separation of concerns and maintainability.

- **Domain-Driven Design (DDD):** The project follows the principles of DDD to model the domain and structure the codebase in a way that reflects the business logic.

- **CQRS (Command Query Responsibility Segregation):** CQRS is employed to separate the command and query responsibilities, optimizing the system for reads and writes independently.
  
-  **Entity Framework Core (EF Core):** The backend uses EF Core as the Object-Relational Mapping (ORM) framework for interacting with the database.

- **Result Types:** Instead of relying on exceptions for error handling, the project utilizes result types to represent the success or failure of operations. This approach promotes a more functional and explicit way of dealing with outcomes.

## Project Structure

The Hell Garage Backend is organized into distinct projects, each serving a specific purpose:

- **Domain:** Contains the core domain models and business logic. This project represents the heart of the application.

- **API:** Implements the RESTful API using Minimal API, with no traditional controllers. The project focuses on simplicity and minimalism for external communication.

- **Infrastructure:** Deals with external concerns such as databases, file systems, and third-party integrations.

- **Application:** Implements application-specific business rules and orchestrates interactions between the domain and infrastructure layers.

- **Shared:** Contains shared components, constants, and utilities used across different layers of the application.

- **Tests:** Includes unit tests for ensuring the correctness of the implemented features.

## Project Structure

The Hell Garage Backend is organized into distinct projects, each serving a specific purpose:

- **Domain:** Contains the core domain models and business logic. This project represents the heart of the application.

- **API:** Implements the RESTful API using Minimal API, with no traditional controllers. The project focuses on simplicity and minimalism for external communication.

- **Infrastructure:** Deals with external concerns such as databases, file systems, and third-party integrations.

- **Application:** Implements application-specific business rules and orchestrates interactions between the domain and infrastructure layers.

- **Shared:** Contains shared components, constants, and utilities used across different layers of the application.

- **Tests:** Includes unit tests for ensuring the correctness of the implemented features.

## Testing

- **Unit Tests:** The Hell Garage Backend includes a comprehensive suite of unit tests for entities. These tests ensure the correctness of the business logic and help maintain code quality.

- **Testing Framework:** We use the Fluent Assertions testing framework to write clear and expressive unit tests. This framework provides a fluent syntax for assertions, making the tests more readable and maintainable.

## Docker Compose

- **Containerization:** The Hell Garage Backend can be run using Docker Compose. The `docker-compose.yml` file included in the repository sets up the backend along with a Microsoft SQL Server database in separate containers.

- **How to Run:**
  1. Ensure Docker and Docker Compose are installed on your system.
  2. Navigate to the project directory.
  3. Run the following command:

    ```bash
    docker-compose up
    ```

This will start the Hell Garage Backend and the associated SQL Server database using Docker Compose. Feel free to explore the codebase, run tests, and interact with the system.

## Getting Started

To set up and run the Hell Garage Backend locally, follow these steps:

1. Clone the repository:

    ```bash
    git clone https://github.com/your-username/hell-garage-backend.git
    ```

2. Navigate to the project directory:

    ```bash
    cd hell-garage-backend
    ```

3. Install dependencies:

    ```bash
    dotnet restore
    ```

4. Run the application:

    ```bash
    dotnet run
    ```

This will start the Hell Garage Backend, and it will be ready to handle requests from the Hell Garage App.

Feel free to explore the codebase, and make sure to refer to the documentation for specific details on how to use the API and integrate it with the Hell Garage App frontend.
