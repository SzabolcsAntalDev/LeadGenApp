using System.Runtime.InteropServices;

namespace LeadGenApp
{
    public class User32Wrapper
    {
        private const int KeyDownCode = 0x0000;
        private const int KeyUpCode = 0x0002;

        public const int AltCode = 0x12;
        public const int ControlCode = 0x11;
        public const int TabCode = 0x09;

        public const int BackspaceCode = 0x08;

        public const int VCode = 0x56;
        public const int CCode = 0x43;

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        public static void KeyDown(byte keyCode)
        {
            keybd_event(keyCode, 0, KeyDownCode, UIntPtr.Zero);
        }

        public static void KeyUp(byte keyCode)
        {
            keybd_event(keyCode, 0, KeyUpCode, UIntPtr.Zero);
        }

        public static void KeyPress(byte keyCode)
        {
            KeyDown(keyCode);
            KeyUp(keyCode);
        }
    }
}
