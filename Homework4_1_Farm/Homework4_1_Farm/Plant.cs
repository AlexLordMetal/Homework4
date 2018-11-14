using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4_1_Farm
{
    class Plant
    {
        public string Name { get; set; }
        public string PlantingSeason { get; set; }
        public string HarvestSeason { get; set; }
        public int Area { get; set; }

        public Plant(string name, string plantingSeason, string harvestSeason, int area = 2)
        {
            Name = name;
            PlantingSeason = plantingSeason;
            HarvestSeason = harvestSeason;
            Area = area;
        }
    }
}
