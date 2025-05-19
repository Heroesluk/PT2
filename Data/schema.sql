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
                        EventId INTEGER PRIMARY KEY AUTOINCREMENT,                        EventName NVARCHAR(50) NOT NULL,
                        Timestamp DATETIME NOT NULL,
                        UserId INT NOT NULL,
                        EventDescription NVARCHAR(255),
                        FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE PurchaseEvents (
                                EventId INT PRIMARY KEY,
                                ItemId INT NOT NULL,
                                Quantity INT NOT NULL,
                                FOREIGN KEY (EventId) REFERENCES Events(EventId),
                                FOREIGN KEY (ItemId) REFERENCES Items(Id)
);