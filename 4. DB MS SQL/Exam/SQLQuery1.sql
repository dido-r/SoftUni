CREATE TABLE Owners(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
[Address] VARCHAR(50) NULL)

CREATE TABLE AnimalTypes(
Id INT PRIMARY KEY IDENTITY(1,1),
AnimalType VARCHAR(30) NOT NULL)

CREATE TABLE Cages(
Id INT PRIMARY KEY IDENTITY(1,1),
AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL)

CREATE TABLE Animals(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(30) NOT NULL,
BirthDate DATE NOT NULL,
OwnerId INT FOREIGN KEY REFERENCES Owners(Id) NULL,
AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL)

CREATE TABLE AnimalsCages(
CageId INT NOT NULL,
AnimalId INT NOT NULL,
CONSTRAINT PK_Primary PRIMARY KEY CLUSTERED(CageId, AnimalId),
CONSTRAINT FK_CageId FOREIGN KEY(CageId) REFERENCES Cages(Id),
CONSTRAINT FK_Animals FOREIGN KEY(AnimalId) REFERENCES Animals(Id))

CREATE TABLE VolunteersDepartments(
Id INT PRIMARY KEY IDENTITY(1,1),
DepartmentName VARCHAR(30) NOT NULL)

CREATE TABLE Volunteers(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
[Address] VARCHAR(50) NULL,
AnimalId INT FOREIGN KEY REFERENCES Animals(Id) NULL,
DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL)

--task 2

INSERT INTO Volunteers([Name], PhoneNumber, [Address], AnimalId, DepartmentId)
VALUES
('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
('Dimitur Stoev', '0877564223', NULL, 42, 4),
('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals([Name], BirthDate, OwnerId, AnimalTypeId)
VALUES
('Giraffe', '2018-09-21', 21, 1),
('Harpy Eagle', '2015-04-17', 15, 3),
('Hamadryas Baboon', '2017-11-02', NULL, 1),
('Tuatara', '2021-06-30', 2, 4)

-- task 3

UPDATE Animals
SET OwnerId = 4
WHERE OwnerId IS NULL

-- task 4

ALTER TABLE Volunteers
ALTER COLUMN DepartmentId INT NULL

UPDATE Volunteers
SET DepartmentId = NULL
WHERE DepartmentId = 2

DELETE FROM VolunteersDepartments WHERE Id = 2

-- task 5

  SELECT 
		 [Name]
		 , PhoneNumber
		 , [Address]
		 , AnimalId
		 , DepartmentId
	FROM Volunteers
ORDER BY [Name], AnimalId, DepartmentId DESC

-- task 6

  SELECT 
		 a.[Name]
		 , t.AnimalType
		 , FORMAT(a.BirthDate, 'dd.MM.yyyy') AS BirthDate
	FROM Animals AS a
	JOIN AnimalTypes AS t ON a.AnimalTypeId = t.Id
ORDER BY a.[Name]

-- task 7

  SELECT TOP 5
		 o.[Name] AS [Owner]
		 , COUNT(a.OwnerId) AS CountOfAnimals
	FROM Animals AS a
	JOIN Owners AS o ON a.OwnerId = o.Id
GROUP BY a.OwnerId, o.[Name]
ORDER BY CountOfAnimals DESC, o.[Name]

-- task 8

  SELECT 
		 CONCAT(o.[Name], '-', a.[Name]) AS OwnersAnimals
		 , o.PhoneNumber
		 , c.CageId
	FROM Animals AS a
	JOIN Owners AS o ON a.OwnerId = o.Id
	JOIN AnimalsCages AS c ON c.AnimalId = a.Id
	WHERE AnimalTypeId = 1
ORDER BY o.[Name], a.[Name] DESC

-- task 9

  SELECT 
		 v.[Name]
		 , v.PhoneNumber
		 , SUBSTRING(v.[Address], CHARINDEX('Sofia', v.[Address], 1) + 7, LEN(v.[Address]) - 7) AS [Address]
	FROM Volunteers AS v
	JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
   WHERE vd.DepartmentName = 'Education program assistant'
	 AND CHARINDEX('Sofia', v.[Address], 1) != 0
ORDER BY v.[Name]

-- task 10

  SELECT 
		 a.[Name]
		 , DATEPART(YEAR, BirthDate) AS BirthYear
		 , t.AnimalType
	FROM Animals AS a
	JOIN AnimalTypes AS t ON t.Id = a.AnimalTypeId
   WHERE a.OwnerId IS NULL
	 AND DATEDIFF(YEAR, BirthDate, '2022-01-01') < 5
	 AND AnimalTypeId != 3
ORDER BY a.[Name]

-- task 11

CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
RETURN
(SELECT COUNT(*)
FROM Volunteers AS v
JOIN VolunteersDepartments AS d ON v.DepartmentId = d.Id
WHERE d.DepartmentName = @VolunteersDepartment
GROUP BY v.DepartmentId)
END

-- task 12

CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
SELECT 
	   a.[Name]
	   ,CASE
	   WHEN a.OwnerId IS NOT NULL THEN o.[Name]
	   WHEN a.OwnerId IS NULL THEN 'For adoption'
	   END AS OwnersName
FROM Animals AS a
LEFT JOIN Owners AS o ON o.Id = a.OwnerId
WHERE a.[Name] = @AnimalName