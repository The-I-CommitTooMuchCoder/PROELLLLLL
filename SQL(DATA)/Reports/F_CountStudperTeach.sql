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
CREATE PROCEDURE F_CountStudentsPerTeacher
AS
BEGIN
    SELECT t.FirstName + ' ' + t.LastName AS TeacherName, COUNT(ss.StudentID) AS StudentCount
    FROM Teachers t
    LEFT JOIN TeacherSubjects ts ON t.TeacherID = ts.TeacherID
    LEFT JOIN StudentSubjects ss ON ts.SubjectID = ss.SubjectID
    GROUP BY t.FirstName, t.LastName;
END;
GO