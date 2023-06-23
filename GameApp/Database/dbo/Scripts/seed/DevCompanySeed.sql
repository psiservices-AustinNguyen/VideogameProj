IF NOT EXISTS (SELECT 1 FROM [dbo].[DevCompany])
BEGIN
	INSERT INTO [dbo].[DevCompany] ([DevName], [DevAddress], [FoundedDate], [MostPopularGame])
	VALUES
		('Rockstar Games', 'New York, NY', '1998-12-21', 'Grand Theft Auto'),
		('Nintendo', 'Kyoto, Japan', '1889-09-23', 'Mario'),
		('Bungie Inc.', 'Bellevue, WA', '1991-05-08', 'Halo')
END