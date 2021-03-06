﻿using System;
using System.Collections.Generic;

namespace Homework4_3_Farm_with_areaconditions_and_moves
{
    class Farm
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public List<GardenBed> GardenBeds { get; set; }
        public List<Building> Buildings { get; set; }

        public Farm(string name = "Default", int area = 100)
        {
            Name = name;
            Area = area;
            GardenBeds = new List<GardenBed>();
            Buildings = new List<Building>();
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

        public void AddBuilding(Building building)
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

        public double OccupiedPercent(int occupiedArea, int area)
        {
            double occupiedPercent = Math.Round((double)occupiedArea / (double)area * 100, 2);
            return occupiedPercent;
        }

        public void FarmReport()
        {
            Console.WriteLine($"Эта ферма \"{Name}\" площадью {Area} гектар с {GardenBeds.Count} грядками и {Buildings.Count} строениями. Всего занято {OccupiedArea} гектар ({OccupiedPercent(OccupiedArea, Area)}% площади).\n");
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
                Console.WriteLine($"заполнено {OccupiedPercent(gardenBedOccupiedArea, GardenBeds[i].Area)}% всей площади грядки.");
            }
            Console.WriteLine();
        }

        public void BuildingsReport()
        {
            Console.WriteLine($"Всего строений {Buildings.Count}.");
            for (int i = 0; i < Buildings.Count; i++)
            {
                Console.Write($"Строение \"{Buildings[i].Name}\" площадью {Buildings[i].Area} гектар на {Buildings[i].Amount} животных. В нем живут ");
                for (int j = 0; j < Buildings[i].Livestocks.Count; j++)
                {
                    Console.Write($"{Buildings[i].Livestocks[j].Name}, ");
                }
                Console.WriteLine($"заполнено на {OccupiedPercent(Buildings[i].OccupiedAmount, Buildings[i].Amount)}%.");
            }
            Console.WriteLine();
        }

        public void ChangePlantGardenBed(int from, int to, int plantNumber = -1)
        {
            int plantCount = GardenBeds[to].Plants.Count;
            if (plantNumber == -1)
            {
                plantNumber = GardenBeds[from].Plants.Count - 1;
            }
            GardenBeds[to].AddPlant(GardenBeds[from].Plants[plantNumber]);
            if (plantCount < GardenBeds[to].Plants.Count)
            {
                GardenBeds[from].Plants.RemoveAt(plantNumber);
            }
        }

        public void ChangeLivestockBuilding(int from, int to, int livestockNumber = -1)
        {
            int livestockCount = Buildings[to].Livestocks.Count;
            if (livestockNumber == -1)
            {
                livestockNumber = Buildings[from].Livestocks.Count - 1;
            }
            Buildings[to].AddLivestock(Buildings[from].Livestocks[livestockNumber]);
            if (livestockCount < Buildings[to].Livestocks.Count)
            {
                Buildings[from].Livestocks.RemoveAt(livestockNumber);
            }
        }
    }
}
