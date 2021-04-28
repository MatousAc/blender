using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blender.Models
{
    using System;
    using System.Collections.Generic;

    public class _recipe
    {
        
        public _recipe()
        {
            this.authors = new List<int>();
            this.categories = new List<string>();
            this.ingredients = new List<string>();
            this.units = new List<string>();
        }

        public _recipe(recipe recipe)
        {
                // general
                this.recipe_id = recipe.recipe_id;
                this.name = recipe.name;
                this.instructions = recipe.instructions;
                this.serves = recipe.serves;
                this.prep_mins = recipe.prep_mins;
                this.cook_mins = recipe.cook_mins;
                this.calories = recipe.calories;
                this.skill_level = recipe.skill_level;
                this.visual = recipe.visual;

                // associations
                // recipe_categories
                List<string> cats = new List<string>();
                foreach (recipe_category recat in recipe.recipe_category)
                {
                    string cat = recat.category;
                    cats.Add(cat);
                }
                this.categories = cats;

                // requires
                string reqs = "";
                foreach (require req in recipe.requires)
                {
                    string amount;
                    if (req.bottom != 1)
                    {
                        amount = $"{req.top}/{req.bottom}";
                    }
                    else
                    {
                        amount = $"{req.top}";
                    }

                    reqs += $"@{amount}%{req.units}%{req.ingredient}";
                }
                this._requires = reqs.Substring(1, -1);
            }

        public int recipe_id { get; set; }
        public string name { get; set; }
        public string instructions { get; set; }
        public int serves { get; set; }
        public int prep_mins { get; set; }
        public int cook_mins { get; set; }
        public int calories { get; set; }
        public string skill_level { get; set; }
        public byte[] visual { get; set; }
        public List<int> authors { get; set; }
        public List<string> categories { get; set; }
        public List<string> units { get; set; }
        public List<string> ingredients { get; set; }
        //public List<string> _requires_list { get; set; }
        public string _requires { get; set; }
    }
}
