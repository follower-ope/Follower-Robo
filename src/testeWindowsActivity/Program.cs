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
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
        static void Main(string[] args)
        {
            IntPtr hWnd = GetConsoleWindow();
            ShowWindow(hWnd, 0);

            string userName = Environment.UserName;

            Processos.run(userName);
        }
    }
}
