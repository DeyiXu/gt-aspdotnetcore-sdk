using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Geetest.WebApp.Helper
{
    public class WebHelper
    {
        /// <summary>
        /// 写Session
        /// </summary>
        /// <param name="key">Session的键名</param>
        /// <param name="value">Session的键值</param>
        public static void WriteSession(string key, string value)
        {
            if (key.Trim() == string.Empty)
                return;

            MyHttpContext.Current.Session.SetString(key, value);
        }

        /// <summary>
        /// 读取Session的值
        /// </summary>
        /// <param name="key">Session的键名</param>        
        public static string GetSession(string key)
        {
            key = key.Trim();
            if (key == string.Empty)
            {
                return string.Empty;
            }
            return MyHttpContext.Current.Session.GetString(key);
        }

        /// <summary>
        /// 删除指定Session
        /// </summary>
        /// <param name="key">Session的键名</param>
        public static void RemoveSession(string key)
        {
            key = key.Trim();
            if (key == string.Empty)
            {
                return;
            }
            MyHttpContext.Current.Session.Remove(key);
        }
    }
}
