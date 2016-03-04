using System.Collections.Generic;
using System.Web.Script.Serialization;
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

        /// <summary>
        /// 调用数据访问方法返回结果
        /// (Newtonsoft 转义问题未解决)
        /// </summary>
        /// <param name="key">appkey</param>
        /// <param name="url">接口url</param>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        public static string GetApiResult2(string key, string url, IDictionary<string, string> parameter)
        {
            var requestParameter = new Dictionary<string, string> { { "key", key }, { "dtype", "json" } };

            foreach (var item in parameter)
            {
                requestParameter.Add(item.Key, item.Value);
            }

            var result = Network.SendGet(url, requestParameter);
            var jobject = new JavaScriptSerializer().Deserialize<dynamic>(result);

            var errorCode = jobject["error_code"].ToString();

            // 失败
            if (errorCode != "0")
            {
                return jobject["error_code"].ToString() + ":" + jobject["reason"].ToString();
            }
            return result;
        }
    }
}
