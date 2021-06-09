using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;

namespace LearnVirus.Virus
{
    public class CMD
    {
        public static void RunCommand(string command)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/k " + command;
            process.StartInfo = startInfo;
            process.Start();
        }
        public static void RunCMD()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c ";
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
