use FINAL_DB
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
CREATE PROCEDURE F_AddT
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Gender NVARCHAR(10),
    @Department NVARCHAR(100),
    @Subject NVARCHAR(100),
    @Username NVARCHAR(50),
    @Password NVARCHAR(100)
AS
BEGIN
    DECLARE @TeacherID INT, @SubjectID INT;

    --  Add Teacher
    INSERT INTO Teachers (FirstName, LastName, Gender, Department, Subject, Username, [Password], Active)
    VALUES (@FirstName, @LastName, @Gender, @Department, @Subject, @Username, @Password, 1);

    SET @TeacherID = SCOPE_IDENTITY();

    --  Find or create the subject
    SELECT @SubjectID = SubjectID FROM Subjects WHERE SubjectName = @Subject;
    IF @SubjectID IS NULL
    BEGIN
        INSERT INTO Subjects (SubjectCode, SubjectName, Active)
        VALUES (@Subject, @Subject, 1);
        SET @SubjectID = SCOPE_IDENTITY();
    END

    --  Link teacher → subject
    IF NOT EXISTS (SELECT 1 FROM TeacherSubjects WHERE TeacherID = @TeacherID AND SubjectID = @SubjectID)
    BEGIN
        INSERT INTO TeacherSubjects (TeacherID, SubjectID)
        VALUES (@TeacherID, @SubjectID);
    END
END
GO
