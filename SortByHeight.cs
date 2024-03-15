using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantLib
{
    public class SortByHeight : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Tree p1 = x as Tree;
            Tree p2 = y as Tree;

            if (p1.Height < p2.Height)
                return -1;
            else
                if (p1.Height == p2.Height)
                return 0;
            else
                return 1;
        }
    }
}
