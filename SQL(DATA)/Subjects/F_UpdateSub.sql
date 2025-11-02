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
CREATE PROCEDURE F_UpdateSubject
    @SubjectID INT,
    @SubjectCode NVARCHAR(50),
    @SubjectName NVARCHAR(150),
    @Active BIT
AS
BEGIN
    UPDATE Subjects
    SET SubjectCode = @SubjectCode,
        SubjectName = @SubjectName,
        Active = @Active
    WHERE SubjectID = @SubjectID;
END;
GO