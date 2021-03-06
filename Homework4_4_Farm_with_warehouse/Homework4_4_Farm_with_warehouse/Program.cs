﻿using System;
using System.Collections.Generic;

namespace Homework4_4_Farm_with_warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates farm, adds name and area
            var myFarm = new Farm("Моя первая ферма", 200);

            //Creates gardenbed of fruits, adds area and fruits
            var fruitsGarden = new GardenBed(20);
            fruitsGarden.AddPlant(new Plant("Банан", Seasons.Spring, Seasons.Summer, 5));
            fruitsGarden.AddPlant(new Plant("Авокадо", Seasons.Winter, Seasons.Autumn));
            fruitsGarden.AddPlant(new Plant("Ананас", Seasons.Spring, Seasons.Autumn, 4));
            fruitsGarden.AddPlant(new Plant("Фейхоа", Seasons.Winter, Seasons.Spring, 3));

            //Creates gardenbed of vegetables, adds area and vegetables
            var vegetablesGarden = new GardenBed(40);
            vegetablesGarden.AddPlant(new Plant("Огурец", Seasons.Summer, Seasons.Autumn, 3));
            vegetablesGarden.AddPlant(new Plant("Помидор", Seasons.Summer, Seasons.Autumn, 3));
            vegetablesGarden.AddPlant(new Plant("Капуста", Seasons.Spring, Seasons.Summer, 5));
            vegetablesGarden.AddPlant(new Plant("Лук", Seasons.Spring, Seasons.Summer));
            vegetablesGarden.AddPlant(new Plant("Картофель", Seasons.Spring, Seasons.Autumn, 10));

            //Adds previously created gardenbeds to farm
            myFarm.AddGardenBed(fruitsGarden);
            myFarm.AddGardenBed(vegetablesGarden);

            //Creates first building with name, area, amount and fills it with livestocks
            var firstBuilding = new Building("Хлев", 50, 4);
            Livestock cow = new Livestock("Корова");
            Livestock goat = new Livestock("Коза");
            Livestock pig = new Livestock("Свинья");
            cow.Production = new Product("молоко коровье", 2);
            goat.Production = new Product("молоко козье", 1);
            pig.Production = new Product("мясо", 3);
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

            //Game
            FarmGame myGame = new FarmGame(myFarm);
            myGame.FarmGameMenu();
        }
    }
}
