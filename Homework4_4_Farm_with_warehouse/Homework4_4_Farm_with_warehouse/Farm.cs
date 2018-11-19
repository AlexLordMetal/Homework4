using System;
using System.Collections.Generic;

namespace Homework4_4_Farm_with_warehouse
{
    class Farm
    {
        private List<string> seasons = new List<string> { "Зима", "Весна", "Лето", "Осень" };

        public string Name { get; set; }
        public int Area { get; set; }
        public List<GardenBed> GardenBeds { get; set; }
        public List<Building> Buildings { get; set; }
        public Warehouse ThisFarmWarehouse { get; set; }
        public List<string> MyProperty { get; set; }
        public string CurrentSeason { get; set; }

        public Farm(string name = "Default", int area = 100)
        {
            Name = name;
            Area = area;
            GardenBeds = new List<GardenBed>();
            Buildings = new List<Building>();
            ThisFarmWarehouse = new Warehouse();
            CurrentSeason = seasons[0];

        }

        public int OccupiedArea
        {
            get
            {
                int occupiedArea = 0;
                foreach (var gardenbed in GardenBeds)
                {
                    occupiedArea += gardenbed.Area;
                }
                foreach (var building in Buildings)
                {
                    occupiedArea += building.Area;
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
                foreach (var plant in GardenBeds[i].Plants)
                {
                    Console.Write($"{plant.Name}, ");
                    gardenBedOccupiedArea += plant.Area;
                }
                Console.WriteLine($"заполнено {OccupiedPercent(gardenBedOccupiedArea, GardenBeds[i].Area)}% всей площади грядки.");
            }
            Console.WriteLine();
        }

        public void BuildingsReport()
        {
            Console.WriteLine($"Всего строений {Buildings.Count}.");
            foreach (var building in Buildings)
            {
                Console.Write($"Строение \"{building.Name}\" площадью {building.Area} гектар на {building.Amount} животных. В нем живут ");
                foreach (var livestock in building.Livestocks)
                {
                    Console.Write($"{livestock.Name}, ");
                }
                Console.WriteLine($"заполнено на {OccupiedPercent(building.OccupiedAmount, building.Amount)}%.");
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

        public void WarehouseReport()
        {
            Console.WriteLine($"Склад имеет общую вместимость {ThisFarmWarehouse.Capacity} килограмм. Заполнен на {OccupiedPercent(ThisFarmWarehouse.OccupiedCapacity, ThisFarmWarehouse.Capacity)}%.");
            if (ThisFarmWarehouse.OccupiedCapacity == 0)
            {
                Console.WriteLine("На складе пусто.");
            }
            else
            {
                Console.WriteLine("На складе хранится:");
                foreach (var product in ThisFarmWarehouse.Products)
                {
                    Console.WriteLine($"{product.Name} - {product.Weight} килограмм.");
                }
            }
            Console.WriteLine();
        }

        public void Harvest(Seasons harvestSeason)
        {
            switch (harvestSeason)
            {
                case Seasons.Winter:
                    Console.Write("Наступила зима.");
                    break;
                case Seasons.Spring:
                    Console.Write("Наступила весна.");
                    break;
                case Seasons.Summer:
                    Console.Write("Наступило лето.");
                    break;
                case Seasons.Autumn:
                    Console.Write("Наступила осень.");
                    break;
                default:
                    break;
            }
            List<Product> products = new List<Product>();
            foreach (var building in Buildings)
            {
                foreach (var livestock in building.Livestocks)
                {
                    Console.WriteLine($"{livestock.Name} дал(а) {livestock.Production.Name} - {livestock.Production.Weight} килограмм.");
                    products.Add(livestock.Production);
                }
            }
            foreach (var gardenbed in GardenBeds)
            {
                foreach (var plant in gardenbed.Plants)
                {
                    if (plant.HarvestSeason == harvestSeason)
                    {
                        Console.WriteLine($"{plant.Name} дал(а) урожай.");
                        products.Add(new Product(plant.Name, 1));
                    }
                }
            }
            ThisFarmWarehouse.WarehouseFill(products);
        }

    }
}
