# SafeVault - Secure Web Application

SafeVault is a secure ASP.NET Core MVC application designed to manage sensitive data while preventing common web vulnerabilities such as **SQL Injection** and **Cross-Site Scripting (XSS)**. It also implements **authentication** and **role-based authorization (RBAC)** to ensure only authorized users can access sensitive features.

---

## 📌 Features
- **Input Validation**: Sanitizes user input to remove malicious characters.
- **Parameterized Queries**: Prevents SQL Injection attacks.
- **XSS Protection**: Escapes user input before rendering.
- **Authentication**: Secure login system with hashed passwords using BCrypt.
- **Authorization**: Role-based access control (admin vs user).
- **Unit Tests**: NUnit tests to simulate SQL Injection, XSS, and unauthorized access.

---

## 🛠 Project Structure

SafeVault/
│
├── Controllers/
│   ├── SafeVaultController.cs        # Handles form submission and validation
│   └── AuthController.cs             # Handles login and role-based access
│
├── Models/
│   └── User.cs                       # User model with roles and password hash
│
├── Views/
│   ├── SafeVault/webform.cshtml      # Secure HTML form
│   └── Auth/Login.cshtml             # Login page
│   └── Auth/AdminDashboard.cshtml    # Admin-only page
│
├── DataAccess/
│   └── DatabaseHelper.cs             # Database operations with parameterized queries
│
├── Tests/
│   ├── TestInputValidation.cs        # Tests for SQL Injection and XSS
│   ├── TestAuth.cs                   # Tests for authentication and RBAC
│   └── TestSecurity.cs               # Tests confirming vulnerability fixes
│
├── appsettings.json                  # Database connection settings
├── Program.cs                        # ASP.NET Core entry point
├── SafeVault.csproj                  # Project configuration
├── database.sql                      # Database schema
├── README.md                         # Project documentation
└── SecuritySummary.md                # Vulnerability summary and fixes

---

## Setup Instructions

### 1. **Prerequisites**
- Install https://dotnet.microsoft.com/download (version 6 or later)
- SQL Server or MySQL
- VS Code or Visual Studio
- NUnit Test Adapter (for running tests)

---

### 2. **Database Setup**
Run the following SQL script to create the `Users` table:
```sql
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(100),
    Email VARCHAR(100),
    PasswordHash VARCHAR(255),
    Role VARCHAR(50)
);

Update appsettings.json with your database connection string:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=SafeVaultDB;Trusted_Connection=True;"
}

---

### 3. **Run the Application**

dotnet restore
dotnet run

### 4. Run Tests
Navigate to the Tests folder and run:
dotnet test
