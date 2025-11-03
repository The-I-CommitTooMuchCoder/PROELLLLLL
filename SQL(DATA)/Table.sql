USE FINAL_DB;

CREATE TABLE Admins (
    AdminID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Age INT,
    Address NVARCHAR(200),
    Phone NVARCHAR(50),
    Email NVARCHAR(100),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    [Password] NVARCHAR(100) NOT NULL,
    ProfilePic NVARCHAR(200) NULL
);
CREATE TABLE Students (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50), 
    Age INT,
    Address NVARCHAR(200),
    Phone NVARCHAR(50),
    Email NVARCHAR(100),
    Username NVARCHAR(50),
    Gender NVARCHAR(10),
    [Password] NVARCHAR(100),
    TermLevel NVARCHAR(50),
    Course NVARCHAR(100),
    Department NVARCHAR(100),  
    Teacher NVARCHAR(100),
    IsActive BIT DEFAULT 1,
    DateCreated DATETIME DEFAULT GETDATE()
);
CREATE TABLE Teachers (
    TeacherID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Gender NVARCHAR(10),
    Department NVARCHAR(100),
    Subject NVARCHAR(100),
    Username NVARCHAR(50),
    [Password] NVARCHAR(100),
    Active BIT DEFAULT 1
);
CREATE TABLE Logs (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    ActionType NVARCHAR(20),
    Description NVARCHAR(255),
    DateLogged DATETIME DEFAULT GETDATE()
);

CREATE TABLE Subjects (
    SubjectID INT IDENTITY(1,1) PRIMARY KEY,
    SubjectCode NVARCHAR(50) UNIQUE NOT NULL,
    SubjectName NVARCHAR(150) NOT NULL,
    Active BIT DEFAULT 1);

CREATE TABLE TeacherSubjects (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TeacherID INT NOT NULL,
    SubjectID INT NOT NULL,
    FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID),
    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
);

CREATE TABLE StudentSubjects (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    SubjectID INT NOT NULL,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
);

INSERT INTO Subjects (SubjectCode, SubjectName) VALUES
('DASTRU', 'Data Structures and Algorithms'),
('INMANA', 'Information Management'),
('EVEDRI', 'Event Driven Programming'),
('TECHNO', 'Technopreneurship'),
('UNDSLF', 'Understanding the Self'),
('PAFIT4', 'Sports and Recreation'),
('GEEL03', 'GE Elective 3 (Living in the IT Era)');

INSERT INTO TeacherSubjects (TeacherID, SubjectID)
VALUES (1, 2);  

INSERT INTO StudentSubjects (StudentID, SubjectID)
VALUES (3, 2); 

SELECT * FROM Subjects


DROP Table StudentSubjects;
EXEC sp_rename 'Students.IsActive', 'Active', 'COLUMN';