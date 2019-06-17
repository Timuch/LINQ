using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Comparers
{
    internal sealed class StringLengthEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return IsSmall(x) == IsSmall(y);
        }

        public int GetHashCode(string obj)
        {
            return IsSmall(obj) ? 0.GetHashCode() : 10.GetHashCode();            
        }

        public static bool IsSmall(string x)
        {
            return x.Length <= 5;
        }
    }
}
