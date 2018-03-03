CREATE DATABASE db_mon;
USE db_mon;

/* Make tables and insert data of various monster stats */
CREATE TABLE tbl_race (
	race_id INT PRIMARY KEY NOT NULL IDENTITY (0,10),
	race_type VARCHAR (20) NOT NULL	
);
INSERT INTO tbl_race
	(race_type)
	VALUES ('Formless'),('Undead'),('Brute'),('Plant'),('Insect'),('Fish'),('Demon'),('Demi-Human'),('Angel'),('Dragon')
;
SELECT * FROM tbl_race;

CREATE TABLE tbl_property (
	property_id INT PRIMARY KEY NOT NULL IDENTITY (1,1),
	property_type VARCHAR (20) NOT NULL
);
INSERT INTO tbl_property
	(property_type)
	VALUES ('Neutral'),('Water'),('Earth'),('Fire'),('Wind'),('Poison'),('Holy'),('Shadow'),('Ghost'),('Undead')
;
SELECT * FROM tbl_property;

/* The main table of monsters with the Foreign Key */
CREATE TABLE tbl_monster (
	monster_id INT PRIMARY KEY NOT NULL IDENTITY (1000,1),
	monster_name VARCHAR (50) NOT NULL,
	monster_hp INT NOT NULL,
	monster_race INT NOT NULL CONSTRAINT fk_race_id FOREIGN KEY REFERENCES tbl_race(race_id) ON UPDATE CASCADE ON DELETE CASCADE,
	monster_property INT NOT NULL CONSTRAINT fk_property_id FOREIGN KEY REFERENCES tbl_property(property_id) ON UPDATE CASCADE ON DELETE CASCADE	
);

/* Make some monsters in the tbl_monster table */
INSERT INTO tbl_monster	
	(monster_name, monster_hp, monster_race, monster_property) /* This statement not needed? */
	VALUES
	('Scorpion', 1109, 40, 4),
	('Poring', 50, 0, 2),
	('Hornet', 169, 40, 5),
	('Familiar', 155, 20, 8)
;
SELECT * FROM tbl_monster;

/* query the monster and their associated stats from both tables */
SELECT 
	x.monster_name, x.monster_hp, tbl_race.race_type, tbl_property.property_type
	FROM
	tbl_monster x
	INNER JOIN tbl_race ON tbl_race.race_id = x.monster_race
	INNER JOIN tbl_property ON tbl_property.property_id = x.monster_property
;

SELECT *
	FROM
	tbl_monster
	INNER JOIN tbl_property on tbl_property.property_id = tbl_monster.monster_property
;

/* group by */
SELECT COUNT(monster_property), monster_hp
	FROM tbl_monster
	GROUP BY monster_hp
	ORDER BY monster_hp asc
;

/* having */
select * from tbl_monster where monster_hp > 100;




select * from tbl_race;
select * from tbl_property;
