using DF.Tryer.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xfrog.Net;
using DF.Tryer.Tool.Extensions;
using System.Collections;
using DF.Tryer.Tool.Helper;

namespace DF.Tryer.Web.Areas.WebApi.Controllers
{
    public class NBAController : ApiController
    {
        private static string appkey = "JHAPIKey_NBA".GetAppSettingString();

        /// <summary>
        /// NBA常规赛赛程赛果
        /// </summary>
        /// <returns></returns>
        public string GetCombat()
        {
            string url = "http://op.juhe.cn/onebox/basketball/nba";

            var parameters = new Dictionary<string, string>();

            return SendResquestHelper.GetApiResult(appkey, url, parameters);
        }

        /// <summary>
        /// 球队赛程赛事查询
        /// </summary>
        /// <param name="TeamName">球队名称</param>
        /// <returns></returns>
        public string GetSchedule(string TeamName)
        {
            string url = "http://op.juhe.cn/onebox/basketball/team";

            var parameters = new Dictionary<string, string>();
            parameters.Add("team", TeamName); 

            return SendResquestHelper.GetApiResult(appkey, url, parameters);
        }

        /// <summary>
        /// 球队对战赛赛程查询
        /// </summary>
        /// <param name="HTeamName">主队球队名称</param>
        /// <param name="VTeamName">客队球队名称</param>
        /// <returns></returns>
        public string GetCombat(string HTeamName, string VTeamName)
        {
            string url = "http://op.juhe.cn/onebox/basketball/combat";

            var parameters = new Dictionary<string, string>();
            parameters.Add("hteam", HTeamName);
            parameters.Add("vteam", VTeamName);

            return SendResquestHelper.GetApiResult(appkey, url, parameters);
        }

    }
}