--2. How many copies of the book titled "The Lost Tribe" are owned by each library branch?
create PROC dbo.howManyInEachLibrary @Title nvarchar(30) = NULL
AS
SELECT 
	No_Of_Copies, BranchName
	FROM BOOK_COPIES
	INNER JOIN BOOK ON BOOK.BookID = BOOK_COPIES.BookID
	INNER JOIN LIBRARY_BRANCH ON BOOK_COPIES.BranchID = LIBRARY_BRANCH.BranchID	
	WHERE Title = @Title
;
GO
exec [dbo].[howManyInEachLibrary] @Title = 'The Lost Tribe'
