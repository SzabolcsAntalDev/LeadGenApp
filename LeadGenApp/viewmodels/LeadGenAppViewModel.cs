using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using LeadGenApp.common;
using LeadGenApp.input;
using WindowsInput;
using Cursor = System.Windows.Forms.Cursor;
using Point = System.Drawing.Point;

namespace LeadGenApp.viewmodels
{
    public class LeadGenAppViewModel : INotifyPropertyChanged
    {
        #region Variables
        private readonly bool IsTesting = false;

        private readonly Point MessageButtonPointSmallScreen = new Point(255, 580);
        private readonly Point IsFreeToOpenProfileTextPointSmallScreen = new Point(1325, 530);
        private readonly Point ThreeDotsButtonPointSmallScreen = new Point(348, 580);
        private readonly Point ConnectSubItemPointSmallScreen = new Point(200, 640);
        private readonly Point EmailRequiredInInvitationBoxPointSmallScreen = new Point(715, 620);
        private readonly Point EmailAddressInInvitationBoxPointSmallScreen = new Point(720, 660);
        private readonly Point RecruiterNameFromEditableInvitationBoxWithoutEmailPointSmallScreen = new Point(750, 595);
        private readonly Point RecruiterNameFromStaticInvitationBoxWithoutEmailPointSmallScreen = new Point(765, 505);
        private readonly Point RecruiterNameFromEditableInvitationBoxWithEmailPointSmallScreen = new Point(740, 555);
        private readonly Point RecruiterNameFromStaticInvitationBoxWithEmailPointSmallScreen = new Point(770, 465);
        private readonly Point SendInvitationButtonWithoutEmailPointSmallScreen = new Point(1120, 715);
        private readonly Point SendInvitationButtonWithEmailPointSmallScreen = new Point(1135, 750);
        private readonly Point DirectMessageSubjectPointSmallScreen = new Point(1040, 565);
        private readonly Point RecruiterNameFromBelowPicturePointSmallScreen = new Point(70, 500);
        private readonly Point RecruiterNameFromDirectMessageContentPointSmallScreen = new Point(1055, 610);
        private readonly Point SendDirectMessageButtonPointSmallScreen = new Point(1425, 990);

        private readonly Point MessageButtonPointBigScreen = new Point(390, 724);
        private readonly Point IsFreeToOpenProfileTextPointBigScreen = new Point(1820, 755);
        private readonly Point ThreeDotsButtonPointBigScreen = new Point(505, 724);
        private readonly Point ConnectSubItemPointBigScreen = new Point(310, 800);
        private readonly Point EmailRequiredInInvitationBoxPointBigScreen = new Point(970, 820);
        private readonly Point EmailAddressInInvitationBoxPointBigScreen = new Point(980, 870);
        private readonly Point RecruiterNameFromEditableInvitationBoxWithoutEmailPointBigScreen = new Point(1010, 790);
        private readonly Point RecruiterNameFromStaticInvitationBoxWithoutEmailPointBigScreen = new Point(1040, 670);
        private readonly Point RecruiterNameFromEditableInvitationBoxWithEmailPointBigScreen = new Point(1010, 740);
        private readonly Point RecruiterNameFromStaticInvitationBoxWithEmailPointBigScreen = new Point(1040, 630);
        private readonly Point SendInvitationButtonWithoutEmailPointBigScreen = new Point(1500, 940);
        private readonly Point SendInvitationButtonWithEmailPointBigScreen = new Point(1500, 990);
        private readonly Point DirectMessageSubjectPointBigScreen = new Point(1460, 800);
        private readonly Point RecruiterNameFromBelowPicturePointBigScreen = new Point(170, 620);
        private readonly Point RecruiterNameFromDirectMessageContentPointBigScreen = new Point(1490, 850);
        private readonly Point SendDirectMessageButtonPointBigScreen = new Point(1940, 1325);

        private Point MessageButtonPoint => IsSmallScreenChecked ? MessageButtonPointSmallScreen : MessageButtonPointBigScreen;
        private Point IsFreeToOpenProfileTextPoint => IsSmallScreenChecked ? IsFreeToOpenProfileTextPointSmallScreen : IsFreeToOpenProfileTextPointBigScreen;
        private Point ThreeDotsButtonPoint => IsSmallScreenChecked ? ThreeDotsButtonPointSmallScreen : ThreeDotsButtonPointBigScreen;
        private Point ConnectSubItemPoint => IsSmallScreenChecked ? ConnectSubItemPointSmallScreen : ConnectSubItemPointBigScreen;
        private Point EmailRequiredInInvitationBoxPoint => IsSmallScreenChecked ? EmailRequiredInInvitationBoxPointSmallScreen : EmailRequiredInInvitationBoxPointBigScreen;
        private Point EmailAddressInInvitationBoxPoint => IsSmallScreenChecked ? EmailAddressInInvitationBoxPointSmallScreen : EmailAddressInInvitationBoxPointBigScreen;

