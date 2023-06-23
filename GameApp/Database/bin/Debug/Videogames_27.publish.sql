﻿/*
Deployment script for Videogames

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Videogames"
:setvar DefaultFilePrefix "Videogames"
:setvar DefaultDataPath "C:\Users\Austin.Nguyen\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Austin.Nguyen\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
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
DECLARE @IdentityCacheEnabled BIT;

SELECT @IdentityCacheEnabled = value
FROM sys.database_scoped_configurations
WHERE name = 'IDENTITY_CACHE';

IF (@IdentityCacheEnabled = 1)
BEGIN
    EXEC ('ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = OFF;');
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[DevCompany])
BEGIN
	INSERT INTO [dbo].[DevCompany] ([DevName], [DevAddress], [FoundedDate], [MostPopularGame])
	VALUES
		('Test1', 'Test1', '1971-12-18', 'Test1'),
		('Test2', 'Test2', '2004-10-21', 'Test2'),
		('Test3', 'Test3', '2018-07-06', 'Test3')
END
GO

GO
PRINT N'Update complete.';


GO
