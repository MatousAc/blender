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

insert into category 
values('Meat'); 

insert into category 
values('Drink'); 

-- some basic units (surprisingly, we don't really need more than this)
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
values('gallon', 'Volume', 'Imperial');

insert into unit
values('liter', 'Volume', 'Metric');

insert into unit
values('gram', 'Weight', 'Metric');

insert into unit
values('kilogram', 'Weight', 'Metric');

insert into unit
values('count', 'NULL', 'Universal');


-- getting started with some ingredients

insert into ingredient
values('egg', null, null, null, null);

insert into ingredient
values('apple', null, null, null, null);

insert into ingredient
values('blueberry', null, null, null, null);

insert into ingredient
values('butter', null, null, null, null);

insert into ingredient
values('carrot', null, null, null, null);

insert into ingredient
values('cheese', null, null, null, null);

insert into ingredient
values('cornstarch', null, null, null, null);

insert into ingredient
values('flour', null, null, null, null);

insert into ingredient
values('honey', null, null, null, null);

insert into ingredient
values('mayple syrup', null, null, null, null);

insert into ingredient
values('milk', null, null, null, null);

insert into ingredient
values('orange', null, null, null, null);

insert into ingredient
values('celery stalk', null, null, null, null);

insert into ingredient
values('rice', null, null, null, null);

insert into ingredient
values('raspberry', null, null, null, null);

insert into ingredient
values('romaine lettuce', null, null, null, null);

insert into ingredient
values('salt', null, null, null, null);

insert into ingredient
values('vanilla', null, null, null, null);

insert into ingredient
values('water', null, null, null, null);

insert into ingredient
values('whole wheat flour', null, null, null, null);

insert into ingredient
values('flour', null, null, null, null);

insert into ingredient
values('chocolate', null, null, null, null);

insert into ingredient
values('frosting', null, null, null, null);

insert into ingredient
values('strawberry', null, null, null, null);

insert into ingredient
values('seaweed sheet', null, null, null, null);

insert into ingredient
values('avocado', null, null, null, null);

insert into ingredient
values('garbanzo bean', null, null, null, null);

insert into ingredient
values('vinegar', null, null, null, null);

insert into ingredient
values('lemon', null, null, null, null);

