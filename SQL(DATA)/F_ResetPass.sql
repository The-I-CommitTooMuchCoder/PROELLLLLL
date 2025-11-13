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
ALTER PROCEDURE F_ResetPass
    @Username NVARCHAR(50),
    @NewPassword NVARCHAR(100),
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Admins WHERE Username = @Username)
    BEGIN
        UPDATE Admins
        SET [Password] = @NewPassword
        WHERE Username = @Username;

        SET @Result = 1; -- Success
    END
    ELSE
    BEGIN
        SET @Result = 0; -- Username not found
    END
END
GO
