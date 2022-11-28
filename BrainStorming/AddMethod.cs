using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorming
{
    public class AddMethod
    {
        public int Add(Model model)
        {
            model.Number = model.Number.AddInt();
            return model.Number;
        }
    }
}
