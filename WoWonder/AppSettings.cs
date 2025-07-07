//Use DoughouzChecker last version 5.1 to
//build your own certifcate
//For Full Documention
//https://doughouzlight.com/?onepage-docs=wowonder-android
//CopyRight DoughouzLight
//For the accuracy of the icon and logo, please use this website " https://appicon.co/ " and add images according to size in folders " mipmap "

using Android.App;
using SocketIOClient.Transport;
using WoWonder.Helpers.Model;
using WoWonderClient;

namespace WoWonder
{
    internal static class AppSettings
    {
        /// <summary>
        /// Deep Links To App Content
        /// you should add your website without http in the analytic.xml file >> ../values/analytic.xml .. line 5
        /// <string name="ApplicationUrlWeb">demo.wowonder.com</string>
        /// </summary>
        public static readonly string TripleDesAppServiceProvider = "eGx2FbvjEo3j1y2N05FKYY57q/jGQGaAUfd7KZHeNcyxgkTlDoo2F7FCL4TLuvYQVgE9U6LmC2AaX9EwTTE4mgy8pNobgI4rM3X0GrSagsxZtfAYCOHf5w0UkwokGjbEVn/gKx6/ywOFFjxiuzdKyZ08P9WBQgOT0VgGds9ODCj8cdo6rEnT4u6z6ZgCsZaC3Aw7Yly/nD9cMDPyLFQQb7prHHLd4hot06uoetD8cTua0ZfHz+DapVYvdGEvWuFMJ6YqMImseMUG8IC8eX83UwA/+O/MqdhPq3Y8Y4HZRnQAfYaiGz38hphNUkO9gg4OQhzCsiAS6vqMpTmWar4SICb9+BxotvdOGF0L8kEdHRAVM27Rbdh3xeD9E1Pqx8sNqFb8Zmf6cbKgKea8FhFnhJ0/bZu8KrLqgiznsYyoZN2+G/CxMLGMmZJol5GS7dxq0FSb1KcQqFP1YVgSMRRooxak+slWaElSVSyuHD6QcI8CVWRmFE61vGHcttOvYUYM4Z8DmnvBOnXtHghuy5T17eQlrv3G+MukWnF+y6h9as9nVelHpl0jzF1XBnRX9mB72DEu962k9c8HyD92qSnTszVgo8QlYGxSzHayTkjzq93fuFiqjoO17J4NELjv5ENP/Ms3us5AhL3QK/Y64l4WMllx0YOpkthfTG5Atx+G7H2NVf1HepQgmXLWNP1o/ARM5VrehEB1u2cufIDefwGfxbFEb8c1KfTdOXIf1FJJP5mLPIbbo0N4mzjtP2hsBdCASBQLAFupQvYJSwl5LpLi5p0+KJLEm0aqQY9FjSMH9YxOdg+r3+pS5/18xSeb1U5Gy0F0RrpH/O4aQQ220HtGz+BtT1jkhRT3XrfOkWE/PIkyKmTS3zfXuZE45lsFWXu0YU1tc/8dX5Xk85XnGmJLMePXo8w7f2pRScJD0eZCwhpzE93W7V4Trre09xFiwoawDfqDlrxK0nTC4TeE/AdkMIjYM6CqUj8l/TmqxwjOaHDFH0DN794O+NNuZvCOyKCw+h4UHqtrPVk76+uTLeg6704MRM8otXwF929kp2qdc8+djeD4srra1QNBNUCqXzUhwsFF3i7qu+trXw9ZOtEFiLYRRS6ghOopjQKdDGj5UuONkFWiSBXPzDy+LdyivMIxTPtDnOqNWLY4JSpgjQ54rzV4s3uS9/iycEnC8SZ0a830mMSFH15+P45OP5l8mK/xLDK5MrHOo6FIFCbHAQ6xWa2f6yOMZ3mph3yGf1/q4P1yFpI4ZK0xy6EsN1ZRkATiRwWEV9O41SMufRls5y2QvcmIK+NDC4tZML//9Ew8gX3r6m6nn5N28AhKu/b2JONEgi9j8xaZtIY3IWlA5GzOkkLmbC8rBiAaIbG0wdUwpGBor0B8y/bE1Ub9cs79FO+ceQyCEqJFgpiS8kcE/dKY8+NSmMcXGb9u4XZ+0eWkg8pOTVa4lN1uRGv0mjQ/uF3CzZozP8qJFclVOVAA3BchIGaIuGL17vkvN6aeo2UaLqBHkHkOCkMgcOdlBp5J38EUu1RIHRjSQsp6cmZItPryJmulz4JjtTuG7QJxscqvHcMdi4xQaGqkZfcE+HJ38NqTiJE8wjXjaZWFwwwO/59Jjw==";

