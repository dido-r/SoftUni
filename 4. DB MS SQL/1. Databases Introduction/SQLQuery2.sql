INSERT INTO Towns (Id, Name)
VALUES 
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna');
INSERT INTO Minions (Id, Name, Age, TownId)
VALUES 
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', Null, 2);

CREATE TABLE People (
    [Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] nvarchar(200) NOT NULL,
    [Picture] VARBINARY NULL,
	CHECK (Picture < 200000),
    [Height] decimal (3,2) NULL,
    [Weight] decimal (5,2) NULL,
    [Gender] char(1) NOT NULL,
	[Birthdate] date NOT NULL,
	[Biography] nvarchar(MAX) NULL
);

INSERT INTO People (Name, Gender, Birthdate)
VALUES
('Dido', 'm', '1993-02-05'),
('Dimo', 'm', '1995-01-09'),
('Jana', 'f', '2000-06-08'),
('az', 'f', '2000-06-08'),
('ti', 'm', '2000-06-08')

CREATE TABLE Users (
    [Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Username] varchar(30) NOT NULL,
    [Password] varchar(26) NOT NULL,
    [ProfilePicture] VARBINARY NULL,
	CHECK (ProfilePicture < 900000),
    [LastLoginTime] datetime2 NULL,
    [IsDeleted] varchar(5) NULL,
);

