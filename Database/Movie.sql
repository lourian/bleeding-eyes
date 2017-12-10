CREATE TABLE [dbo].[Movie]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY, 
    [Name] NVARCHAR(500) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL
)
