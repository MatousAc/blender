-- adding images to things

use blender

ALTER TABLE chef
ADD profile_image image NULL;

ALTER TABLE recipe
ADD visual image NULL;
