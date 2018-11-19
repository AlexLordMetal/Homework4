using System;
using System.Collections.Generic;

namespace Homework4_4_Farm_with_warehouse
{
    class GardenBed
    {
        public int Area { get; set; }
        public List<Plant> Plants { get; set; }

        public GardenBed(int area = 50)
        {
            Area = area;
            Plants = new List<Plant>();
        }

        public int OccupiedArea
        {
            get
            {
                int occupiedArea = 0;
                for (int i = 0; i < Plants.Count; i++)
                {
                    occupiedArea += Plants[i].Area;
                }
                return occupiedArea;
            }
        }

        public void AddPlant(Plant plant)
        {
            if ((OccupiedArea + plant.Area) <= Area)
            {
                Plants.Add(plant);
            }
            else
            {
                Console.WriteLine($"Растение \"{plant.Name}\" не добавлено, поскольку оно уже не помещается на грядке (превышение максимального размера грядки на {OccupiedArea + plant.Area - Area} гектар)\n");
            }

        }
    }
}
