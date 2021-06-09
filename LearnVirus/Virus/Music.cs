using System;
using System.Collections.Generic;
using System.Media;
using System.Net;
using System.Text;

namespace LearnVirus.Virus
{
    public class Music
    {
        public static void PlayMusic()
        {
            //Download sound
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://raw.githubusercontent.com/f3098jr9fhd87sq89gba8wei/resources/main/music.wav", @"c:\Windows\System32\bad.wav");

            //Play sound
            SoundPlayer bad = new SoundPlayer(@"c:\Windows\System32\bad.wav");
            bad.Play();
        }
    }
}
