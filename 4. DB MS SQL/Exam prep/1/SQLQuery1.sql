--task 1

CREATE DATABASE CigarShop

CREATE TABLE Sizes(
Id INT PRIMARY KEY IDENTITY (1, 1),
[Length] INT CHECK ([Length] >= 10 AND [Length] <= 25) NOT NULL,
RingRange DECIMAL (18,2) CHECK (RingRange >= 1.5 AND RingRange <= 7.5) NOT NULL)

CREATE TABLE Tastes(
Id INT PRIMARY KEY IDENTITY (1, 1),
TasteType VARCHAR(20) NOT NULL,
TasteStrength VARCHAR(15) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL)

CREATE TABLE Brands(
Id INT PRIMARY KEY IDENTITY (1, 1),
BrandName VARCHAR(30) NOT NULL UNIQUE,
BrandDescription VARCHAR(MAX) NULL)

CREATE TABLE Cigars(
Id INT PRIMARY KEY IDENTITY (1, 1),
CigarName VARCHAR(80) NOT NULL,
BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
PriceForSingleCigar DECIMAL (10,2) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL)

CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY (1, 1),
Town VARCHAR(30) NOT NULL,
Country NVARCHAR(30) NOT NULL,
Streat NVARCHAR(100) NOT NULL,
ZIP VARCHAR(200) NOT NULL)

CREATE TABLE Clients(
Id INT PRIMARY KEY IDENTITY (1, 1),
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Email NVARCHAR(500) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL)

CREATE TABLE ClientsCigars(
ClientId INT NOT NULL,
CigarId INT NOT NULL,
CONSTRAINT PK_ClientsCigars PRIMARY KEY CLUSTERED (ClientId ASC, CigarId ASC),
CONSTRAINT FK_ClientsCigars_ClientId FOREIGN KEY(ClientId) REFERENCES Clients(Id), 
CONSTRAINT FK_ClientsCigars_CigarId FOREIGN KEY(CigarId) REFERENCES Cigars(Id))

-- task 2

INSERT INTO Cigars (CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses (Town, Country, Streat, ZIP)
VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

--task 3

UPDATE Cigars
SET PriceForSingleCigar *= 1.2
WHERE TastId = 1

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

-- task 4

ALTER TABLE Clients
ALTER COLUMN AddressId INT NULL

UPDATE Clients
SET AddressId = NULL
WHERE AddressId IN (
			SELECT Id FROM Addresses
			WHERE LEFT([Country], 1) = 'C')


DELETE FROM Addresses
WHERE LEFT([Country], 1) = 'C'

-- task 5

  SELECT
		 CigarName
		 , PriceForSingleCigar
		 , ImageURL
    FROM Cigars
ORDER BY PriceForSingleCigar ASC, CigarName DESC

-- task 6

  SELECT
		 c.Id
		 , c.CigarName
		 , c.PriceForSingleCigar
		 , t.TasteType
		 , t.TasteStrength
    FROM Cigars AS c
	JOIN Tastes AS t ON t.Id = c.TastId
   WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
ORDER BY PriceForSingleCigar DESC

-- task 7

   SELECT Id
		  , CONCAT (c.FirstName, ' ', c.LastName) AS ClientName
	      , c.Email
	 FROM Clients AS c
LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
	WHERE cc.CigarId IS NULL
 ORDER BY ClientName

 -- task 8

  SELECT TOP 5
	     c.CigarName
		 , c.PriceForSingleCigar
		 , c.ImageURL
    FROM Cigars AS c
	JOIN Sizes AS s ON s.Id = c.SizeId
   WHERE s.[Length] >= 12 AND (CHARINDEX('ci', c.CigarName, 1) != 0
	  OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
ORDER BY c.CigarName, c.PriceForSingleCigar DESC

 -- task 9

SELECT 
	sub.FullName
	, sub.Country
	, sub.ZIP
	, sub.CigarPrice
FROM (SELECT 
	  CONCAT(c.FirstName, ' ', c.LastName) AS FullName
	  , a.Country
	  , a.ZIP
	  , CONCAT('$', cg.PriceForSingleCigar) AS CigarPrice
	  , DENSE_RANK() OVER ( PARTITION BY c.FirstName ORDER BY cg.PriceForSingleCigar DESC) AS Ranking
 FROM Clients AS c
 JOIN Addresses AS a ON c.AddressId = a.Id
 JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
 JOIN Cigars AS cg ON cc.CigarId = cg.Id
 WHERE ISNUMERIC(a.ZIP) = 1) AS sub
 WHERE sub.Ranking = 1
 ORDER BY sub.FullName

 -- task 10

 SELECT 
	sub.LastName
	, AVG(sub.CiagrLength) AS CiagrLength
	, CEILING(AVG(sub.CiagrRingRange)) AS CiagrRingRange
 FROM (SELECT
		cl.LastName
		, s.[Length] AS CiagrLength
		, s.RingRange AS CiagrRingRange
   FROM ClientsCigars AS cc
   JOIN Cigars AS c ON c.Id = cc.CigarId
   JOIN Clients AS cl ON cc.ClientId = cl.Id
   JOIN Sizes AS s ON s.Id = c.SizeId) AS sub
   GROUP BY sub.LastName
   ORDER BY CiagrLength DESC
 
 -- task 11

 CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR (30))
 RETURNS INT
 AS
 BEGIN
 DECLARE @Result INT
 SET @Result =
 (SELECT COUNT(cc.CigarId)
 FROM Clients AS c
 LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
 GROUP BY c.FirstName
 HAVING c.FirstName = @name)
 IF(@Result IS NULL)
 SET @Result = 0
 RETURN @Result
 END

-- task 12

CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
SELECT
	c.CigarName
	, CONCAT('$', c.PriceForSingleCigar) AS Price
	, t.TasteType
	, b.BrandName
	, CONCAT(s.[Length], ' cm') AS CigarLength
	, CONCAT(s.RingRange, ' cm') AS CigarRingRange
FROM Cigars AS c
JOIN Tastes AS t ON c.TastId = t.Id
JOIN Brands AS b ON c.BrandId = b.Id
JOIN Sizes AS s ON c.SizeId = s.Id
WHERE t.TasteType = @taste
ORDER BY s.[Length], s.RingRange DESC