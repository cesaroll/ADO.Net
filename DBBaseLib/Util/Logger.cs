using System;
using Base.Interface.Util;

namespace Base.Util
{
    public class Logger : ILogger
    {
        public void WriteLogMsg(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}