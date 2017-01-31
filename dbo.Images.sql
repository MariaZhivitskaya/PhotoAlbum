CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Image] IMAGE NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [UserId] INT NOT NULL
)
