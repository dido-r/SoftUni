CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
SELECT
	   FirstName
	   , LastName
FROM Employees
WHERE Salary > 35000

-- task 2

GO
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18,4))
AS
SELECT
	FirstName
	, LastName
FROM Employees
WHERE Salary >= @Number
GO

--task 3

GO

CREATE PROC usp_GetTownsStartingWith(@StartString VARCHAR(50))
AS
SELECT
	[Name]
FROM Towns
WHERE CHARINDEX(@StartString, [Name], 1) = 1

GO

--task 4

CREATE PROC usp_GetEmployeesFromTown(@TownName VARCHAR(50))
AS
SELECT
	e.FirstName
	, e.LastName
FROM Employees AS e
LEFT JOIN Addresses AS a ON e.AddressID = a.AddressID
LEFT JOIN Towns AS t ON a.TownID = t.TownID
WHERE t.[Name] = @TownName

--task 5

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
DECLARE @Result VARCHAR(7)
IF(@salary < 30000)
SET @Result = 'Low'
ELSE IF(@salary BETWEEN 30000 AND 50000)
SET @Result = 'Average'
ELSE
SET @Result = 'High'
RETURN @Result 
END

SELECT 
	Salary
	, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
FROM Employees

-- task 6

CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(7))
AS
SELECT  
		sub.FirstName
		, sub.LastName
FROM
	(SELECT 
	FirstName
	, LastName
	, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
FROM Employees) AS sub
WHERE sub.[Salary Level] = @salaryLevel

-- task 7

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(20), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
DECLARE @charResult INT
DECLARE @result BIT
SET @result = 1
DECLARE @wordLenght INT
SET @wordLenght = LEN(@word)
DECLARE @count INT
SET @count = 1
WHILE @count <= @wordLenght
BEGIN
SET @charResult = CHARINDEX(SUBSTRING(@word, @count, 1), @setOfLetters, 1)
IF (@charResult = 0)
SET @result = 0
SET @count = @count + 1
END
RETURN @result
END

-- task 8



--task 9

CREATE PROC usp_GetHoldersFullName
AS
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
FROM AccountHolders

--task 10

CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number MONEY)
AS
SELECT
	ah.FirstName
	, ah.LastName
FROM AccountHolders AS ah
JOIN
(SELECT 
	a.AccountHolderId
	, SUM(Balance) AS Balance
FROM Accounts AS a
JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
GROUP BY AccountHolderId) AS sub ON ah.Id = sub.AccountHolderId
WHERE sub.Balance > @number
ORDER BY ah.FirstName, ah.LastName

-- task 11

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue (@sum DECIMAL (15,4), @interestRate FLOAT, @years INT)
RETURNS DECIMAL (15,4)
AS
BEGIN
RETURN @sum* (POWER((1+@interestRate), @years))
END

-- task 12

CREATE OR ALTER PROC usp_CalculateFutureValueForAccount (@accountId INT,  @interestRate FLOAT)
AS
SELECT 
	ah.Id AS [Account Id]
	, ah.FirstName AS [First Name]
	, ah.LastName AS [Last Name]
	, a.Balance AS [Current Balance]
	, dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
FROM AccountHolders AS ah
JOIN Accounts AS a ON a.Id = ah.Id
WHERE ah.Id = @accountId

-- task 13

CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN
SELECT SUM(sub.Cash) AS SumCash
  FROM (SELECT 
  	   g.[Name]
  	   , ug.Cash
  	   , ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNumber
FROM UsersGames AS ug
JOIN Games AS g ON ug.GameId = g.Id
WHERE g.[Name] = @gameName ) AS sub
WHERE (RowNumber % 2 != 0)
