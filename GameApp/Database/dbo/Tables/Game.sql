﻿CREATE TABLE [dbo].[Game]
(
    [GameId] INT NOT NULL, 
    [GameName] NVARCHAR(255) NULL, 
    [DevId] INT NULL, 
    [GameDescription] NVARCHAR(255) NULL, 
    PRIMARY KEY ([GameId]), 
    CONSTRAINT [FK_Game_Dev] FOREIGN KEY (DevId) REFERENCES DevCompany(DevCoId)
)
