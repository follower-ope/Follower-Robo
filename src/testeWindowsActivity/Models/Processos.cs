using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using testeWindowsActivity.Services;

namespace testeWindowsActivity.Models
{
    public class Processos
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public static void run(string userName)
        {
            string processoAnterior = string.Empty;

            while (true)
            {
                Process currentProcess = GetActiveProcess();

                if (currentProcess == null)
                    continue;

                try
                {
                    if (currentProcess.BasePriority == 8 && !currentProcess.ProcessName.Equals("explorer") && !currentProcess.MainModule.FileVersionInfo.FileDescription.Equals(processoAnterior) && !currentProcess.ProcessName.Equals("Idle"))
                    {
                        processoAnterior = currentProcess.MainModule.FileVersionInfo.FileDescription;

                        _ = new SendActivities().SendAsync(userName, currentProcess.ProcessName, processoAnterior, DateTime.Now);

                    }
                }
                catch{}
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
