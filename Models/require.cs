//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace blender.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class require
    {
        public int requirement_id { get; set; }
        public int recipe_id { get; set; }
        public string ingredient { get; set; }
        public string units { get; set; }
        public int top { get; set; }
        public int bottom { get; set; }
    
        public virtual ingredient ingredient1 { get; set; }
        public virtual recipe recipe { get; set; }
        public virtual unit unit { get; set; }
    }
}
