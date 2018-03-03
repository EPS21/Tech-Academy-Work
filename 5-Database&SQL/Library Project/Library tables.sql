
USE db_books;

IF Exists (Select 1 FROM INFORMATION_SCHEMA.TABLES BOOK_LOANS)
DROP TABLE BOOK_LOANS, BORROWER, BOOK_COPIES, LIBRARY_BRANCH, BOOK_AUTHORS, BOOK, PUBLISHER;


/*************************
 ** Book Related Tables **
 *************************/
CREATE TABLE PUBLISHER (
	Name VARCHAR(50) NOT NULL,
	Address VARCHAR(50) NULL,
	Phone VARCHAR(50) NOT NULL,
	PRIMARY KEY (Name)
);
CREATE TABLE BOOK (
	BookID INT NOT NULL IDENTITY (1,1),
	Title VARCHAR (50) NOT NULL,
	PublisherName VARCHAR (50) NOT NULL,
	PRIMARY KEY (BookID),
	FOREIGN KEY (PublisherName) REFERENCES PUBLISHER(Name)
);
CREATE TABLE BOOK_AUTHORS (
	BookID INT NOT NULL,
	AuthorName VARCHAR(50) NOT NULL,
	PRIMARY KEY (BookID),
	FOREIGN KEY (BookID) REFERENCES BOOK(BookID)
);
/****************************
 ** Library related tables **
 ****************************/
CREATE TABLE LIBRARY_BRANCH (
	BranchID INT NOT NULL IDENTITY (1,1),
	BranchName VARCHAR(50) NOT NULL,
	Address VARCHAR(50) NOT NULL,
	PRIMARY KEY (BranchID),
);
CREATE TABLE BOOK_COPIES (
	BookID INT NOT NULL,
	BranchID INT NOT NULL,
	No_Of_Copies INT NOT NULL,
	--PRIMARY KEY (BookID), (No primary key on BookID to have multiple books)
	FOREIGN KEY (BookID) REFERENCES BOOK(BookID),
	FOREIGN KEY (BranchID) REFERENCES LIBRARY_BRANCH(BranchID),
);
CREATE TABLE BORROWER (
	CardNo INT NOT NULL IDENTITY (101,1),
	Name VARCHAR(50) NOT NULL,
	Address VARCHAR(50) NOT NULL,
	Phone VARCHAR(50) NOT NULL,
	PRIMARY KEY (CardNo)
);
CREATE TABLE BOOK_LOANS (
	BookID INT NOT NULL,
	BranchID INT NOT NULL,
	CardNo INT NOT NULL,
	DateOut DATE NOT NULL,
	DueDate DATE NOT NULL,
	--PRIMARY KEY (BookID), (No primary key on BookID to have multiple books)
	FOREIGN KEY (BookID) REFERENCES BOOK(BookID),
	FOREIGN KEY (BranchID) REFERENCES LIBRARY_BRANCH(BranchID),
	FOREIGN KEY (CardNo) REFERENCES BORROWER(CardNo)
);
/************************************
 ** Inserting data into the tables **
 ************************************/
INSERT INTO PUBLISHER
	(Name, Address, Phone)
	VALUES
	('Stumptown', '123 Fake St', '123-456-7890'),
	('Ltd Press', '555 BRZ St', '253-123-4567'), 
	('Viking', '1038 Main St', '360-666-7773'),
	('Obama Press', '1600 Pennsylvania Ave', '202-456-1111')
;
SELECT * FROM PUBLISHER;

INSERT INTO BOOK
	(Title, PublisherName)
	VALUES
	('The Lost Tribe', 'Stumptown'),
	('It', 'Viking'), --Stephen King book 1
	('The Shining', 'Viking'), --Stephen King book 2
	('The Hungry Games', 'Ltd Press'),
	('50 Shades of Grey', 'Stumptown'),
	('Who Moved My Cheese?', 'Viking'),
	('Good to Great', 'Obama Press'),
	('The Help', 'Stumptown'),
	('Welcome to the NHK','Viking'),
	('Food','Ltd Press'),

	('Street Fighter the Movie the Game','Viking'),
	('Becoming','Obama Press'),
	('Top 20 Doge Pics','Stumptown'),
	('Buzzfeed but its in a book','Viking'),
	('The bee movie','Ltd Press'),
	('but everytime they say bee','Ltd Press'),
	('It gets faster','Ltd Press'),
	('Enough As She Is','Obama Press'),
	('How to care for your Snorlax','Viking'),
	('Naked Lunch','Viking'),
	('1984', 'Stumptown')
