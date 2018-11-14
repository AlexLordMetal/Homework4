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
            //Creates farm, adds name and area
            var myFarm = new Farm();
            myFarm.Name = "Моя первая ферма";
            myFarm.Area = 200;
            
            //Creates list of fruits, adds some fruits
            var fruitsList = new List<Plant>();
            fruitsList.Add(new Plant("Банан", "март", "июль", 5));
            fruitsList.Add(new Plant("Авокадо", "февраль", "сентябрь"));
            fruitsList.Add(new Plant("Ананас", "апрель", "август", 4));
            fruitsList.Add(new Plant("Фейхоа", "январь", "май", 3));

            //Creates gardenbed of fruits, adds area and list of fruits
            var fruitsGarden = new GardenBed();
            fruitsGarden.Area = 20;
            fruitsGarden.Plants = fruitsList;

            //Creates list of vegetables, adds some vegetables
            var vegetablesList = new List<Plant>();
            vegetablesList.Add(new Plant("Огурец", "апрель", "август", 3));
            vegetablesList.Add(new Plant("Помидор", "апрель", "сентябрь", 3));
            vegetablesList.Add(new Plant("Капуста", "март", "август", 5));
            vegetablesList.Add(new Plant("Лук", "март", "июль"));
            vegetablesList.Add(new Plant("Картофель", "март", "сентябрь", 10));

            //Creates gardenbed of vegetables, adds area and list of vegetables
            var vegetablesGarden = new GardenBed();
            vegetablesGarden.Area = 40;
            vegetablesGarden.Plants = vegetablesList;

            //Creates list of gardenbeds, adds previously created gardenbeds
            var gardenBedsList = new List<GardenBed>();
            gardenBedsList.Add(fruitsGarden);
            gardenBedsList.Add(vegetablesGarden);

            //Adds list of gardenbeds to farm
            myFarm.GardenBeds = gardenBedsList;

            //Creates first list of livestocks, fills it
            var livestocksFirstList = new List<Livestock>();
            Livestock cow = new Livestock();
            cow.Name = "Корова";
            cow.Production = new Product("молоко", 1000);
            livestocksFirstList.Add(cow);
            Livestock goat = new Livestock();
            goat.Name = "Коза";
            goat.Production = new Product("молоко", 500);
            livestocksFirstList.Add(goat);
            Livestock pig = new Livestock();
            pig.Name = "Свинья";
            pig.Production = new Product("мясо", 2500);
            livestocksFirstList.Add(pig);

            //Creates first building, adds name, area, amount and previously created first list of livestocks
            var firstBuilding = new Buiding();
            firstBuilding.Name = "Хлев";
            firstBuilding.Area = 50;
            firstBuilding.LivestocksAmount = 10;
            firstBuilding.Livestocks = livestocksFirstList;

            //Creates second list of livestocks, fills it
            var livestocksSecondList = new List<Livestock>();
            Livestock chicken = new Livestock();
            chicken.Name = "Курица";
            chicken.Production = new Product("яйцо", 2);
            livestocksSecondList.Add(chicken);
            livestocksSecondList.Add(chicken);
            livestocksSecondList.Add(chicken);
            Livestock duck = new Livestock();
            duck.Name = "Утка";
            duck.Production = new Product("яйцо", 1);
            livestocksSecondList.Add(duck);
            livestocksSecondList.Add(duck);

            //Creates second building, adds name, area, amount and previously created first list of livestocks
            var secondBuilding = new Buiding();
            secondBuilding.Name = "Сарай";
            secondBuilding.Area = 20;
            secondBuilding.LivestocksAmount = 15;
            secondBuilding.Livestocks = livestocksSecondList;

            //Creates list of buildings, adds previously created buildings
            var buildingsList = new List<Buiding>();
            buildingsList.Add(firstBuilding);
            buildingsList.Add(secondBuilding);

            //Adds list of buildings to farm
            myFarm.Buildings = buildingsList;

            //Console.WriteLine($"{myFarm.Buildings[1].LivestocksAmount}, {myFarm.Buildings[1].Livestocks[4].Production.Name}");
            Console.ReadKey();
        }
    }
}
