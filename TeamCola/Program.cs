using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Data;

namespace TeamCola
{
   
    class Program
    {


        private static string xml_file = string.Empty;

        const string TEAM = "cdcae5b640764794a939d315a128b775";
        const string LABEL = "567258abf6ab42d5b0d89d8360428337";

        static void Main(string[] args)
        {
            Console.Write("请将工作日志文件拖到本窗口:");
            xml_file = Console.ReadLine();
            Console.WriteLine("正在读取...");
            XMLImport xin = new XMLImport(xml_file);
            List<WorkLogEntity> wlogs = xin.GetWorkLog();
            Console.WriteLine("读取到{0}条记录",wlogs.Count);
            Console.WriteLine("正在使用你的账号登陆");
            string username = Properties.Settings.Default.username;
            string password = Properties.Settings.Default.password;
            Cola cola = new Cola();
            object creadits = cola.Login(username, password);
            if (creadits == null)
            {
                Console.WriteLine("登陆失败");
            }
            else
            {
                Console.WriteLine("登陆成功");
            }
            foreach (WorkLogEntity item in wlogs)
            {
                long st = ColaTimeUtil.ToColaDatetime(item.Start);
                long ed = ColaTimeUtil.ToColaDatetime(item.End);
                string cnt = item.WorkLog;
                string postCnt = ColaContentUtil.GetPostData(cnt, TEAM, LABEL, st, ed);
                string c = cola.Post(postCnt, creadits);
            }
            Console.WriteLine("发布完成");
            Console.ReadKey();
            
        }

       
 

    }
}
