using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4_4_Farm_with_warehouse
{
    public static class FarmMathUtilities
    {
        public static double OccupiedPercent(int occupiedArea, int area)
        {
            double occupiedPercent = Math.Round((double)occupiedArea / (double)area * 100, 2);
            return occupiedPercent;
        }
    }
}
