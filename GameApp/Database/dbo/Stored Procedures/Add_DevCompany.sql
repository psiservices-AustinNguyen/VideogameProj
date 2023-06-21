CREATE PROCEDURE dbo.Add_DevCompany
    @Name NVARCHAR(255),
    @Address NVARCHAR(255)
AS
BEGIN
    INSERT INTO DevCompany (DevName, DevAddress)
    VALUES (@Name, @Address)
END