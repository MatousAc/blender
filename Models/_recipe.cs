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
            this.authors = new List<author>();
            this.categories = new List<string>();
            this.requires = new List<require>();
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
        public List<author> authors { get; set; }
        public List<string> categories { get; set; }
        // public virtual skill_level skill_level1 { get; set; }
        public List<require> requires { get; set; }
    }
}
