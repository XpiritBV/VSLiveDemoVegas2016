using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Services
{
    public class SessionListService : ISessionListService
    {
        public IEnumerable<string> GetTop20Sessions()
        {
            return new string[] { "T17 MVC 6 - The New Unified Web Programming Model", "T11 Native Mobile App Development for iOS, Android and Windows Using C#", "W03 Exploring Microservices in a Microsoft Landscape", "TH18 Async Patterns for .NET Development", "TH24 Use Visual Studio to Scale Agile in Your Enterprise" };
        }
    }
}
