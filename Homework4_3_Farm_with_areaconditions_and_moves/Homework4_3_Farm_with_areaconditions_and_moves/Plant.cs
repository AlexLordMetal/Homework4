namespace Homework4_3_Farm_with_areaconditions_and_moves
{
    class Plant
    {
        public string Name { get; set; }
        public string PlantingSeason { get; set; }
        public string HarvestSeason { get; set; }
        public int Area { get; set; }

        public Plant(string name, string plantingSeason, string harvestSeason, int area = 2)
        {
            Name = name;
            PlantingSeason = plantingSeason;
            HarvestSeason = harvestSeason;
            Area = area;
        }
    }
}
