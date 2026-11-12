-- =========================
-- DATABASE
-- =========================
CREATE DATABASE WMS_DB
GO

USE WMS_DB
GO

-- =========================
-- ROLE TABLE
-- =========================
CREATE TABLE Role (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RoleName VARCHAR(50) NOT NULL UNIQUE
)
GO

-- =========================
-- USER TABLE
-- =========================
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Email VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(20),
    RoleId INT NOT NULL,
    Status VARCHAR(50) NOT NULL DEFAULT 'Active',
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_User_Role
    FOREIGN KEY (RoleId) REFERENCES Role(RoleId)
)
GO

-- =========================
-- PERMISSION TABLE
-- =========================
CREATE TABLE Permission (
    PermissionId INT IDENTITY(1,1) PRIMARY KEY,
    PermissionName VARCHAR(100) NOT NULL UNIQUE
)
GO

-- =========================
-- ROLE-PERMISSION TABLE
-- =========================
CREATE TABLE RolePermission (
    RoleId INT NOT NULL,
    PermissionId INT NOT NULL,

    PRIMARY KEY (RoleId, PermissionId),

    FOREIGN KEY (RoleId) REFERENCES Role(RoleId),
    FOREIGN KEY (PermissionId) REFERENCES Permission(PermissionId)
)
GO

-- =========================
-- DRIVER (ENTITY)
-- =========================
CREATE TABLE Driver (
    DriverId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    LicenseNumber VARCHAR(50) NOT NULL UNIQUE,
    LicenseExpiryDate DATE NOT NULL, 
    VehicleAssigned VARCHAR(100),
    AvailabilityStatus VARCHAR(50) NOT NULL,

    CONSTRAINT FK_Driver_User
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
)
GO

-- =========================
-- WAREHOUSE SECTION
-- =========================
CREATE TABLE WarehouseSection (
    SectionId INT IDENTITY(1,1) PRIMARY KEY,
    SectionName VARCHAR(100) NOT NULL,
    Description VARCHAR(255),
    Status VARCHAR(50) NOT NULL
)
GO

-- =========================
-- STOCK
-- =========================
CREATE TABLE Stock (
    StockId INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    SectionId INT NOT NULL,
    QuantityAvailableKg DECIMAL(10,2) NOT NULL,
    ReorderLevelKg DECIMAL(10,2) NOT NULL,
    InventoryStatus VARCHAR(50) NOT NULL,

    CONSTRAINT FK_Stock_Section
    FOREIGN KEY (SectionId) REFERENCES WarehouseSection(SectionId)
)
GO

-- =========================
-- SUPPLIER
-- =========================
CREATE TABLE Supplier (
    SupplierId INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName VARCHAR(100) NOT NULL,
    ContactPerson VARCHAR(100),
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Address VARCHAR(255),
    Status VARCHAR(50) NOT NULL
)
GO

-- =========================
-- SUPPLIER ORDER
-- =========================
CREATE TABLE SupplierOrder (
    SupplierOrderId INT IDENTITY(1,1) PRIMARY KEY,
    SupplierId INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    TotalAmount DECIMAL(10,2) NOT NULL,

    CONSTRAINT FK_SupplierOrder_Supplier
    FOREIGN KEY (SupplierId) REFERENCES Supplier(SupplierId)
)
GO

-- =========================
-- OPTIONAL: STOCK TAKE SESSION (BETTER THAN Stock_Taker TABLE)
-- =========================
CREATE TABLE StockTakeSession (
    SessionId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    SectionId INT NOT NULL,
    SessionDate DATETIME NOT NULL DEFAULT GETDATE(),
    Status VARCHAR(50) NOT NULL,
    Notes VARCHAR(255),

    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (SectionId) REFERENCES WarehouseSection(SectionId)
)
GO

-- =========================
-- INSERT DEFAULT ROLES
-- =========================
INSERT INTO Role (RoleName) VALUES 
('AdminClerk'),
('WarehouseManager'),
('Packer'),
('Driver'),
('StockTaker')
GO

-- =========================
-- INSERT SAMPLE PERMISSIONS
-- =========================
INSERT INTO Permission (PermissionName) VALUES
('Create User'),
('Update User'),
('Delete User'),
('View User'),
('Manage Stock'),
('Manage Orders')
GO