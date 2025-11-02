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
CREATE PROCEDURE F_UpdateS
    @StudentID INT,
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
    UPDATE Students
    SET 
        FirstName = @FirstName,
        LastName = @LastName,
        Gender = @Gender,
        Age = @Age,
        Address = @Address,
        Phone = @Phone,
        Email = @Email,
        Department = @Department,
        Course = @Course,
        TermLevel = @TermLevel,
        Username = @Username,
        [Password] = @Password
    WHERE StudentID = @StudentID;
END
GO