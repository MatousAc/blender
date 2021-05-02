using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using blender.features;
using Humanizer;

namespace blender.Models
{
    using System;
    using System.Collections.Generic;

    public class _recipe
    {
        public int recipe_id { get; set; }
        public string name { get; set; }
        public string instructions { get; set; }
        public int serves { get; set; }
        public int prep_mins { get; set; }
        public int cook_mins { get; set; }
        public int calories { get; set; }
        public string skill_level { get; set; }
        public string image_url { get; set; }
        public List<int> authors { get; set; }
        public List<string> categories { get; set; }
        public List<string> units { get; set; }
        public List<string> ingredients { get; set; }
        public List<int> top { get; set; }
        public List<int> bottom { get; set; }
        public string _requires { get; set; }



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
            this.image_url = recipe.image_url;

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
            this.top = new List<int>(); // for easier scaling
            this.bottom = new List<int>(); // same
            List<string> reqs = new List<string>();
            foreach (require req in recipe.requires)
            {
                string units = req.unit.name;
                string amount;
                if (req.bottom != 1)
                {
                    amount = $"{req.top}/{req.bottom}";
                    this.bottom.Add(req.bottom);
                }
                else
                {
                    amount = $"{req.top}";
                    this.bottom.Add(1);
                }
                this.top.Add(req.top);

                // making whole numbers happen:
                amount = wholify(amount);
                // pluralizing units
                //if (req.top != 1 && req.bottom != 1)
                //{
                //    units = units.Pluralize();
                //}

                reqs.Add($"{amount}%{units}%{req.ingredient}");
            }
            this._requires = String.Join("@", reqs);
        }

        public static string wholify (string amount)
        {
            if (amount.Contains('/'))
            {
                int numerator = Convert.ToInt32(amount.Split('/')[0]);
                int denominator = Convert.ToInt32(amount.Split('/')[1]);
                if (numerator >= denominator)
                {
                    int wholePart = numerator / denominator;
                    numerator = numerator % denominator;
                    amount = $"{wholePart} {numerator}/{denominator}";
                }
            }
            return amount;
        }

        public void scale(int serves)
        {
            double scale_factor = (double)serves / this.serves;
            foreach (int index in Enumerable.Range(0, top.Count) ) 
            {
                int numerator = top[index]; // the top of the fraction
                int denominator = bottom[index]; // and the bottom
                double goal = scale_factor * numerator / denominator; // this is the raw value we want to get to

                if (denominator == 1) // if its just a count
                {
                    numerator = (int)(numerator * scale_factor);
                }

                else
                {
                    int cf = 1; // closest fraction we want to get to (should change below)
                    if (denominator % 2 == 0) { cf = 8; } // when we want to get to the closest eigth
                    else if (denominator % 3 == 0) { cf = 3; } // when we want to get to the closest third
                    // below I scale up the numerator and make the top an integer, thus bringing it to the 
                    // closest eigth or third. 
                    // we use the round function to do better than just truncating the decimal
                    int num = (int)Math.Round((scale_factor * numerator * cf));
                    numerator = num / cf;

                    //then I divide it back down and simplify the fraction
                    int divisor = gcd(numerator, denominator);
                    numerator = numerator / divisor;
                    denominator = denominator / divisor;
                }

                top[index] = numerator;
                bottom[index] = denominator;
            }
            this._requiresFromTopBottom();
            this.serves = serves;
        }

        // helpers!

        // Thanks for Mike for the following function:
        // defines function 		serves	4	int
        // that calculates the gcd with parameters a and b
        public static int gcd(int a, int b)
        {
            //find the gcd using the Euclid’s algorithm
            while (a != b)
            {
                if (a < b) b = b - a;
                else a = a - b;
            }
            //since at this point a=b, the gcd can be either of them
            //it is necessary to pass the gcd to the main function
            return (a);
        }

        public void _requiresFromTopBottom()
        {
            string[] _requires_list = _requires.Split('@');
            string[] new_requires = new string[this.top.Count];
            foreach (int index in Enumerable.Range(0, top.Count))
            {
                string[] rs = _requires_list[index].Split('%');
                string amount;
                string units = rs[1];
                string ingredient = rs[2];
                if (bottom[index] == 1)
                {   // forget the denominator if it's one
                    amount = top[index].ToString();
                }
                else
                {
                    amount = $"{top[index]}/{bottom[index]}";
                }

                amount = wholify(amount);
                // we don't wanna display "count" on the details
                if (units == "count")
                {
                    units = "";
                    if (top[index] > bottom[index])
                    {
                        ingredient = ingredient.Pluralize();
                    }
                }
                // pluralizing units
                if (top[index] > bottom[index])
                {
                    units = units.Pluralize();
                }

                new_requires[index] = ($"{amount}%{units}%{ingredient}");
            }
            _requires = String.Join("@", new_requires);
        }

    }

}
