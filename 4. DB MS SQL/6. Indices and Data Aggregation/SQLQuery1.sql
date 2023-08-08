SELECT COUNT(*) AS [Count] FROM WizzardDeposits

-- task 2

SELECT 
	   MAX(MagicWandSize) AS LongestMagicWand 
  FROM WizzardDeposits

  -- task 3

  SELECT 
         DepositGroup
         , MAX(MagicWandSize) AS LongestMagicWand 
    FROM WizzardDeposits
GROUP BY DepositGroup

  -- task 4

  SELECT TOP 2
		DepositGroup
   FROM
  (SELECT 
         DepositGroup AS DepositGroup
         , AVG (MagicWandSize) AS LongestMagicWand 
    FROM WizzardDeposits
GROUP BY DepositGroup) AS sub
ORDER BY LongestMagicWand

-- task 5

  SELECT 
	     DepositGroup
	     , SUM (DepositAmount) AS TotalSum
    FROM WizzardDeposits
GROUP BY DepositGroup

-- taks 6

  SELECT 
         DepositGroup
         , SUM (DepositAmount) AS TotalSum 
    FROM WizzardDeposits
   WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

-- task 7

 SELECT
        DepositGroup
        , TotalSum
   FROM
        (SELECT 
                DepositGroup
                , SUM (DepositAmount) AS TotalSum 
           FROM WizzardDeposits
          WHERE MagicWandCreator = 'Ollivander family'
       GROUP BY DepositGroup) AS sub
WHERE TotalSum < 150000
ORDER BY TotalSum DESC

-- task 8

  SELECT
	     DepositGroup
		 , MagicWandCreator
	     , MIN(DepositCharge) AS MinDepositCharge
    FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

-- task 9

  SELECT
         CASE
	     WHEN Age >= 0 AND Age <= 10 THEN '[0-10]' 
	     WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
	     WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
	     WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
	     WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
	     WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
	     WHEN Age >= 61 THEN '[61+]'
		 END AS AgeGroup
         , COUNT(*) AS WizardCount
    FROM WizzardDeposits
GROUP BY
		 CASE
	     WHEN Age >= 0 AND Age <= 10 THEN '[0-10]' 
	     WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
	     WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
	     WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
	     WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
	     WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
	     WHEN Age >= 61 THEN '[61+]'
		 END 

-- task 10

SELECT
	   FirstLetter
  FROM
 (SELECT
	     SUBSTRING(FirstName, 1, 1) AS FirstLetter
    FROM WizzardDeposits
   WHERE DepositGroup = 'Troll Chest'
GROUP BY FirstName) AS sub
GROUP BY FirstLetter

-- taks 11

   SELECT
	      DepositGroup
	      , IsDepositExpired
	      , AVG(DepositInterest) AS AverageInterest
     FROM WizzardDeposits
    WHERE DepositStartDate > '1985-01-01'
 GROUP BY DepositGroup, IsDepositExpired
 ORDER BY DepositGroup DESC, IsDepositExpired

-- task 12

 SELECT
		SUM([Host Wizard Deposit] - [Guest Wizard Deposit]) AS SumDifference
	FROM (SELECT
		w1.FirstName AS [Host Wizard]
		, w1.DepositAmount AS [Host Wizard Deposit]
		, LEAD(FirstName) OVER (ORDER BY Id) AS [Guest Wizard]
		, LEAD(DepositAmount) OVER (ORDER BY Id) AS [Guest Wizard Deposit]
   FROM WizzardDeposits AS w1) AS sub

-- taks 13

  SELECT
		 DepartmentID
		 , SUM(Salary) AS TotalSalary
	FROM Employees
GROUP BY DepartmentID

-- taks 14

  SELECT
		 DepartmentID
		 , MIN(Salary) AS MinimumSalary
	FROM Employees
   WHERE HireDate > '2000-01-01'
GROUP BY DepartmentID
  HAVING DepartmentID = 2 OR DepartmentID = 5 OR DepartmentID = 7

 -- taks 15

 CREATE TABLE NEW(
  EmployeeID int NOT NULL,
  FirstName VARCHAR(50) NOT NULL,
  LastName VARCHAR(50) NOT NULL,
  MiddleName VARCHAR(50) NULL,
  JobTitle VARCHAR(50) NOT NULL,
  DepartmentID int NOT NULL,
  ManagerID int NULL,
  HireDate smalldatetime NOT NULL,
  Salary money NOT NULL,
  AddressID int NULL,
)

INSERT INTO NEW (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
 SELECT
		*
   FROM Employees
  WHERE Salary > 30000

 DELETE FROM NEW WHERE ManagerID = 42

 UPDATE NEW
 SET Salary += 5000
 WHERE DepartmentID = 1

   SELECT
		  DepartmentID
		  , AVG(Salary) AS AverageSalary
	 FROM NEW
 GROUP BY DepartmentID

 -- task 16

   SELECT
		  DepartmentID
		  , MAX(Salary) AS MaxSalary
	 FROM Employees
 GROUP BY DepartmentID
   HAVING MAX(Salary) < 30000 OR MAX(Salary) > 70000

 -- task 17

   SELECT
		  COUNT(Salary) AS [Count]
	 FROM Employees
	WHERE ManagerID IS NULL

 -- task 18

  SELECT 
		 a.DepartmentID
		 , a.Salary
	FROM (SELECT 
				 DepartmentID
				 , Salary
				 , DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
			FROM Employees) AS a
		   WHERE SalaryRank = 3
		   GROUP BY a.DepartmentID, a.Salary

 -- taks 19

 SELECT TOP 10
	b.FirstName
	, b.LastName
	, b.DepartmentID
	FROM (SELECT
		e.FirstName AS FirstName
		, e.LastName AS LastName
		, e.DepartmentID AS DepartmentID
		, e.Salary AS Salary
		, s.AverageSAlary AS Avgslr
 FROM Employees AS e
 JOIN(
  SELECT
		 DepartmentID
		 , AVG(Salary) AS AverageSAlary
    FROM Employees
GROUP BY DepartmentID) AS s ON s.DepartmentID = e.DepartmentID) AS b
WHERE b.Salary > b.Avgslr
ORDER BY DepartmentID
 