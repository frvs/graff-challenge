CREATE TABLE Persons (
  Id varchar(36) PRIMARY KEY, 
  Name VARCHAR(100) NOT NULL
);

CREATE TABLE Bids (
  Id varchar(36) PRIMARY KEY, 
  ProductId VARCHAR(36) NOT NULL,
  OwnerId VARCHAR(36) NOT NULL,
  Value decimal NOT NULL,
);

CREATE TABLE Products (
  Id varchar(36) PRIMARY KEY, 
  Name VARCHAR(100) NOT NULL, 
  InitialValue decimal NOT NULL, 
);