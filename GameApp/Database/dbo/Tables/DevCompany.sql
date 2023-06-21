CREATE TABLE [dbo].[DevCompany]
(
    [DevCoId]     INT IDENTITY (1, 1) NOT NULL, 
    [DevName] NVARCHAR(255) NULL, 
    [DevAddress] NVARCHAR(255) NULL, 
    [FoundedDate] DATETIME NULL, 
    [MostPopularGame] NVARCHAR(255) NULL, 
    PRIMARY KEY ([DevCoId])
)
