/***********************************************************
 * These are the query statements that are saved as stored *
 * procedures which can be run with different values	   *
 * depending on what you want to display *******************
 ***********************************************************/

/* Some queries for testing */
select * from book
select * from book order by bookid asc
select * from book where Title like 'w%';
select * from book where bookid = '3'
select count(bookid) from book
select * from book where BookID > 5 order by 

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

/* alternative way to do this */
SELECT BORROWER.Name
FROM BORROWER
WHERE BORROWER.CardNo NOT IN
(SELECT BOOK_LOANS.CardNo FROM BOOK_LOANS);

--4. For each book that is loaned out from the "Sharpstown" branch and whose DueDate is today, retrieve the book title, the borrower's name, and the borrower's address.
select * from borrower
select * from BOOK_LOANS
select * from BOOK

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

/* More Notes */
select month(getdate())
select convert(varchar(11), getdate())
SELECT sysdatetime()
select getdate() --gets currenet date and time
select convert(date, getdate()) --gets current date without time
select convert(time, getdate()) --gets time without date

--5. For each library branch, retrieve the branch name and the total number of books loaned out from that branch.
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

--6. Retrieve the names, addresses, and number of books checked out for all borrowers who have more than five books checked out.
-- you can't do a normal select with a count (aggregate function) without the GROUP BY statement
-- you have to do HAVING instead of WHERE if its followed by a GROUP BY statement
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

--7. For each book authored by "Stephen King", retrieve the title and the number of copies owned by the library branch whose name is "Central".
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