CREATE TABLE [dbo].[Expense]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[ExpenseTypeId] INT NOT NULL,
	[Note] NVARCHAR(1000) NULL,
	[Amount] DECIMAL(16,4) NOT NULL,
	[Date] DATETIMEOFFSET(7) NOT NULL,
	CONSTRAINT [PK_Expense_Id] PRIMARY KEY([Id]),
	CONSTRAINT [FK_Expense_ExpenseTypeId] FOREIGN KEY([ExpenseTypeId]) REFERENCES [ExpenseType]([Id])
)
