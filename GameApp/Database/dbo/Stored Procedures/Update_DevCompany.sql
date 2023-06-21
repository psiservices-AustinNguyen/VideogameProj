CREATE PROCEDURE dbo.Update_DevCompany
    @Id INT,
    @Name NVARCHAR(255),
    @Address NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE DevCompany
    SET DevName = @Name,
        DevAddress = @Address
    WHERE DevCoId = @Id;
END
