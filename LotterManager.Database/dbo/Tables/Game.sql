CREATE TABLE [dbo].[Game]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [State] NVARCHAR(2) NOT NULL, 
    [IsActive] BIT NOT NULL, 
    [Price] DECIMAL(3) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL
	
)
