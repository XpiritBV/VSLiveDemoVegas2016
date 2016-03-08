using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Services
{
    public interface ISessionListService
    {
        IEnumerable<string> GetTop20Sessions();
    }
}
