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
CREATE PROCEDURE F_AddSubject
     @SubjectCode NVARCHAR(50),
    @SubjectName NVARCHAR(150),
    @TeacherID INT = NULL,
    @StudentID INT = NULL
AS
BEGIN

    SET NOCOUNT ON;

    -- Prevent duplicate subject codes
    IF EXISTS (SELECT 1 FROM Subjects WHERE SubjectCode = @SubjectCode)
    BEGIN
        RAISERROR('Subject code already exists!', 16, 1);
        RETURN;
    END

    INSERT INTO Subjects (SubjectCode, SubjectName)
    VALUES (@SubjectCode, @SubjectName);

    DECLARE @NewSubjectID INT = SCOPE_IDENTITY();

    IF @TeacherID IS NOT NULL
        INSERT INTO TeacherSubjects (TeacherID, SubjectID) VALUES (@TeacherID, @NewSubjectID);

    IF @StudentID IS NOT NULL
        INSERT INTO StudentSubjects (StudentID, SubjectID) VALUES (@StudentID, @NewSubjectID);
END;
GO