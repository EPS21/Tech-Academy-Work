/*****************
 **** Video 1 ****
 *****************/

USE db_zooTest

CREATE TABLE tbl_animalia (
	animalia_id INT PRIMARY KEY NOT NULL IDENTITY (1,1),
	animalia_type VARCHAR(50) NOT NULL
);

INSERT INTO tbl_animalia
	(animalia_type)
	VALUES
	('vertebrate'),
	('invertebrate')
;
SELECT * FROM tbl_animalia;

CREATE TABLE tbl_class (
	class_id INT PRIMARY KEY NOT NULL IDENTITY (100,1),
	class_type VARCHAR(50) NOT NULL
);

INSERT INTO tbl_class
	(class_type)
	VALUES
	('bird') , ('reptilian') , ('mammal') , ('arthropod') , ('fish') , ('worm') , ('cnidaria') , ('echinoderm')
;
SELECT * FROM tbl_class;

INSERT INTO tbl_class
	(class_type) VALUES ('aura');

/* Overwrite the field 'bird' to 'birds' */
UPDATE tbl_class SET class_type = 'birds' WHERE class_type = 'bird';

/* Temporarily replace a value with SELECT */
SELECT REPLACE(class_type, 'worm' /*old value*/, 'wormssss' /*new value*/) FROM tbl_class;

/* selects from col class_type where value = birds */
SELECT class_type FROM tbl_class WHERE class_type = 'birds';

SELECT UPPER(class_type) FROM tbl_class WHERE class_type = 'birds';
SELECT COUNT(class_type) FROM tbl_class WHERE class_type = 'birds';


