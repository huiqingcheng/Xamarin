using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Tencent.MM.Sdk.Openapi;



namespace net.sourceforge.simcpux.wxapi
{
    /// <summary>
    /// 微信接入类
    /// </summary>
    [Activity(Label = "WXEntryActivity", Exported = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop)]
    public class WXEntryActivity : Activity, IWXAPIEventHandler
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            MainActivity.wxApi.HandleIntent(Intent, this);
            // Create your application here
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            Intent = intent;
            MainActivity.wxApi.HandleIntent(Intent, this);
        }

        /// <summary>
        ///  接受微信发来的消息
        /// </summary>
        /// <param name="p0"></param>
        public void OnReq(BaseReq p0)
        {
            switch (p0.Type)
            {
                default:
                    break;
            }
        }

        /// <summary>
        /// 接受发往微信的消息的回调
        /// </summary>
        /// <param name="p0"></param>
        public void OnResp(BaseResp p0)
        {
            int result = 0;
            switch (p0.errCode)
            {
                case BaseResp.ErrCode.ErrOk:
                    break;
                case BaseResp.ErrCode.ErrSentFailed:
                    break;
                case BaseResp.ErrCode.ErrAuthDenied:
                    break;
                default:
                    break;
            }
        }
    }
}