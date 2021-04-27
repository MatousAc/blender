using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blender.Models
{
    public partial class recipe
    {
        public recipe(_recipe _recipe)
        {   // let's make the real recipe object and all associated relationship objects
            // general
            this.recipe_id = _recipe.recipe_id;
            this.name = _recipe.name;
            this.instructions = _recipe.instructions;
            this.serves = _recipe.serves;
            this.prep_mins = _recipe.prep_mins;
            this.cook_mins = _recipe.cook_mins;
            this.calories = _recipe.calories;
            this.skill_level = _recipe.skill_level;
            this.visual = _recipe.visual;

            // associations
            // recipe_categories
            List<recipe_category> recats = new List<recipe_category>();
            foreach (string cat in _recipe.categories)
            {
                recipe_category recat = new recipe_category()
                {
                    recipe_id = _recipe.recipe_id,
                    category = cat
                };
                recats.Add(recat);
            }
            this.recipe_category = recats;
        }
    }
}