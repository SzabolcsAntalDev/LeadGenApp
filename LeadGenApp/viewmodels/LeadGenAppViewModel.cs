using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using LeadGenApp.common;
using LeadGenApp.input;
using WindowsInput;
using Screen = System.Windows.Forms.Screen;
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

        private Point MessageButtonPoint => IsSmallScreenSelected ? MessageButtonPointSmallScreen : MessageButtonPointBigScreen;
        private Point IsFreeToOpenProfileTextPoint => IsSmallScreenSelected ? IsFreeToOpenProfileTextPointSmallScreen : IsFreeToOpenProfileTextPointBigScreen;
        private Point ThreeDotsButtonPoint => IsSmallScreenSelected ? ThreeDotsButtonPointSmallScreen : ThreeDotsButtonPointBigScreen;
        private Point ConnectSubItemPoint => IsSmallScreenSelected ? ConnectSubItemPointSmallScreen : ConnectSubItemPointBigScreen;
        private Point EmailRequiredInInvitationBoxPoint => IsSmallScreenSelected ? EmailRequiredInInvitationBoxPointSmallScreen : EmailRequiredInInvitationBoxPointBigScreen;
        private Point EmailAddressInInvitationBoxPoint => IsSmallScreenSelected ? EmailAddressInInvitationBoxPointSmallScreen : EmailAddressInInvitationBoxPointBigScreen;

        private Point RecruiterNameFromEditableInvitationBoxWithoutEmailPoint => IsSmallScreenSelected ? RecruiterNameFromEditableInvitationBoxWithoutEmailPointSmallScreen : RecruiterNameFromEditableInvitationBoxWithoutEmailPointBigScreen;
        private Point RecruiterNameFromStaticInvitationBoxWithoutEmailPoint => IsSmallScreenSelected ? RecruiterNameFromStaticInvitationBoxWithoutEmailPointSmallScreen : RecruiterNameFromStaticInvitationBoxWithoutEmailPointBigScreen;
        private Point RecruiterNameFromEditableInvitationBoxWithEmailPoint => IsSmallScreenSelected ? RecruiterNameFromEditableInvitationBoxWithEmailPointSmallScreen : RecruiterNameFromEditableInvitationBoxWithEmailPointBigScreen;
        private Point RecruiterNameFromStaticInvitationBoxWithEmailPoint => IsSmallScreenSelected ? RecruiterNameFromStaticInvitationBoxWithEmailPointSmallScreen : RecruiterNameFromStaticInvitationBoxWithEmailPointBigScreen;
        private Point SendInvitationButtonWithoutEmailPoint => IsSmallScreenSelected ? SendInvitationButtonWithoutEmailPointSmallScreen : SendInvitationButtonWithoutEmailPointBigScreen;
        private Point SendInvitationButtonWithEmailPoint => IsSmallScreenSelected ? SendInvitationButtonWithEmailPointSmallScreen : SendInvitationButtonWithEmailPointBigScreen;
        private Point DirectMessageSubjectPoint => IsSmallScreenSelected ? DirectMessageSubjectPointSmallScreen : DirectMessageSubjectPointBigScreen;
        private Point RecruiterNameFromBelowPicturePoint => IsSmallScreenSelected ? RecruiterNameFromBelowPicturePointSmallScreen : RecruiterNameFromBelowPicturePointBigScreen;
        private Point RecruiterNameFromDirectMessageContentPoint => IsSmallScreenSelected ? RecruiterNameFromDirectMessageContentPointSmallScreen : RecruiterNameFromDirectMessageContentPointBigScreen;
        private Point SendDirectMessageButtonPoint => IsSmallScreenSelected ? SendDirectMessageButtonPointSmallScreen : SendDirectMessageButtonPointBigScreen;
        #endregion Variables

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private const string InvitationContent = "Hi Name,\r\n\r\nI am a C# .NET software engineer with 11 years of experience, currently working as a contractor/consultant and looking for a new project. If you are aware of any open job positions of this kind, I would appreciate it if you could let me know. :)\r\n\r\nBest regards.";
        private const string DirectMessageSubject = "C# .NET software developer looking for remote job";
        private const string DirectMessageContent = "Hi Name,\r\n\r\nI am a C# .NET software engineer with 11 years of experience, currently working as a contractor/consultant and looking for a new project. If you are aware of any open job positions of this kind, I would appreciate it if you could let me know. :)\r\n\r\nBest regards,";
        private const string EmailAddress = "szabolcs.antal.dev@gmail.com";

        private readonly InputSimulator _inputSimulator = new();

        private const int WaitBeforeActionStart = 3000;
        private const int ShortDelay = 200;
        private const int LongDelay = 1000;

        public string InfoText { get; set; }

        private bool _wasTestedOnCurrentScreenSize;
        public bool WasTestedOnCurrentScreenSize
        {
            get => _wasTestedOnCurrentScreenSize;
            set
            {
                _wasTestedOnCurrentScreenSize = value;
                OnPropertyChanged(nameof(_wasTestedOnCurrentScreenSize));
            }
        }

        private bool _isSmallScreenSelected;
        public bool IsSmallScreenSelected
        {
            get => _isSmallScreenSelected;
            set
            {
                _isSmallScreenSelected = value;
                OnPropertyChanged(nameof(IsSmallScreenSelected));
            }
        }

        public ICommand ClickMessageButtonCommand { get; }
        public ICommand SendOnylDirectMessagesToOpenProfilesButtonCommand { get; }
        public ICommand SendOnylDirectMessagesToAllProfilesButtonCommand { get; }
        public ICommand ConnectCommand { get; }


        public LeadGenAppViewModel()
        {
            SetupInfoText();

            ClickMessageButtonCommand = new RelayCommand(_ => ExecuteClickMessageButtonCommand());
            SendOnylDirectMessagesToOpenProfilesButtonCommand = new RelayCommand(_ => ExecuteSendOnylDirectMessagesToOpenProfilesButtonCommand());
            SendOnylDirectMessagesToAllProfilesButtonCommand = new RelayCommand(_ => ExecuteSendOnylDirectMessagesToAllProfilesButtonCommand());
            ConnectCommand = new RelayCommand(_ => ExecuteConnectCommand());
        }

        private void SetupInfoText()
        {
            var width = Screen.PrimaryScreen.Bounds.Width ;
            var height = Screen.PrimaryScreen.Bounds.Height;
            var text = $"Current screen resolution is {width}x{height}." + Environment.NewLine;

            if (width == 1920 && height == 1080)
            {
                text += "The app works well if Scale is set to 100%.";
                IsSmallScreenSelected = true;
                WasTestedOnCurrentScreenSize = true;
            }
            else if (width == 2560 && height == 1440)
            {
                text += "The app works well if Scale is set to 125%.";
                IsSmallScreenSelected = false;
                WasTestedOnCurrentScreenSize = true;
            }
            else
            {
                text +=
                    "The app will probably not work well on this resolution." + Environment.NewLine +
                    "It works well on:" + Environment.NewLine +
                    "1920x1080 with Scaling 100%" + Environment.NewLine +
                    "2560x1440 with Scaling 125%";

                IsSmallScreenSelected = true;
            }

            InfoText = text;
        }

        private void ExecuteClickMessageButtonCommand()
        {
            Thread.Sleep(WaitBeforeActionStart);

            while (true)
            {
                if (IsEmptyTab())
                    return;

                ClickMessageButton();

                if (IsTesting)
                    return;
                else
                    ChangeTab();
            }
        }

        private void ExecuteSendOnylDirectMessagesToOpenProfilesButtonCommand()
        {
            Thread.Sleep(WaitBeforeActionStart);

            while (true)
            {
                if (IsEmptyTab())
                    return;

                ClickMessageButton();

                if (IsFreeToOpenProfile())
                    SendDirectMessage();

                if (IsTesting)
                    return;
                else
                    ChangeTab();
            }
        }

        private void ExecuteSendOnylDirectMessagesToAllProfilesButtonCommand()
        {
            Thread.Sleep(WaitBeforeActionStart);

            while (true)
            {
                if (IsEmptyTab())
                    return;

                ClickMessageButton();
                SendDirectMessage();

                if (IsTesting)
                    return;
                else
                    ChangeTab();
            }
        }

        private void ExecuteConnectCommand()
        {
            Thread.Sleep(WaitBeforeActionStart);

            while (true)
            {
                if (IsEmptyTab())
                    return;

                ClickMessageButton();

                if (IsFreeToOpenProfile())
                    SendDirectMessage();
                else
                    SendInvitation();

                if (IsTesting)
                    return;
                else
                    ChangeTab();
            }
        }

        private bool IsEmptyTab()
        {
            CopyFrom(RecruiterNameFromBelowPicturePoint);

            return GetClipboardTextSafe() == Environment.NewLine;
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
            }
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

        private static void GoToForTesting(Point point)
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

        private static void DeleteLastCharacter()
        {
            Thread.Sleep(ShortDelay);

            if (GetClipboardTextSafe().EndsWith(" "))
                User32Wrapper.KeyPress(User32Wrapper.BackspaceCode);

            Thread.Sleep(ShortDelay);
        }

        private void ClickMessageButton()
        {
            ClickTo(MessageButtonPoint);

            Thread.Sleep(LongDelay);
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

        private bool EmailRequiredOnInvitation()
        {
            Clipboard.Clear();

            CopyFrom(EmailRequiredInInvitationBoxPoint);
            return !string.IsNullOrEmpty(GetClipboardTextSafe()); ;
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
