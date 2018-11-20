using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4_4_Farm_with_warehouse
{
    class FarmGame
    {
        public Farm GameFarm { get; set; }
        public Seasons CurrentSeason { get; set; }

        public FarmGame(Farm gameFarm, Seasons currentSeason = Seasons.Winter)
        {
            GameFarm = gameFarm;
            CurrentSeason = currentSeason;
        }

        public void NextSeason()
        {
            if (CurrentSeason != Seasons.Autumn)
            {
                CurrentSeason = CurrentSeason + 1;
            }
            else
            {
                CurrentSeason = Seasons.Winter;
            }
        }

        public void FarmGameMenu()
        {
            var stopGame = false;
            while (stopGame != true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Отчет по ферме;");
                Console.WriteLine("2 - Отчет по грядкам;");
                Console.WriteLine("3 - Отчет по строениям;");
                Console.WriteLine("4 - Отчет по складу;");
                Console.WriteLine("5 - Управление фермой;");
                Console.WriteLine("Q (q) - Выход из игры;");
                Console.WriteLine("Другое - Смена сезона;");

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
}
