using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4_1_Farm
{
    class Buiding
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public int LivestocksAmount { get; set; }
        public List<Livestock> Livestocks { get; set; }
    }
}
