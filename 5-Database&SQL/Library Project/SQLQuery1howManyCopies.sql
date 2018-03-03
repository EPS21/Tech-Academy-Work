--1. How many copies of the book titled "The Lost Tribe" are owned by the library branch whose name is "Sharpstown"?
CREATE PROC dbo.howManyCopies @Title nvarchar(30) = NULL, @BranchName nvarchar(30) = NULL --(bookid, branch_id)
AS 
SELECT 
	No_Of_Copies
	FROM BOOK_COPIES
	INNER JOIN BOOK ON BOOK.BookID = BOOK_COPIES.BookID
	INNER JOIN LIBRARY_BRANCH ON LIBRARY_BRANCH.BranchID = BOOK_COPIES.BranchID	
	WHERE Title = ISNULL(@Title, Title)
	AND BranchName = ISNULL(@BranchName, BranchName)
;
GO
exec [dbo].[howManyCopies] @Title = 'The Lost Tribe', @BranchName = 'Sharpstown'