SELECT TOP 5
	e.EmployeeID
	, e.JobTitle
	, e.AddressID
	, a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY AddressID ASC

-- task 2

SELECT TOP 50
	e.FirstName
	, e.LastName
	, t.[Name] AS Town
	, a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY FirstName, LastName

-- task 3

SELECT
	EmployeeID
	, FirstName
	, LastName
	, d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID

-- task 4

SELECT TOP 5
	EmployeeID
	, FirstName
	, Salary
	, d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

-- taks 5

SELECT TOP 3
	e.EmployeeID
	, e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS p ON p.EmployeeID = e.EmployeeID
WHERE p.ProjectID IS NULL
ORDER BY EmployeeID 

-- task 6

SELECT
	FirstName
	, LastName
	, HireDate
	, d.[Name] AS DeptName
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE (d.[Name] = 'Sales' OR d.[Name] = 'Finance')
	AND HireDate > '1999-01-01'
ORDER BY HireDate

-- task 7

SELECT TOP 5
	e.EmployeeID
	, e.FirstName
	, p.[Name] AS ProjectName
FROM Projects AS p
RIGHT JOIN EmployeesProjects AS ep ON ep.ProjectID = p.ProjectID
JOIN Employees AS e ON e.EmployeeID = ep.EmployeeID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

-- task 8

SELECT
	ep.EmployeeID
	, e.FirstName,
	CASE
	WHEN p.StartDate >= '2005-01-01' THEN NULL
	ELSE p.[Name]
	END AS ProjectName
FROM EmployeesProjects AS ep
JOIN Employees AS e ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE ep.EmployeeID = 24

-- task 9

SELECT
	e.EmployeeID
	, e.FirstName
	, e.ManagerID
	, m.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS m ON m.EmployeeID = e.ManagerID
WHERE e.ManagerID = 3 OR e.ManagerID = 7
ORDER BY EmployeeID

-- taks 10

SELECT TOP 50
	e.EmployeeID
	, CONCAT (e.FirstName, ' ', e.LastName) AS EmployeeName
	, CONCAT (m.FirstName, ' ', m.LastName) AS ManagerName
	, d.[Name]
FROM Employees AS e
JOIN Employees AS m ON m.EmployeeID = e.ManagerID
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
ORDER BY EmployeeID

-- task 11

SELECT
	MIN(b.AverageSalaryPerDept)
FROM (SELECT
	e.DepartmentID
	, AVG(e.Salary) AS AverageSalaryPerDept
FROM Employees AS e
GROUP BY e.DepartmentID) AS b

-- taks 12

SELECT 
	mc.CountryCode
	, m.MountainRange
	, p.PeakName
	, p.Elevation
FROM Peaks AS p
JOIN MountainsCountries AS mc ON mc.MountainId = p.MountainId
JOIN Mountains AS m ON m.Id = p.MountainId
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

-- task 13

SELECT
	CountryCode
	, COUNT(*) AS MountainRanges
FROM MountainsCountries
WHERE CountryCode = 'BG' OR CountryCode = 'RU' OR CountryCode = 'US'
GROUP BY CountryCode

-- task 14

SELECT TOP 5
	c.CountryName
	, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

-- task 15

   	SELECT 
		sub.ContinentCode
		, sub.CurrencyCode
		, sub.CurrencyUsage
	FROM (SELECT
		   b.ContinentCode AS ContinentCode
		   , b.CurrencyCode
		   , b.Usage AS CurrencyUsage
		   , RANK() OVER (PARTITION BY b.ContinentCode ORDER BY b.Usage DESC) AS Ranking
	  FROM Countries AS c

JOIN(	
	SELECT 
		   a.ContinentCodeX AS ContinentCode
		   , a.CurrencyCodeX AS CurrencyCode
		   , MAX(a.MaxUsage) AS Usage
	  FROM
			(SELECT
					x.ContinentCode AS ContinentCodeX
					, x.CurrencyCode AS CurrencyCodeX
					, COUNT(CurrencyCode) AS MaxUsage
			   FROM Countries AS x
		   GROUP BY ContinentCode, CurrencyCode) AS a
		   GROUP BY a.ContinentCodeX, a.CurrencyCodeX) AS b ON b.ContinentCode = c.ContinentCode

  GROUP BY b.ContinentCode, b.CurrencyCode, b.Usage) AS sub
  WHERE sub.Ranking = 1 AND sub.CurrencyUsage > 1

-- task 16

SELECT
	COUNT(*) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS m ON c.CountryCode = m.CountryCode
WHERE m.MountainId IS NULL

-- task 17

SELECT TOP 5
	one.CountryName AS CountryName
	, MAX(one.MaxElevation) AS HighestPeakElevation
	, MAX(two.[Length]) AS LongestRiverLength
FROM

	(SELECT
		MAX(Elevation) AS MaxElevation
		, a.CountryName
	FROM
		(SELECT
			c.CountryName AS CountryName
			, p.Elevation AS Elevation
		FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
		JOIN Peaks AS p ON p.MountainId = mc.MountainId) AS a
		GROUP BY a.CountryName) AS one

JOIN (SELECT
	MAX([Length]) AS [Length]
	, b.CountryName
	FROM
		(SELECT
			c.CountryName AS CountryName
			, r.Length AS [Length]
		FROM Countries AS c
		LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
		JOIN Rivers AS r ON r.Id = cr.RiverId) AS b
		GROUP BY b.CountryName) AS two ON one.CountryName = two.CountryName
GROUP BY one.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName


-- taks 18

SELECT --TOP 5
	   cn.CountryName
	   , CASE 
			WHEN b.PeakName IS NULL THEN '(no highest peak)'
			WHEN b.PeakName IS NOT NULL THEN b.PeakName
			END AS [Highest Peak Name]
	   , CASE 
			WHEN b.Elevation IS NULL THEN 0
			WHEN b.Elevation IS NOT NULL THEN b.Elevation
			END AS [Highest Peak Elevation]
	   , CASE 
			WHEN b.MountainName IS NULL THEN '(no mountain)'
			WHEN b.MountainName IS NOT NULL THEN b.MountainName
			END AS [Mountain]
FROM Countries AS cn
LEFT JOIN(

SELECT * FROM 
(SELECT
		c.CountryName AS CountryName
		, p.PeakName AS PeakName
		, p.Elevation AS Elevation
		, m.MountainRange AS MountainName
		, DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS Ranking
FROM Peaks AS p
JOIN Mountains AS m ON m.Id = p.MountainId
JOIN MountainsCountries AS mc ON mc.MountainId = p.MountainId
JOIN Countries AS c ON c.CountryCode = mc.CountryCode
GROUP BY c.CountryName, Elevation, p.PeakName , m.MountainRange, m.MountainRange
 HAVING Elevation = MAX(Elevation)) AS a
 WHERE Ranking = 1) AS b ON cn.CountryName = b.CountryName
 ORDER BY cn.CountryName