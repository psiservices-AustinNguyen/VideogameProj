CREATE PROCEDURE dbo.Delete_DevCompany
    @DevCoId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM DevCompany
    WHERE DevCoId = @DevCoId;

END