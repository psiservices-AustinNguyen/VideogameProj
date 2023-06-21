CREATE PROCEDURE [dbo].Get_DevCompanies
AS
BEGIN

	SET NOCOUNT ON;

	--SELECT
	--	u.[DevName]
	--	, u.[DevAddress]
	--	, u.DevCoId
	--FROM 
	--	dbo.DevCompany u

	SELECT * FROM DevCompany

END 

--u is an alias for the table dbo.DevCompany. It is used as a shorthand notation to reference the table in the SELECT statement