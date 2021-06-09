using System.Runtime.InteropServices;
using System.Threading;

namespace LearnVirus.Virus
{
    public class TaskbarEffect
    {
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;
        private static int FlashDuration = 500;

        public static void Hide()
        {
            int hwnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwnd, SW_HIDE);
        }

        public static void Reset()
        {
            int hwnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwnd, SW_SHOW);
        }

        public static void Flash()
        {
            Hide();
            Thread.Sleep(FlashDuration + 10);
            Reset();
            Thread.Sleep(FlashDuration + 10);
            if(FlashDuration > 0)
                FlashDuration -= 5;
            Flash();
        }
    }
}
