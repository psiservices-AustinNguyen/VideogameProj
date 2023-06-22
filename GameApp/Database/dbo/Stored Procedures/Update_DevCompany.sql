CREATE PROCEDURE dbo.Update_DevCompany
    @DevCoId INT,
    @DevName NVARCHAR(255),
    @DevAddress NVARCHAR(255),
    @FoundedDate DATETIME,
    @MostPopularGame NVARCHAR(255)
AS
BEGIN

    SET NOCOUNT ON;

    UPDATE DevCompany
    SET DevName = @DevName,
        DevAddress = @DevAddress,
        FoundedDate = @FoundedDate,
        MostPopularGame = @MostPopularGame
    WHERE DevCoId = @DevCoId;
END
