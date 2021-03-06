﻿using DF.Tryer.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xfrog.Net;
using DF.Tryer.Tool.Extensions;
using DF.Tryer.Tool.Helper;

namespace DF.Tryer.Web.Areas.WebApi.Controllers
{
    public class FootballController : ApiController
    {
        private static string appkey = "JHAPIKey_Football".GetAppSettingString();

        /// <summary>
        /// 足球联赛赛事查询
        /// </summary>
        /// <param name="LeagueName">联赛名称</param>
        /// <returns></returns>
        public string GetLeague(string LeagueName)
        {
            string url = "http://op.juhe.cn/onebox/football/league";

            var parameters = new Dictionary<string, string>();
            parameters.Add("league", LeagueName);

            return SendResquestHelper.GetApiResult(appkey, url, parameters);
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
            string url = "http://op.juhe.cn/onebox/football/combat";

            var parameters = new Dictionary<string, string>();
            parameters.Add("hteam", HTeamName);
            parameters.Add("vteam", VTeamName);

            return SendResquestHelper.GetApiResult(appkey, url, parameters);
        }
    }
}

