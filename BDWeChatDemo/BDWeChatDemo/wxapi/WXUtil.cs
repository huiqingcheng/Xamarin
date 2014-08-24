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
using Android.Graphics;
using Com.Tencent.MM.Sdk.Openapi;
using net.sourceforge.simcpux;

///Author Huiqing
namespace net.sourceforge.simcpux.wxapi
{
    public class WXUtil
    {
        public static readonly int VERSION_TIMELINE = 0x21020001;
        public static bool IsTimeLineSupported()
        {
            return MainActivity.wxApi.IsWXAppSupportAPI;
        }

        public static bool IsWXSupported()
        {
            return MainActivity.wxApi.IsWXAppInstalled
                    && MainActivity.wxApi.IsWXAppSupportAPI;
        }

        public static void sendWxReq(Context ctx, String targetUrl, String desp,
                String title, Bitmap bmp, int type)
        {
            if (!IsWXSupported())
            {
                Toast.MakeText(ctx, "wx DON'T SUPPORT",
                        ToastLength.Long).Show();
                return;
            }
            SendWXReqInner(targetUrl, title, desp, bmp, type);
        }

        private static void SendWXReqInner(String url, String title,
                String contentmsg, Bitmap bmp, int type)
        {
            SendMessageToWX.Req req;
            WXWebpageObject textObj = new WXWebpageObject();
            textObj.WebpageUrl = url;
            WXMediaMessage msg = new WXMediaMessage();
            msg.Title = title;
            msg.Description = contentmsg;

            if (bmp != null)
            {
                bmp = Bitmap.CreateScaledBitmap(bmp, 50, 50, true);
            }

            msg.mediaObject = textObj;
            req = new SendMessageToWX.Req();
            req.Transaction = BuildTransaction("webpage");
            req.Message = msg;
            if(type==1)
            {
                req.Scene = SendMessageToWX.Req.WXSceneSession;
            }
            else
            {
                if(type==0)
                {
                    req.Scene = SendMessageToWX.Req.WXSceneTimeline;
                }
            }
            bool res = MainActivity.wxApi.SendReq(req);
        }

        private static String BuildTransaction(String type)
        {
            return (type == null) ? DateTime.Now.ToLongTimeString()
                    : type + DateTime.Now.ToLongTimeString();
        }

    }
}