using Geetest.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geetest.WebApp.Helper
{
    public class GeetestHelper
    {

        private static readonly String publicKey = "publicKey";
        private static readonly String privateKey = "privateKey";
        private static GeetestLib geetest;
        private static GeetestLib Geetest
        {
            get
            {
                if (geetest == null)
                {
                    geetest = new GeetestLib(publicKey, privateKey);
                }
                return geetest;
            }
        }
        public static string GetCaptcha()
        {
            byte gtServerStatus = Geetest.preProcess();

            WebHelper.WriteSession(GeetestLib.gtServerStatusSessionKey, gtServerStatus.ToString());

            return Geetest.getResponseStr();
        }
        public static bool ValidateCapthca(HttpRequest request)
        {

            byte gt_server_status_code = byte.Parse(WebHelper.GetSession(GeetestLib.gtServerStatusSessionKey));

            int result = 0;
            string challenge = string.Empty;
            string validate = string.Empty;
            string seccode = string.Empty;

            if (request.Method.ToLower() == "post")
            {
                challenge = request.Form[GeetestLib.fnGeetestChallenge];
                validate = request.Form[GeetestLib.fnGeetestValidate];
                seccode = request.Form[GeetestLib.fnGeetestSeccode];
            }
            else
            {
                challenge = request.Query[GeetestLib.fnGeetestChallenge];
                validate = request.Query[GeetestLib.fnGeetestValidate];
                seccode = request.Query[GeetestLib.fnGeetestSeccode];
            }

            if (gt_server_status_code == 1)
            {
                result = Geetest.enhencedValidateRequest(challenge, validate, seccode);
            }
            else
            {
                result = Geetest.failbackValidateRequest(challenge, validate, seccode);
            }
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
