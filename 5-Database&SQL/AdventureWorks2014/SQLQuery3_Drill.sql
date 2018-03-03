select * from [Person].[Person]
select * from [Person].[EmailAddress]
select * from [Person].[Password]

DROP PROC dbo.uspGetPersonAndEmail
CREATE PROC dbo.uspGetPersonAndEmail @FirstName nvarchar(30) = NULL, @LastName nvarchar(60) = NULL
AS
SELECT 
	Person.BusinessEntityID, 
	Person.FirstName, 
	Person.LastName, 
	Person.EmailAddress.EmailAddress,
	Person.Password.PasswordSalt
	FROM Person.Person
	JOIN Person.EmailAddress ON Person.EmailAddress.BusinessEntityID = Person.Person.BusinessEntityID
	JOIN Person.Password ON Person.Password.BusinessEntityID = Person.Person.BusinessEntityID
	WHERE FirstName LIKE ISNULL(@FirstName, FirstName)
	AND LastName LIKE ISNULL(@LastName, LastName)
GO

EXEC [dbo].[uspGetPersonAndEmail] @FirstName = 'z%', @LastName = '%z'

