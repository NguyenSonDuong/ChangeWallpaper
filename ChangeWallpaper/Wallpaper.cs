using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChangeWallpaper
{
    class Wallpaper
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SystemParametersInfo(uint action, uint para, string path, uint type);
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hdl, int id, int fs, int vk);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hdl, int id);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hd, int type);
        const uint SETDESKTOP = 0x14;
        const uint FILE = 0x01;

        public static void ChangerWallpaper(String path)
        {
            SystemParametersInfo(SETDESKTOP, 0, path, FILE);
        }
    }
}
