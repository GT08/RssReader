CREATE TABLE [dbo].[ReadHistory]
(
	[Id] INT NOT NULL,
	[ReadDate] DATETIME NOT NULL DEFAULT (GETDATE()), 
    CONSTRAINT [PK_ReadHistory] PRIMARY KEY ([Id])
)
