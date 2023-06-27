/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF EXISTS (SELECT * FROM sys.database_scoped_configurations WHERE name = 'IDENTITY_CACHE')
BEGIN
	ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = OFF;
END
GO
IF NOT EXISTS (SELECT 1 FROM [dbo].[DevCompany])
BEGIN
	INSERT INTO [dbo].[DevCompany] ([DevName], [DevAddress], [FoundedDate], [MostPopularGame])
	VALUES
		('Rockstar Games', 'New York, NY', '1998-12-21', 'Grand Theft Auto'),
		('Nintendo', 'Kyoto, Japan', '1889-09-23', 'Mario'),
		('Bungie Inc.', 'Bellevue, WA', '1991-05-08', 'Halo')
END
GO
