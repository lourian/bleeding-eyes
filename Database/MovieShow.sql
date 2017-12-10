CREATE TABLE [dbo].[MovieShow]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY, 
    [MovieId] INT NOT NULL, 
    [CinemaId] INT NOT NULL, 
    [Date] DATETIME NOT NULL, 
    CONSTRAINT [FK_MovieShow_ToMovie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie]([Id]), 
    CONSTRAINT [FK_MovieShow_ToCiname] FOREIGN KEY ([CinemaId]) REFERENCES [dbo].[Cinema]([Id]) 
)
