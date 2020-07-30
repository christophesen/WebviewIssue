
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace WebViewApp.Droid
{
    [Activity(Label = "WebViewActivity")]
    public class WebViewActivity : Activity
    {
        string _html = "https://www.axabank.be/mobilebanking/current-accounts/s2b-c2b-conversion?sc_lang=nl";
        private WebView webView = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Window.SetFlags(WindowManagerFlags.HardwareAccelerated, WindowManagerFlags.HardwareAccelerated);

            SetContentView(Resource.Layout.webview_activity);

            // Get our button from the layout resource,
            // and attach an event to it
            webView = FindViewById<WebView>(Resource.Id.webview);

            LoadWebView();
        }

        public override View OnCreateView(string name, Context context, IAttributeSet attrs)
        {
            return base.OnCreateView(name, context, attrs);


        }

        void LoadWebView()
        {
            webView.SetLayerType(LayerType.Hardware, null);
            webView.LoadUrl(_html);

            //webView.LoadData(_html, "text/html", "utf-8");
        }

        protected override void OnDestroy()
        {
            webView.ClearCache(true);
            webView.ClearHistory();

            base.OnDestroy();
        }
    }
}
