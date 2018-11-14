using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4_1_Farm
{
    class Program
    {
        static void Main(string[] args)
        {
            var myFarm = new Farm();
            myFarm.Name = "Моя первая ферма";
            myFarm.Area = 200;
            myFarm.GardenBed[0].Area = 20;
            myFarm.GardenBed[0].Plant[0].Name = "Огурец";
            myFarm.GardenBed[0].Plant[0].PlantingSeason = "Апрель";
            myFarm.GardenBed[0].Plant[0].HarvestSeason = "Август";
            myFarm.GardenBed[0].Plant[0].Area = 4;
        }
    }
}
