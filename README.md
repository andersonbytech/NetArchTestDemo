# NetArchTest Demo 🚧

This project demonstrates how to use **NetArchTest** to validate architectural rules in a .NET solution. Inspired by concepts from the book **"Software Architecture: The Hard Parts"**, the project implements **Fitness Functions** to ensure that the architecture remains clean and maintainable.

---

## 🛠 Project Structure

The project is divided into three layers:
- **Controllers**: Handles HTTP requests and delegates logic to the Services.
- **Services**: Contains the business logic and communicates with Repositories.
- **Repositories**: Responsible for data access.

Each layer has specific architectural rules validated using **NetArchTest**.

---

## 🎯 Goals and Rules

### Architectural Rules:
1. **Controllers**:
   - Should only depend on **Services**.
   - Must not directly depend on **Repositories** or external namespaces.

2. **Services**:
   - Should only depend on **Repositories** or other **Services**.
   - Must not depend on **Controllers** or external namespaces.

3. **Repositories**:
   - Should remain isolated and not depend on other layers.

---

## ❌ How to Introduce a Violation

You can test the effectiveness of the architectural rules by deliberately introducing a violation in your code. For example:

1. **Controllers Violating Rules**:
   - Add a dependency from a Controller directly to a Repository.
   - Example:
     ```csharp
     using NetArchTestDemo.Repositories; // Forbidden dependency

     public class ExampleController
     {
         private readonly ExampleRepository _repository; // Violation
         public ExampleController(ExampleRepository repository)
         {
             _repository = repository;
         }
     }
     ```

2. **Services Violating Rules**:
   - Add a dependency from a Service directly to a Controller.
   - Example:
     ```csharp
     using NetArchTestDemo.Controllers; // Forbidden dependency

     public class ExampleService
     {
         private readonly ExampleController _controller; // Violation
         public ExampleService(ExampleController controller)
         {
             _controller = controller;
         }
     }
     ```

3. **Repositories Violating Rules**:
   - Add a dependency from a Repository to a Controller or Service.
   - Example:
     ```csharp
     using NetArchTestDemo.Controllers; // Forbidden dependency

     public class ExampleRepository
     {
         private readonly ExampleController _controller; // Violation
         public ExampleRepository(ExampleController controller)
         {
             _controller = controller;
         }
     }
     ```

Run the tests after making these changes to confirm that they correctly fail and highlight the violations.

---

## 🚀 Getting Started

### Prerequisites
- .NET 6 or higher
- Visual Studio 2022 or another .NET-supported IDE

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/netarchtest-demo.git
