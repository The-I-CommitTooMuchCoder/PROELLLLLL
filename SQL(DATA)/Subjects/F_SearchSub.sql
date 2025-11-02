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
CREATE PROCEDURE F_SearchSubject
    @Keyword NVARCHAR(100)
AS
BEGIN
    SELECT 
        S.SubjectID,
        S.SubjectCode,
        S.SubjectName,
        S.Active,
        T.FirstName + ' ' + T.LastName AS TeacherName,
        ST.FirstName + ' ' + ST.LastName AS StudentName
    FROM Subjects S
    LEFT JOIN TeacherSubjects TS ON S.SubjectID = TS.SubjectID
    LEFT JOIN Teachers T ON TS.TeacherID = T.TeacherID
    LEFT JOIN StudentSubjects SS ON S.SubjectID = SS.SubjectID
    LEFT JOIN Students ST ON SS.StudentID = ST.StudentID
    WHERE S.SubjectCode LIKE '%' + @Keyword + '%'
       OR S.SubjectName LIKE '%' + @Keyword + '%'
       OR T.FirstName LIKE '%' + @Keyword + '%'
       OR ST.FirstName LIKE '%' + @Keyword + '%'
    ORDER BY S.SubjectID DESC;
END;
GO
