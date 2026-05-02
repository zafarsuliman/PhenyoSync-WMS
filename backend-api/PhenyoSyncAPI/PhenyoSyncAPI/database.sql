CREATE DATABASE WMS_DB
GO

USE WMS_DB
GO

CREATE TABLE [User] (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Email VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(20),
    Role VARCHAR(50) NOT NULL
)
GO

CREATE TABLE AdminClerk (
    AdminClerkId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    EmployeeNumber VARCHAR(50) NOT NULL UNIQUE,
    AccessLevel VARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_AdminClerk_User
    FOREIGN KEY (UserId) REFERENCES [User](UserId)
)
GO

CREATE TABLE WarehouseManager (
    WarehouseManagerId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    ManagerCode VARCHAR(50) NOT NULL UNIQUE,
    WarehouseSection VARCHAR(100) NOT NULL,

    CONSTRAINT FK_WarehouseManager_User
    FOREIGN KEY (UserId) REFERENCES [User](UserId)
)
GO

CREATE TABLE Packer (
    PackerId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Shift VARCHAR(50) NOT NULL,
    AssignedSection VARCHAR(100) NOT NULL,

    CONSTRAINT FK_Packer_User
    FOREIGN KEY (UserId) REFERENCES [User](UserId)
)
GO

CREATE TABLE Driver (
    DriverId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    LicenseNumber VARCHAR(50) NOT NULL UNIQUE,
    LicenseExpiryDate DATE NOT NULL, 
    VehicleAssigned VARCHAR(100),
    AvailabilityStatus VARCHAR(50) NOT NULL,

    CONSTRAINT FK_Driver_User
    FOREIGN KEY (UserId) REFERENCES [User](UserId)
)
GO

CREATE TABLE Stock_Taker (
    stocktaker_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    assigned_warehouse_zone VARCHAR(100) NOT NULL,
    last_stock_take_date DATE,
    accuracy_score DECIMAL(5,2),

    CONSTRAINT FK_StockTaker_User
    FOREIGN KEY (user_id) REFERENCES [User](UserId)
)
GO

CREATE TABLE Supplier (
    Supplier_id INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName VARCHAR(100) NOT NULL,
    ContactPerson VARCHAR(100),
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Address VARCHAR(255),
    Status VARCHAR(50) NOT NULL
)
GO

CREATE TABLE SupplierOrder (
    SupplierOrder_id INT IDENTITY(1,1) PRIMARY KEY,
    Supplier_id INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    TotalAmount DECIMAL(10,2) NOT NULL,

    CONSTRAINT FK_SupplierOrder_Supplier
    FOREIGN KEY (Supplier_id) REFERENCES Supplier(Supplier_id)
)
GO

CREATE TABLE WarehouseSection (
    Section_id INT IDENTITY(1,1) PRIMARY KEY,
    SectionName VARCHAR(100) NOT NULL,
    Description VARCHAR(255),
    Status VARCHAR(50) NOT NULL
)
GO

CREATE TABLE Stock (
    Stock_id INT IDENTITY(1,1) PRIMARY KEY,
    Product_id INT NOT NULL,
    Section_id INT NOT NULL,
    QuantityAvailableKg DECIMAL(10,2) NOT NULL,
    ReorderLevelKG DECIMAL(10,2) NOT NULL,
    InventoryStatus VARCHAR(50) NOT NULL,

    CONSTRAINT FK_Stock_Section
    FOREIGN KEY (Section_id) REFERENCES WarehouseSection(Section_id)

    -- Add this later when your Product table exists:
    -- CONSTRAINT FK_Stock_Product
    -- FOREIGN KEY (Product_id) REFERENCES Product(Product_id)
)
GO