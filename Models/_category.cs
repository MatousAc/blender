using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blender.Models
{
    public class _category
    {
        public _category() { }
        public _category(category category, List<recipe> recipes)
        {
            this.name = category.name;
            this.recipes = recipes;
        }
        public string name { get; set; }
        public IEnumerable<recipe> recipes { get; set; }
    }
}