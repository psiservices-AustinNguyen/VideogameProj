CREATE PROCEDURE dbo.Add_DevCompany
    @DevName NVARCHAR(255),
    @DevAddress NVARCHAR(255)
AS
BEGIN
    INSERT INTO DevCompany (DevName, DevAddress)
    VALUES (@DevName, @DevAddress)
END