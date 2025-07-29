using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Webkit;
using Java.Interop;
using WoWonder.Activities.Tab.Fragment; // Asegúrate de importar tu fragmento

namespace WoWonder.Activities.Tab.Fragment
{
    public class WebAppInterface : Java.Lang.Object
    {
        private readonly HomeFragment host;

        public WebAppInterface(HomeFragment fragment)
        {
            host = fragment;
        }

        [JavascriptInterface]
        [Export("reloadWebView")]
        public void ReloadWebView()
        {
            host.Activity.RunOnUiThread(() =>
            {
                host.InitWebView();  // Esto recargará la página desde el código nativo
            });
        }
    }
}
