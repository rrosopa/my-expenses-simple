CREATE TABLE [dbo].[ExpenseType]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(100) NOT NULL,
	[IsEnabled] BIT CONSTRAINT [DF_ExpenseType_IsEnabled] DEFAULT 1,
	CONSTRAINT [PK_ExpenseType_Id] PRIMARY KEY([Id]),
	CONSTRAINT [UQ_ExpenseType_Name] UNIQUE([Name])
)
