CREATE PROCEDURE dbo.Get_DevCompanyList
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		DevName
		, DevAddress
		, DevCoId
	FROM 
		DevCompany 

END 
