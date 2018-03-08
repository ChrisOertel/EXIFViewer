using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Runtime.InteropServices;

namespace de.coe.components.win32api
{
    /// <summary>
    /// Kapselung des Zugriffs auf Informationen des Dateisystems mittels der Win32 API für Funktionen, die durch das .NET Framework 2.0 nicht bereitgestellt werden.
    /// </summary>
    public class GetFileInformation
    {

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        private class Win32
        {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
            public const uint SHGFI_SMALLICON = 0x1; // 'Small icon
            public const uint SHGFI_TYPENAME = 0x400; // File Type Information

            [DllImport("shell32.dll")]
            public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public GetFileInformation()
        {}

        /// <summary>
        /// Liefert zu einer angegebenen Datei das dazugehörende Smallicon (16*16 Pixel) zurück.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Icon</returns>
        public static Icon GetSmallIcon(string fileName)
        {
            IntPtr hImgSmall; //the handle to the system image list
            SHFILEINFO shinfo = new SHFILEINFO();
            //Use this to get the small Icon
            hImgSmall = Win32.SHGetFileInfo(fileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);
            //The icon is returned in the hIcon member of the shinfo struct
            return System.Drawing.Icon.FromHandle(shinfo.hIcon);
        }

        /// <summary>
        /// Liefert zu einer angegebenen Datei das dazugehörende Largeicon (32*32 Pixel) zurück.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Icon</returns>
        public static Icon GetLargeIcon(string fileName)
        {
            IntPtr hImgLarge; //the handle to the system image list
            SHFILEINFO shinfo = new SHFILEINFO();
            //Use this to get the large Icon
            hImgLarge = Win32.SHGetFileInfo(fileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);
            //The icon is returned in the hIcon member of the shinfo struct
            return System.Drawing.Icon.FromHandle(shinfo.hIcon);
        }

        /// <summary>
        /// Liefert zu einer angegebenen Datei die im Windows registrierte Typenbezeichnung zur Extension zurück
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileType(string fileName)
        {
            IntPtr hImgLarge; //the handle to the system image list
            SHFILEINFO shinfo = new SHFILEINFO();
            hImgLarge = Win32.SHGetFileInfo(fileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_TYPENAME);
            return shinfo.szTypeName;
        }

    }
}