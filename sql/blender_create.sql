-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2021-04-20 22:34:52.77

use blender

-- tables
-- Table: skill_level
CREATE TABLE skill_level (
    name varchar(20)  NOT NULL,
    CONSTRAINT skill_level_pk PRIMARY KEY  (name)
);

-- Table: unit_system
CREATE TABLE unit_system (
    name varchar(20)  NOT NULL,
    CONSTRAINT unit_system_pk PRIMARY KEY  (name)
);

-- Table: unit_type
CREATE TABLE unit_type (
    name varchar(20)  NOT NULL,
    CONSTRAINT unit_type_pk PRIMARY KEY  (name)
);

-- Table: unit
CREATE TABLE unit (
    name varchar(100)  NOT NULL,
    type varchar(20)  NOT NULL,
    system varchar(20)  NOT NULL,
    CONSTRAINT unit_pk PRIMARY KEY  (name),
	FOREIGN KEY (system)
    REFERENCES unit_system (name)
		ON DELETE cascade
		ON UPDATE cascade,
	FOREIGN KEY (type)
    REFERENCES unit_type (name)
		ON DELETE cascade
		ON UPDATE cascade
);

-- Table: category
CREATE TABLE category (
    name varchar(50)  NOT NULL,
    CONSTRAINT category_pk PRIMARY KEY  (name)
);

-- Table: chef
CREATE TABLE chef (
    chef_id int  NOT NULL IDENTITY(0, 1),
    first_name varchar(100)  NOT NULL,
    last_name varchar(100)  NOT NULL,
    profile image  NULL,
    dob date  NOT NULL,
    bio text  NULL,
    CONSTRAINT chef_pk PRIMARY KEY  (chef_id)
);

-- Table: ingredient
CREATE TABLE ingredient (
    name varchar(100)  NOT NULL,
    source text  NULL,
    price numeric  NULL,
    color varchar(100)  NULL,
    description text  NULL,
    CONSTRAINT ingredient_pk PRIMARY KEY  (name)
);

-- Table: recipe
CREATE TABLE recipe (
    recipe_id int  NOT NULL IDENTITY(0, 1),
    name varchar(100)  NOT NULL,
    instructions text  NOT NULL,
    serves int  NOT NULL,
    prep_mins int  NOT NULL,
    cook_mins int  NOT NULL,
    calories int  NOT NULL,
    skill_level varchar(20)  NOT NULL,
    visual image  NULL,
    CONSTRAINT recipe_pk PRIMARY KEY  (recipe_id),
	FOREIGN KEY (skill_level)
    REFERENCES skill_level (name)
		ON UPDATE cascade
);

-- Table: recipe_category
CREATE TABLE recipe_category (
    categorization_id int  NOT NULL IDENTITY(0, 1),
    recipe_id int  NOT NULL,
    category varchar(50)  NOT NULL,
    CONSTRAINT one_recipe_category UNIQUE (recipe_id, categorization_id),
    CONSTRAINT recipe_category_pk PRIMARY KEY  (categorization_id),
	FOREIGN KEY (category)
    REFERENCES category (name)
		ON DELETE cascade
		ON UPDATE cascade,
	FOREIGN KEY (recipe_id)
    REFERENCES recipe (recipe_id)
		ON DELETE cascade
		ON UPDATE cascade
);

-- Table: requires
CREATE TABLE requires (
    requirement_id int  NOT NULL IDENTITY(0, 1),
    recipe_id int  NOT NULL,
    ingredient varchar(100)  NOT NULL,
    [top] int  NOT NULL,
	bottom int  NOT NULL,
    units varchar(100)  NOT NULL,
    CONSTRAINT one_recipe_ingredient UNIQUE (recipe_id, ingredient),
    CONSTRAINT requires_pk PRIMARY KEY  (requirement_id),
    FOREIGN KEY (ingredient)
    REFERENCES ingredient (name)
		ON DELETE cascade
		ON UPDATE cascade,
	FOREIGN KEY (recipe_id)
    REFERENCES recipe (recipe_id)
		ON DELETE cascade
		ON UPDATE cascade,
	FOREIGN KEY (units)
    REFERENCES unit (name)
		ON DELETE cascade
		ON UPDATE cascade
);

-- Table: author
CREATE TABLE author (
    authorship_id int  NOT NULL IDENTITY(0, 1),
    chef_id int  NOT NULL,
    recipe_id int  NOT NULL,
    created date  NOT NULL,
    CONSTRAINT one_authorship UNIQUE (chef_id, recipe_id),
    CONSTRAINT author_pk PRIMARY KEY  (authorship_id),
	FOREIGN KEY (chef_id)
    REFERENCES chef (chef_id)
		ON DELETE cascade
		ON UPDATE cascade,
	FOREIGN KEY (recipe_id)
    REFERENCES recipe (recipe_id)
		ON DELETE cascade
		ON UPDATE cascade
);

