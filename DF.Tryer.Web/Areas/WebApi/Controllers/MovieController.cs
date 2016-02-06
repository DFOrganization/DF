using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DF.Tryer.Tool.Extensions;
using DF.Tryer.Tool.Helper;

namespace DF.Tryer.Web.Areas.WebApi.Controllers
{
    public class MovieController : ApiController
    {
        private static string appkey = "JHAPIKey_Movie".GetAppSettingString();

        /// <summary>
        /// 电影搜索
        /// </summary>
        /// <param name="MovieName">电影名称</param>
        /// <returns></returns>
        public string GetMovie(string MovieName)
        {
            string url = "http://op.juhe.cn/onebox/movie/video";

            var parameters = new Dictionary<string, string>();
            parameters.Add("q", MovieName);

            return SendResquestHelper.GetApiResult(appkey, url, parameters);
        }

        /// <summary>
        /// 最近影讯
        /// </summary>
        /// <param name="CityName">城市名称</param>
        /// <returns></returns>
        public string GetFilmNews(string CityName)
        {
            string url = "http://op.juhe.cn/onebox/movie/pmovie";

            var parameters = new Dictionary<string, string>();
            parameters.Add("city", CityName);

            return SendResquestHelper.GetApiResult(appkey, url, parameters);
        }
    }
}
