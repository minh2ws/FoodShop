CREATE DATABASE TheFoodHouse

USE TheFoodHouse

CREATE TABLE tblCategory (
    idCategory NVARCHAR(20) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL
)

CREATE TABLE tblProducts (
    idProduct INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    price FLOAT NOT NULL,
    quantity INT NOT NULL,
    status BIT NOT NULL,
    idCategory NVARCHAR(20) FOREIGN KEY REFERENCES tblCategory(idCategory)
)

CREATE TABLE tblCustomers (
    idCustomer INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    phone INT NOT NULL,
    address NTEXT NULL,
    point FLOAT NOT NULL,
)

CREATE TABLE tblEmployees (
    idEmployee INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    password VARCHAR(20) NOT NULL,
    role NVARCHAR(20) NOT NULL,
    status BIT NOT NULL
)

CREATE TABLE tblCategoryLogs (
    idEmployee INT FOREIGN KEY REFERENCES tblEmployees(idEmployee),
    idCategory NVARCHAR(20) FOREIGN KEY REFERENCES tblCategory(idCategory),
    status NVARCHAR(20),
    modifyDate DATE,
    PRIMARY KEY(idEmployee, idCategory)
)

CREATE TABLE tblProductLogs (
    idEmployee INT FOREIGN KEY REFERENCES tblEmployees(idEmployee),
    idProduct INT FOREIGN KEY REFERENCES tblProducts(idProduct),
    status NVARCHAR(20),
    modifyDate DATE,
    PRIMARY KEY(idEmployee, idProduct)
)

CREATE TABLE tblOrder(
    idOrder NVARCHAR(30) PRIMARY KEY,
    idCustomer INT FOREIGN KEY REFERENCES tblCustomers(idCustomer),
    idEmployee INT FOREIGN KEY REFERENCES tblEmployees(idEmployee),
    priceSum FLOAT NOT NULL,
    discount FLOAT NOT NULL,
    priceTotal FLOAT NOT NULL,
    orderDate DATETIME
)

CREATE TABLE tblOrderDetail(
    idOrder NVARCHAR(30) FOREIGN KEY REFERENCES tblOrder(idOrder),
    idProduct INT FOREIGN KEY REFERENCES tblProducts(idProduct),
    quantity INT NOT NULL,
    price FLOAT NOT NULL,
    PRIMARY KEY(idOrder, idProduct)
)