        //Main Settings >>>>>
        //*********************************************************
        public static string Version = "5.5";
        public static readonly string ApplicationName = "Zuitch App";
        public static readonly string DatabaseName = "WoWonderMessenger";

        // Friend system = 0 , follow system = 1
        public static readonly int ConnectivitySystem = 1;

        public static readonly InitializeWoWonder.ConnectionType ConnectionTypeChat = InitializeWoWonder.ConnectionType.RestApi;
        public static readonly string PortSocketServer = "3000";
        public static readonly TransportProtocol Transport = TransportProtocol.WebSocket;

        //Main Colors >>
        //*********************************************************
        public static readonly string MainColor = Application.Context.GetText(Resource.Color.accent);
        public static readonly string StoryReadColor = "#235777";

        //Language Settings >> http://www.lingoes.net/en/translator/langcode.htm
        //*********************************************************
        public static bool FlowDirectionRightToLeft = false;
        public static string Lang = ""; //Default language ar_AE

        //Set Language User on site from phone
        public static readonly bool SetLangUser = true;

        //Notification Settings >>
        //*********************************************************
        public static bool ShowNotification = true;
        public static string OneSignalAppId = "cd6e8711-2790-40c8-90a2-4e9f902509bf";

        //Error Report Mode
        //*********************************************************
        public static readonly bool SetApisReportMode = false;

        //Code Time Zone (true => Get from Internet , false => Get From #CodeTimeZone )
        //*********************************************************
        public static readonly bool AutoCodeTimeZone = true;
        public static readonly string CodeTimeZone = "UTC";

        public static readonly bool EnableRegisterSystem = true;

        //Set Theme Full Screen App
        //*********************************************************
        public static readonly bool EnableFullScreenApp = true;

        public static readonly bool ShowSettingsUpdateManagerApp = true;

        public static readonly bool ShowSettingsRateApp = true;
        public static readonly int ShowRateAppCount = 5;

        //AdMob >> Please add the code ad in the Here and analytic.xml
        //*********************************************************
        public static readonly ShowAds ShowAds = ShowAds.AllUsers;

        public static readonly bool RewardedAdvertisingSystem = true;

        //Three times after entering the ad is displayed
        public static readonly int ShowAdInterstitialCount = 5;
        public static readonly int ShowAdRewardedVideoCount = 5;
        public static int ShowAdNativeCount = 14;
        public static readonly int ShowAdAppOpenCount = 3;

        public static readonly bool ShowAdMobBanner = false;
        public static readonly bool ShowAdMobInterstitial = false;
        public static readonly bool ShowAdMobRewardVideo = false;
        public static readonly bool ShowAdMobNative = false;
        public static readonly bool ShowAdMobAppOpen = false;
        public static readonly bool ShowAdMobRewardedInterstitial = false;

        public static readonly string AdInterstitialKey = "ca-app-pub-5135691635931982/3442638218";
        public static readonly string AdRewardVideoKey = "ca-app-pub-5135691635931982/3814173301";
        public static readonly string AdAdMobNativeKey = "ca-app-pub-5135691635931982/9452678647";
        public static readonly string AdAdMobAppOpenKey = "ca-app-pub-5135691635931982/3836425196";
        public static readonly string AdRewardedInterstitialKey = "ca-app-pub-5135691635931982/7476900652";