;
SELECT * FROM BOOK;

INSERT INTO BOOK_AUTHORS
	(BookID, AuthorName)
	VALUES
	(1 , 'William King'),
	(2 , 'Stephen King'),
	(3 , 'Stephen King'),
	(4 , 'Suzanne Collins'),
	(5 , 'E L James'),
	(6 , 'Ono San'),
	(7 , 'Michelle Obama'),
	(8 , 'Brian Orland'),
	(9 , 'Tatsuhiko Takimoto'),
	(10 , 'Margaret Thatcher'),

	(11, 'Ono San'),
	(12, 'Michelle Obama'),
	(13, 'William King'),
	(14, 'E L James'),
	(15, 'Brian Orland'),
	(16, 'Brian Orland'),
	(17, 'Brian Orland'),
	(18, 'Michelle Obama'),
	(19, 'Tatsuhiko Takimoto'),
	(20, 'William S. Burroughs'),
	(21, 'George Orwell')
	
;
SELECT * FROM BOOK_AUTHORS;


/* Library Data */
INSERT INTO LIBRARY_BRANCH
	(BranchName, Address)
	VALUES
	('Sharpstown', '456 EvenFaker St.'), --Branch 1
	('Central', '828 Tallywager St.'), --Branch 2
	('Gig Harbor', '4424 Point Fosdick Dr NW'), -- Branch 3
	('Seattle Central Library', '1000 4th Ave') -- Branch 4
;
SELECT * FROM LIBRARY_BRANCH

INSERT INTO BOOK_COPIES
	(BookID, BranchID, No_Of_Copies)
	VALUES
	-- Sharpstown Branch --
	(01, 1, 15), (02, 1, 20), (03, 1, 20), (04, 1, 20), (05, 1, 20), (06, 1, 20), (07, 1, 20), (08, 1, 20), (09, 1, 20), (10, 1, 20), 
	-- Central Branch --
	(02, 2, 13), (03, 2, 10), (12, 2, 20), (13, 2, 20), (14, 2, 20), (15, 2, 20), (16, 2, 20), (17, 2, 20), (18, 2, 20), (19, 2, 20), 
	-- Gig Harbor Branch --
	(05, 3, 20), (10, 3, 20), (15, 3, 20), (20, 3, 20), (19, 3, 20), (01, 3, 20), (02, 3, 20), (03, 3, 20), (04, 3, 20), (06, 3, 20), 
	-- Seattle Branch --
	(02, 4, 20), (04, 4, 20), (06, 4, 20), (08, 4, 20), (10, 4, 20), (12, 4, 20), (14, 4, 20), (16, 4, 20), (18, 4, 20), (20, 4, 20)
;
SELECT * FROM BOOK_COPIES

--There are at least 8 borrowers in the BORROWER table, and at least 2 of those borrowers have more than 5 books loaned to them.
INSERT INTO BORROWER
	(Name, Address, Phone)
	VALUES
	('Eric', '7706 40th st ct NW', '555-313-8888'),
	('Daniel', '5454 Risebridge Ct', '765-237-9854'),
	('Ronaldo', '694 Turkey Way', '562-089-7345'),
	('Didi', '9877 Gong Ave', '234-763-3453'),
	('Sally', '2233 Buhnrob St', '232-344-4567'),
	('David', '998 E Valley Way', '386-395-9953'),
	('Yulin', '110 Wanda Rd', '886-052-3456'),
	('Tony', '777 Chicken Way', '111-222-3334'),
	('Idunborrow', '12 Noborrow Way', '001-101-0011')
;
SELECT * FROM BORROWER

