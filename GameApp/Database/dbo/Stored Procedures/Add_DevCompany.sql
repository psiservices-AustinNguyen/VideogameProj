CREATE PROCEDURE dbo.Add_DevCompany
    @DevName NVARCHAR(255),
    @DevAddress NVARCHAR(255),
    @FoundedDate DATETIME,
    @MostPopularGame NVARCHAR(255)
AS
BEGIN

    SET NOCOUNT ON;

    INSERT INTO DevCompany (DevName, DevAddress, FoundedDate, MostPopularGame)
    VALUES (@DevName, @DevAddress, @FoundedDate, @MostPopularGame)

END