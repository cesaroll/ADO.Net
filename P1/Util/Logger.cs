using System;
using P1.Interface.Util;

namespace P1.Util
{
    public class Logger : ILogger
    {
        public void WriteLogMsg(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}