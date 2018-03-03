CREATE PROC totalBooksLoanedOut
AS
SELECT
	LB.BranchName, count(BL.BranchID) as 'Total books loaned out'
	FROM BOOK_LOANS BL
	join LIBRARY_BRANCH LB ON BL.BranchID = LB.BranchID
	GROUP BY LB.BranchName
;
GO
exec [dbo].[totalBooksLoanedOut]
