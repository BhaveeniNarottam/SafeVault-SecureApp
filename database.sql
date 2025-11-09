CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(100),
    Email VARCHAR(100),
    PasswordHash VARCHAR(255),
    Role VARCHAR(50)
);
