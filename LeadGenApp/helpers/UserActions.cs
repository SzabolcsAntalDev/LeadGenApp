using LeadGenApp.input;
using Cursor = System.Windows.Forms.Cursor;
using Point = System.Drawing.Point;
using WindowsInput;
using System.Windows;

namespace LeadGenApp.helpers
{
    public static class UserActions
    {
        private const int ShortDelay = 200;

        private static readonly InputSimulator _inputSimulator = new();

        public static void ClickTo(Point point)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = point;
            _inputSimulator.Mouse.LeftButtonClick();

            Thread.Sleep(ShortDelay);
        }

        public static void AltTab()
        {
            Thread.Sleep(ShortDelay);

            User32Wrapper.KeyDown(User32Wrapper.AltCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyPress(User32Wrapper.TabCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyUp(User32Wrapper.AltCode);

            Thread.Sleep(ShortDelay);
        }

        public static void ControlTab()
        {
            Thread.Sleep(ShortDelay);

            User32Wrapper.KeyDown(User32Wrapper.ControlCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyPress(User32Wrapper.TabCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyUp(User32Wrapper.ControlCode);

            Thread.Sleep(ShortDelay);
        }

        public static void PressTab()
        {
            Thread.Sleep(ShortDelay);

            User32Wrapper.KeyPress(User32Wrapper.TabCode);

            Thread.Sleep(ShortDelay);
        }

        public static void PressEnter()
        {
            Thread.Sleep(ShortDelay);

            User32Wrapper.KeyPress(User32Wrapper.EnterCode);

            Thread.Sleep(ShortDelay);
        }

        public static void PressBackspace()
        {
            Thread.Sleep(ShortDelay);

            User32Wrapper.KeyPress(User32Wrapper.BackspaceCode);

            Thread.Sleep(ShortDelay);
        }

        public static void CopyFromWithSingleClick(Point point)
        {
            CopyFrom(point, 1);
        }

        public static void CopyFromWithDoubleClick(Point point)
        {
            CopyFrom(point, 2);
        }

        public static void CopyFromWithTripleClick(Point point)
        {
            CopyFrom(point, 3);
        }

        private static void CopyFrom(Point point, int clicks)
        {
            Thread.Sleep(ShortDelay);

            var cursorPosition = point;

            Thread.Sleep(ShortDelay);

            Cursor.Position = cursorPosition;

            for (int i = 0; i < clicks; i++)
                _inputSimulator.Mouse.LeftButtonClick();

            User32Wrapper.KeyDown(User32Wrapper.ControlCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyPress(User32Wrapper.CCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyUp(User32Wrapper.ControlCode);

            Thread.Sleep(ShortDelay);
        }

        public static void PasteTo(Point point, string? text = null)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = point;

            Thread.Sleep(ShortDelay);
            _inputSimulator.Mouse.LeftButtonClick();

            if (!string.IsNullOrEmpty(text))
                Clipboard.SetText(text);

            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyDown(User32Wrapper.ControlCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyPress(User32Wrapper.VCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyUp(User32Wrapper.ControlCode);

            Thread.Sleep(ShortDelay);
        }

        public static void PasteReplaceTo(Point point)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = point;
            Thread.Sleep(ShortDelay);
            _inputSimulator.Mouse.LeftButtonClick();
            _inputSimulator.Mouse.LeftButtonClick();

            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyDown(User32Wrapper.ControlCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyPress(User32Wrapper.VCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyUp(User32Wrapper.ControlCode);

            Thread.Sleep(ShortDelay);
        }

        public static void ScrollUpAt(Point point)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = point;
            Thread.Sleep(ShortDelay);
            _inputSimulator.Mouse.LeftButtonClick();
            Thread.Sleep(ShortDelay);
            _inputSimulator.Mouse.VerticalScroll(3);

            Thread.Sleep(ShortDelay);
        }

        public static void DeleteLastCharacterFromClipboardIfEndsWithSpace()
        {
            Thread.Sleep(ShortDelay);

            if (GetClipboardTextSafe().EndsWith(" "))
                PressBackspace();

            Thread.Sleep(ShortDelay);
        }

        public static string GetClipboardTextSafe()
        {
            try
            {
                Thread.Sleep(ShortDelay);

                return Clipboard.GetText();
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot retrieve clipboard text." + Environment.NewLine + e.Message);
                Environment.Exit(1);
                return string.Empty;
            }
        }

        public static void GoToForTesting(Point point)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = point;

            Thread.Sleep(ShortDelay);
        }
    }
}
