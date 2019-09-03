using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace testeWindowsActivity
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        static void Main(string[] args)
        {
            string processoAnterior = string.Empty;

            while (true)
            {
                Process currentProcess = GetActiveProcess();

                if (currentProcess == null)
                    continue;

                if (!currentProcess.ProcessName.Equals(processoAnterior) && !currentProcess.ProcessName.Equals("Idle"))
                {
                    processoAnterior = currentProcess.ProcessName;
                    Console.WriteLine(processoAnterior + " - " + DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss"));
                }
            }
        }

        private static Process GetActiveProcess()
        {
            IntPtr hwnd = GetForegroundWindow();

            return hwnd != null ? GetProcessByHandle(hwnd) : null;
        }

        private static Process GetProcessByHandle(IntPtr hwnd)
        {
            try
            {
                uint processID;
                GetWindowThreadProcessId(hwnd, out processID);
                return Process.GetProcessById((int)processID);
            }
            catch { return null; }
        }
    }
}
