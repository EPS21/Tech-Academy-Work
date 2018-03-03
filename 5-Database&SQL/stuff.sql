use db_zoo;
use db_zooTest;

/* Creates a new database */
create database db_zooTest

/* Creates a new table and instantiates new columns */
create table tbl_animalia (
	animalia_id int primary key not null identity (1,1),
	animalia_type varchar(50) not null
);

/* Inserts values into the tbl_animalia */
insert into tbl_animalia
	(animalia_type)
	values ('vertebrate'),('invertebrate'),('supervertebrate'),('superdupervertebrate')
select * from tbl_animalia;

/* Sets it so you can insert by animalia_id, normally restricted because of primary key */
set identity_insert tbl_animalia ON

/* Another way to insert */
insert into tbl_animalia (animalia_id, animalia_type)
values (3, 'superdupervertebrate');

/* selects everything from the table and displays it */
select * from tbl_animalia;
select * from tbl_1;

/* sorts the values in the tbl and sorts them in various ways */
select * from tbl_animalia order by animalia_id desc;
select * from tbl_animalia order by animalia_type asc;

/* copies values from tbl_animalia into new tbl_1 */
select * into tbl_1 from tbl_animalia;
select animalia_type into tbl_1 from tbl_animalia order by animalia_type desc;

/* delete values from table */
delete from tbl_1 where animalia_type = 'supervertebrate';
delete from tbl_animalia;

/* deletes the WHOLE table from memory */
drop table tbl_animalia;
drop table tbl_1;


