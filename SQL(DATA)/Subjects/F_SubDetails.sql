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
CREATE PROCEDURE F_SubjectDetails
    @SubjectID INT
AS
BEGIN
    SELECT 
        s.SubjectCode,
        s.SubjectName,
        t.FirstName + ' ' + t.LastName AS TeacherName,
        st.FirstName + ' ' + st.LastName AS StudentName
    FROM Subjects s
    LEFT JOIN TeacherSubjects ts ON s.SubjectID = ts.SubjectID
    LEFT JOIN Teachers t ON ts.TeacherID = t.TeacherID
    LEFT JOIN StudentSubjects ss ON s.SubjectID = ss.SubjectID
    LEFT JOIN Students st ON ss.StudentID = st.StudentID
    WHERE s.SubjectID = @SubjectID;
END
GO
