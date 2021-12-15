CREATE TABLE [dbo].[SalesOrder]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Customer] NVARCHAR(MAX) NOT NULL, 
    [Product] NVARCHAR(50) NOT NULL, 
    [Price] MONEY NOT NULL
)
