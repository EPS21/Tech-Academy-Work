/****************
 *** Video 5 ****
 ****************/

print 'hello world!'

declare @myVariable INT
SET @myVariable = 7;
print @myVariable;

declare @var1 float, @var2 float
Set @var1 = 3
Set @var2 = 6

/* char(9) is a Tab, char(13) is a line break */
print char(9) + char(13) + 'having fun with linlin' + ' and TrannySQL and MS SQL Server! and ' + convert(varchar(50),(@var1 * @var2))
print char(13) + convert(varchar(20),(@var1 / @var2)) + char(13)

/* Logic statements */

IF @var1 != 3
	BEGIN
		print 'variable 1 is ' + convert(varchar(5),@var1) +  ' and not 3.'
	END
ELSE
	BEGIN
		print 'variable 1 is indeed equal to 3'
	END