-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE F_AddS
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Gender NVARCHAR(10),
    @Age INT,
    @Address NVARCHAR(200),
    @Phone NVARCHAR(50),
    @Email NVARCHAR(100),
    @Department NVARCHAR(100),
    @Course NVARCHAR(100),
    @TermLevel NVARCHAR(50),    
    @Username NVARCHAR(50),
    @Password NVARCHAR(100)
AS
BEGIN
    DECLARE @StudentID INT, @SubjectID INT;

    --  Add Student
    INSERT INTO Students 
    (FirstName, LastName, Gender, Age, Address, Phone, Email, Department, Course, TermLevel, Username, [Password], Active)
    VALUES 
    (@FirstName, @LastName, @Gender, @Age, @Address, @Phone, @Email, @Department, @Course, @TermLevel, @Username, @Password, 1);

    --SET @StudentID = SCOPE_IDENTITY();

    ----  Find or create the subject
    --SELECT @SubjectID = SubjectID FROM Subjects WHERE SubjectName = @Subject;
    --IF @SubjectID IS NULL
    --BEGIN
    --    INSERT INTO Subjects (SubjectCode, SubjectName, Active)
    --    VALUES (@Subject, @Subject, 1);
    --    SET @SubjectID = SCOPE_IDENTITY();
    --END

    ----  Link student → subject
    --IF NOT EXISTS (SELECT 1 FROM StudentSubjects WHERE StudentID = @StudentID AND SubjectID = @SubjectID)
    --BEGIN
    --    INSERT INTO StudentSubjects (StudentID, SubjectID)
    --    VALUES (@StudentID, @SubjectID);
    --END
END
GO