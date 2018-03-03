use db_zooTest

select * from tbl_species

select * from tbl_nutrition

select species_name from tbl_species;

/* Drill 1 */
SELECT * FROM tbl_habitat;

/* Drill 2 */
SELECT species_name FROM tbl_species WHERE species_order = 3;

/* Drill 3 */ 
SELECT nutrition_type FROM tbl_nutrition WHERE nutrition_cost <= 600;

/* Drill 4 */
SELECT
	species_name, species_nutrition
	FROM tbl_species
	INNER JOIN tbl_nutrition ON tbl_nutrition.nutrition_id = tbl_species.species_nutrition
	WHERE species_nutrition BETWEEN 2202 AND 2206 ORDER BY species_nutrition ASC
;

/* Drill 5 */
SELECT
	species_name AS 'Species Name:',
	nutrition_type AS 'Nutrition Type:'
	FROM tbl_species
	JOIN tbl_nutrition on tbl_nutrition.nutrition_id = tbl_species.species_nutrition
;

/* Drill 6 */ 
select * from tbl_specialist
select * FROM tbl_care
select * from tbl_species

SELECT
	specialist_fname,
	specialist_lname,
	specialist_contact
	FROM tbl_specialist
	INNER JOIN tbl_care ON tbl_care.care_specialist = tbl_specialist.specialist_id
	INNER JOIN tbl_species ON tbl_care.care_id = tbl_species.species_care
	WHERE species_name = 'penguin'
;

/* Drill 7 */
