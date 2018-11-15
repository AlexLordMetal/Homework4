using System.Collections.Generic;

namespace Homework4_3_Farm_with_areaconditions_and_moves
{
    class Buiding
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public int LivestocksAmount { get; set; }
        public List<Livestock> Livestocks { get; set; }
    }
}
