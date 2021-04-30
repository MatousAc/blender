using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blender.Models
{
    public class _recipe_teaser
    {

        public int recipe_id { get; set; }
        public string name { get; set; }
        public string skill_level { get; set; }
        public string image_url { get; set; }
        public List<int> authors { get; set; }
        public List<string> categories { get; set; }
        public _recipe_teaser() { }
        public _recipe_teaser(_recipe _recipe)
        {
            this.authors = new List<int>();
            this.recipe_id = _recipe.recipe_id;
            this.name = _recipe.name;
            this.image_url = _recipe.image_url;
            this.skill_level = _recipe.skill_level;
            this.categories = _recipe.categories;
        }

    }
}