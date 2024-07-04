
Use Biblioteca;
GO
/**
CREATE TABLE Book (
    BookID INT PRIMARY KEY IDENTITY(1,1),
    Book VARCHAR(50) NOT NULL,
    Author VARCHAR(50) NOT NULL,
	ReleaseYear DATE


);
CREATE TABLE Author (
    AuthorID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL
);
INSERT INTO dbo.Book (Book, Author, ReleaseYear) VALUES 
('Twilight', 'J.K Rowling', '2006-6-6'),
('Chainsaw Man', 'Fujimoto', '2019-9-6'),
('Juan Bobo', 'Juan Carlos Rivera', '1969-6-9');
GO
INSERT INTO dbo.Author(FirstName, LastName) VALUES 
('Bruja', 'Rowling'),
('Tatsuki', 'Fujimoto'),
('Juan', 'Rivera');
GO
SELECT * FROM dbo.Author;
**/



