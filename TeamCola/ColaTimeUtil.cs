﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeamCola
{
   public  class ColaTimeUtil
    {
       /// <summary>
       /// Unix时间转换为Datetime
       /// </summary>
       /// <param name="d"></param>
       /// <returns></returns>
        public static System.DateTime ConvertIntDateTime(double d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(d);
            return time;
        }

       /// <summary>
       /// 转换为PHP中使用的Unix时间
       /// </summary>
       /// <param name="dt"></param>
       /// <returns></returns>
        public static long ToColaDatetime(DateTime dt)
        {
            double t = ConvertDateTimeInt(dt);
            return ((long)(t * 1000));

        }


       /// <summary>
       /// 将时间转换为Unix时间
       /// </summary>
       /// <param name="time"></param>
       /// <returns></returns>
        public static double ConvertDateTimeInt(System.DateTime time)
        {
            double intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (time - startTime).TotalSeconds;
            return intResult;
        }
    }
}
