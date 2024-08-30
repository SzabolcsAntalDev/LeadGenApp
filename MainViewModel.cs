using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WindowsInput;
using Cursor = System.Windows.Forms.Cursor;
using Point = System.Drawing.Point;

namespace LeadGenApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Variables
        private readonly Point MessageButtonPointSmallScreen = new Point(255, 595);
        private readonly Point IsFreeToOpenProfileTextPointSmallScreen = new Point(1325, 530);
        private readonly Point ThreeDotsButtonPointSmallScreen = new Point(350, 600);
        private readonly Point ConnectSubItemPointSmallScreen = new Point(200, 650);
        private readonly Point RecruiterNameFromEditableInvitationBoxPointSmallScreen = new Point(750, 595);
        private readonly Point RecruiterNameFromStaticInvitationBoxPointSmallScreen = new Point(765, 505);
        private readonly Point SendInvitationButtonPointSmallScreen = new Point(1120, 715);
        private readonly Point DirectMessageSubjectPointSmallScreen = new Point(1040, 565);
        private readonly Point RecruiterNameFromBelowPicturePointSmallScreen = new Point(70, 500);
        private readonly Point RecruiterNameFromDirectMessageContentPointSmallScreen = new Point(1055, 610);
        private readonly Point SendDirectMessageButtonPointSmallScreen = new Point(1425, 990);

        private readonly Point MessageButtonPointBigScreen = new Point(390, 745);
        private readonly Point IsFreeToOpenProfileTextPointBigScreen = new Point(1820, 755);
        private readonly Point ThreeDotsButtonPointBigScreen = new Point(505, 740);
        private readonly Point ConnectSubItemPointBigScreen = new Point(310, 815);
        private readonly Point RecruiterNameFromEditableInvitationBoxPointBigScreen = new Point(1010, 790);
        private readonly Point RecruiterNameFromStaticInvitationBoxPointBigScreen = new Point(1040, 670);
        private readonly Point SendInvitationButtonPointBigScreen = new Point(1500, 940);
        private readonly Point DirectMessageSubjectPointBigScreen = new Point(1460, 800);
        private readonly Point RecruiterNameFromBelowPicturePointBigScreen = new Point(170, 620);
        private readonly Point RecruiterNameFromDirectMessageContentPointBigScreen = new Point(1490, 850);
        private readonly Point SendDirectMessageButtonPointBigScreen = new Point(1940, 1325);

        private Point MessageButtonPoint => IsBigScreenChecked ? MessageButtonPointBigScreen : MessageButtonPointSmallScreen;
        private Point IsFreeToOpenProfileTextPoint => IsBigScreenChecked ? IsFreeToOpenProfileTextPointBigScreen : IsFreeToOpenProfileTextPointSmallScreen;
        private Point ThreeDotsButtonPoint => IsBigScreenChecked ? ThreeDotsButtonPointBigScreen : ThreeDotsButtonPointSmallScreen;
        private Point ConnectSubItemPoint => IsBigScreenChecked ? ConnectSubItemPointBigScreen : ConnectSubItemPointSmallScreen;
        private Point RecruiterNameFromEditableInvitationBoxPoint => IsBigScreenChecked ? RecruiterNameFromEditableInvitationBoxPointBigScreen : RecruiterNameFromEditableInvitationBoxPointSmallScreen;
        private Point RecruiterNameFromStaticInvitationBoxPoint => IsBigScreenChecked ? RecruiterNameFromStaticInvitationBoxPointBigScreen : RecruiterNameFromStaticInvitationBoxPointSmallScreen;
        private Point SendInvitationButtonPoint => IsBigScreenChecked ? SendInvitationButtonPointBigScreen : SendInvitationButtonPointSmallScreen;
        private Point DirectMessageSubjectPoint => IsBigScreenChecked ? DirectMessageSubjectPointBigScreen : DirectMessageSubjectPointSmallScreen;
        private Point RecruiterNameFromBelowPicturePoint => IsBigScreenChecked ? RecruiterNameFromBelowPicturePointBigScreen : RecruiterNameFromBelowPicturePointSmallScreen;
        private Point RecruiterNameFromDirectMessageContentPoint => IsBigScreenChecked ? RecruiterNameFromDirectMessageContentPointBigScreen : RecruiterNameFromDirectMessageContentPointSmallScreen;
        private Point SendDirectMessageButtonPoint => IsBigScreenChecked ? SendDirectMessageButtonPointBigScreen : SendDirectMessageButtonPointSmallScreen;
        #endregion Variables

        public event PropertyChangedEventHandler? PropertyChanged;

        private const string InvitationContent = "Hi Name,\r\n\r\nI am a C# .NET software engineer with 11 years of experience, currently working as a contractor/consultant and looking for a new project. If you are aware of any open job positions of this kind, I would appreciate it if you could let me know. :)\r\n\r\nBest regards.";
        private const string DirectMessageSubject = "C# .NET software developer looking for remote job";
        private const string DirectMessageContent = "Hi Name,\r\n\r\nI am a C# .NET software engineer with 11 years of experience, currently working as a contractor/consultant and looking for a new project. If you are aware of any open job positions of this kind, I would appreciate it if you could let me know. :)\r\n\r\nBest regards,";

        private readonly InputSimulator _inputSimulator = new();

        private const int WaitBeforeActionStart = 3000;
        private const int ShortDelay = 200;
        private const int LongDelay = 1500;

        public bool IsBigScreenChecked { get; set; } = true;

        public int NumberOfTabsClickMessageButton { get; set; } = 1;
        public int NumberOfTabsConnect { get; set; } = 1;

        public ICommand ClickMessageButtonCommand { get; }
        public ICommand ConnectCommand { get; }


        public MainViewModel()
        {
            ClickMessageButtonCommand = new RelayCommand(_ => ExecuteClickMessageButtonCommand());
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

        #region Common
        private void ClickTo(Point point)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = point;
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

        private void CopyFrom(Point point)
        {
            Thread.Sleep(ShortDelay);

            var cursorPosition = point;

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

        private void PasteTo(Point point, string? text = null)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = point;

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

        private void PasteReplaceTo(Point point, string? text = null)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = point;
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

        private void ScrollUpAt(Point point)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = point;
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

        private void ClickMessageButton()
        {
            ClickTo(MessageButtonPoint);
        }

        private bool IsFreeToOpenProfile()
        {
            CopyFrom(IsFreeToOpenProfileTextPoint);
            return Clipboard.GetText() == "Free ";
        }
        #endregion Common

        #region Invitation
        private void ClickOnThreeDots()
        {
            ClickTo(ThreeDotsButtonPoint);
        }

        private void ClickOnConnect()
        {
            ClickTo(ConnectSubItemPoint);
        }

        private void InsertInvitationContent()
        {
            PasteTo(RecruiterNameFromEditableInvitationBoxPoint, InvitationContent);
        }

        private void CopyRecruiterNameFromInvitationBox()
        {
            CopyFrom(RecruiterNameFromStaticInvitationBoxPoint);
        }

        private void ScrollUpInvitationText()
        {
            ScrollUpAt(RecruiterNameFromEditableInvitationBoxPoint);
        }

        private void PasteRecruiterNameToInvitationBox()
        {
            PasteReplaceTo(RecruiterNameFromEditableInvitationBoxPoint);
        }

        private void ClickSendInvitation()
        {
            ClickTo(SendInvitationButtonPoint);
        }
        #endregion Invitation

        #region Direct Message
        private void InsertDirectMessageSubject()
        {
            PasteTo(DirectMessageSubjectPoint, DirectMessageSubject);
        }

        private void InsertDirectMessageContent()
        {
            PasteTo(RecruiterNameFromDirectMessageContentPoint, DirectMessageContent);
        }

        private void CopyRecruiterNameFromBelowPicture()
        {
            CopyFrom(RecruiterNameFromBelowPicturePoint);
        }

        private void PasteRecruiterNameToDirectMessageContent()
        {
            PasteReplaceTo(RecruiterNameFromDirectMessageContentPoint);
        }

        private void ClickSendDirectMessage()
        {
            ClickTo(SendDirectMessageButtonPoint);
        }
        #endregion Direct Message
    }
}
