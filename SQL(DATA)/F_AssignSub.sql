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
CREATE PROCEDURE F_AssignSubject
    @SubjectID INT,
    @TeacherID INT = NULL,
    @StudentID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Link Teacher
    IF @TeacherID IS NOT NULL AND 
       NOT EXISTS (SELECT 1 FROM TeacherSubjects WHERE TeacherID = @TeacherID AND SubjectID = @SubjectID)
    BEGIN
        INSERT INTO TeacherSubjects (TeacherID, SubjectID)
        VALUES (@TeacherID, @SubjectID);
    END

    -- Link Student
    IF @StudentID IS NOT NULL AND 
       NOT EXISTS (SELECT 1 FROM StudentSubjects WHERE StudentID = @StudentID AND SubjectID = @SubjectID)
    BEGIN
        INSERT INTO StudentSubjects (StudentID, SubjectID)
        VALUES (@StudentID, @SubjectID);
    END
END
GO
