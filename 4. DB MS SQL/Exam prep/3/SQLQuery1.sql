CREATE TABLE Passengers(
Id INT PRIMARY KEY IDENTITY (1, 1),
FullName VARCHAR(100) UNIQUE NOT NULL,
Email VARCHAR(50) UNIQUE NOT NULL)

CREATE TABLE Pilots(
Id INT PRIMARY KEY IDENTITY (1, 1),
FirstName VARCHAR(30) UNIQUE NOT NULL,
LastName VARCHAR(30) UNIQUE NOT NULL,
Age TINYINT CHECK (Age >= 21 AND Age <= 62) NOT NULL,
Rating FLOAT CHECK (Rating >= 0.0 AND Rating <= 10.0) NULL)

CREATE TABLE AircraftTypes(
Id INT PRIMARY KEY IDENTITY (1, 1),
TypeName VARCHAR(30) UNIQUE NOT NULL)

CREATE TABLE Aircraft(
Id INT PRIMARY KEY IDENTITY (1, 1),
Manufacturer VARCHAR(25) NOT NULL,
Model VARCHAR(30) NOT NULL,
[Year] INT NOT NULL,
FlightHours INT NULL,
Condition CHAR(1) NOT NULL,
TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL)

CREATE TABLE PilotsAircraft(
AircraftId INT,
PilotId INT,
CONSTRAINT PK_PrimaryKey PRIMARY KEY CLUSTERED(AircraftId, PilotId),
CONSTRAINT FK_AircraftId FOREIGN KEY(AircraftId) REFERENCES Aircraft(Id),
CONSTRAINT FK_PilotId FOREIGN KEY(PilotId) REFERENCES Pilots(Id))

CREATE TABLE Airports(
Id INT PRIMARY KEY IDENTITY (1, 1),
AirportName VARCHAR(70) UNIQUE NOT NULL,
Country VARCHAR(100) UNIQUE NOT NULL)

CREATE TABLE FlightDestinations(
Id INT PRIMARY KEY IDENTITY (1, 1),
AirportId INT FOREIGN KEY REFERENCES Airports(Id) NOT NULL,
[Start] DATETIME NOT NULL,
AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
TicketPrice DECIMAL(18,2) DEFAULT 15 NOT NULL)

-- task 2

INSERT INTO Passengers (FullName, Email)
SELECT 
	   CONCAT(FirstName, ' ', LastName)
	   , CONCAT(FirstName, LastName, '@gmail.com')
FROM Pilots
WHERE Id BETWEEN 5 AND 15

-- task 3

UPDATE Aircraft
SET Condition = 'A'
WHERE (Condition = 'C' OR Condition = 'B')
  AND (FlightHours IS NULL OR FlightHours <= 100)
  AND [Year] >= 2013

 -- task 4

 DELETE FROM Passengers WHERE LEN(FullName) <= 10

 -- task 5

   SELECT 
		  Manufacturer
		  , Model
		  , FlightHours
		  , Condition
	 FROM Aircraft
 ORDER BY FlightHours DESC

 -- task 6

  SELECT
		 p.FirstName
		 , p.LastName
		 , a.Manufacturer
		 , a.Model
		 , a.FlightHours
	FROM PilotsAircraft AS pa
	JOIN Pilots AS p ON p.Id = pa.PilotId
	JOIN Aircraft AS a ON a.Id = pa.AircraftId
   WHERE a.FlightHours IS NOT NULL AND a.FlightHours < 304
ORDER BY FlightHours DESC, p.FirstName

-- task 7

   SELECT TOP 20
		  f.Id AS DestinationId
		  , f.[Start]
		  , p.FullName
		  , a.AirportName
		  , f.TicketPrice
	 FROM FlightDestinations AS f
	 JOIN Airports AS a ON a.Id = f.AirportId
	 JOIN Passengers AS p ON p.Id = f.PassengerId
    WHERE DATEPART(DAY, f.[Start]) % 2 = 0
 ORDER BY f.TicketPrice DESC, a.AirportName

 -- task 8

   SELECT
		 a.Id
		 , a.Manufacturer
		 , a.FlightHours
		 , b.FlightDestinationsCount
		 , AvgPrice
    FROM Aircraft AS a
    JOIN (
		 SELECT
				AircraftId
				, COUNT(AircraftId) AS [FlightDestinationsCount]
				, ROUND(AVG([TicketPrice]), 2) AS AvgPrice
		   FROM FlightDestinations
	   GROUP BY AircraftId) AS b ON a.Id = b.AircraftId
   WHERE b.FlightDestinationsCount >= 2
ORDER BY b.FlightDestinationsCount DESC, a.Id

-- task 9

  SELECT 
		 * 
	FROM
 (SELECT p.FullName
		 , COUNT(f.AircraftId) AS CountOfAircraft
		 , SUM(f.TicketPrice) AS TotalPayed
	FROM FlightDestinations AS f
	JOIN Passengers AS p ON f.PassengerId = p.Id
GROUP BY p.FullName
  HAVING SUBSTRING(p.FullName, 2, 1) = 'a') AS sub
   WHERE CountOfAircraft > 1
ORDER BY sub.FullName

--task 10

  SELECT
		 ap.AirportName
		 , f.[Start] AS DayTime
		 , f.TicketPrice
		 , p.FullName
		 , ac.Manufacturer
		 , ac.Model
    FROM FlightDestinations AS f
    JOIN Airports AS ap ON f.AirportId = ap.Id
    JOIN Aircraft AS ac ON f.AircraftId = ac.Id
    JOIN Passengers AS p ON f.PassengerId = p.Id
   WHERE DATEPART(HOUR, f.[Start]) BETWEEN 6 AND 19
	 AND f.TicketPrice > 2500
ORDER BY ac.Model


-- task 11

CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS 
BEGIN
RETURN
(SELECT
COUNT(*)
FROM FlightDestinations AS f
JOIN Passengers AS p ON p.Id = f.PassengerId
WHERE p.Email = @email)
END

-- task 12

CREATE PROC usp_SearchByAirportName(@airportName VARCHAR(70))
AS
  SELECT 
	     ap.AirportName
	     , p.FullName
	     , CASE
	     WHEN f.TicketPrice <= 400 THEN 'Low'
	     WHEN f.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
	     ELSE 'High' 
	     END AS LevelOfTickerPrice
	     , ac.Manufacturer
	     , ac.Condition
	     , a.TypeName
	FROM FlightDestinations AS f
	JOIN Airports AS ap ON ap.Id = f.AirportId
	JOIN Passengers AS p ON p.Id = f.PassengerId
	JOIN Aircraft AS ac ON f.AircraftId = ac.Id
	JOIN AircraftTypes AS a ON a.Id = ac.TypeId
   WHERE ap.AirportName = @airportName
ORDER BY ac.Manufacturer, p.FullName
