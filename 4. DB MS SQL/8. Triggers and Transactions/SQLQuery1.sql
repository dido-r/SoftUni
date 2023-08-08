CREATE TABLE Logs(
LogId INT PRIMARY KEY IDENTITY (1,1),
AccountId INT,
OldSum DECIMAL (15,2),
NewSum DECIMAL (15,2))

CREATE TRIGGER tr_ChangedSum
ON Accounts FOR UPDATE
AS
INSERT INTO Logs (AccountId, OldSum, NewSum)
SELECT i.Id, d.Balance, i.Balance
FROM inserted AS i
JOIN deleted AS d ON d.Id = i.Id
WHERE i.Id = d.Id

-- task 2

CREATE TABLE NotificationEmails(
Id INT PRIMARY KEY IDENTITY (1,1),
Recipient INT, 
[Subject] VARCHAR (50), 
Body VARCHAR (100))

CREATE TRIGGER tr_CreateEmailForNewRecord
ON Accounts FOR UPDATE
AS
INSERT INTO NotificationEmails(Recipient, [Subject], Body)
SELECT 
	i.Id
	, CONCAT('Balance change for account: ', i.Id)
	, CONCAT('On ', GETDATE(),' your balance was changed from ', d.Balance, ' to ', i.Balance, '.')
FROM inserted AS i
JOIN deleted AS d ON d.Id = i.Id
WHERE i.Id = d.Id

-- task 3

CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL (18,4))
AS
BEGIN TRANSACTION
UPDATE Accounts
SET Balance = Balance + @MoneyAmount
WHERE Id = @AccountId
IF (@MoneyAmount < 0)
ROLLBACK
COMMIT

-- task 4

CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL (18,4))
AS
BEGIN TRANSACTION
UPDATE Accounts
SET Balance = Balance - @MoneyAmount
WHERE Id = @AccountId
IF (@MoneyAmount < 0)
ROLLBACK
COMMIT

-- task 5

CREATE PROC usp_TransferMoney (@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18,4))
AS
BEGIN TRANSACTION
EXEC dbo.usp_WithdrawMoney @SenderId, @Amount
EXEC dbo.usp_DepositMoney @ReceiverId, @Amount
COMMIT

-- task 6 and task 7

-- task 8

CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
VALUES(@emloyeeId, @projectID)
DECLARE @CurrentProjects INT
SET @CurrentProjects =  
(SELECT COUNT(ProjectID)
FROM EmployeesProjects
WHERE EmployeeID = @emloyeeId)
IF @CurrentProjects > 3
BEGIN
	ROLLBACK;
	THROW 50001, 'The employee has too many projects!', 1;
	RETURN;
END
COMMIT


-- task 9

CREATE TABLE Deleted_Employees(
EmployeeId INT PRIMARY KEY IDENTITY (1, 1),
FirstName VARCHAR(50),
LastName VARCHAR(50), 
MiddleName VARCHAR(50), 
JobTitle VARCHAR(50), 
DepartmentId INT, 
Salary MONEY)

CREATE TRIGGER tr_DeleteEmployee
ON Employees FOR DELETE
AS
INSERT INTO Deleted_Employees (FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
SELECT 
	d.FirstName
	, d.LastName
	, d.MiddleName
	, d.JobTitle
	, d.DepartmentId
	, d.Salary
FROM deleted AS d