using System;
using System.Collections.Generic;

namespace Homework4_3_Farm_with_areaconditions_and_moves
{
    class Farm
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public List<GardenBed> GardenBeds { get; set; }
        public List<Buiding> Buildings { get; set; }

        public Farm(string name = "Default", int area = 100)
        {
            Name = name;
            Area = area;
            GardenBeds = new List<GardenBed>();
            Buildings = new List<Buiding>();
        }

        public int OccupiedArea
        {
            get
            {
                int occupiedArea = 0;

                for (int i = 0; i < GardenBeds.Count; i++)
                {
                    occupiedArea += GardenBeds[i].Area;
                }

                for (int i = 0; i < Buildings.Count; i++)
                {
                    occupiedArea += Buildings[i].Area;
                }
                return occupiedArea;
            }
        }


        public void AddGardenBed(GardenBed gardenbed)
        {
            if ((OccupiedArea + gardenbed.Area) <= Area)
            {
                GardenBeds.Add(gardenbed);
            }
            else
            {
                Console.WriteLine($"{GardenBeds.Count + 1} грядка не добавлена, поскольку она уже не помещается на ферме \"{Name}\" (превышение максимального размера фермы на {OccupiedArea + gardenbed.Area - Area} гектар)\n");
            }

        }

        public void AddBuilding(Buiding building)
        {
            if ((OccupiedArea + building.Area) <= Area)
            {
                Buildings.Add(building);
            }
            else
            {
                Console.WriteLine($"Здание \"{building.Name}\" не добавлено, поскольку оно уже не помещается на ферме \"{Name}\" (превышение максимального размера фермы на {OccupiedArea + building.Area - Area} гектар)\n");
            }

        }

        public void FarmReport()
        {
            Console.WriteLine($"Эта ферма \"{Name}\" площадью {Area} гектар с {GardenBeds.Count} грядками и {Buildings.Count} строениями.\n");
        }

        public void GardenBedsReport()
        {
            Console.WriteLine($"Всего грядок {GardenBeds.Count}.");
            for (int i = 0; i < GardenBeds.Count; i++)
            {
                int gardenBedOccupiedArea = 0;
                Console.Write($"Грядка {i + 1} площадью {GardenBeds[i].Area} гектар. На ней растут ");
                for (int j = 0; j < GardenBeds[i].Plants.Count; j++)
                {
                    Console.Write($"{GardenBeds[i].Plants[j].Name}, ");
                    gardenBedOccupiedArea += GardenBeds[i].Plants[j].Area;
                }
                double occupiedPercent = Math.Round((double)gardenBedOccupiedArea * 100 / (double)GardenBeds[i].Area, 2);
                Console.WriteLine($"заполнено {occupiedPercent}% всей площади грядки.");
            }
            Console.WriteLine();
        }

        public void BuildingsReport()
        {
            Console.WriteLine($"Всего строений {Buildings.Count}.");
            for (int i = 0; i < Buildings.Count; i++)
            {
                Console.Write($"Строение \"{Buildings[i].Name}\" площадью {Buildings[i].Area} гектар на {Buildings[i].LivestocksAmount} животных. В нем живут ");
                for (int j = 0; j < Buildings[i].Livestocks.Count; j++)
                {
                    Console.Write($"{Buildings[i].Livestocks[j].Name}, ");
                }
                double occupiedPercent = Math.Round((double)Buildings[i].Livestocks.Count * 100 / (double)Buildings[i].LivestocksAmount, 2);
                Console.WriteLine($"заполнено на {occupiedPercent}%.");
            }
            Console.WriteLine();
        }
    }
}
