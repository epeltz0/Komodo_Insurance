using System;
using System.Collections.Generic;
using System.Text;

namespace Developers_Repository
{
        public class Developers
        {
            public string Name { get; set; }
            public double IdNumber { get; set; }
            public bool PluralsightAccess { get; set; }


            public Developers() { }

            public Developers(string name, double idNumber, bool pluralsightAccess)
            {
                Name = name;
                IdNumber = idNumber;
                PluralsightAccess = pluralsightAccess;
            }
        }
    }



