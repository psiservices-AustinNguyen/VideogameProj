CREATE PROCEDURE dbo.Get_DevCompany
    @DevCoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        DevCoId,
        DevName,
        DevAddress,
        FoundedDate,
        MostPopularGame
    FROM
        DevCompany
    WHERE
        DevCoId = @DevCoId;
END