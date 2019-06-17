using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Comparers
{
    internal sealed class StringLenthComparer : IComparer<string> 
    {
        public int Compare(string x, string y)
        {
            if (x.Length > y.Length) return 1;
            if (x.Length < y.Length) return -1;
            return 0;
        }        
    }
}
