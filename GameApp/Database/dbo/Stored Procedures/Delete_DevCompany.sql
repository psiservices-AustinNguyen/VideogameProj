CREATE PROCEDURE dbo.Delete_DevCompany
    @DevCoId INT
AS
BEGIN
    DELETE FROM DevCompany
    WHERE DevCoId = @DevCoId;
END