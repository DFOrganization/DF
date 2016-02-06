using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xfrog.Net;

namespace DF.Tryer.Tool.Helper
{
    public static class SendResquestHelper
    {
        /// <summary>
        /// 调用数据访问方法返回结果
        /// </summary>
        /// <param name="key">appkey</param>
        /// <param name="url">接口url</param>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        public static string GetApiResult(string key, string url, IDictionary<string, string> parameter)
        {
            var requestParameter = new Dictionary<string, string> { { "key", key }, { "dtype", "json" } };

            foreach (var item in parameter)
            {
                requestParameter.Add(item.Key, item.Value);
            }

            string result = Network.SendGet(url, requestParameter);

            JsonObject newObj = new JsonObject(result);
            string errorCode = newObj["error_code"].Value;

            // 失败
            if (errorCode != "0")
            {
                return newObj["error_code"].Value + ":" + newObj["reason"].Value;
            }
            return newObj.ToString();
        }
    }
}
