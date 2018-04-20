CREATE TABLE [dbo].[Customers]
(
	[CustomerID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [Name] VARCHAR(50) NOT NULL, 
    [Address] VARCHAR(50) NOT NULL, 
    [City] VARCHAR(50) NOT NULL, 
    [State] VARCHAR(50) NOT NULL, 
    [PostalCode] VARCHAR(50) NOT NULL, 
    [Notes] VARCHAR(MAX) NULL
)
