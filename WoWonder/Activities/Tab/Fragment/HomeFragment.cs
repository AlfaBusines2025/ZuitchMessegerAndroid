using Android;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Util;
using System;
using System.Linq;
using System.Reflection;
using WoWonder.Helpers.Model;
using AndroidX.Core.Content;
using AndroidX.Core.App;

namespace WoWonder.Activities.Tab.Fragment
{
    public class HomeFragment : AndroidX.Fragment.App.Fragment
    {
        private const string LogTag = "ZUITCH_APP";
        private const string BaseUrl = "https://zuitch.com/";

        private WebView _web;
        private PermissionRequest _pendingWebRequest;        // ← petición WebRTC en espera
        private const int MediaReqCode = 4001;
        private static readonly string[] MediaPerms =
        {
            Manifest.Permission.Camera,
            Manifest.Permission.RecordAudio
        };

        // ──────────────────────────────────────────────────────────────
        public override View OnCreateView(LayoutInflater inflater,
                                          ViewGroup container,
                                          Bundle savedInstanceState)
        {
            var root = inflater.Inflate(Resource.Layout.fragment_home, container, false);
            _web = root.FindViewById<WebView>(Resource.Id.web_home);

            DumpUserDetails();            // log variables
            AskMediaPermsIfNeeded();      // solicitar permisos (si falta alguno)
            InitWebView();                // configurar y cargar

            return root;
        }

        /* ---------- permisos ---------- */

        private bool HasMediaPerms() =>
            MediaPerms.All(p => ContextCompat.CheckSelfPermission(RequireContext(), p)
                                == Permission.Granted);

        private void AskMediaPermsIfNeeded()
        {
            if (!HasMediaPerms())
                RequestPermissions(MediaPerms, MediaReqCode);
        }

        public override void OnRequestPermissionsResult(int requestCode,
                                                        string[] permissions,
                                                        Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == MediaReqCode && HasMediaPerms() && _pendingWebRequest != null)
            {
                // el usuario aceptó ⇒ concedemos al WebView
                _pendingWebRequest.Grant(_pendingWebRequest.GetResources());
                _pendingWebRequest = null;
            }
        }

        /* ---------- WebView ---------- */

        public void InitWebView()
        {
            var st = _web.Settings;
            st.JavaScriptEnabled = true;
            st.DomStorageEnabled = true;
            _web.AddJavascriptInterface(new WebAppInterface(this), "AndroidInterface");  // ← Aquí

            _web.SetWebViewClient(new InsideClient());
            _web.SetWebChromeClient(new MediaChrome(this));

            string startUrl = !string.IsNullOrWhiteSpace(UserDetails.AccessToken)
                ? $"{BaseUrl}api/set-browser-cookie?url_redirect={Uri.EscapeDataString(BaseUrl)}&access_token={UserDetails.AccessToken}"
                : BaseUrl;

            Log.Info(LogTag, $"LoadUrl → {startUrl}");
            _web.LoadUrl(startUrl);          

        }

        private class InsideClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view,
                                                          IWebResourceRequest request) => false;
            public override bool ShouldOverrideUrlLoading(WebView view,
                                                          string url) => false;
            public override void OnReceivedError(WebView view, IWebResourceRequest request, WebResourceError error)
            {
                if (request.IsForMainFrame)
                {
                    ShowCustomErrorPage(view);
                }
            }

            public override void OnReceivedHttpError(WebView view, IWebResourceRequest request, WebResourceResponse errorResponse)
            {
                if (request.IsForMainFrame)
                {
                    ShowCustomErrorPage(view);
                }
            }

            private void ShowCustomErrorPage(WebView view)
            {
                string htmlData = @"
            <html>
                <head>
                    <style>
                        body { 
                            background-color: #f5f5f5; 
                            display: flex; 
                            justify-content: center; 
                            align-items: center; 
                            height: 100vh; 
                            flex-direction: column;
                            font-family: sans-serif;
                        }
                        img {
                            width: 120px;
                            margin-bottom: 20px;
                        }
                button {
                        display: flex;
                        align-items: center;
                        gap: 10px;
                        padding: 12px 24px;
                        font-size: 16px;
                        font-weight: bold;
                        background-color: #72b0be;
                        color: white;
                        border: none;
                        border-radius: 8px;
                        cursor: pointer;
                        box-shadow: 0px 4px 8px rgba(0,0,0,0.2);
                        transition: background-color 0.3s ease;
                    }
                        h2 {
                            color: #555;
                        }
                    </style>
                </head>
                <body>
                    <img src='file:///android_asset/zuitch_logo.png' />
                    <button onclick='AndroidInterface.reloadWebView()'>Recargar</button>
                </body>
            </html>";

                view.LoadDataWithBaseURL(null, htmlData, "text/html", "UTF-8", null);
            }

        }




        private class MediaChrome : WebChromeClient
        {
            private readonly HomeFragment host;
            public MediaChrome(HomeFragment h) => host = h;

            public override void OnPermissionRequest(PermissionRequest request)
            {
                // Si ya hay permisos del sistema, concedemos de inmediato
                if (host.HasMediaPerms())
                {
                    request.Grant(request.GetResources());
                }
                else
                {
                    // Guardamos la petición y pedimos permisos al usuario
                    host._pendingWebRequest = request;
                    host.AskMediaPermsIfNeeded();
                }
            }
        }

        /* ---------- util ---------- */

        private void DumpUserDetails()
        {
            foreach (var f in typeof(UserDetails)
                     .GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var v = f.GetValue(null) ?? "null";
                Log.Info(LogTag, $"{f.Name} = {v}");
                System.Diagnostics.Debug.WriteLine($"{LogTag}: {f.Name} = {v}");
            }
        }
    }
}
