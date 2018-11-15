using System;
using System.Collections.Generic;

namespace Homework4_2_Farm_with_reports
{
    class Farm
    {
        public string Name {get; set; }
        public int Area { get; set; }
        public List<GardenBed> GardenBeds { get; set; }
        public List<Buiding> Buildings { get; set; }

        public void FarmReport()
        {
            Console.WriteLine($"Эта ферма \"{Name}\" площадью {Area} гектар с {GardenBeds.Count} грядками и {Buildings.Count} строениями.\n");
        }

        public void GardenBedsReport()
        {
            Console.WriteLine($"Всего грядок {GardenBeds.Count}");
            for (int i = 0; i < GardenBeds.Count; i++)
            {
                int occupiedArea = 0;
                Console.Write($"Грядка {i+1} площадью {GardenBeds[i].Area} гектар. На ней растут ");
                for (int j = 0; j < GardenBeds[i].Plants.Count; j++)
                {
                    Console.Write($"{GardenBeds[i].Plants[j].Name}, ");
                    occupiedArea += GardenBeds[i].Plants[j].Area;
                }
                double occupiedPercent = Math.Round((double)occupiedArea * 100 / (double)GardenBeds[i].Area, 2);
                Console.WriteLine($"заполнено {occupiedPercent}% всей площади грядки.");
            }
            Console.WriteLine();            
        }

        public void BuildingsReport()
        {
            Console.WriteLine($"Всего строений {GardenBeds.Count}");
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
