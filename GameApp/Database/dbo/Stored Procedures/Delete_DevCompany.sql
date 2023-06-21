CREATE PROCEDURE dbo.Delete_DevCompany
    @Id INT
AS
BEGIN
    DELETE FROM DevCompany
    WHERE DevCoId = @Id;
END