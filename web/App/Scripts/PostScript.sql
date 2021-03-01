﻿SET IDENTITY_INSERT [dbo].[ExpenseType] ON 
GO

INSERT INTO [dbo].[ExpenseType] ([Id], [Name], [IsEnabled])
VALUES 
	(1, 'Clothes', 1),
	(2, 'Food', 1),
	(3, 'Gas', 1),
	(4, 'Gift', 1),
	(5, 'Grocery', 1),
	(6, 'Medicine', 1),
	(7, 'Rent', 1),
	(8, 'Travel', 1)
GO

SET IDENTITY_INSERT [dbo].[ExpenseType] OFF
GO



INSERT INTO [dbo].[Expense] ([ExpenseTypeId], [Amount], [Date])
VALUES 
	(1, 100, '2021-03-01'),
	(2, 300, '2021-03-01'),
	(3, 1000, '2021-03-01'),
	(4, 500, '2021-03-01'),
	(5, 100, '2021-03-01'),
	(6, 100, '2021-03-01'),
	(7, 100, '2021-03-01'),
	(8, 100, '2021-03-01'),
	(1, 100, '2021-03-02'),
	(2, 300, '2021-03-02'),
	(3, 1000, '2021-03-02'),
	(4, 500, '2021-03-03'),
	(5, 100, '2021-03-03'),
	(6, 100, '2021-03-03'),
	(7, 100, '2021-03-03'),
	(8, 100, '2021-03-03'),
	(1, 100, '2021-03-07'),
	(2, 300, '2021-03-08'),
	(3, 1000, '2021-03-10'),
	(4, 500, '2021-03-10'),
	(5, 100, '2021-03-15'),
	(6, 100, '2021-03-15'),
	(7, 100, '2021-03-18'),
	(8, 100, '2021-03-19'),
	(1, 100, '2021-03-21'),
	(2, 300, '2021-03-21'),
	(3, 1000, '2021-03-21'),
	(4, 500, '2021-03-21'),
	(5, 100, '2021-03-22'),
	(6, 100, '2021-03-23'),
	(7, 100, '2021-03-23'),
	(8, 100, '2021-03-25')
GO