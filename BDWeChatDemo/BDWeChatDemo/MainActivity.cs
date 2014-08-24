using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Tencent.MM.Sdk.Openapi;


///Author Huiqing
namespace net.sourceforge.simcpux
{
    [Activity(Label = "BDWeChatDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static IWXAPI wxApi;
        public static readonly string APP_ID = "wxd930ea5d5a258f4f";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //官方demo的app_id，如使用请用本项目中的debug.keystore!!!可简单的覆盖Xamarin.Android的原有debug.keystore
            //强烈建议使用自建的微信app_id和keystore，注意包名等细节，确保可正常调起，如何创建请百度
            wxApi = WXAPIFactory.CreateWXAPI(this,  APP_ID, true);
            wxApi.RegisterApp(APP_ID);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += delegate { wxapi.WXUtil.sendWxReq(this, "http://www.qmyd360.com", "Xamarin.Android Wechat Binding","Hello Xmarin", null, 1); };

            Button button1 = FindViewById<Button>(Resource.Id.MyButton1);
            button1.Click += delegate { wxapi.WXUtil.sendWxReq(this, "http://www.qmyd360.com", "Xamarin.Android Wechat Binding", "Hello Xmarin", null, 0); };

            Button button2 = FindViewById<Button>(Resource.Id.MyButton2);
            button2.Click += delegate { wxApi.OpenWXApp(); };
        }
    }
}

