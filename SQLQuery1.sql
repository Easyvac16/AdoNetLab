CREATE DATABASE StationeryFirm;
USE StationeryFirm;

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY,
    ProductName NVARCHAR(100),
    ProductType NVARCHAR(50),
    Quantity INT,
    Cost DECIMAL(10, 2)
);

CREATE TABLE SalesManagers (
    ManagerID INT PRIMARY KEY IDENTITY,
    ManagerName NVARCHAR(100)
);

CREATE TABLE Sales (
    SaleID INT PRIMARY KEY IDENTITY,
    ProductID INT,
    ManagerID INT,
    CustomerCompany NVARCHAR(100),
    SoldQuantity INT,
    UnitPrice DECIMAL(10, 2),
    SaleDate DATE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (ManagerID) REFERENCES SalesManagers(ManagerID)
);



INSERT INTO Products (ProductName, ProductType, Quantity, Cost)
VALUES 
    ('Paper A4', 'Paper', 100, 50.99),
    ('Gel pen', 'Pen', 200, 10.50),
    ('Stationery knife', 'Other', 50, 30.25);
    
INSERT INTO Products (ProductName, ProductType, Quantity, Cost)
VALUES 
    ('Paper A5', 'Paper', 200, 70.00),
    ('Pencil', 'Pen', 100, 5.20),
    ('knife', 'Other', 25, 40.25);

INSERT INTO SalesManagers (ManagerName)
VALUES 
    ('Ivanov Ivan'),
    ('Petrov Petro'),
    ('Sidorov Sidir');

INSERT INTO Sales (ProductID, ManagerID, CustomerCompany, SoldQuantity, UnitPrice, SaleDate)
VALUES 
    (1, 1, 'Company "Horns and Hoofs"', 20, 60.00, '2024-02-15'),
    (2, 2, '"Rainbow" LLC', 50, 15.75, '2024-02-16'),
    (3, 3, 'KP "Druzhba"', 10, 35.99, '2024-02-17');

