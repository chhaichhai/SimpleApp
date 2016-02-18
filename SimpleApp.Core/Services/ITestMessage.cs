using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Core.Services
{
    public interface ITestMessage
    {
        string GetMessage(string name, string age);
    }
}
