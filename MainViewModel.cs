using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WindowsInput;
using Cursor = System.Windows.Forms.Cursor;

namespace LeadGenApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private const string InvitationContent = "Hi Name,\r\n\r\nI am a C# .NET software engineer with 11 years of experience, currently working as a contractor/consultant and looking for a new project. If you are aware of any open job positions of this kind, I would appreciate it if you could let me know. :)\r\n\r\nBest regards.";
        private const string DirectMessageSubject = "C# .NET software developer looking for remote job";
        private const string DirectMessageContent = InvitationContent;

        private readonly InputSimulator _inputSimulator = new();

        private const int WaitBeforeActionStart = 3000;
        private const int ShortDelay = 100;
        private const int LongDelay = 1000;

        public bool IsBigScreenChecked { get; set; } = true;

        public int NumberOfTabsClickMessageButton { get; set; } = 1;
        public int NumberOfTabsSendInvitation { get; set; } = 1;
        public int NumberOfTabsSendDirectMessage { get; set; } = 1;
        public int NumberOfTabsConnect { get; set; } = 1;

        public ICommand ClickMessageButtonCommand { get; }
        public ICommand SendInvitationCommand { get; }
        public ICommand SendDirectMessageCommand { get; }
        public ICommand ConnectCommand { get; }


        public MainViewModel()
        {
            ClickMessageButtonCommand = new RelayCommand(_ => ExecuteClickMessageButtonCommand());
            SendInvitationCommand = new RelayCommand(_ => ExecuteSendInvitationCommand());
            SendDirectMessageCommand = new RelayCommand(_ => ExecuteSendDirectMessageCommand());
            ConnectCommand = new RelayCommand(_ => ExecuteConnectCommand());
        }

        private void ExecuteClickMessageButtonCommand()
        {
            Thread.Sleep(WaitBeforeActionStart);

            for (int i = 0; i < NumberOfTabsClickMessageButton; i++)
            {
                ClickMessageButton();
                ChangeTab();
            }
        }

        private void ExecuteSendInvitationCommand()
        {
            Thread.Sleep(WaitBeforeActionStart);

            for (int i = 0; i < NumberOfTabsSendInvitation; i++)
                SendInvitation();
        }

        private void SendInvitation()
        {
            ClickOnThreeDots();
            ClickOnConnect();
            InsertInvitationContent();
            CopyRecruiterNameFromInvitationBox();
            ScrollUpInvitationText();
            PasteRecruiterNameToInvitationBox();
            DeleteLastCharacter();
            ClickSendInvitation();
            Thread.Sleep(LongDelay);
            ChangeTab();
        }

        private void ExecuteSendDirectMessageCommand()
        {
            Thread.Sleep(WaitBeforeActionStart);

            for (int i = 0; i < NumberOfTabsSendDirectMessage; i++)
                SendDirectMessage();
        }

        private void SendDirectMessage()
        {
            ClickMessageButton();
            InsertDirectMessageSubject();
            InsertDirectMessageContent();
            CopyRecruiterNameFromBelowPicture();
            PasteRecruiterNameToDirectMessageContent();
            DeleteLastCharacter();
            ClickSendDirectMessage();
            Thread.Sleep(LongDelay);
            ChangeTab();
        }

        private void ExecuteConnectCommand()
        {
            Thread.Sleep(WaitBeforeActionStart);

            for (int i = 0; i < NumberOfTabsConnect; i++)
            {
                ClickMessageButton();

                if (IsFreeToOpenProfile())
                    SendDirectMessage();
                else
                    SendInvitation();
            }
        }

        private bool IsFreeToOpenProfile()
        {
            CopyFrom(1820, 755);
            return Clipboard.GetText() == "Free ";
        }

        #region Common
        private void ClickTo(int x, int y)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = new System.Drawing.Point(x, y);
            _inputSimulator.Mouse.LeftButtonClick();

            Thread.Sleep(ShortDelay);
        }

        private static void ChangeTab()
        {
            Thread.Sleep(ShortDelay);

            User32Wrapper.KeyDown(User32Wrapper.ControlCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyPress(User32Wrapper.TabCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyUp(User32Wrapper.ControlCode);

            Thread.Sleep(ShortDelay);
        }

        private void CopyFrom(int x, int y)
        {
            Thread.Sleep(ShortDelay);

            var cursorPosition = new System.Drawing.Point(x, y);

            Thread.Sleep(ShortDelay);

            Cursor.Position = cursorPosition;
            _inputSimulator.Mouse.LeftButtonClick();
            _inputSimulator.Mouse.LeftButtonClick();

            User32Wrapper.KeyDown(User32Wrapper.ControlCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyPress(User32Wrapper.CCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyUp(User32Wrapper.ControlCode);

            Thread.Sleep(ShortDelay);
        }

        private void PasteTo(int x, int y, string? text = null)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = new System.Drawing.Point(x, y);

            Thread.Sleep(ShortDelay);
            _inputSimulator.Mouse.LeftButtonClick();

            if (text != null)
                Clipboard.SetText(text);

            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyDown(User32Wrapper.ControlCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyPress(User32Wrapper.VCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyUp(User32Wrapper.ControlCode);

            Thread.Sleep(ShortDelay);
        }

        private void PasteReplaceTo(int x, int y, string? text = null)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = new System.Drawing.Point(x, y);
            Thread.Sleep(ShortDelay);
            _inputSimulator.Mouse.LeftButtonClick();
            _inputSimulator.Mouse.LeftButtonClick();

            if (text != null)
                Clipboard.SetText(text);

            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyDown(User32Wrapper.ControlCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyPress(User32Wrapper.VCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyUp(User32Wrapper.ControlCode);

            Thread.Sleep(ShortDelay);
        }

        private void ScrollUpAt(int x, int y)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = new System.Drawing.Point(x, y);
            Thread.Sleep(ShortDelay);
            _inputSimulator.Mouse.LeftButtonClick();
            Thread.Sleep(ShortDelay);
            _inputSimulator.Mouse.VerticalScroll(3);

            Thread.Sleep(ShortDelay);
        }

        private static void DeleteLastCharacter()
        {
            Thread.Sleep(ShortDelay);

            User32Wrapper.KeyPress(User32Wrapper.BackspaceCode);

            Thread.Sleep(ShortDelay);
        }
        #endregion Common

        #region Invitation
        private void ClickOnThreeDots()
        {
            ClickTo(505, 740);
        }

        private void ClickOnConnect()
        {
            ClickTo(310, 815);
        }

        private void InsertInvitationContent()
        {
            PasteTo(1000, 790, InvitationContent);
        }
        private void CopyRecruiterNameFromInvitationBox()
        {
            CopyFrom(1040, 675);
        }

        private void ScrollUpInvitationText()
        {
            ScrollUpAt(1000, 790);
        }

        private void PasteRecruiterNameToInvitationBox()
        {
            PasteReplaceTo(1010, 785);
        }

        private void ClickSendInvitation()
        {
            ClickTo(1500, 940);
        }
        #endregion Invitation

        #region Direct Message
        private void ClickMessageButton()
        {
            ClickTo(390, 745);
        }

        private void InsertDirectMessageSubject()
        {
            PasteTo(1460, 800, DirectMessageSubject);
        }

        private void InsertDirectMessageContent()
        {
            PasteTo(1460, 850, DirectMessageContent);
        }

        private void CopyRecruiterNameFromBelowPicture()
        {
            CopyFrom(155, 620);
        }

        private void PasteRecruiterNameToDirectMessageContent()
        {
            PasteReplaceTo(1490, 850);
        }

        private void ClickSendDirectMessage()
        {
            ClickTo(1940, 1325);
        }
        #endregion Direct Message
    }
}
