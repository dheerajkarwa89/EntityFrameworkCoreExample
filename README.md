# EntityFrameworkCoreExample

Run below commands : 

Create database : 

CREATE TABLE Authors (
    AuthorId INT PRIMARY KEY,
    Name NVARCHAR(100)
);


CREATE TABLE Books (
    BookId INT PRIMARY KEY,
    Title NVARCHAR(200),
    AuthorId INT FOREIGN KEY REFERENCES Authors(AuthorId)
);


dotnet tool install --global dotnet-ef

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet ef dbcontext scaffold "Server=localhost\SQLEXPRESS;Database=BookStore;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models

Scaffold command will create models folder with entities
