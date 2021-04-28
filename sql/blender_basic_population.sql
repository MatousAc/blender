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

insert into unit_type 
values('NULL'); 

-- some prescribed categories
insert into category 
values('Breakfast'); 

insert into category 
values('Entree'); 

insert into category 
values('Dessert'); 

-- some basic units
insert into unit
values('cup', 'Volume', 'Imperial');

insert into unit
values('teaspoon', 'Volume', 'Imperial');

insert into unit
values('tablespoon', 'Volume', 'Imperial');

insert into unit
values('quart', 'Volume', 'Imperial');

insert into unit
values('pint', 'Volume', 'Imperial');

insert into unit
values('allon', 'Volume', 'Imperial');

insert into unit
values('liter', 'Volume', 'Metric');

insert into unit
values('gram', 'Weight', 'Metric');

insert into unit
values('kilogram', 'Weight', 'Metric');

insert into unit
values('count', 'NULL', 'Universal');

insert into unit
values('pinch', 'NULL', 'Universal');