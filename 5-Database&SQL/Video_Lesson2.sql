/*******************
 ***** Video 2 *****
 *******************/

 /* Making a table of persons */
CREATE TABLE tbl_persons (
	persons_id INT PRIMARY KEY NOT NULL IDENTITY (1,1),
	persons_fname VARCHAR(50) NOT NULL,
	persons_lname VARCHAR(50) NOT NULL,
	persons_contact VARCHAR(50) NOT NULL
);

INSERT INTO tbl_persons
	(persons_fname, persons_lname, persons_contact)
	VALUES
	('bob', 'smith', '555-123-4567'),
	('mary', 'sue', '222-333-8765'),
	('tex', 'burns', '543-123-7777'),
	('gerry', 'kerns', '555-123-9999'),
	('sally', 'fields', '364-321-3344')
;

SELECT * FROM tbl_persons;

/* Here's a whole bunch of different ways you can manipulate data in the table */

/* Selects fname, lname, contact from tbl, between and including ID's of 2 and 5 */
SELECT persons_fname, persons_lname, persons_contact FROM tbl_persons WHERE persons_id BETWEEN 2 AND 5;

/* Selects fname, lname, contact from tbl, and finds last_names like "ke%" (% is wildcard) */
SELECT persons_fname, persons_lname, persons_contact FROM tbl_persons WHERE persons_lname LIKE 'ke%';

/* Selects fname, lname, contact from tbl, and finds last_name like "_u%s" (skips first letter, u is second letter, and ends in s) */
SELECT persons_fname, persons_lname, persons_contact FROM tbl_persons WHERE persons_lname LIKE '_u%s';

/* finds persons_fname that starts with m, and then sorts it in descending alphabetical notation */
SELECT persons_fname, persons_lname, persons_contact FROM tbl_persons WHERE persons_fname LIKE 'm%' ORDER BY persons_fname DESC;

/* Makes your query temporarily change column names with AS */
SELECT persons_fname AS 'Firstname', persons_lname AS 'Lastname', persons_contact AS 'phone #' FROM tbl_persons ORDER BY persons_lname ASC;

/* Makes a permanent change to tbl_persons, pointing to persons_fname column, and changing it to mars where the persons_fname = bob */
UPDATE tbl_persons SET persons_fname = 'mars' WHERE persons_fname = 'bob';

/* How to delete an entry from the table */
DELETE FROM tbl_persons WHERE persons_lname = 'smith';

/* Delete the whole table */
DROP TABLE tbl_persons