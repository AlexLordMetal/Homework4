using System;
using System.Collections.Generic;

namespace Homework4_4_Farm_with_warehouse
{
    class Farm
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public List<GardenBed> GardenBeds { get; set; }
        public List<Building> Buildings { get; set; }
        public Warehouse FarmWarehouse { get; set; }
        public List<string> MyProperty { get; set; }

        public Farm(string name = "Default", int area = 100)
        {
            Name = name;
            Area = area;
            GardenBeds = new List<GardenBed>();
            Buildings = new List<Building>();
            FarmWarehouse = new Warehouse();
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

        public void FarmReport()
        {
            Console.WriteLine($"Эта ферма \"{Name}\" площадью {Area} гектар с {GardenBeds.Count} грядками и {Buildings.Count} строениями. Всего занято {OccupiedArea} гектар ({FarmMathUtilities.OccupiedPercent(OccupiedArea, Area)}% площади).\n");
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
                Console.WriteLine($"заполнено {FarmMathUtilities.OccupiedPercent(gardenBedOccupiedArea, GardenBeds[i].Area)}% всей площади грядки.");
            }
            Console.WriteLine();
        }

        public void BuildingsReport()
        {
            Console.WriteLine($"Всего строений {Buildings.Count}.");
            for (int i = 0; i < Buildings.Count; i++)
            {
                Console.Write($"Строение {i + 1} \"{Buildings[i].Name}\" площадью {Buildings[i].Area} гектар на {Buildings[i].Amount} животных. В нем живут ");
                foreach (var livestock in Buildings[i].Livestocks)
                {
                    Console.Write($"{livestock.Name}, ");
                }
                Console.WriteLine($"заполнено на {FarmMathUtilities.OccupiedPercent(Buildings[i].OccupiedAmount, Buildings[i].Amount)}%.");
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

        public void Harvest(Seasons season)
        {
            switch (season)
            {
                case Seasons.Winter:
                    Console.WriteLine("Наступила зима.");
                    break;
                case Seasons.Spring:
                    Console.WriteLine("Наступила весна.");
                    break;
                case Seasons.Summer:
                    Console.WriteLine("Наступило лето.");
                    break;
                case Seasons.Autumn:
                    Console.WriteLine("Наступила осень.");
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
                    if (plant.HarvestSeason == season)
                    {
                        Console.WriteLine($"{plant.Name} дал(а) урожай.");
                        products.Add(new Product(plant.Name, 1));
                    }
                }
            }
            FarmWarehouse.WarehouseFill(products);
            Console.WriteLine();
        }

        public void FarmGameManagement()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Добавить грядку ;");
            Console.WriteLine("2 - Удалить грядку;");
            Console.WriteLine("3 - Добавить строение;");
            Console.WriteLine("4 - Удалить строение;");
            Console.WriteLine("5 - Посадить растение на грядку;");
            Console.WriteLine("6 - Пересадить растение на другую грядку;");
            Console.WriteLine("7 - Выкопать растение с грядки;");
            Console.WriteLine("8 - Добавить животное в строение;");
            Console.WriteLine("9 - Переселить животное в другое строение;");
            Console.WriteLine("0 - Выгнать животное из строения;");
            Console.WriteLine("Другое - ничего не делать;");

            switch (Console.ReadLine())
            {
                case "1":
                    GameFarm.FarmReport();
                    break;
                case "2":
                    GameFarm.GardenBedsReport();
                    break;
                case "3":
                    GameFarm.BuildingsReport();
                    break;
                case "4":
                    GameFarm.FarmWarehouse.Report();
                    break;
                case "5":
                    GameFarm.FarmGameManagement();
                    break;
                case "Q":
                    stopGame = true;
                    break;
                case "q":
                    stopGame = true;
                    break;
                default:
                    NextSeason();
                    GameFarm.Harvest(CurrentSeason);
                    break;
            }
        }


    }
}
