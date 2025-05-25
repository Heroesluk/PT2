CREATE TABLE IF NOT EXISTS Users (
                                     Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                     Username TEXT NOT NULL UNIQUE,
                                     Password TEXT NOT NULL,
                                     Email TEXT NOT NULL UNIQUE
);

-- Add some initial data
INSERT OR IGNORE INTO Users (Username, Password, Email) VALUES
                                                            ('admin', 'admin123', 'admin@example.com'),
                                                            ('user1', 'pass123', 'user1@example.com');