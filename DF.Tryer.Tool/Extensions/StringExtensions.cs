using DF.Tryer.Tool.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Tryer.Tool.Extensions
{
    /// <summary>
    /// String扩展类
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 获取对应的AppSetting
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetAppSettingString(this string input)
        {
            return ConfigHelper.GetAppConfig(input);
        }
    }
}
