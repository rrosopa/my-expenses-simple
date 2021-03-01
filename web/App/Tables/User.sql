CREATE TABLE [dbo].[User]
(
	[Id]                    INT NOT NULL IDENTITY(1,1),
    [PublicId]              NVARCHAR(38) NOT NULL,
    [Email]                 NVARCHAR(256) NOT NULL, 
    [PasswordHash]          NVARCHAR(1000) NULL, 
    [FirstName]             NVARCHAR(256) NOT NULL, 
    [MiddleName]            NVARCHAR(256) NULL, 
    [LastName]              NVARCHAR(256) NOT NULL, 
    [Suffix]                NVARCHAR(5) NULL, 
    [IsEnabled]             BIT NOT NULL CONSTRAINT [DF_User_IsEnabled] DEFAULT 1, 
    [IsLocked]              BIT NOT NULL CONSTRAINT [DF_User_IsLocked] DEFAULT 0, 
    [ConcurrencyStamp]      NVARCHAR(38) NOT NULL CONSTRAINT [DF_User_ConcurrencyStamp] DEFAULT NEWID(), 
    [CreatedBy]             INT NOT NULL, 
    [CreatedDate]           DATETIMEOFFSET NOT NULL CONSTRAINT [DF_User_CreatedDate] DEFAULT GETDATE(), 
    [LastModifiedBy]        INT NOT NULL, 
    [LastModifiedDate]      DATETIMEOFFSET NOT NULL CONSTRAINT [DF_User_LastModifiedDate] DEFAULT GETDATE(),

    CONSTRAINT PK_User PRIMARY KEY([Id]),
    CONSTRAINT UQ_User_PublicId UNIQUE([PublicId])
)