# EFCore CRUD Application
A simple console application demonstrating CRUD (Create, Read, Update, Delete) operations using Entity Framework Core with SQL Server.

## Features
* Create: Insert new blog posts into the database
* Read: Display all active blog posts (excluding soft-deleted ones)
* Update: Modify existing blog posts by ID
* Delete: Soft delete blog posts (sets DeleteFlag to true instead of physical deletion)

## Project Structure
        text
        EFCore_CRUD/
        ├── Program.cs                 # Main application entry point
        ├── AppDbContext.cs            # Entity Framework DbContext configuration
        ├── EFCoreHelper.cs            # CRUD operations implementation
        └── Models/
            └── BlogDataModel.cs       # Blog entity model

## Prerequisites
* .NET 6.0 or later
* SQL Server (local or remote)
* Entity Framework Core packages

## Database Setup
The application uses the following database configuration:
* Server: Local SQL Server instance
* Database: TrainingBatch5
* Authentication: SQL Server Authentication (sa/user id)

## Required Database Table
        sql
        CREATE TABLE Blogs (
            BlogId INT PRIMARY KEY IDENTITY(1,1),
            BlogTitle NVARCHAR(MAX) NOT NULL,
            BlogAuthor NVARCHAR(MAX) NOT NULL,
            BlogContent NVARCHAR(MAX) NOT NULL,
            DeleteFlag BIT NOT NULL DEFAULT 0
        );

## Installation
1. Clone the repository:

        bash
        git clone https://github.com/thetnaing-dh/EFCore_CRUD_Application
        cd EFCore_CRUD

2. Update the connection string in AppDbContext.cs to match your SQL Server instance:

        csharp
        string connectionString = "Server=.;Database=TrainingBatch5;User Id=sa;Password=your_password;TrustServerCertificate=True;";

3. Restore NuGet packages:

        bash
        dotnet restore

## Usage
Run the application:

        bash
        dotnet run

## Available Commands
* R: Read all blog posts
* C: Create a new blog post
* U: Update an existing blog post
* D: Delete a blog post (soft delete)
* Any other key: Exit the application

## Example Workflow
1. Create a blog post:
  * Press 'C'
  * Enter title, author, and content when prompted
2. Read blog posts:
  * Press 'R' to view all active posts
3. Update a blog post:
  * Press 'U'
  * Enter the Blog ID to update
  * Provide new title, author, and/or content
4. Delete a blog post:
  * Press 'D'
  * Enter the Blog ID to soft delete

## Code Overview
### Key Components
BlogDataModel
Represents the blog entity with properties:
* BlogId (primary key)
* BlogTitle
* BlogAuthor
* BlogContent
* DeleteFlag (for soft deletion)

### AppDbContext
Configures the database connection and DbSet for Blog entities.

### EFCoreHelper
Contains methods for CRUD operations:
* ReadData(): Retrieves non-deleted blogs
* InsertData(): Adds new blogs
* UpdateData(): Modifies existing blogs
* DeleteData(): Performs soft deletion

## Entity Framework Core Features Used
* DbContext configuration
* LINQ queries with Where clauses
* Change tracking
* Entity states
* Soft delete pattern
* AsNoTracking for read-only operations

## Error Handling
The application includes basic error handling for:
* Invalid Blog ID inputs
* Non-existent records during update/delete operations
* Database connection issues

## Security Notes
⚠️ Important: This example uses SQL Server Authentication with a plaintext password. In production applications:
* Use Windows Authentication where possible
* Store connection strings securely (e.g., Azure Key Vault, environment variables)
* Avoid using sa account for application connections
* Implement proper password management

## Dependencies
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore

## License
This project is for educational purposes. Feel free to modify and use as needed.
