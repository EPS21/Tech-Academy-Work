CREATE PROC getBookCopiesByAuthor @AuthorName nvarchar(30), @BranchName nvarchar(30)
AS
SELECT
	BOOK.Title, BC.No_Of_Copies
	FROM BOOK_COPIES BC
	join BOOK on BC.BookID = BOOK.BookID
	join BOOK_AUTHORS BA on BOOK.BookID = BA.BookID
	join LIBRARY_BRANCH LB on BC.BranchID = LB.BranchID
	WHERE BA.AuthorName = @AuthorName AND LB.BranchName = @BranchName
;
GO
exec getBookCopiesByAuthor @AuthorName = 'Stephen King', @BranchName = 'Central'