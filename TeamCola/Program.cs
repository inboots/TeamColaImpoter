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

        enum MsgType
        {
            ERROR,
            INFOMATION,
            SUCCESS
        }

        private static string csv_file = string.Empty;

        static void Main(string[] args)
        {
            Console.Write("请将工作日志文件拖到本窗口:");
            csv_file = Console.ReadLine();
            Console.WriteLine("正在读取...");
           
            
        }

       
 

    }
}
