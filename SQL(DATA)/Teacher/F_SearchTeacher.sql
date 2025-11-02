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
CREATE PROCEDURE F_SearchT
      @Keyword NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Teachers
    WHERE FirstName LIKE '%' + @Keyword + '%'
       OR LastName LIKE '%' + @Keyword + '%'
       OR Gender LIKE '%' + @Keyword + '%'
       OR Department LIKE '%' + @Keyword + '%'
       OR Subject LIKE '%' + @Keyword + '%'
    ORDER BY TeacherID DESC;
END
GO
