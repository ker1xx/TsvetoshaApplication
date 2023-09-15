using System;
using System.Configuration;
using System.IO;

namespace TsvetoshaApplication.Abstraction
{
    interface ILogger
    {
        void WriteLog(string message);
    }
}
