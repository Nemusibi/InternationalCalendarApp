-- schema.sql
CREATE TABLE Events (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100),
    Date DATE,
    Description NVARCHAR(255)
);