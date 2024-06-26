USE ContactManagement;
GO

/**
CREATE TABLE Contact (
    ContactID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE
);
GO

CREATE TABLE Appointment (
    AppointmentID INT PRIMARY KEY IDENTITY(1,1),
    ContactID INT,
    AppointmentDate DATE,
    AppointmentTime TIME,
    Description TEXT,
    FOREIGN KEY (ContactID) REFERENCES Contact(ContactID)
);
GO
INSERT INTO Contact (FirstName, LastName, Email) VALUES
('Juan', 'Torres', 'j.torres@gmail.com'),
('Messi', 'Leonel', 'argentina@campeondelmundo.com'),
('Pedro', 'PedroPe', 'pedropedropedropedrope@hotmail.com');
GO

INSERT INTO Appointment (ContactID, AppointmentDate, AppointmentTime, Description) VALUES
(1, '2000-09-11', '10:00:00', 'Entrevista de trabajo'),
(2, '2024-06-27', '10:00:00', 'Clase de Framework'),
(3, '2021-07-01', '4:00:00', 'Training al nuevo');
GO

SELECT * FROM dbo.Contact;

SELECT * FROM dbo.Appointment;

CREATE PROCEDURE AddContact 
    @p_FirstName VARCHAR(50),
    @p_LastName VARCHAR(50),
    @p_Email VARCHAR(100)
AS
BEGIN
    INSERT INTO Contact (FirstName, LastName, Email) VALUES (@p_FirstName, @p_LastName, @p_Email);
END
GO

CREATE PROCEDURE UpdateContact 
    @p_ContactID INT,
    @p_FirstName VARCHAR(50),
    @p_LastName VARCHAR(50),
    @p_Email VARCHAR(100)
AS
BEGIN
    UPDATE Contact
    SET FirstName = @p_FirstName,
        LastName = @p_LastName,
        Email = @p_Email
    WHERE ContactID = @p_ContactID;
END
GO


CREATE PROCEDURE DeleteContact 
    @p_ContactID INT
AS
BEGIN
    DELETE FROM Contact WHERE ContactID = @p_ContactID;
END
GO
EXEC AddContact 'Juancho','Juanito','email';
EXEC UpdateContact 4, 'Mano','Pelada','gallo@gmail.com';

EXEC DeleteContact 4;

SELECT * FROM dbo.Contact;

ALTER TABLE dbo.Contact
ADD LastUpdated DATETIME DEFAULT GETDATE();
GO

CREATE TRIGGER TrAfterUpdateContact
ON dbo.Contact
AFTER UPDATE
AS
BEGIN
    UPDATE c
    SET c.LastUpdated = GETDATE()
    FROM dbo.Contact c
    INNER JOIN inserted i ON c.ContactID = i.ContactID;
END;
EXEC UpdateContact 1,'Juancho','Alcachofa','loslobos@gmail.com';
**/


