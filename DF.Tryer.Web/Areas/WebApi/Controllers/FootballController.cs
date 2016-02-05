using DF.Tryer.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xfrog.Net;

namespace DF.Tryer.Web.Areas.WebApi.Controllers
{
    public class FootballController : ApiController
    {
        private static string appkey = "8dcd003148e04c22e025e9bbf8c6c886";

        /// <summary>
        /// 足球联赛赛事查询
        /// </summary>
        /// <param name="LeagueName">联赛名称</param>
        /// <returns></returns>
        public string GetLeague(string LeagueName)
        {
            string url = "http://op.juhe.cn/onebox/football/league";

            var parameters = new Dictionary<string, string>();

            parameters.Add("key", appkey);
            parameters.Add("dtype", "");
            parameters.Add("league", LeagueName);

            string result = Network.SendGet(url, parameters);

            JsonObject newObj = new JsonObject(result);
            string errorCode = newObj["error_code"].Value;

            // 失败
            if (errorCode != "0")
            {
                return newObj["error_code"].Value + ":" + newObj["reason"].Value;
            }
            return newObj["result"].ToString();
        }

        /// <summary>
        /// 球队赛程查询
        /// </summary>
        /// <param name="TeamName">球队名称</param>
        /// <returns></returns>
        public string GetSchedule(string TeamName)
        {
            string url = "http://op.juhe.cn/onebox/football/team";

            var parameters = new Dictionary<string, string>();

            parameters.Add("key", appkey);//你申请的key
            parameters.Add("dtype", ""); //返回数据的格式,xml或json，默认json
            parameters.Add("team", TeamName); //球队名称

            string result = Network.SendGet(url, parameters);

            JsonObject newObj = new JsonObject(result);
            string errorCode = newObj["error_code"].Value;

            // 失败
            if (errorCode != "0")
            {
                return newObj["error_code"].Value + ":" + newObj["reason"].Value;
            }
            return newObj["result"].ToString();
        }

        /// <summary>
        /// 球队对战赛赛程查询
        /// </summary>
        /// <param name="HTeamName">主队球队名称</param>
        /// <param name="VTeamName">客队球队名称</param>
        /// <returns></returns>
        public string GetCombat(string HTeamName, string VTeamName)
        {
            string url = "http://op.juhe.cn/onebox/football/combat";

            var parameters = new Dictionary<string, string>();

            parameters.Add("key", appkey);
            parameters.Add("dtype", "");
            parameters.Add("hteam", HTeamName);
            parameters.Add("vteam", VTeamName);

            string result = Network.SendGet(url, parameters);

            JsonObject newObj = new JsonObject(result);
            string errorCode = newObj["error_code"].Value;

            // 失败
            if (errorCode != "0")
            {
                return newObj["error_code"].Value + ":" + newObj["reason"].Value;
            }
            return newObj["result"].ToString();
        }
    }
}

