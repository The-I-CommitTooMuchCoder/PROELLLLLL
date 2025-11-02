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
CREATE PROCEDURE F_AssignTeacher
    @TeacherID INT,
    @SubjectID INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM TeacherSubjects WHERE TeacherID = @TeacherID AND SubjectID = @SubjectID)
    BEGIN
        INSERT INTO TeacherSubjects (TeacherID, SubjectID)
        VALUES (@TeacherID, @SubjectID);
    END
END
GO
