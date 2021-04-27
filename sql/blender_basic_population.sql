use blender

-- hard-coding skill levels
insert into skill_level 
values('Beginner');

insert into skill_level 
values('Intermediate');

insert into skill_level 
values('Advanced');

-- setting systems
insert into unit_system 
values('Universal'); -- for things that need not be converted

insert into unit_system 
values('Metric'); 

insert into unit_system 
values('Imperial'); 

-- some basic unit-types
insert into unit_type 
values('Volume'); 

insert into unit_type 
values('Weight'); 

-- some prescribed categories
insert into category 
values('Breakfast'); 

insert into category 
values('Entree'); 

insert into category 
values('Dessert'); 
