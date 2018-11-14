using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4_1_Farm
{
    class Product
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public Product(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
    }
}
