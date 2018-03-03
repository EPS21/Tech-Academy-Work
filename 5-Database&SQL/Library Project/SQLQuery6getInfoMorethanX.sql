CREATE PROC getInfoMorethanX @NumberOfBooks int
AS
SELECT 
	BO.Name, BO.Address, count(BL.CardNo) as 'Books Checked Out'
	FROM BORROWER BO
	join BOOK_LOANS BL ON BO.CardNo = BL.CardNo
	GROUP BY BO.Name, BO.Address
	HAVING count(BL.CardNo) > @NumberOfBooks
;
GO
exec [dbo].[getInfoMorethanX] @NumberOfBooks = 5
