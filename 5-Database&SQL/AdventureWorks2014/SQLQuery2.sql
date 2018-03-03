exec [dbo].[uspGetAddress1]
exec [dbo].[uspGetAddress] @City = 'New York'
exec [dbo].[uspGetAddress2]

DECLARE @AddressCount INT
exec dbo.uspGetAddressCount @City = 'Seattle', @AddressCount = @AddressCount OUTPUT SELECT @AddressCount
-- SELECT @AddressCount

exec [dbo].[uspTryCatchTest]
exec [dbo].[uspGetAddressNoCount] @City = 'San Francisco'
exec [dbo].[uspGetCity] @City = 'ne%'