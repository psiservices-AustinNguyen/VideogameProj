CREATE PROCEDURE dbo.Update_DevCompany
    @DevCoId INT,
    @DevName NVARCHAR(255),
    @DevAddress NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE DevCompany
    SET DevName = @DevName,
        DevAddress = @DevAddress
    WHERE DevCoId = @DevCoId;
END
