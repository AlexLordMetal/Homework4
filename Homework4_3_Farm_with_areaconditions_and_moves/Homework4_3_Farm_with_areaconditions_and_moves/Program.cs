using System;
using System.Collections.Generic;

namespace Homework4_3_Farm_with_areaconditions_and_moves
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates farm, adds name and area
            var myFarm = new Farm("Моя первая ферма", 200);

            //Creates gardenbed of fruits, adds area and fruits
            var fruitsGarden = new GardenBed(20);
            fruitsGarden.AddPlant(new Plant("Банан", "март", "июль", 5));
            fruitsGarden.AddPlant(new Plant("Авокадо", "февраль", "сентябрь"));
            fruitsGarden.AddPlant(new Plant("Ананас", "апрель", "август", 4));
            fruitsGarden.AddPlant(new Plant("Фейхоа", "январь", "май", 3));

            //Creates gardenbed of vegetables, adds area and vegetables
            var vegetablesGarden = new GardenBed(40);
            vegetablesGarden.AddPlant(new Plant("Огурец", "апрель", "август", 3));
            vegetablesGarden.AddPlant(new Plant("Помидор", "апрель", "сентябрь", 3));
            vegetablesGarden.AddPlant(new Plant("Капуста", "март", "август", 5));
            vegetablesGarden.AddPlant(new Plant("Лук", "март", "июль"));
            vegetablesGarden.AddPlant(new Plant("Картофель", "март", "сентябрь", 10));

            //Adds previously created gardenbeds to farm
            myFarm.AddGardenBed(fruitsGarden);
            myFarm.AddGardenBed(vegetablesGarden);

            //Creates first building with name, area, amount and fills it with livestocks
            var firstBuilding = new Building("Хлев", 50, 10);
            Livestock cow = new Livestock("Корова");
            Livestock goat = new Livestock("Коза");
            Livestock pig = new Livestock("Свинья");
            cow.Production = new Product("молоко", 1000);
            goat.Production = new Product("молоко", 500);
            pig.Production = new Product("мясо", 2500);
            firstBuilding.AddLivestock(cow);
            firstBuilding.AddLivestock(goat);
            firstBuilding.AddLivestock(pig);

            //Creates second building with name, area, amount and fills it with livestocks
            var secondBuilding = new Building("Сарай", 20, 15);
            Livestock chicken = new Livestock("Курица");
            Livestock duck = new Livestock("Утка");
            chicken.Production = new Product("яйцо куриное", 2);
            duck.Production = new Product("яйцо утиное", 1);
            secondBuilding.AddLivestock(chicken);
            secondBuilding.AddLivestock(duck);
            secondBuilding.AddLivestock(chicken);
            secondBuilding.AddLivestock(chicken);
            secondBuilding.AddLivestock(duck);

            //Adds previously created buildings to farm
            myFarm.AddBuilding(firstBuilding);
            myFarm.AddBuilding(secondBuilding);

            //Writes reports to console
            myFarm.FarmReport();
            myFarm.GardenBedsReport();
            myFarm.BuildingsReport();

            myFarm.ChangePlantGardenBed(0,1,1);
            myFarm.GardenBedsReport();

            myFarm.ChangeLivestockBuilding(1, 0);
            myFarm.BuildingsReport();

            Console.ReadKey();
        }
    }
}
