using System;
using System.Security.Principal;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using testeWindowsActivity.Models;
using System.IO;
using System.Threading.Tasks;

namespace testeWindowsActivity
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Environment.UserName;

            Processos.run(userName);
        }
    }
}
