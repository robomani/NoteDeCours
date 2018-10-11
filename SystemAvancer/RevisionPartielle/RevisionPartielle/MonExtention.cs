using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionPartielle
{
    static class MonExtention
    {
        public static bool IsEven(this int x)
        {
            return (x % 2) == 0;
        }
    }
}
