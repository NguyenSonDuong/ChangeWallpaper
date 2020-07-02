using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChangeWallpaper
{
    class ChangeWallpaper
    {
        // đây là các cách sự dụng các hàm ccuar thư viện hệ thống. ở đây là User32.dll :3 
        // cái hàm ngay dưới đây là để cài hình nền desktop
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fWinIni);
        // Hàm này thì để đăng ký Hotkey ( Phím tắt ế )
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        //hàm này để hủy đăng ký
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        // đây là enum chưa giá trị của các key 
        public enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }
        // đây là key để set ảnh cho desktop ( :3 )
        const uint SPI_SETDESKWALLPAPER = 0x14;
        // đây là key cho việc cài băt file ( có lẽ vậy )
        const uint SPIF_UPDATEINIFILE = 0x01;

        // đây là hàm để gọi lại nè
        public static void SetDesktopWallpaper(string path)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE);
        }
    }
}
