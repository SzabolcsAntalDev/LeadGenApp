using LeadGenApp.common;
using LeadGenApp.helpers;
using LeadGenApp.input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WindowsInput;
using Point = System.Drawing.Point;
using Screen = System.Windows.Forms.Screen;

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
        private readonly Point EndOfNotepadPointSmallScreen = new Point(1800, 900);
        private readonly Point CopyLinkedinUrlTopButtonPointSmallScreen = new Point(200, 700);
        private readonly Point CopyLinkedinUrlBottomButtonPointSmallScreen = new Point(200, 750);
        private readonly Point BrowsersHyperlinkPointSmallScreen = new Point(170, 60);
        private readonly Point CurrentRoleTextOnBottomPointSmallScreen = new Point(80, 650);
        private readonly Point RoleAtCompanyTopTextPointSmallScreen = new Point(120, 690);
        private readonly Point RoleAtCompanyBottomTextPointSmallScreen = new Point(120, 740);

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
        private readonly Point EndOfNotepadPointBigScreen = new Point(2300, 1200);
        private readonly Point CopyLinkedinUrlTopButtonPointBigScreen = new Point(310, 875);
        private readonly Point CopyLinkedinUrlBottomButtonPointBigScreen = new Point(310, 920);
        private readonly Point BrowsersHyperlinkPointBigScreen = new Point(220, 75);
        private readonly Point CurrentRoleTextOnBottomPointBigScreen = new Point(170, 840);
        private readonly Point RoleAtCompanyTopTextPointBigScreen = new Point(220, 860);
        private readonly Point RoleAtCompanyBottomTextPointBigScreen = new Point(220, 920);

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
        private Point EndOfNotepadPoint => IsSmallScreenSelected ? EndOfNotepadPointSmallScreen : EndOfNotepadPointBigScreen;
        private Point CopyLinkedinUrlTopButtonPoint => IsSmallScreenSelected ? CopyLinkedinUrlTopButtonPointSmallScreen : CopyLinkedinUrlTopButtonPointBigScreen;
        private Point CopyLinkedinUrlBottomButtonPoint => IsSmallScreenSelected ? CopyLinkedinUrlBottomButtonPointSmallScreen : CopyLinkedinUrlBottomButtonPointBigScreen;
        private Point BrowsersHyperlinkPoint => IsSmallScreenSelected ? BrowsersHyperlinkPointSmallScreen : BrowsersHyperlinkPointBigScreen;
        private Point CurrentRoleTextOnBottomPoint => IsSmallScreenSelected ? CurrentRoleTextOnBottomPointSmallScreen : CurrentRoleTextOnBottomPointBigScreen;
        private Point RoleAtCompanyTopTextPointScreen => IsSmallScreenSelected ? RoleAtCompanyTopTextPointSmallScreen : RoleAtCompanyTopTextPointBigScreen;
        private Point RoleAtCompanyBottomTextPointScreen => IsSmallScreenSelected ? RoleAtCompanyBottomTextPointSmallScreen : RoleAtCompanyBottomTextPointBigScreen;

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

        private const int WaitBeforeActionStart = 4000;
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

        public ICommand SendOnylDirectMessagesToOpenProfilesButtonCommand { get; }
        public ICommand SendOnylDirectMessagesToAllProfilesButtonCommand { get; }
        public ICommand ConnectCommand { get; }
        public ICommand ExtractDataCommand { get; }

        public LeadGenAppViewModel()
        {
            SetupInfoText();

            SendOnylDirectMessagesToOpenProfilesButtonCommand = new RelayCommand(_ => ExecuteSendOnylDirectMessagesToOpenProfilesButtonCommand());
            SendOnylDirectMessagesToAllProfilesButtonCommand = new RelayCommand(_ => ExecuteSendOnylDirectMessagesToAllProfilesButtonCommand());
            ConnectCommand = new RelayCommand(_ => ExecuteConnectCommand());
            ExtractDataCommand = new RelayCommand(_ => ExecuteExtractDataCommand());
        }

        #region Main
        private void SetupInfoText()
        {
            var width = Screen.PrimaryScreen.Bounds.Width;
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

        private void ExecuteSendOnylDirectMessagesToOpenProfilesButtonCommand()
        {
            Thread.Sleep(WaitBeforeActionStart);

            while (true)
            {
                if (IsEmptyTab())
                    return;

                ClickOnMessageButton();

                if (IsFreeToOpenProfile())
                    SendDirectMessage();

                if (IsTesting)
                    return;
                else
                    UserActions.ControlTab();
            }
        }

        private void ExecuteSendOnylDirectMessagesToAllProfilesButtonCommand()
        {
            Thread.Sleep(WaitBeforeActionStart);

            while (true)
            {
                if (IsEmptyTab())
                    return;

                ClickOnMessageButton();
                SendDirectMessage();

                if (IsTesting)
                    return;
                else
                    UserActions.ControlTab();
            }
        }

        private void ExecuteConnectCommand()
        {
            Thread.Sleep(WaitBeforeActionStart);

            while (true)
            {
                if (IsEmptyTab())
                    return;

                ClickOnMessageButton();

                if (IsFreeToOpenProfile())
                    SendDirectMessage();
                else
                    SendInvitation();

                if (IsTesting)
                    return;
                else
                    UserActions.ControlTab();
            }
        }

        private void ExecuteExtractDataCommand()
        {
            Thread.Sleep(WaitBeforeActionStart);

            while (true)
            {
                if (IsEmptyTab())
                    return;

                CopyRecruiterFullNameFromBelowPicture();
                UserActions.AltTab();
                PasteToEndOfNotepad();
                UserActions.PressBackspace();
                UserActions.PressTab();
                UserActions.AltTab();

                // copy linkedin profile link
                CopyLinkedinUrl();
                UserActions.AltTab();
                PasteToEndOfNotepad();
                UserActions.PressTab();
                UserActions.AltTab();

                // copy sales nav link
                CopyHyperlinkFromBrowser();
                UserActions.AltTab();
                PasteToEndOfNotepad();
                UserActions.PressTab();
                UserActions.AltTab();

                // copy company
                CopyCompanyNameFromCurrentRoleText();
                UserActions.AltTab();
                PasteToEndOfNotepad();
                UserActions.PressBackspace();
                UserActions.PressEnter();
                UserActions.AltTab();

                if (IsTesting)
                    return;
                else
                    UserActions.ControlTab();
            }
        }

        private bool IsEmptyTab()
        {
            UserActions.CopyFromWithDoubleClick(RecruiterNameFromBelowPicturePoint);

            return UserActions.GetClipboardTextSafe() == Environment.NewLine;
        }

        private void SendInvitation()
        {
            ClickOnThreeDotsButton();
            ClickOnConnectButton();

            var emailRequired = IsEmailRequiredOnInvitation();

            PasteInvitationContentToEditableInvitationBox(emailRequired);
            CopyRecruiterNameFromInvitationBox(emailRequired);
            ScrollUpInvitationText(emailRequired);
            PasteReplaceToRecruiterNameFromEditableInvitationBox(emailRequired);
            UserActions.DeleteLastCharacterFromClipboardIfEndsWithSpace();

            if (emailRequired)
                PasteEmailAddressToInvitationBox();

            if (IsTesting)
            {
                GoToSendInvitationForTesting(emailRequired);
            }
            else
            {
                ClickSendInvitationButton(emailRequired);
                Thread.Sleep(LongDelay);
            }
        }

        private void SendDirectMessage()
        {
            ClickOnMessageButton();
            PasteDirectMessageSubjectToDirectMessageSubject();
            PasteDirectMessageToDirectMessageContent();
            CopyRecruiterFirstNameFromBelowPicture();
            PasteReplaceToRecruiterNameFromDirectMessageContent();
            UserActions.DeleteLastCharacterFromClipboardIfEndsWithSpace();

            if (IsTesting)
            {
                GoToSendDirectMessageForTesting();
            }
            else
            {
                ClickOnSendDirectMessageButton();
                Thread.Sleep(LongDelay);
            }
        }
        #endregion Main

        #region Testing
        private void GoToSendInvitationForTesting(bool emailRequired)
        {
            UserActions.GoToForTesting(
                emailRequired
                    ? SendInvitationButtonWithEmailPoint
                    : SendInvitationButtonWithoutEmailPoint);
        }

        private void GoToSendDirectMessageForTesting()
        {
            UserActions.GoToForTesting(SendDirectMessageButtonPoint);
        }
        #endregion Testing

        #region Boolean
        private bool IsFreeToOpenProfile()
        {
            UserActions.CopyFromWithDoubleClick(IsFreeToOpenProfileTextPoint);
            return UserActions.GetClipboardTextSafe() == "Free ";
        }

        private bool IsEmailRequiredOnInvitation()
        {
            Clipboard.Clear();

            UserActions.CopyFromWithDoubleClick(EmailRequiredInInvitationBoxPoint);
            return !string.IsNullOrEmpty(UserActions.GetClipboardTextSafe());
        }

        private bool CurrentPositionIsOnBottom()
        {
            Clipboard.Clear();

            UserActions.CopyFromWithDoubleClick(CurrentRoleTextOnBottomPoint);
            return UserActions.GetClipboardTextSafe() == "Current ";
        }
        #endregion Boolean

        #region Click
        private void ClickOnMessageButton()
        {
            UserActions.ClickTo(MessageButtonPoint);

            Thread.Sleep(LongDelay);
        }

        private void ClickOnThreeDotsButton()
        {
            UserActions.ClickTo(ThreeDotsButtonPoint);
        }

        private void ClickOnConnectButton()
        {
            UserActions.ClickTo(ConnectSubItemPoint);
        }

        private void ClickSendInvitationButton(bool emailRequired)
        {
            UserActions.ClickTo(
                emailRequired
                    ? SendInvitationButtonWithEmailPoint
                    : SendInvitationButtonWithoutEmailPoint);
        }

        private void CopyLinkedinUrl()
        {
            Clipboard.Clear();

            ClickOnThreeDotsButton();
            UserActions.ClickTo(CopyLinkedinUrlBottomButtonPoint);

            // have to paste empty somehwere otherwise getting text of clipboard fails
            UserActions.PasteTo(CopyLinkedinUrlBottomButtonPoint);

            if (string.IsNullOrEmpty(UserActions.GetClipboardTextSafe()))
            {
                ClickOnThreeDotsButton();
                UserActions.ClickTo(CopyLinkedinUrlTopButtonPoint);
            }
        }

        private void ClickOnSendDirectMessageButton()
        {
            UserActions.ClickTo(SendDirectMessageButtonPoint);
        }
        #endregion Click

        #region Scroll
        private void ScrollUpInvitationText(bool emailRequired)
        {
            UserActions.ScrollUpAt(
                emailRequired
                    ? RecruiterNameFromEditableInvitationBoxWithEmailPoint
                    : RecruiterNameFromEditableInvitationBoxWithoutEmailPoint);
        }
        #endregion Scroll

        #region Copy
        private void CopyRecruiterNameFromInvitationBox(bool emailRequired)
        {
            UserActions.CopyFromWithDoubleClick(
                emailRequired
                    ? RecruiterNameFromStaticInvitationBoxWithEmailPoint
                    : RecruiterNameFromStaticInvitationBoxWithoutEmailPoint);
        }

        private void CopyRecruiterFirstNameFromBelowPicture()
        {
            UserActions.CopyFromWithDoubleClick(RecruiterNameFromBelowPicturePoint);
        }

        private void CopyRecruiterFullNameFromBelowPicture()
        {
            UserActions.CopyFromWithTripleClick(RecruiterNameFromBelowPicturePoint);
        }

        private void CopyHyperlinkFromBrowser()
        {
            UserActions.CopyFromWithSingleClick(BrowsersHyperlinkPoint);
        }

        private void CopyCompanyNameFromCurrentRoleText()
        {
            if (CurrentPositionIsOnBottom())
                UserActions.CopyFromWithTripleClick(RoleAtCompanyBottomTextPointScreen);
            else
                UserActions.CopyFromWithTripleClick(RoleAtCompanyTopTextPointScreen);

            Clipboard.SetText(GetCompanyNameFromRoleAtCompanyText(UserActions.GetClipboardTextSafe()));
        }

        private static string GetCompanyNameFromRoleAtCompanyText(string roleAtCompany)
        {
            string searchString = "at ";
            int index = roleAtCompany.IndexOf(searchString);

            return index == -1
                ? string.Empty
                : roleAtCompany.Substring(index + searchString.Length);
        }
        #endregion Copy

        #region Paste
        private void PasteInvitationContentToEditableInvitationBox(bool emailRequired)
        {
            UserActions.PasteTo(
                emailRequired
                    ? RecruiterNameFromEditableInvitationBoxWithEmailPoint
                    : RecruiterNameFromEditableInvitationBoxWithoutEmailPoint,
                InvitationContent);
        }

        private void PasteReplaceToRecruiterNameFromEditableInvitationBox(bool emailRequired)
        {
            UserActions.PasteReplaceTo(
                emailRequired
                    ? RecruiterNameFromEditableInvitationBoxWithEmailPoint
                    : RecruiterNameFromEditableInvitationBoxWithoutEmailPoint);
        }

        private void PasteEmailAddressToInvitationBox()
        {
            UserActions.PasteTo(EmailAddressInInvitationBoxPoint, EmailAddress);
        }

        private void PasteDirectMessageSubjectToDirectMessageSubject()
        {
            UserActions.PasteTo(DirectMessageSubjectPoint, DirectMessageSubject);
        }

        private void PasteDirectMessageToDirectMessageContent()
        {
            UserActions.PasteTo(RecruiterNameFromDirectMessageContentPoint, DirectMessageContent);
        }

        private void PasteReplaceToRecruiterNameFromDirectMessageContent()
        {
            UserActions.PasteReplaceTo(RecruiterNameFromDirectMessageContentPoint);
        }

        private void PasteToEndOfNotepad()
        {
            UserActions.PasteTo(EndOfNotepadPoint);
        }
        #endregion Paste
    }
}
