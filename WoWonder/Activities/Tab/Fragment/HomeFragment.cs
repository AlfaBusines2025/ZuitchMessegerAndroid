using Android.OS;
using Android.Views;
using Android.Webkit;
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

            DumpUserDetails();   // imprime todas las variables
            InitWebView();       // configura y carga la página

            return root;
        }

        /* ---------- helpers ---------- */

        private void DumpUserDetails()
        {
            foreach (var f in typeof(UserDetails)
                     .GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var v = f.GetValue(null) ?? "null";
                Android.Util.Log.Info(LogTag, $"{f.Name} = {v}");
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

            _web.LoadUrl(BaseUrl);
        }

        /* ---------- WebViewClient mínimo ---------- */

        private class InsideClient : WebViewClient
        {
            // Para Android ≥ API-24
            public override bool ShouldOverrideUrlLoading(WebView view,
                                                          IWebResourceRequest request)
                => false;    // siempre cargar en el WebView

            // Para Android < API-24
            public override bool ShouldOverrideUrlLoading(WebView view,
                                                          string url)
                => false;
        }
    }
}
