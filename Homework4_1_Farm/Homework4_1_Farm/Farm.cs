using System.Collections.Generic;

namespace Homework4_1_Farm
{
    class Farm
    {
        public string Name {get; set; }
        public int Area { get; set; }
        public List<GardenBed> GardenBeds { get; set; }
        public List<Buiding> Buildings { get; set; }
    }
}
