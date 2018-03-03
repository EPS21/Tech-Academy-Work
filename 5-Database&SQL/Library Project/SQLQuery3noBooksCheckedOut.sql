--3. Retrieve the names of all borrowers who do not have any books checked out.
CREATE PROC noBooksCheckedOut
AS
	SELECT borrower.Name, BL.CardNo
	FROM BOOK_LOANS as BL
	RIGHT JOIN BORROWER 
	ON BL.CardNo = BORROWER.CardNo
	WHERE BL.CardNo IS NULL
;
GO
exec [dbo].[noBooksCheckedOut]