INSERT INTO BOOK_LOANS
	(BookID, BranchID, CardNo, DateOut, DueDate)
	VALUES --hooory ship yep its gonna be a loooong list tahts 50 of em
	
	(01 , 1, 101, '01-01-2000', convert(date, getdate())), (09 , 1, 105, '02-15-2018', convert(date, getdate())), 
	(02 , 1, 101, '01-01-2000', '01-15-2000'), (10 , 1, 105, '02-15-2018', '03-01-2018'), 
	(03 , 1, 101, '01-02-2000', '01-16-2000'), (05 , 1, 105, '01-15-2000', '01-30-2000'), 
	(04 , 1, 101, '02-01-2018', '03-01-2018'), (13 , 1, 105, '01-15-2000', '01-30-2000'), 
	(05 , 1, 101, '02-01-2018', '03-01-2018'), (21 , 1, 105, '02-15-2018', '03-01-2018'), 

	(06 , 2, 102, '01-15-2000', '01-30-2000'), (21 , 1, 106, '01-15-2000', '01-30-2000'), 
	(07 , 2, 102, '01-15-2000', '01-30-2000'), (20 , 1, 106, '01-15-2000', '01-30-2000'), 
	(08 , 2, 102, '01-15-2000', '01-30-2000'), (12 , 1, 106, '01-15-2000', '01-30-2000'), 
	(09 , 2, 102, '01-15-2000', '01-30-2000'), (02 , 1, 106, '01-15-2000', '01-30-2000'), 
	(10 , 2, 102, '01-15-2000', '01-30-2000'), (03 , 1, 106, '01-15-2000', '01-30-2000'),

	(06 , 3, 103, '01-15-2000', '01-30-2000'), (04 , 3, 107, '01-15-2000', '01-30-2000'), 
	(12 , 3, 103, '01-15-2000', '01-30-2000'), (06 , 3, 107, '01-15-2000', '01-30-2000'), 
	(15 , 3, 103, '01-15-2000', '01-30-2000'), (08 , 3, 107, '01-15-2000', '01-30-2000'), 
	(16 , 3, 103, '01-15-2000', '01-30-2000'), (10 , 3, 107, '01-15-2000', '01-30-2000'), 
	(17 , 3, 103, '01-15-2000', '01-30-2000'),  

	(17 , 4, 104, '01-15-2000', '01-30-2000'), (06 , 4, 108, '01-15-2000', '01-30-2000'), 
	(01 , 4, 104, '01-15-2000', '01-30-2000'), (07 , 4, 108, '01-15-2000', '01-30-2000'), 
	(15 , 4, 104, '01-15-2000', '01-30-2000'), (08 , 4, 108, '01-15-2000', '01-30-2000'), 
	(16 , 4, 104, '01-15-2000', '01-30-2000'), (09 , 4, 108, '01-15-2000', '01-30-2000'), 
	(17 , 4, 104, '01-15-2000', '01-30-2000'), (10 , 4, 108, '01-15-2000', '01-30-2000'), 

	(11 , 4, 108, '01-15-2000', '01-30-2000'), (11 , 3, 108, '01-15-2000', '01-30-2000'),
	(12 , 4, 108, '01-15-2000', '01-30-2000'), (01 , 2, 101, '02-15-2018', convert(date, getdate())),
	(13 , 4, 108, '01-15-2000', '01-30-2000'), 
	(14 , 4, 108, '01-15-2000', '01-30-2000'), 
	(15 , 4, 108, '01-15-2000', '01-30-2000'), 
	(16 , 4, 108, '01-15-2000', '01-30-2000'), 
	(17 , 4, 108, '01-15-2000', '01-30-2000'), 
	(18 , 4, 108, '01-15-2000', '01-30-2000'), 
	(19 , 4, 108, '01-15-2000', '01-30-2000'), 
	(20 , 4, 108, '01-15-2000', '01-30-2000')
;
SELECT * FROM BOOK_LOANS

/*
/* Some select statements to check stuff like FK */
SELECT BOOK_COPIES.BookID, BOOK.Title, LIBRARY_BRANCH.BranchName FROM BOOK_COPIES
	JOIN BOOK ON BOOK.BookID = BOOK_COPIES.BookID
	JOIN LIBRARY_BRANCH ON LIBRARY_BRANCH.BranchID = BOOK_COPIES.BranchID

SELECT
	*
	FROM BOOK
	JOIN PUBLISHER ON PUBLISHER.Name = BOOK.PublisherName
	WHERE Title = 'It'
;
*/
--DELETE FROM BOOK;
--DELETE FROM PUBLISHER;