        //FaceBook Ads >> Please add the code ad in the Here and analytic.xml
        //*********************************************************
        public static readonly bool ShowFbBannerAds = false;
        public static readonly bool ShowFbInterstitialAds = false;
        public static readonly bool ShowFbRewardVideoAds = false;
        public static readonly bool ShowFbNativeAds = false;

        public static readonly string AdsFbBannerKey = "250485588986218_554026418632132";
        public static readonly string AdsFbInterstitialKey = "250485588986218_554026125298828";
        public static readonly string AdsFbRewardVideoKey = "250485588986218_554072818627492";
        public static readonly string AdsFbNativeKey = "250485588986218_554706301897477";

        //Ads AppLovin >> Please add the code ad in the Here
        //*********************************************************
        public static readonly bool ShowAppLovinBannerAds = false;
        public static readonly bool ShowAppLovinInterstitialAds = false;
        public static readonly bool ShowAppLovinRewardAds = false;

        public static string AdsAppLovinBannerId = "27de87b390bb5884";
        public static string AdsAppLovinInterstitialId = "7af32ee3997a12d7";
        public static string AdsAppLovinRewardedId = "99d027a690382f70";
        //*********************************************************

        //Social Logins >>
        //If you want login with facebook or google you should change id key in the analytic.xml file or AndroidManifest.xml
        //Facebook >> ../values/analytic.xml ..
        //Google >> ../Properties/AndroidManifest.xml .. line 37
        //*********************************************************
        public static readonly bool EnableSmartLockForPasswords = false;

        public static readonly bool ShowFacebookLogin = false;
        public static readonly bool ShowGoogleLogin = true;

        public static readonly string ClientId = "486221582328-9f88tnv658a6uflhijlhsp6bu2aecb1g.apps.googleusercontent.com";

        //Chat Window Activity >>
        //*********************************************************
        //if you want this feature enabled go to Properties -> AndroidManefist.xml and remove comments from below code
        //Just replace it with this 5 lines of code
        /*
         <uses-permission android:name="android.permission.READ_CONTACTS" />
         <uses-permission android:name="android.permission.READ_PHONE_NUMBERS" />
         */
        public static readonly bool ShowButtonContact = true;
        public static readonly bool InvitationSystem = true;  //Invite friends section
        /////////////////////////////////////

        public static readonly ChatTheme ChatTheme = ChatTheme.Tokyo;

        public static readonly bool ShowButtonCamera = true;
        public static readonly bool ShowButtonImage = true;
        public static readonly bool ShowButtonVideo = true;
        public static readonly bool ShowButtonAttachFile = true;
        public static readonly bool ShowButtonColor = true;
        public static readonly bool ShowButtonStickers = true;
        public static readonly bool ShowButtonMusic = true;
        public static readonly bool ShowButtonGif = true;
        public static readonly bool ShowButtonLocation = true;

        public static readonly bool OpenVideoFromApp = true;
        public static readonly bool OpenImageFromApp = true;


        public static readonly bool ShowQrCodeSystem = true;
        public static readonly bool ShowSearchForMessage = true;


        //Record Sound Style & Text
        public static readonly bool ShowButtonRecordSound = true;

        // Options List Message
        public static readonly bool EnableReplyMessageSystem = true;
        public static readonly bool EnableForwardMessageSystem = true;
        public static readonly bool EnableFavoriteMessageSystem = true;
        public static readonly bool EnablePinMessageSystem = true;
        public static readonly bool EnableReactionMessageSystem = true;

        public static readonly bool ShowNotificationWithUpload = true;

        public static readonly bool AllowDownloadMedia = true;
        public static readonly bool EnableFitchOgLink = true;

        public static readonly bool EnableSuggestionMessage = true;

        /// <summary>
        /// https://dashboard.stipop.io/
        /// you can get api key from here https://prnt.sc/26ofmq9
        /// </summary>
        public static readonly string StickersApikey = "950a22e795ca1f047842854e3305a5df";

        //List Chat >>
        //*********************************************************
        public static readonly bool EnableChatPage = false; //>> Next update
        public static readonly bool EnableChatGroup = true;

        public static readonly bool EnableBroadcast = true;

