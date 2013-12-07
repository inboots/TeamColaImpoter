using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCola
{
    public class ColaContentUtil
    {
        /// <summary>
        /// 构造发起的POST DATA BODY
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="team">Team编号</param>
        /// <param name="labels">Label描述</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        public static string GetPostData(string content, string team, string labels, long start, long end)
        {
            string data = "{\"content\":\"" + System.Web.HttpUtility.UrlEncode(content) + "\",\"team\":\"" + team + "\",\"labels\":[\"" + labels + "\"],\"start\":" + start + ",\"end\":" + end + "}";
            string all = "timezone=8&data=" + data;
            return all;
        }
    }
}