        private Point RecruiterNameFromEditableInvitationBoxWithoutEmailPoint => IsSmallScreenChecked ? RecruiterNameFromEditableInvitationBoxWithoutEmailPointSmallScreen : RecruiterNameFromEditableInvitationBoxWithoutEmailPointBigScreen;
        private Point RecruiterNameFromStaticInvitationBoxWithoutEmailPoint => IsSmallScreenChecked ? RecruiterNameFromStaticInvitationBoxWithoutEmailPointSmallScreen : RecruiterNameFromStaticInvitationBoxWithoutEmailPointBigScreen;
        private Point RecruiterNameFromEditableInvitationBoxWithEmailPoint => IsSmallScreenChecked ? RecruiterNameFromEditableInvitationBoxWithEmailPointSmallScreen : RecruiterNameFromEditableInvitationBoxWithEmailPointBigScreen;
        private Point RecruiterNameFromStaticInvitationBoxWithEmailPoint => IsSmallScreenChecked ? RecruiterNameFromStaticInvitationBoxWithEmailPointSmallScreen : RecruiterNameFromStaticInvitationBoxWithEmailPointBigScreen;
        private Point SendInvitationButtonWithoutEmailPoint => IsSmallScreenChecked ? SendInvitationButtonWithoutEmailPointSmallScreen : SendInvitationButtonWithoutEmailPointBigScreen;
        private Point SendInvitationButtonWithEmailPoint => IsSmallScreenChecked ? SendInvitationButtonWithEmailPointSmallScreen : SendInvitationButtonWithEmailPointBigScreen;
        private Point DirectMessageSubjectPoint => IsSmallScreenChecked ? DirectMessageSubjectPointSmallScreen : DirectMessageSubjectPointBigScreen;
        private Point RecruiterNameFromBelowPicturePoint => IsSmallScreenChecked ? RecruiterNameFromBelowPicturePointSmallScreen : RecruiterNameFromBelowPicturePointBigScreen;
        private Point RecruiterNameFromDirectMessageContentPoint => IsSmallScreenChecked ? RecruiterNameFromDirectMessageContentPointSmallScreen : RecruiterNameFromDirectMessageContentPointBigScreen;
        private Point SendDirectMessageButtonPoint => IsSmallScreenChecked ? SendDirectMessageButtonPointSmallScreen : SendDirectMessageButtonPointBigScreen;
        #endregion Variables

        public event PropertyChangedEventHandler? PropertyChanged;

        private const string InvitationContent = "Hi Name,\r\n\r\nI am a C# .NET software engineer with 11 years of experience, currently working as a contractor/consultant and looking for a new project. If you are aware of any open job positions of this kind, I would appreciate it if you could let me know. :)\r\n\r\nBest regards.";
        private const string DirectMessageSubject = "C# .NET software developer looking for remote job";
        private const string DirectMessageContent = "Hi Name,\r\n\r\nI am a C# .NET software engineer with 11 years of experience, currently working as a contractor/consultant and looking for a new project. If you are aware of any open job positions of this kind, I would appreciate it if you could let me know. :)\r\n\r\nBest regards,";
        private const string EmailAddress = "szabolcs.antal.dev@gmail.com";

        private readonly InputSimulator _inputSimulator = new();

        private const int WaitBeforeActionStart = 3000;
        private const int ShortDelay = 200;
        private const int LongDelay = 1500;

        public bool IsSmallScreenChecked { get; set; } = false;

        public int NumberOfTabsClickMessageButton { get; set; } = 1;
        public int NumberOfTabsConnect { get; set; } = 1;

        public ICommand ClickMessageButtonCommand { get; }
        public ICommand ConnectCommand { get; }


        public LeadGenAppViewModel()
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

            var emailRequired = EmailRequiredOnInvitation();

