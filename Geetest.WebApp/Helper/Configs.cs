using Microsoft.Extensions.Configuration;
using System;

namespace Geetest.WebApp.Helper
{
    public class Configs
    {
        public static IConfigurationRoot Configuration;

        /// <summary>
        /// 根据Key取Value值
        /// </summary>
        /// <param name="key"></param>
        public static string GetValue(string key)
        {
            return Configuration[key.Trim()].Trim();
        }
        /// <summary>
        /// 根据Key修改Value
        /// </summary>
        /// <param name="key">要修改的Key</param>
        /// <param name="value">要修改为的值</param>
        public static void SetValue(string key, string value)
        {
            Configuration[key.Trim()] = value.Trim();
        }
    }
}
