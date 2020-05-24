CREATE TYPE [dbo].[BasicUserDT] AS TABLE
(
	[Id] NVARCHAR(128),
	[FirstName] NVARCHAR(50),
	[LastName] NVARCHAR(50),
	[EmailAddress] NVARCHAR(256),
    [PhoneNumber] NVARCHAR(20) 
)
