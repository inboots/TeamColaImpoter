using System;
using System.Collections.Generic;
using System.Text;

namespace TeamCola
{
    public class Cola
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public object Login(string user, string pwd)
        {
            object cookieCredits = null;
            Http.WebClient wc = new Http.WebClient();
            try
            {
                string s = wc.Post(API.API_LOGIN, "timezone=8&data=%7B%22username%22%3A%22"+System.Web.HttpUtility.UrlEncode(user)+"%22%2C%22password%22%3A%22"+System.Web.HttpUtility.UrlEncode(pwd)+"%22%7D");
                if (s.Contains("success") && s.Contains("true"))
                {
                    cookieCredits = wc.CookieContainer;
                }
            }
            catch
            {
                
            }

            return cookieCredits;

        }

        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="contentBody">内容正文</param>
        /// <param name="Cookieredits">登陆凭据</param>
        /// <returns></returns>
        public string Post(string contentBody, object Cookieredits)
        {
            Http.WebClient wc = new Http.WebClient();
            wc.CookieContainer = (System.Net.CookieContainer)Cookieredits;
            string result = string.Empty;
            try
            {
                result = wc.Post(API.API_POST, contentBody);
            }
            catch
            {

            }
            return result;
        }
    }
}
