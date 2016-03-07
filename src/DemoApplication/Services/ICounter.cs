using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Services
{
    interface ICounter
    {
       void Count(string fromMethod);
        int GetCounterValue();

        string GetLastCallerName();
    }
}
