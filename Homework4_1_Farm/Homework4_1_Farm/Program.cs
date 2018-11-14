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
            myFarm.GardenBeds = new List<GardenBed>();
            myFarm.GardenBeds.Add(20, new List<Plant>());
            myFarm.GardenBeds[0].Area += 10;
            Console.WriteLine(myFarm.GardenBeds[0].Area);
            Console.ReadKey();
        }
    }
}
