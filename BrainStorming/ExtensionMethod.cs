using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorming
{
    public static class ExtensionMethod
    {
        public static int AddInt(this int number)
        {
            number = number + 5;
            return number;
        }
    }
}
