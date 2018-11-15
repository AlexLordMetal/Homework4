using System;
using System.Collections.Generic;

namespace Homework4_3_Farm_with_areaconditions_and_moves
{
    class Building
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public int Amount { get; set; }
        public List<Livestock> Livestocks { get; set; }

        public Building(string name = "Default", int area = 20, int amount = 10)
        {
            Name = name;
            Area = area;
            Amount = amount;
            Livestocks = new List<Livestock>();
        }

        public int OccupiedAmount
        {
            get
            {
                int occupiedAmount = Livestocks.Count;
                return occupiedAmount;
            }
        }

        public void AddLivestock(Livestock livestock)
        {
            if (OccupiedAmount < Amount)
            {
                Livestocks.Add(livestock);
            }
            else
            {
                Console.WriteLine($"Животное \"{livestock.Name}\" не добавлено, поскольку оно уже не помещается в \"{Name}\" (строение уже заполнено максимально - {OccupiedAmount} животных)\n");
            }

        }
    }
}
