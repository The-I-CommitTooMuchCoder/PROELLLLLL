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
CREATE PROCEDURE F_Register
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Age INT,
    @Address NVARCHAR(200),
    @Phone NVARCHAR(50),
    @Email NVARCHAR(100),
    @Username NVARCHAR(50),
    @Password NVARCHAR(100),
    @ProfilePic NVARCHAR(255)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Admins WHERE Username = @Username)
    BEGIN
        RAISERROR('Username already exists!', 16, 1);
        RETURN;
    END

    INSERT INTO Admins (FirstName, LastName, Age, Address, Phone, Email, Username, [Password], ProfilePic)
    VALUES (@FirstName, @LastName, @Age, @Address, @Phone, @Email, @Username, @Password, @ProfilePic);
END
GO
