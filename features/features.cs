using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using blender.Models;

namespace blender.features
{
    public class features
    {
        //defines function that calculates the gcd with parameters a and b
        public static int gcd(int a, int b)
        {
            //find the gcd using the Euclid’s algorithm
            while (a != b)
                if (a < b) b = b - a;
                else a = a - b;
            //since at this point a=b, the gcd can be either of them
            //it is necessary to pass the gcd to the main function
            return (a);
        }

    }
}