        public static readonly bool EnableChatGpt = true; //New

        // Options List Chat
        public static readonly bool EnableChatArchive = true;
        public static readonly bool EnableChatPin = true;
        public static readonly bool EnableChatMute = true;
        public static readonly bool EnableChatMakeAsRead = true;

        // Story >>
        //*********************************************************
        //Set a story duration >> Sec
        public static readonly long StoryImageDuration = 7;
        public static readonly long StoryVideoDuration = 30;

        /// <summary>
        /// If it is false, it will appear only for the specified time in the value of the StoryVideoDuration
        /// </summary>
        public static readonly bool ShowFullVideo = false;

        public static readonly bool EnableStorySeenList = true;
        public static readonly bool EnableReplyStory = true;

        /// <summary>
        /// you can edit video using FFMPEG
        /// </summary>
        public static readonly bool EnableVideoEditor = true;
        public static readonly bool EnableVideoCompress = false;

        public static readonly bool EnableImageEditor = true; //#New

        /// <summary>
        /// https://developer.deepar.ai/
        /// you can get api key from here https://prnt.sc/b4MBmwlx-6Bx
        /// </summary>
        public static readonly string DeepArKey = "e04529938c873ebfec901d15509f088464330b3bc31d8e5b5ad22e8bde53dffb22a147d2c00d7e65"; //#New

        //*********************************************************
        /// <summary>
        ///  Currency
        /// CurrencyStatic = true : get currency from app not api
        /// CurrencyStatic = false : get currency from api (default)
        /// </summary>
        public static readonly bool CurrencyStatic = false;
        public static readonly string CurrencyIconStatic = "$";
        public static readonly string CurrencyCodeStatic = "USD";

        // Video/Audio Call Settings >>
        //*********************************************************
        public static readonly EnableCall EnableCall = EnableCall.AudioAndVideo;
        public static readonly SystemCall UseLibrary = SystemCall.Agora;

        // Walkthrough Settings >>
        //*********************************************************
        public static readonly bool ShowWalkTroutPage = true;

        // Register Settings >>
        //*********************************************************
        public static readonly bool ShowGenderOnRegister = true;

        //Last Messages Page >>
        //*********************************************************
        public static readonly bool ShowOnlineOfflineMessage = true;

        public static readonly int RefreshAppAPiSeconds = 3500; // 3 Seconds
        public static readonly int MessageRequestSpeed = 4000; // 4 Seconds

        public static readonly ToastTheme ToastTheme = ToastTheme.Default;
        public static readonly ColorMessageTheme ColorMessageTheme = ColorMessageTheme.Default;

        //Bypass Web Errors
        //*********************************************************
        public static readonly bool TurnTrustFailureOnWebException = true;
        public static readonly bool TurnSecurityProtocolType3072On = true;

        public static readonly bool ShowTextWithSpace = false;

        public static TabTheme SetTabDarkTheme = TabTheme.Light;

        public static readonly bool ShowSuggestedUsersOnRegister = true;

        //Settings Page >> General Account
        public static readonly bool ShowSettingsAccount = true;
        public static readonly bool ShowSettingsPassword = true;
        public static readonly bool ShowSettingsBlockedUsers = true;
        public static readonly bool ShowSettingsDeleteAccount = true;
        public static readonly bool ShowSettingsTwoFactor = true;
        public static readonly bool ShowSettingsManageSessions = true;
        public static readonly bool ShowSettingsWallpaper = true;
        public static readonly bool ShowSettingsFingerprintLock = true;

        //Options chat heads (Bubbles)
        //*********************************************************
        public static readonly bool ShowChatHeads = false;

        //Always , Hide , FullScreen
        public static readonly string DisplayModeSettings = "Always";

        //Default , Left  , Right , Nearest , Fix , Thrown
        public static readonly string MoveDirectionSettings = "Right";

        //Circle , Rectangle
        public static readonly string ShapeSettings = "Circle";

        // Last position
        public static readonly bool IsUseLastPosition = true;

        public static readonly int AvatarPostSize = 60;
        public static readonly int ImagePostSize = 200;
    }
}