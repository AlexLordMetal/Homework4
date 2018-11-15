using System.Collections.Generic;

namespace Homework4_2_Farm_with_reports
{
    class Buiding
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public int LivestocksAmount { get; set; }
        public List<Livestock> Livestocks { get; set; }
    }
}
