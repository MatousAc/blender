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
            this.image_url = _recipe.image_url;

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

            // requires
            List<require> reqs = new List<require>();
            string[] _requires_split = _recipe._requires.Split('@');
            foreach (string _req in _requires_split)
            {
                if (_req != "")
                {
                    string[] _req_list = _req.Split('%');
                    string _amount = _req_list[0];
                    int _top;
                    int _bottom;
                    string _unit = _req_list[1];
                    string _ingredient = _req_list[2];
                    string[] _split = _amount.Split('/');
                    if (_split.Length == 2)
                    {
                        _top = Int32.Parse(_split[0]);
                        _bottom = Int32.Parse(_split[1]);
                    }
                    else
                    {
                        _top = Int32.Parse(_amount);
                        _bottom = 1;
                    }

                    require req = new require()
                    {
                        recipe_id = _recipe.recipe_id,
                        top = _top,
                        bottom = _bottom,
                        units = _unit,
                        ingredient = _ingredient
                    };
                    reqs.Add(req);
                }
            }
            this.requires = reqs;
        }

        public void update(_recipe _recipe)
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
            this.image_url = _recipe.image_url;

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
            this.recipe_category.Clear();
            this.recipe_category = recats;

            // requires
            List<require> reqs = new List<require>();
            string[] _requires_split = _recipe._requires.Split('@');
            foreach (string _req in _requires_split)
            {
                if (_req != "")
                {
                    string[] _req_list = _req.Split('%');
                    string _amount = _req_list[0];
                    int _top;
                    int _bottom;
                    string _unit = _req_list[1];
                    string _ingredient = _req_list[2];
                    string[] _split = _amount.Split('/');
                    if (_split.Length == 2)
                    {
                        _top = Int32.Parse(_split[0]);
                        _bottom = Int32.Parse(_split[1]);
                    }
                    else
                    {
                        _top = Int32.Parse(_amount);
                        _bottom = 1;
                    }

                    require req = new require()
                    {
                        recipe_id = _recipe.recipe_id,
                        top = _top,
                        bottom = _bottom,
                        units = _unit,
                        ingredient = _ingredient
                    };
                    reqs.Add(req);
                }
            }
            this.requires.Clear();
            this.requires = reqs;
        }

    }
}