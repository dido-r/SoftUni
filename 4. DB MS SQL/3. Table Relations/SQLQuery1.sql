CREATE TABLE Passports(
	PassportID INT PRIMARY KEY IDENTITY(101,1),
	PassportNumber VARCHAR(8) NOT NULL,
	)

	INSERT INTO Passports(PassportNumber)
	VALUES
	('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2')

CREATE TABLE Persons(
	PersonID INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(20) NOT NULL,
	Salary DECIMAL (7,2) NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Persons(FirstName, Salary, PassportID)
	VALUES
	('Roberto', 43300, 102),
	('Tom', 56100, 103),
	('Yana', 60200, 101)

	--task 2

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(20) NOT NULL,
	EstablishedOn DATE NOT NULL
)

INSERT INTO Manufacturers([Name], EstablishedOn)
	VALUES
	('BMW', '1916-03-07'),
	('Tesla', '2003-01-01'),
	('Lada', '1966-05-01')

	CREATE TABLE Models(
	ModelID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(15) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
	)

	INSERT INTO Models(Name, ManufacturerID)
	VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3)

	--task 3

	CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(15) NOT NULL,
	)
	
	INSERT INTO Students ([Name])
	VALUES
	('Mila'),
	('Toni'),
	('Ron')

	CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(15) NOT NULL,
	)

	INSERT INTO Exams ([Name])
	VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

	CREATE TABLE StudentsExams(
	StudentID INT,
	ExamID INT,
	CONSTRAINT PK_Key PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_Key1 FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_Key2 FOREIGN KEY(ExamID) REFERENCES Exams(ExamID),
	)

	--task 4

	CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(15) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
	)

	INSERT INTO Teachers (Name, ManagerID)
	VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101)

	--task 5

	CREATE TABLE Cities(
	CityID INT PRIMARY KEY,
	[Name] VARCHAR(50)
	)

	CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY,
	[Name] VARCHAR(50),
	Birthday DATE,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
	)

	CREATE TABLE Orders(
	OrderID INT PRIMARY KEY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
	)

	CREATE TABLE ItemTypes(
	ItemTypeID INT PRIMARY KEY,
	[Name] VARCHAR(50)
	)

	CREATE TABLE Items(
	ItemID INT PRIMARY KEY,
	[Name] VARCHAR(50),
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
	)

	CREATE TABLE OrderItems(
	OrderID INT,
	ItemID INT,
	CONSTRAINT PK_KeyOrder PRIMARY KEY(OrderID, ItemID),
	CONSTRAINT FK_Key1Order FOREIGN KEY(OrderID) REFERENCES Orders(OrderID),
	CONSTRAINT FK_Key2Order FOREIGN KEY(ItemID) REFERENCES Items(ItemID),
	)

	--task 6
	
	CREATE TABLE Majors(
	MojarID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
	)

	CREATE TABLE Subjects(
	SubjectID INT PRIMARY KEY,
	SubjectName VARCHAR(50) NOT NULL
	)

	CREATE TABLE Students(
	StudentID INT PRIMARY KEY,
	SubjectNumber VARCHAR(20) NOT NULL,
	SubjectName VARCHAR(50) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MojarID)
	)

	CREATE TABLE Payments(
	PaymentID INT PRIMARY KEY,
	PaymentDate DATE,
	PaymentAmount INT,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
	)

	CREATE TABLE Agenda(
	StudentID INT,
	SubjectID INT,
	CONSTRAINT PK_Primary PRIMARY KEY(StudentID, SubjectID),
	CONSTRAINT FK_Student FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_Subject FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID),
	)

	--task 9

	SELECT  
		Mountains.MountainRange
		, Peaks.PeakName
		, Peaks.Elevation
	FROM Mountains
	JOIN Peaks ON Peaks.MountainId = Mountains.Id
	WHERE Mountains.MountainRange = 'Rila'
	ORDER BY Peaks.Elevation DESC