INSERT INTO Users (Username, Password)
VALUES
('Dido131', 'StrongPass'),
('hoax12', '123456'),
('gamer666', '1Qser*'),
('scamer', 'blabla'),
('Gosho', 'azsymnomer1')

	CREATE TABLE Directors (
		[Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
		[DirectorName] varchar(20) NOT NULL,
		[Notes] varchar(20) NULL,
);
	INSERT INTO Directors (DirectorName)
	VALUES
	('Someone'),
	('Other'),
	('Ford'),
	('Dani'),
	('Joro')
	
	CREATE TABLE Genres (
		[Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
		[GenreName] varchar(20) NOT NULL,
		[Notes] varchar(20) NULL,
);
	INSERT INTO Genres (GenreName)
	VALUES
	('Rock'),
	('Jazz'),
	('Metal'),
	('Hip-Hop'),
	('Electrinic')

	CREATE TABLE Categories (
		[Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
		[CategoryName] varchar(20) NOT NULL,
		[Notes] varchar(20) NULL,
);
	INSERT INTO Categories (CategoryName)
	VALUES
	('Best'),
	('Good'),
	('Poor'),
	('Awful'),
	('Excellent')

	CREATE TABLE Movies (
		[Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
		[Title] varchar(20) NOT NULL,
		[DirectorId] int FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
		[CopyrightYear] varchar(20) NULL,
		[Length] varchar(20) NULL,
		[GenreId] int FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
		[CategoryId] int FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
		[Rating] varchar(20) NULL,
		[Notes] varchar(20) NULL
);
	INSERT INTO Movies (Title, DirectorId, GenreId, CategoryId)
	VALUES
	('Lord of the Rings', 2, 3, 1),
	('Seven', 1, 4, 3),
	('Requiem for a dream', 4, 2, 1),
	('Kids', 5, 1, 3),
	('1408', 4, 2, 3)

	CREATE TABLE Categories (
    [Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [CategoryName] varchar(50) NOT NULL,
    [DailyRate] int NULL,
    [WeeklyRate] int NULL,
    [MonthlyRate] int NULL,
    [WeekendRate] int NULL
);

INSERT INTO Categories (CategoryName)
VALUES ('Jeep');
INSERT INTO Categories (CategoryName)
VALUES ('Combi');
INSERT INTO Categories (CategoryName)
VALUES ('Sedan');

CREATE TABLE Cars (
    [Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [PlateNumber] int NOT NULL,
    [Manufacturer] varchar(20) NOT NULL,
    [Model] varchar(20) NOT NULL,
    [CarYear] int NOT NULL,
    [CategoryId] int FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
    [Doors] int NULL,
    [Picture] image NULL,
    [Condition] varchar(10) NULL,
    [Available] varchar(3) NULL
);

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId)
VALUES (9400, 'Audi', 'A4', 2017, 3);
INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId)
VALUES (1234, 'BMW', '3', 2010, 2);
INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId)
VALUES (7854, 'Mercedes', 'CLK', 2017, 1);

CREATE TABLE Employees (
    [Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [FirstName] varchar(20) NOT NULL,
    [LastName] varchar(20) NOT NULL,
    [Title] varchar(5) NULL,
    [Notes] int NULL
);

INSERT INTO Employees (FirstName, LastName)
VALUES ('Pesho', 'Peshov');
INSERT INTO Employees (FirstName, LastName)
VALUES ('Joro', 'Kolev');
INSERT INTO Employees (FirstName, LastName)
VALUES ('Marto', 'Marto');

CREATE TABLE Customers (
    [Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [DriverLicenceNumber] int NOT NULL,
    [FullName] varchar(30) NOT NULL,
    [Address] varchar(50) NULL,
    [City] varchar(15) NOT NULL,
    [ZIPCode] int NULL,
    [Notes] varchar(50) NULL
);

INSERT INTO Customers (DriverLicenceNumber, FullName, City)
VALUES (97845623, 'NqkoiSiTam', 'Nadaleko');
INSERT INTO Customers (DriverLicenceNumber, FullName, City)
VALUES (8621, 'Some', 'Jungle');
INSERT INTO Customers (DriverLicenceNumber, FullName, City)
VALUES (47853, 'Me', 'Hawaii');

CREATE TABLE RentalOrders (
    [Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [EmployeeId] int FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
    [CustomerId] int FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
    [CarId] int FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
    [TankLevel] int NOT NULL,
    [KilometrageStart] int NOT NULL,
    [KilometrageEnd] int NOT NULL,
    [TotalKilometrage] int NULL,
    [StartDate] date NULL,
    [EndDate] date NULL,
    [TotalDays] int NULL,
    [RateApplied] int NULL,
    [TaxRate] int NULL,
    [OrderStatus] int NULL,
	[Notes] varchar(50) NULL
);

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd)
VALUES 
(1, 2, 3, 25, 100, 120),
(2, 2, 1, 40, 10000, 10200),
(3, 1, 2, 10, 145670, 145980)

CREATE TABLE Employees (
    [Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [FirstName] varchar(20) NOT NULL,
    [LastName] varchar(20) NOT NULL,
    [Title] varchar(5) NULL,
    [Notes] int NULL
);

INSERT INTO Employees (FirstName, LastName)
VALUES ('Pesho', 'Peshov');
INSERT INTO Employees (FirstName, LastName)
VALUES ('Joro', 'Kolev');
INSERT INTO Employees (FirstName, LastName)
VALUES ('Marto', 'Marto');

CREATE TABLE Customers (
    [Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [AccountNumber] int NOT NULL,
    [FirstName] varchar(10) NOT NULL,
    [LastName] varchar(10) NOT NULL,
    [PhoneNumber] int NOT NULL,
    [EmergencyName] int NULL,
    [EmergencyNumber] int NULL,
    [Notes] varchar(50) NULL
);

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber)
VALUES (3845, 'Nedqlko', 'Ivanov', 0889658465);
INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber)
VALUES (8621, 'Some', 'Doe', 40758249);
INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber)
VALUES (47853, 'Me', 'Jonny', 0889654875);

CREATE TABLE RoomStatus (
    [RoomStatus] varchar(15) NOT NULL PRIMARY KEY,
    [Notes] varchar(50) NULL
);

INSERT INTO RoomStatus (RoomStatus)
VALUES ('Free');
INSERT INTO RoomStatus (RoomStatus)
VALUES ('Not Available');
INSERT INTO RoomStatus (RoomStatus)
VALUES ('Renovating');

CREATE TABLE RoomTypes (
    [RoomType] varchar(10) NOT NULL PRIMARY KEY,
    [Notes] varchar(50) NULL
);

INSERT INTO RoomTypes (RoomType)
VALUES ('Apartment');
INSERT INTO RoomTypes (RoomType)
VALUES ('Single');
INSERT INTO RoomTypes (RoomType)
VALUES ('Double');


CREATE TABLE BedTypes (
    [BedType] varchar(15) NOT NULL PRIMARY KEY,
    [Notes] varchar(50) NULL
);

INSERT INTO BedTypes (BedType)
VALUES ('Single');
INSERT INTO BedTypes (BedType)
VALUES ('Double');
INSERT INTO BedTypes (BedType)
VALUES ('Extra Large');

CREATE TABLE Rooms (
    [RoomNumber] int NOT NULL PRIMARY KEY,
    [RoomType] varchar(10) NOT NULL,
    [BedType] varchar(10) NOT NULL,
    [Rate] varchar(50) NULL,
    [RoomStatus] varchar(10) NOT NULL,
	[Notes] varchar(50) NULL
);

INSERT INTO Rooms (RoomNumber, RoomType, BedType, RoomStatus)
VALUES (124, 1, 2, 3);
INSERT INTO Rooms (RoomNumber, RoomType, BedType, RoomStatus)
VALUES (125, 3, 2 ,2);
INSERT INTO Rooms (RoomNumber, RoomType, BedType, RoomStatus)
VALUES (126, 1, 3, 1);

CREATE TABLE Payments (
    [Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [EmployeeId] int FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
    [PaymentDate] date  NULL,
    [AccountNumber] int NOT NULL,
    [FirstDateOccupied] date  NOT NULL,
    [LastDateOccupied] date  NOT NULL,
    [TotalDays] int  NULL,
    [AmountCharged] int NULL,
    [TaxRate] int  NULL,
    [TaxAmount] int  NULL,
    [PaymentTotal] int  NOT NULL,
    [Notes] varchar(50)  NULL
);

INSERT INTO Payments (EmployeeId, AccountNumber, FirstDateOccupied, LastDateOccupied, PaymentTotal)
VALUES (2, 3845, '2022-02-02', '2022-02-10', 750);
INSERT INTO Payments (EmployeeId, AccountNumber, FirstDateOccupied, LastDateOccupied, PaymentTotal)
VALUES (1, 8621, '2022-05-02', '2022-05-02', 80);
INSERT INTO Payments (EmployeeId, AccountNumber, FirstDateOccupied, LastDateOccupied, PaymentTotal)
VALUES (1, 47853, '2022-05-10', '2022-05-13', 150);

CREATE TABLE Occupancies (
    [Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [EmployeeId] int FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
    [DateOccupied] date NULL,
	[AccountNumber] int NOT NULL,
	[RoomNumber] int NOT NULL,
	[RateApplied] int NULL,
	[PhoneCharge] int NULL,
	[Notes] varchar(50) NULL
);

INSERT INTO Occupancies (EmployeeId, AccountNumber, RoomNumber)
VALUES 
(2, 3845, 124),
(3, 8621, 125),
(1, 47853, 126)

SELECT * FROM Towns;
SELECT * FROM Departments;
SELECT * FROM Employees;

SELECT * FROM Towns
ORDER BY Name ASC;

SELECT * FROM Departments
ORDER BY Name ASC;

SELECT * FROM Employees
ORDER BY Salary DESC;

SELECT Name
FROM Towns
ORDER BY Name ASC;

SELECT Name
FROM Departments
ORDER BY Name ASC;

SELECT FirstName, LastName, JobTitle, Salary
FROM Employees
ORDER BY Salary DESC;

UPDATE Employees
SET Salary *= 1.1;
SELECT Salary
FROM Employees;

UPDATE Payments
SET TaxRate *= 0.97;
SELECT TaxRate
FROM Payments;

TRUNCATE TABLE Occupancies;
