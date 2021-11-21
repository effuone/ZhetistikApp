--USE master
--GO
--DROP DATABASE IF EXISTS ZhetistikApp
--GO
--CREATE DATABASE ZhetistikApp
--GO
--USE ZhetistikApp
--GO

DROP TABLE IF EXISTS Countries;
CREATE TABLE Countries(
CountryID INT IDENTITY(1,1) NOT NULL,
CountryName NVARCHAR(25) NOT NULL,
CONSTRAINT QK_Countries_CountryName UNIQUE (CountryName),
CONSTRAINT PK_Countries PRIMARY KEY (CountryID)
)
DROP TABLE IF EXISTS Cities;
CREATE TABLE Cities(
CityID INT IDENTITY(1,1) NOT NULL,
CountryID INT NOT NULL,
CityName NVARCHAR(50) NOT NULL
CONSTRAINT QK_Cities_CityName UNIQUE (CityName),
CONSTRAINT PK_Cities PRIMARY KEY (CityID),
CONSTRAINT FK_Cities_To_Countries FOREIGN KEY (CountryID) REFERENCES Countries(CountryID)
)
DROP TABLE IF EXISTS States;
CREATE TABLE States(
StateID INT IDENTITY(1,1) NOT NULL,
CountryID INT NOT NULL,
StateName NVARCHAR(50) NOT NULL
CONSTRAINT QK_States_StateName UNIQUE (StateName),
CONSTRAINT PK_States PRIMARY KEY (StateID),
CONSTRAINT FK_States_To_Countries FOREIGN KEY (CountryID) REFERENCES Countries(CountryID)
)
DROP TABLE IF EXISTS Locations;
CREATE TABLE Locations(
LocationID INT NOT NULL,
CityID INT NOT NULL,
StateID INT NOT NULL,
CountryID INT NOT NULL,
CONSTRAINT PK_Locations PRIMARY KEY (LocationID),
CONSTRAINT FK_Locations_To_Cities FOREIGN KEY (CityID) REFERENCES Cities(CityID),
CONSTRAINT FK_Locations_To_Countries FOREIGN KEY (CountryID) REFERENCES Countries(CountryID),
CONSTRAINT FK_Locations_To_States FOREIGN KEY (StateID) REFERENCES States(StateID)
)
DROP TABLE IF EXISTS Schools;
CREATE TABLE Schools(
SchoolID INT IDENTITY(1,1) NOT NULL,
PlacementID INT NOT NULL,
SchoolName NVARCHAR(100) NOT NULL,
FoundationYear DATE NOT NULL,
CONSTRAINT PK_Schools PRIMARY KEY (SchoolID),
CONSTRAINT FK_Schools_To_Locations FOREIGN KEY (PlacementID) REFERENCES Locations(LocationID)
)
GO
DROP TABLE IF EXISTS UniversityTypes;
CREATE TABLE UniversityTypes(
UniversityTypeID INT IDENTITY(1,1) NOT NULL,
UniversityTypeName NVARCHAR(20) NOT NULL,
CONSTRAINT QK_UniversityTypes UNIQUE (UniversityTypeName),
CONSTRAINT PK_UniersityTypes PRIMARY KEY(UniversityTypeID)
)
GO
DROP TABLE IF EXISTS Universities;
CREATE TABLE Universities(
UniversityID INT IDENTITY(1,1) NOT NULL,
UniversityName NVARCHAR(50) NOT NULL,
UniversityDescription NVARCHAR(1000) NOT NULL,
PlacementID INT NOT NULL,
FoundationYear DATE NOT NULL,
StudentsCount INT NOT NULL,
UniversityTypeID INT NOT NULL,
CONSTRAINT QK_Universities_Name UNIQUE (UniversityName),
CONSTRAINT PK_Universities PRIMARY KEY (UniversityID),
CONSTRAINT FK_Universities_To_Locations FOREIGN KEY (PlacementID) REFERENCES Locations(LocationID),
CONSTRAINT FK_Universities_To_UniversityTypes FOREIGN KEY (UniversityTypeID) REFERENCES UniversityTypes(UniversityTypeID)
)
GO
DROP TABLE IF EXISTS Courses;
CREATE TABLE Courses(
CourseID INT IDENTITY(1,1) NOT NULL,
CourseName NVARCHAR(100) NOT NULL,
CourseDescription NVARCHAR(255) NOT NULL,
CourseLength INT NOT NULL,
CONSTRAINT PK_Courses PRIMARY KEY (CourseID)
)
GO
DROP TABLE IF EXISTS Faculties;
CREATE TABLE Faculties(
FacultyID INT IDENTITY(1,1) NOT NULL,
FacultyName NVARCHAR(40) NOT NULL,
CourseID INT NOT NULL,
UniversityID INT NOT NULL,
CONSTRAINT PK_Faculties PRIMARY KEY (FacultyID),
CONSTRAINT FK_Faculties_To_Courses FOREIGN KEY(CourseID) REFERENCES Courses(CourseID),
CONSTRAINT FK_Faculties_To_Universities FOREIGN KEY(UniversityID) REFERENCES Universities(UniversityID),
)
GO
DROP TABLE IF EXISTS Candidates;
CREATE TABLE Candidates(
CandidateID INT IDENTITY(1,1) NOT NULL,
UserID INT NOT NULL,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Birthday DateTime NOT NULL,
Email NVARCHAR(40) NOT NULL,
PhoneNumber NVARCHAR(20) NOT NULL,
CONSTRAINT QK_Candidates_Email UNIQUE (Email),
CONSTRAINT QK_Candidates_Phone UNIQUE (PhoneNumber),
CONSTRAINT PK_Candidates PRIMARY KEY (CandidateID)
)

GO
DROP TABLE IF EXISTS AchievementTypes;
CREATE TABLE AchievementTypes(
AchievementTypeID INT IDENTITY(1,1) NOT NULL,
AchievementTypeName varchar(255) NOT NULL,
CONSTRAINT QK_AchievementTypes UNIQUE (AchievementTypeName),
CONSTRAINT PK_AchievementTypeID PRIMARY KEY (AchievementTypeID)
)
DROP TABLE IF EXISTS Achievements;
CREATE TABLE Achievements(
AchievementID INT IDENTITY(1,1) NOT NULL,
AchievementTypeID INT NOT NULL,
Score INT,
Image IMAGE,
URL VARCHAR(2048),
CONSTRAINT PK_Achievements PRIMARY KEY (AchievementID),
CONSTRAINT FK_Achievements_To_AchievementTypes FOREIGN KEY (AchievementTypeID) REFERENCES AchievementTypes(AchievementTypeID)
)
GO
DROP TABLE IF EXISTS Portfolios;
CREATE TABLE Portfolios(
PortofolioID INT IDENTITY(1,1) NOT NULL,
CandidateID INT NOT NULL,
PlacementID INT NOT NULL,
AchievementID INT NOT NULL,
IsPublished BIT NOT NULL,
CreatedDate DATETIME NOT NULL,
CONSTRAINT PK_Portfolios PRIMARY KEY (PortofolioID),
CONSTRAINT FK_Portfolios_To_Candidates FOREIGN KEY (CandidateID) REFERENCES Candidates(CandidateID),
CONSTRAINT FK_Portfolios_To_Locations FOREIGN KEY (PlacementID) REFERENCES Locations(LocationID),
CONSTRAINT FK_Portfolios_To_Achievement FOREIGN KEY (CandidateID) REFERENCES Achievements(AchievementID),
)
