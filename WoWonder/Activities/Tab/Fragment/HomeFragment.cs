using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Util;
using System;
using System.Reflection;
using WoWonder.Helpers.Model;

namespace WoWonder.Activities.Tab.Fragment
{
    public class HomeFragment : AndroidX.Fragment.App.Fragment
    {
        private const string LogTag = "ZUITCH_APP";
        private const string BaseUrl = "https://zuitch.com/";
        private WebView _web;

        public override View OnCreateView(LayoutInflater inflater,
                                          ViewGroup container,
                                          Bundle savedInstanceState)
        {
            var root = inflater.Inflate(Resource.Layout.fragment_home, container, false);
            _web = root.FindViewById<WebView>(Resource.Id.web_home);

            DumpUserDetails();   // valores en Output y Logcat
            InitWebView();       // autocookie + carga del sitio

            return root;
        }

        /* ---------- Helpers ---------- */

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

        private void InitWebView()
        {
            var st = _web.Settings;
            st.JavaScriptEnabled = true;
            st.DomStorageEnabled = true;

            // Mantener toda la navegación dentro del WebView
            _web.SetWebViewClient(new InsideClient());

            // Si disponemos de token ⇒ llamar al endpoint que crea la cookie
            if (!string.IsNullOrWhiteSpace(UserDetails.AccessToken))
            {
                var cookieUrl =
                    $"{BaseUrl}api/set-browser-cookie" +
                    $"?url_redirect={Uri.EscapeDataString(BaseUrl)}" +
                    $"&access_token={UserDetails.AccessToken}";

                Log.Info(LogTag, $"LoadUrl → {cookieUrl}");
                _web.LoadUrl(cookieUrl);
            }
            else
            {
                // Sin token: simplemente abre la página y mostrará login
                _web.LoadUrl(BaseUrl);
            }
        }

        /* ---------- WebViewClient mínimo ---------- */

        private class InsideClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view,
                                                          IWebResourceRequest request) => false;

            public override bool ShouldOverrideUrlLoading(WebView view,
                                                          string url) => false;
        }
    }
}
