-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2021-04-05 00:02:54.854

-- tables
-- Table: recipe
CREATE TABLE recipe (
    recipe_id integer NOT NULL CONSTRAINT recipe_pk PRIMARY KEY,
    name varchar(100) NOT NULL,
    instructions text NOT NULL,
    prep_mins integer,
    serves integer
);

-- Table: ingredient
CREATE TABLE ingredient (
    name varchar(100) NOT NULL CONSTRAINT ingredient_pk PRIMARY KEY,
    source text,
    price numeric,
    color varchar(100),
    description text
);

-- Table: systm
CREATE TABLE systm (
    name varchar(20) NOT NULL CONSTRAINT systm_pk PRIMARY KEY
);

-- Table: unit_type
CREATE TABLE unit_type (
    name varchar(20) NOT NULL CONSTRAINT unit_type_pk PRIMARY KEY
);

-- Table: unit
CREATE TABLE unit (
    name varchar(100) NOT NULL CONSTRAINT unit_pk PRIMARY KEY,
    type varchar(100) NOT NULL,
    system varchar(20) NOT NULL,
    CONSTRAINT measurement_type FOREIGN KEY (type)
    REFERENCES unit_type (name),
    CONSTRAINT measurement_system FOREIGN KEY (system)
    REFERENCES systm (name)
);

-- Table: requires
CREATE TABLE requires (
    recipe_id integer NOT NULL,
    ingredient varchar(100) NOT NULL,
    amount integer NOT NULL,
    units varchar(100) NOT NULL,
    CONSTRAINT requires_pk PRIMARY KEY (ingredient,recipe_id),
    CONSTRAINT Table_3_ingredient FOREIGN KEY (ingredient)
    REFERENCES ingredient (name),
    CONSTRAINT Table_3_recipe FOREIGN KEY (recipe_id)
    REFERENCES recipe (recipe_id),
    CONSTRAINT requires_measurement FOREIGN KEY (units)
    REFERENCES unit (name)
);

-- Table: clearence_level
CREATE TABLE clearence_level (
    clrnc_lvl varchar(20) NOT NULL CONSTRAINT clearence_level_pk PRIMARY KEY
);

-- Table: chef
CREATE TABLE chef (
    chef_id integer NOT NULL CONSTRAINT chef_pk PRIMARY KEY,
    first_name varchar(100) NOT NULL,
    last_name varchar(100) NOT NULL,
    clrnc_lvl varchar(20) NOT NULL,
    CONSTRAINT user_role FOREIGN KEY (clrnc_lvl)
    REFERENCES clearence_level (clrnc_lvl)
);

-- Table: author
CREATE TABLE author (
    chef_id integer NOT NULL,
    recipe_id integer NOT NULL,
    CONSTRAINT author_pk PRIMARY KEY (chef_id,recipe_id),
    CONSTRAINT author_chef FOREIGN KEY (chef_id)
    REFERENCES chef (chef_id),
    CONSTRAINT author_recipe FOREIGN KEY (recipe_id)
    REFERENCES recipe (recipe_id)
);

-- End of file.

