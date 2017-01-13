using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace MusicControl
{
    class Program
    {
        // define music control commands
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;
        private const int APPCOMMAND_MEDIA_PLAY_PAUSE = 0xE0000;

        // define SendMessageW function
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
        IntPtr wParam, IntPtr lParam);

        static void Main(string[] args)
        {
            // define console window handle
            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;

            if (args.Count() > 0)
            {
                switch (args[0])
                {
                    // Play & Pause command
                    case "playpause":
                        SendMessageW(handle, WM_APPCOMMAND, handle,
                            (IntPtr)APPCOMMAND_MEDIA_PLAY_PAUSE);
                        break;

                    // Mute command
                    case "mute":
                        SendMessageW(handle, WM_APPCOMMAND, handle,
                            (IntPtr)APPCOMMAND_VOLUME_MUTE);
                        break;
                    
                    // Volume Down command
                    case "volumedown":
                        SendMessageW(handle, WM_APPCOMMAND, handle,
                            (IntPtr)APPCOMMAND_VOLUME_DOWN);
                        break;

                   // Volume Up command
                    case "volumeup":
                        SendMessageW(handle, WM_APPCOMMAND, handle,
                            (IntPtr)APPCOMMAND_VOLUME_UP);
                        break;
                }
            }
        }
    }
}
