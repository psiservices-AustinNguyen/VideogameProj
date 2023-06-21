CREATE PROCEDURE dbo.Get_DevCompanyList
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		  DevName
		, DevAddress
		, FoundedDate
		, MostPopularGame
		, DevCoId
	FROM 
		DevCompany 

END 
