CREATE TABLE [dbo].[Tasks]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1, 1),
	Title NVarChar(140) Not Null,
	IsCompleted BIT,
	CreationDate DateTime Default(GetDate())
)