            InsertInvitationContent(emailRequired);
            CopyRecruiterNameFromInvitationBox(emailRequired);
            ScrollUpInvitationText(emailRequired);
            PasteRecruiterNameToInvitationBox(emailRequired);
            DeleteLastCharacter();

            if (emailRequired)
                PasteEmailAddressToInvitationBox();

            if (IsTesting)
            {
                GoToSendInvitationForTesting(emailRequired);
            }
            else
            {
                ClickSendInvitation(emailRequired);
                Thread.Sleep(LongDelay);
                ChangeTab();
            }
        }

        private bool EmailRequiredOnInvitation()
        {
            Clipboard.Clear();

            CopyFrom(EmailRequiredInInvitationBoxPoint);
            return !string.IsNullOrEmpty(GetClipboardTextSafe()); ;
        }

        private void SendDirectMessage()
        {
            ClickMessageButton();
            InsertDirectMessageSubject();
            InsertDirectMessageContent();
            CopyRecruiterNameFromBelowPicture();
            PasteRecruiterNameToDirectMessageContent();
            DeleteLastCharacter();

            if (IsTesting)
            {
                GoToSendDirectMessageForTesting();
            }
            else
            {
                ClickSendDirectMessage();
                Thread.Sleep(LongDelay);
                ChangeTab();
            }
        }

        #region Common
        private void ClickTo(Point point)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = point;
            _inputSimulator.Mouse.LeftButtonClick();

            Thread.Sleep(ShortDelay);
        }

        private void GoToForTesting(Point point)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = point;

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

        private void PasteTo(Point point, string text)
        {
            Thread.Sleep(ShortDelay);

            Cursor.Position = point;

            Thread.Sleep(ShortDelay);
            _inputSimulator.Mouse.LeftButtonClick();

            Clipboard.SetText(text);

            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyDown(User32Wrapper.ControlCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyPress(User32Wrapper.VCode);
            Thread.Sleep(ShortDelay);
            User32Wrapper.KeyUp(User32Wrapper.ControlCode);

            Thread.Sleep(ShortDelay);
        }

        private void PasteReplaceTo(Point point)
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

        private void DeleteLastCharacter()
        {
            Thread.Sleep(ShortDelay);

            if (GetClipboardTextSafe().EndsWith(" "))
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
            return GetClipboardTextSafe() == "Free ";
        }

        private static string GetClipboardTextSafe()
        {
            try
            {
                return Clipboard.GetText();
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot retrieve clipboard text." + Environment.NewLine + e.Message);
                Environment.Exit(1);
                return string.Empty;
            }
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

        private void InsertInvitationContent(bool emailRequired)
        {
            PasteTo(
                emailRequired
                    ? RecruiterNameFromEditableInvitationBoxWithEmailPoint
                    : RecruiterNameFromEditableInvitationBoxWithoutEmailPoint,
                InvitationContent);
        }

        private void CopyRecruiterNameFromInvitationBox(bool emailRequired)
        {
            CopyFrom(
                emailRequired
                    ? RecruiterNameFromStaticInvitationBoxWithEmailPoint
                    : RecruiterNameFromStaticInvitationBoxWithoutEmailPoint);
        }

        private void ScrollUpInvitationText(bool emailRequired)
        {
            ScrollUpAt(
                emailRequired
                    ? RecruiterNameFromEditableInvitationBoxWithEmailPoint
                    : RecruiterNameFromEditableInvitationBoxWithoutEmailPoint);
        }

        private void PasteRecruiterNameToInvitationBox(bool emailRequired)
        {
            PasteReplaceTo(
                emailRequired
                    ? RecruiterNameFromEditableInvitationBoxWithEmailPoint
                    : RecruiterNameFromEditableInvitationBoxWithoutEmailPoint);
        }

        private void PasteEmailAddressToInvitationBox()
        {
            PasteTo(EmailAddressInInvitationBoxPoint, EmailAddress);
        }

        private void ClickSendInvitation(bool emailRequired)
        {
            ClickTo(
                emailRequired
                    ? SendInvitationButtonWithEmailPoint
                    : SendInvitationButtonWithoutEmailPoint);
        }

        private void GoToSendInvitationForTesting(bool emailRequired)
        {
            GoToForTesting(
                emailRequired
                    ? SendInvitationButtonWithEmailPoint
                    : SendInvitationButtonWithoutEmailPoint);
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

        private void GoToSendDirectMessageForTesting()
        {
            GoToForTesting(SendDirectMessageButtonPoint);
        }
        #endregion Direct Message
    }
}
