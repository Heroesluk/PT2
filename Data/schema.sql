CREATE TABLE Users (
                       Id INTEGER PRIMARY KEY AUTOINCREMENT,                       Username NVARCHAR(50) NOT NULL UNIQUE,
                       Password NVARCHAR(50) NOT NULL,
                       Email NVARCHAR(100) NOT NULL
);

CREATE TABLE Items (
                       Id INTEGER PRIMARY KEY AUTOINCREMENT,                       Name NVARCHAR(100) NOT NULL,
                       Description NVARCHAR(255),
                       Price FLOAT NOT NULL
);

CREATE TABLE InventoryState (
                                ItemId INT PRIMARY KEY,
                                Quantity INT NOT NULL,
                                FOREIGN KEY (ItemId) REFERENCES Items(Id)
);

CREATE TABLE Events (
                        EventId INTEGER PRIMARY KEY AUTOINCREMENT,                        EventName NVARCHAR(50) ,
                        Timestamp DATETIME ,
                        UserId INT,
                        EventDescription NVARCHAR(255)
);

CREATE TABLE PurchaseEvents (
                                EventId INT PRIMARY KEY,
                                ItemId INT  ,
                                Quantity INT  
);



