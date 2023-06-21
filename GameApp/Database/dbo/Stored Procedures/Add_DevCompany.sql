CREATE PROCEDURE dbo.Add_DevCompany
    @DevName NVARCHAR(255),
    @DevAddress NVARCHAR(255),
    @FoundedDate DATETIME,
    @MostPopularGame NVARCHAR(255)
AS
BEGIN
    INSERT INTO DevCompany (DevName, DevAddress, FoundedDate, MostPopularGame)
    VALUES (@DevName, @DevAddress, @FoundedDate, @MostPopularGame)
END