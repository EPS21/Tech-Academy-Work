USE AdventureWorks2014
GO

/* uspGetAddress2, can accept blank agruments and multiple args*/
CREATE PROCEDURE dbo.uspGetAddress2 @City nvarchar(30) = NULL, @AddressLine1 nvarchar(60) = NULL
AS
SELECT * 
	FROM Person.Address
	WHERE City = ISNULL(@City, City)
	AND AddressLine1 LIKE '%' + ISNULL(@AddressLine1, AddressLine1) + '%'
GO

-- address count
CREATE PROCEDURE dbo.uspGetAddressCount @City nvarchar(30), @AddressCount int OUTPUT
AS
SELECT @AddressCount = count(*)
	FROM Person.Address
	WHERE City = @City
GO

-- try catch
CREATE PROCEDURE dbo.uspTryCatchTest
AS
BEGIN TRY
    SELECT 1/0
END TRY
BEGIN CATCH
    SELECT ERROR_NUMBER() AS ErrorNumber
     ,ERROR_SEVERITY() AS ErrorSeverity
     ,ERROR_STATE() AS ErrorState
     ,ERROR_PROCEDURE() AS ErrorProcedure
     ,ERROR_LINE() AS ErrorLine
     ,ERROR_MESSAGE() AS ErrorMessage;
END CATCH

-- using SET NOCOUNT ON 
CREATE PROCEDURE dbo.uspGetAddressNoCount @City nvarchar(30)
AS
SET NOCOUNT ON
SELECT * 
FROM Person.Address
WHERE City = @City
GO

--------------Dropping stored procedures--------------
DROP PROCEDURE dbo.uspTryCatchTest
GO

DROP PROC dbo.uspTryCatchTest, dbo.uspGetAddressNoCount
GO

----------------Altering Procedures-------------------
CREATE PROCEDURE dbo.uspGetCity @City nvarchar(30)
AS
SELECT * 
FROM Person.Address
WHERE City = @City
GO

ALTER PROCEDURE dbo.uspGetCity @City nvarchar(30)
AS
SELECT * 
FROM Person.Address
WHERE City LIKE @City + '%'
GO