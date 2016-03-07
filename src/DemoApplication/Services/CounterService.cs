using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Services
{
    public class CounterService : ICounter
    {
        private int _counter = 0;
        private string _lastCalledByMethod;
        public CounterService()
        {
            _lastCalledByMethod = "ctor";
        }
        public void Count(string fromMethod)
        {
            _counter++;
            _lastCalledByMethod = fromMethod;
        }

        public int GetCounterValue()
        {
            return _counter;
        }

        public string GetLastCallerName()
        {
            return _lastCalledByMethod;
        }
    }
}
