CREATE PROC booksDueToday @BranchName nvarchar(30)
AS
SELECT 
	BOOK.Title, BO.Name, BO.Address, BL.DueDate
	FROM BORROWER BO
	join BOOK_LOANS BL ON BO.CardNo = BL.Cardno
	join BOOK ON BL.BookID = BOOK.BookID
	join LIBRARY_BRANCH LB ON BL.BranchID = LB.BranchID
	WHERE BranchName = @BranchName AND BL.DueDate = convert(date, getdate())
;
GO
exec [dbo].[booksDueToday] @BranchName = 'Sharpstown'
