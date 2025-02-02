CREATE TABLE [dbo].[Game]
(
	[GameId] INT NOT NULL PRIMARY KEY,
	[GameName] VARCHAR(50) NOT NULL,
	[State] VARCHAR(2) NOT NULL,
	[ValidationStatus] INT NOT NULL,
	[TicketPrice] DECIMAL(3,2) NOT NULL,
	[TotalTicketsInPack] INT NOT NULL
)
