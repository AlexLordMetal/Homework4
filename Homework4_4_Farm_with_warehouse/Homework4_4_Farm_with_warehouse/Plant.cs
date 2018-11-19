namespace Homework4_4_Farm_with_warehouse
{
    class Plant
    {
        public string Name { get; set; }
        public Seasons PlantingSeason { get; set; }
        public Seasons HarvestSeason { get; set; }
        public int Area { get; set; }

        public Plant(string name, Seasons plantingSeason, Seasons harvestSeason, int area = 2)
        {
            Name = name;
            PlantingSeason = plantingSeason;
            HarvestSeason = harvestSeason;
            Area = area;
        }
    }
}