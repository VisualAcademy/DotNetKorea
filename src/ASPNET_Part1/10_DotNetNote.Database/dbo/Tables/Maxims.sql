CREATE TABLE [dbo].[Maxims]
(
	[Id] Int Primary Key Not Null Identity(1, 1),
	Name NVarChar(25) Not Null,
	Content NVarChar(255) Null,
	CreationDate DateTime Default(GetDate())
)
