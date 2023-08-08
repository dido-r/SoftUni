CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY (1, 1),
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(30) NOT NULL,
Email VARCHAR(30) NOT NULL)

CREATE TABLE Repositories(
Id INT PRIMARY KEY IDENTITY (1, 1),
[Name]  VARCHAR(50) NOT NULL)

CREATE TABLE RepositoriesContributors(
RepositoryId INT,
ContributorId INT,
CONSTRAINT PK_RepositoriesContributors PRIMARY KEY CLUSTERED (RepositoryId, ContributorId),
CONSTRAINT FK_RepositoryId FOREIGN KEY(RepositoryId) REFERENCES Repositories(Id),
CONSTRAINT FK_ContributorId FOREIGN KEY(ContributorId) REFERENCES Users(Id))

CREATE TABLE Issues(
Id INT PRIMARY KEY IDENTITY (1, 1),
Title VARCHAR(255) NOT NULL,
IssueStatus VARCHAR(6) NOT NULL,
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,)

CREATE TABLE Commits(
Id INT PRIMARY KEY IDENTITY (1, 1),
[Message] VARCHAR(255) NOT NULL,
IssueId INT FOREIGN KEY REFERENCES Issues(Id),
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL)

CREATE TABLE Files(
Id INT PRIMARY KEY IDENTITY (1, 1),
[Name] VARCHAR(100) NOT NULL,
Size DECIMAL (15,2) NOT NULL,
ParentId INT FOREIGN KEY REFERENCES Files(Id),
CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL)

--task 2

INSERT INTO Files([Name], Size, ParentId, CommitId)
VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues([Title], IssueStatus, RepositoryId, AssigneeId)
VALUES
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

--task 3

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

-- task 4

ALTER TABLE Issues
ALTER COLUMN RepositoryID INT NULL

UPDATE Issues
SET RepositoryID = NULL
WHERE RepositoryID = 3

ALTER TABLE Commits
ALTER COLUMN RepositoryID INT NULL

UPDATE Commits
SET RepositoryID = NULL
WHERE RepositoryID = 3

DELETE FROM Issues WHERE Id = 3
DELETE FROM RepositoriesContributors WHERE RepositoryId = 3
DELETE FROM Repositories WHERE Id = 3

--task 5

SELECT 
	Id
	, [Message]
	, RepositoryId
	, ContributorId
FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

-- task 6

SELECT 
	 Id
	 , [Name]
	 , Size
FROM Files
WHERE Size > 1000 AND CHARINDEX('html', [Name], 1) != 0
ORDER BY Size DESC, Id, [Name]

-- task 7

SELECT 
	  i.Id
	  , CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
FROM Issues AS i
JOIN Users AS u ON u.Id = i.AssigneeId
ORDER BY i.Id DESC, u.Username

-- task 8

SELECT
		b.Id
		, b.[Name]
		, CONCAT(b.Size, 'KB') AS Size
FROM(
	SELECT
	       f.Id
	       , f.[Name]
	       , f.Size
	       , sub.ParentId
	  FROM Files AS f
 LEFT JOIN  (	
						SELECT DISTINCT
							   ParentId
						  FROM Files
						  ) AS sub ON f.Id = sub.ParentId) AS b
WHERE b.ParentId IS NULL
ORDER BY Id, [Name], Size DESC

--task 9

SELECT TOP 5
		r.Id
		, r.Name
		, COUNT(r.Id) AS Commits
FROM Repositories AS r
JOIN Commits AS c ON c.RepositoryId = r.Id
JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.Name
ORDER BY Commits DESC, r.Id, r.[Name]


-- task 10

SELECT	
	   u.Username
	   , AVG(f.Size) AS Size
FROM RepositoriesContributors AS rc
JOIN Users AS u ON u.Id = rc.ContributorId
JOIN Commits AS c ON c.ContributorId = rc.ContributorId
JOIN Files AS f ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY Size DESC, u.Username

-- task 11

CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
RETURN(
SELECT COUNT(c.Id)
FROM Commits AS c
JOIN Users AS u ON u.Id = c.ContributorId
WHERE u.Username = @username)
END

--task 12

CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(10))
AS
SELECT
	  Id
	  , [Name]
	  , CONCAT(Size, 'KB') AS Size
FROM Files
WHERE RIGHT([Name], LEN(@fileExtension)) = @fileExtension
ORDER BY Id, [Name], Size DESC