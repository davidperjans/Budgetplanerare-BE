-- User-tabellen
CREATE TABLE Users (
    UserId UNIQUEIDENTIFIER PRIMARY KEY,
    Username NVARCHAR(100),
    Email NVARCHAR(255),
    PasswordHash NVARCHAR(255),
    Currency NVARCHAR(10),
    DefaultCategoryId UNIQUEIDENTIFIER
);

-- Category-tabellen
CREATE TABLE Categories (
    CategoryId UNIQUEIDENTIFIER PRIMARY KEY,
    UserId UNIQUEIDENTIFIER,
    Name NVARCHAR(100),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

-- Transaction-tabellen
CREATE TABLE Transactions (
    TransactionId UNIQUEIDENTIFIER PRIMARY KEY,
    UserId UNIQUEIDENTIFIER,
    Amount DECIMAL(18,2),
    Description NVARCHAR(255),
    Date DATETIME,
    CategoryId UNIQUEIDENTIFIER,
    Type NVARCHAR(10) CHECK (Type IN ('Income', 'Expense')),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

