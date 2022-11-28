using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorming
{
    public class TestService : ITestService
    {
        public async Task TestMe()
        {
            Console.WriteLine("Method called from Hangfire");

        }
    }
}
