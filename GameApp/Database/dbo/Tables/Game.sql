CREATE TABLE [dbo].[Game]
(
	[Id] INT NOT NULL , 
    [GameId] INT NOT NULL, 
    [GameName] NVARCHAR(255) NULL, 
    [DevId] INT NULL, 
    PRIMARY KEY ([GameId]), 
    CONSTRAINT [FK_Game_Dev] FOREIGN KEY (DevId) REFERENCES DevCompany(DevCoId)
)
