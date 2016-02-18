using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleApp.Core.Services;

namespace SimpleApp.Core.Concrete
{
    public class PrintMessage : ITestMessage
    {
        public string GetMessage(string name, string age)
        {
            return name + " " + age;
        }
    }
}
