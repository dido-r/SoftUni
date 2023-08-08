SELECT
	FirstName
	, LastName
FROM Employees
WHERE LEFT(FirstName, 2) = 'Sa'

--task 2

SELECT
	FirstName
	, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--task 3

SELECT
	FirstName
FROM Employees
WHERE (DepartmentID = 3 OR DepartmentID = 10)
AND (HireDate BETWEEN '1994' AND '2006')

--task 4

SELECT
	FirstName
	, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--task 5

SELECT [Name]
FROM Towns
WHERE LEN([Name]) BETWEEN 5 AND 6
ORDER BY [Name]

--task 6

SELECT
	TownID
	, [Name]
FROM Towns
WHERE LEFT([Name], 1) = 'M' OR LEFT([Name], 1) = 'K' OR LEFT([Name], 1) = 'B' OR LEFT([Name], 1) = 'E'
ORDER BY [Name]

--task 7

SELECT
	TownID
	, [Name]
FROM Towns
WHERE LEFT([Name], 1) != 'R' AND LEFT([Name], 1) != 'B' AND LEFT([Name], 1) != 'D'
ORDER BY [Name]

--task 8

CREATE VIEW [V_EmployeesHiredAfter2000] AS
SELECT
	FirstName
	, LastName
FROM Employees
WHERE CAST(DATEPART(YEAR, HireDate) AS INT) > 2000

--task 9

SELECT 
	FirstName
	, LastName
FROM Employees
WHERE LEN(LastName) = 5

--task 10

SELECT 
	EmployeeID
	, FirstName
	, LastName
	, Salary
	, DENSE_RANK () OVER (PARTITION BY Salary ORDER BY EmployeeID ASC) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000 
ORDER BY Salary DESC

--task 11

SELECT
	EmployeeID
	, FirstName
	, LastName
	, Salary
	, 2 AS [Rank]
	FROM(
SELECT 
	EmployeeID
	, FirstName
	, LastName
	, Salary
	, DENSE_RANK () OVER (PARTITION BY Salary ORDER BY EmployeeID ASC) AS [Rank]
FROM Employees
) subquery
WHERE [Rank] = 2
AND (Salary BETWEEN 10000 AND 50000)
ORDER BY Salary DESC

--task 12

SELECT
	CountryName
	, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--taks 13

SELECT
	PeakName
	, RiverName
	, CONCAT(LOWER(PeakName), LOWER(SUBSTRING(RiverName, 2 , LEN(RiverName) - 1))) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

--taks 14

SELECT TOP(50) 
	[Name]
	, FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

-- task 15

SELECT
	Username
	, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email) + 1) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username

-- task 16

SELECT
	Username
	, IpAddress
FROM Users
WHERE IpAddress LIKE '[0-9]{3}.1[0-9]{1,}.[0-9]{1,}.[0-9]{3}$'
ORDER BY Username

-- task 17

SELECT 
	[Name]
	,CASE 
	WHEN DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
	WHEN DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
	WHEN DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
	END AS 'Part of the Day'
	,CASE 
	WHEN Duration IS NULL THEN 'Extra Long'
	WHEN Duration <= 3 THEN 'Extra Short'
	WHEN Duration <= 6 THEN 'Short'
	WHEN Duration > 6 THEN 'Long'
	END AS 'Duration'
FROM Games
ORDER BY [Name], Duration

-- task 18

SELECT 
	ProductName
	, OrderDate
	, DATEADD(DAY, 3, OrderDate) AS [Pay Due]
	, DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders

-- taks 19

CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(20),
	Birthdate DATETIME2
)

INSERT INTO People ([Name], Birthdate)
VALUES 
('Victor', '2000-12-07'),
('Steven', '1992-09-10'),
('Stephen', '1910-09-19'),
('John', '2010-01-06')

SELECT 
	[Name]
	, DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years]
	, DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months]
	, DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days]
	, DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People
